using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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

        public InfoWorker(ILogger<InfoWorker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation($"{DateTime.Now:G} : Procurando ítem na fila....");

                    var factory = new ConnectionFactory { HostName = "localhost" };
                    using var connection = factory.CreateConnection();
                    using var channel = connection.CreateModel();

                    channel.QueueDeclare(queue: "protocoloQueue",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        var protocolo = JsonSerializer.Deserialize<ProtocoloEntity>(message);

                        _logger.LogInformation($"[*] DADOS PROTOCOLO [*] \n " +
                            $"Nº Protocolo: {protocolo.NumProtocolo} | Via: {protocolo.NumViaDocumento} \n " +
                            $"Nome: {protocolo.Nome} | CPF: {protocolo.Cpf} | RG: {protocolo.Rg} \n" +
                            $"-----------------");
                    };
                    channel.BasicConsume(queue: "protocoloQueue",
                                         autoAck: true,
                                         consumer: consumer);
                }
                catch (Exception ex)
                {
                    _logger.LogError("Erro ao consumir a fila.", ex);
                    throw new Exception(ex.Message);
                }

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
