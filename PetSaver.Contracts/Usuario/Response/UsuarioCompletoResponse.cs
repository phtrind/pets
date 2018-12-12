using System;

namespace PetSaver.Contracts.Usuario
{
    public class UsuarioCompletoResponse
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Nascimento { get; set; }
        public string Sexo { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
