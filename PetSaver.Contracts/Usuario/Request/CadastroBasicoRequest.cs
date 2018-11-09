using System;

namespace PetSaver.Contracts.Usuario
{
    public class CadastroBasicoRequest
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
