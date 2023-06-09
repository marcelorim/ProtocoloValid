﻿using Bogus;
using Microsoft.Extensions.Logging;
using Protocolo.Models.Entities;
using Protocolo.Models.Extensions;
using Protocolo.Models.Utils;
using Protocolo.Publisher.Business.Interfaces;
using Protocolo.Publisher.Repository.Interfaces;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using static Bogus.DataSets.Name;

namespace Protocolo.Publisher.Business.Services
{
    public class ProtocoloServices : IProtocoloServices
    {
        private readonly ILogger<ProtocoloServices> _logger;
        private readonly IProtocoloRepository _protocoloRepository;


        public ProtocoloServices(ILogger<ProtocoloServices> logger, IProtocoloRepository protocoloRepository)
        {
            _logger = logger;
            _protocoloRepository = protocoloRepository;
        }
        public async Task MontaDadosEnviaFila()
        {
            try
            {
                for (int i = 0; i < 20; i++)
                {
                    ProtocoloEntity entity = ObterDadosProtocoloFake();
                    await EnviarDadosFila(entity);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public ProtocoloEntity ObterDadosProtocoloFake()
        {
            var faker = new Faker("pt_BR");
            var entity = new ProtocoloEntity()
            {
                Id = Guid.NewGuid(),
                NumProtocolo = new Random().Next(999999999),
                NumViaDoc = faker.Random.Number(1, 50),
                NumCpf = Convert.ToInt64(Regex.Replace(Utils.Extensions.GerarCpf(), "[^0-9]", "")),
                NumRg = Convert.ToInt64(Regex.Replace(Utils.Extensions.GerarRG(), "[^0-9]", "")),
                Nome = faker.Name.FullName(),
                NomeMae = faker.Name.FullName(Gender.Female),
                NomePai = faker.Name.FullName(Gender.Male),
                Foto = faker.Internet.Avatar()
            };

            return entity;
        }

        public Task<bool> EnviarDadosFila(ProtocoloEntity entity)
        {
            bool retorno = true;

            try
            {
                var factory = new ConnectionFactory { HostName = "localhost" };
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                channel.QueueDeclare(queue: "protocoloQueue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = JsonSerializer.Serialize(entity);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: string.Empty,
                                     routingKey: "protocoloQueue",
                                     basicProperties: null,
                                     body: body);
            }
            catch (Exception ex)
            {
                _logger.AddLogError(ex.Message);
                throw new Exception(ex.Message);
            }

            return Task.FromResult(retorno);
        }

        public async Task<ProtocoloEntity> ObterPorParametro(long? numProtocolo, long? numCpf, long? numRg)
        {
            try
            {
                var entity = await _protocoloRepository.GetByParametro(numProtocolo, numCpf, numRg);
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError("ERRO: " + ex);
                throw new Exception(Mensagem.Erro);
            }
        }

    }
}
