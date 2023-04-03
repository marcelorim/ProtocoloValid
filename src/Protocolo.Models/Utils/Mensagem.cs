namespace Protocolo.Models.Utils
{
    public class Mensagem
    {
        /// <summary>
        /// Mensagem padrão de SUCESSO do sistema
        /// </summary>
        public static string Sucesso
        {
            get { return "Operação realizada com sucesso."; }
        }

        /// <summary>
        /// Mensagem padrão de ERRO do sistema
        /// </summary>
        public static string Erro
        {
            get { return "Erro na execução da operação."; }
        }
    }
}
