using System;

namespace PetSaver.Contracts.Usuario
{
    public class UsuarioSessionContract
    {
        public int IdLogin { get; set; }
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public DateTime DthValidadeToken { get; set; }
    }
}
