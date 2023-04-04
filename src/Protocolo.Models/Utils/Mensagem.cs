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
        /// Mensagem padrão de FALHA do sistema
        /// </summary>
        public static string Falha
        {
            get { return "Operação não realizada."; }
        }

        /// <summary>
        /// Mensagem padrão de ERRO do sistema
        /// </summary>
        public static string Erro
        {
            get { return "Erro na execução da operação."; }
        }

        /// <summary>
        /// Mensagem padrão de validar DUPLICIDADE do sistema
        /// </summary>
        public static string Duplicidade
        {
            get { return "Não é possivel incluir registro, pois o mesmo já encontra-se cadastrado"; }
        }
    }
}
