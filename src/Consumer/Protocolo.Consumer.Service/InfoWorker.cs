﻿using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Protocolo.Consumer.Repository.Interfaces;
using Protocolo.Consumer.Service.Interfaces;
using Protocolo.Models.Entities;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Protocolo.Consumer.Services
{
    public class InfoWorker : BackgroundService
    {
        private readonly ILogger<InfoWorker> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private IConnection _connection;
        private IModel _channel;
        const string quebraLinha = $"\n";

        public InfoWorker(ILogger<InfoWorker> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            var factory = new ConnectionFactory { HostName = "localhost", UserName = "guest", Password = "guest" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "protocoloQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            _logger.LogInformation(quebraLinha + $"### PROCESSAMENTO DE CONSUMO INICIADO EM: {DateTime.Now:G} ###" + quebraLinha);
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (channel, evt) =>
            {
                var message = Encoding.UTF8.GetString(evt.Body.ToArray());
                var protocolo = JsonSerializer.Deserialize<ProtocoloEntity>(message);
                ProcessarEnvio(protocolo).GetAwaiter().GetResult();

                _logger.LogInformation(quebraLinha +
                    $"--------------------------------------------------------" + quebraLinha +
                    $"### DADOS PROTOCOLO ###" + quebraLinha +
                    $"Nº Protocolo: {protocolo.NumProtocolo} | Via: {protocolo.NumViaDoc}" + quebraLinha +
                    $"Nome: {protocolo.Nome} | CPF: {protocolo.NumCpf} | RG: {protocolo.NumRg}" + quebraLinha +
                    $"--------------------------------------------------------" + quebraLinha
                );
                _channel.BasicAck(evt.DeliveryTag, false);
            };
            _channel.BasicConsume(queue: "protocoloQueue", autoAck: false, consumer: consumer);
            return Task.CompletedTask;
        }

        private async Task ProcessarEnvio(ProtocoloEntity protocolo)
        {
            await _unitOfWork.Protocolo.Insert(protocolo);
        }
    }
}
