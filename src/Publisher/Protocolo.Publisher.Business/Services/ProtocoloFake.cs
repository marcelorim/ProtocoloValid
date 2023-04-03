using Bogus;
using Protocolo.Models.Entities;
using System.Text.RegularExpressions;
using static Bogus.DataSets.Name;

namespace Protocolo.Publisher.Business.Services
{
    public class ProtocoloFake : Faker<ProtocoloEntity>
    {
        public void ObterProtocoloFake()
        {
            RuleFor(o => o.Id, f => Guid.NewGuid());
            RuleFor(o => o.NumProtocolo, f => f.Random.Number(0001, 1000));
            RuleFor(o => o.Cpf, f =>  Convert.ToInt64(Regex.Replace(Utils.Extensions.GerarCpf(), "[^0-9]", "")));
            RuleFor(o => o.Rg, f => Convert.ToInt64(Regex.Replace(Utils.Extensions.GerarRG(), "[^0-9]", "")));
            RuleFor(o => o.Nome, f => f.Name.FullName());
            RuleFor(o => o.NomeMae, f => f.Name.FullName(Gender.Female));
            RuleFor(o => o.NomePai, f => f.Name.FullName(Gender.Male));
            //RuleFor(o => o.Foto, f => f.PickRandom());
        }
    }
}
