namespace Protocolo.Models.Utils
{
    public class Mensagem
    {
        /// <summary>
        /// Mensagem padrão de sucesso da api
        /// </summary>
        public static string Sucesso
        {
            get { return "Operação realizada com sucesso."; }
        }

        /// <summary>
        /// Mensagem padrão de falha da api
        /// </summary>
        public static string Falha
        {
            get { return "Operação não realizada."; }
        }

        /// <summary>
        /// Mensagem padrão de erro da api
        /// </summary>
        public static string Erro
        {
            get { return "Erro na execução da operação."; }
        }

        /// <summary>
        /// Mensagem para erro de inclusão na fila da api
        /// </summary>
        public static string ErroInclusaoFila
        {
            get { return "Erro ao criar a fila."; }
        }

        //

        /// <summary>
        /// Mensagem para validar duplicidade de registro da api
        /// </summary>
        public static string Duplicidade
        {
            get { return "Não é possivel incluir registro, pois o mesmo já encontra-se cadastrado"; }
        }
    }
}
