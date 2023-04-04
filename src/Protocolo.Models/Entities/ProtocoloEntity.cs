namespace Protocolo.Models.Entities
{
    public class ProtocoloEntity : BaseEntity
    {
        public long NumProtocolo { get; set; }
        public long NumViaDoc { get; set; }
        public long NumCpf { get; set; }
        public long NumRg { get; set; }
        public string? Nome { get; set; }
        public string? NomeMae { get; set; }
        public string? NomePai { get; set; }
        public string? Foto { get; set; }
    }
}
