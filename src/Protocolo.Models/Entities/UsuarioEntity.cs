using System.ComponentModel.DataAnnotations;

namespace Protocolo.Models.Entities
{
    public class UsuarioEntity
    {
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
