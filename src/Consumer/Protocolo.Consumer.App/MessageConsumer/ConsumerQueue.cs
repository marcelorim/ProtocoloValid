//using Protocolo.Consumer.Business.Interfaces;
//using Protocolo.Consumer.Business.Services;
//using Protocolo.Consumer.Repository.Interfaces;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using Protocolo.Models.Entities;

namespace Protocolo.Consumer.App.MessageConsumer
{
    public class ConsumerQueue : BackgroundService
    {

        //private readonly ILogger<ConsumerServices> _logger;
        //private readonly IConsumerServices _consumerServices;

        //public ConsumerQueue(ILogger<ConsumerServices> logger, IConsumerServices consumerServices)
        //{
        //    _logger = logger;
        //    _consumerServices = consumerServices;
        //}

        private readonly ILogger<ConsumerQueue> _logger;

        public ConsumerQueue(ILogger<ConsumerQueue> logger)
        {
            _logger = logger;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

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

        //protected override Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        //    stoppingToken.ThrowIfCancellationRequested();

        //    try
        //    {
        //        var factory = new ConnectionFactory { HostName = "localhost" };
        //        using var connection = factory.CreateConnection();
        //        using var channel = connection.CreateModel();

        //        channel.QueueDeclare(queue: "protocoloQueue",
        //                             durable: false,
        //                             exclusive: false,
        //                             autoDelete: false,
        //                             arguments: null);

        //        var consumer = new EventingBasicConsumer(channel);
        //        consumer.Received += (model, ea) =>
        //        {
        //            var body = ea.Body.ToArray();
        //            var message = Encoding.UTF8.GetString(body);
        //            var protocolo = JsonSerializer.Deserialize<ProtocoloEntity>(message);

        //            Console.WriteLine($" [*] DADOS PROTOCOLO [*] \n " +
        //                $"Nº Protocolo: {protocolo.NumProtocolo} | Via: {protocolo.NumViaDocumento} \n " +
        //                $"Nome: {protocolo.Nome} | CPF: {protocolo.Cpf} | RG: {protocolo.RG} \n" +
        //                $"-----------------");

        //        };
        //        channel.BasicConsume(queue: "protocoloQueue",
        //                             autoAck: true,
        //                             consumer: consumer);
        //    }
        //    catch (Exception ex)
        //    {
        //        //_logger.LogError("Erro ao consumir a fila.", ex);
        //        throw new Exception(ex.Message);
        //    }

        //    return Task.CompletedTask;
        //}
    }
}
