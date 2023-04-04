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
            RuleFor(o => o.NumProtocolo, f => new Random().Next(999999999));
            RuleFor(o => o.NumViaDoc, f => f.Random.Number(1, 50));
            RuleFor(o => o.NumCpf, f =>  Convert.ToInt64(Regex.Replace(Utils.Extensions.GerarCpf(), "[^0-9]", "")));
            RuleFor(o => o.NumRg, f => Convert.ToInt64(Regex.Replace(Utils.Extensions.GerarRG(), "[^0-9]", "")));
            RuleFor(o => o.Nome, f => f.Name.FullName());
            RuleFor(o => o.NomeMae, f => f.Name.FullName(Gender.Female));
            RuleFor(o => o.NomePai, f => f.Name.FullName(Gender.Male));
            RuleFor(o => o.Foto, f => f.Internet.Avatar());
        }
    }
}
