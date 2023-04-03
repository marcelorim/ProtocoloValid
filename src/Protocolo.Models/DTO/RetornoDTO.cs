namespace Protocolo.Models.DTO
{
    public class RetornoDTO
    {
        public RetornoDTO() { }

        public RetornoDTO(bool sucesso, string mensagem)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
        }

        public bool Sucesso { get; set; }
        public string? Mensagem { get; set; }
    }
}
