using System;

namespace PetSaver.Contracts.Usuario
{
    public class VerificarFuncionarioReponse
    {
        public bool IsFuncionario { get; set; }
        public int? IdLogin { get; set; }
        public int? IdFuncionario { get; set; }
        public string Nome { get; set; }
        public DateTime DthValidadeToken { get; set; }
    }
}
