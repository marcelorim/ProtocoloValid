namespace Protocolo.Consumer.Models.Entities
{
    public class ProtocoloEntity : BaseEntity
    {
        /*  • Número do Protocolo (obrigatório)
            • Número da Via do documento (obrigatório) - EX: via 1 = Primeira via de um RG, Via 2,3,4... = Segunda via emitida para um cidadão (perda ou roubo)
            • Cpf (obrigatório) Sem formatação
            • RG (obrigatório)
            • Nome (obrigatório)
            • Nome da Mãe
            • Nome do Pai
            • Foto (obrigatório) - Uma imagem no formato jpg ou png*/

        public int NumProtocolo { get; set; }
        public int NumViaDocumento { get; set; }
        public long Cpf { get; set; }
        public long RG { get; set; }
        public string? Nome { get; set; }
        public string? NomeMae { get; set; }
        public string? NomePai { get; set; }
        public string? Foto { get; set; }
    }
}
