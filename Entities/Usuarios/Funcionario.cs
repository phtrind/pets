using System;

namespace Entities.Usuarios
{
    public class Funcionario : Pessoa
    {
        public DateTime DataAdmissao { get; set; }

        /// <summary>
        /// Nível de acesso do funcionário no sistema
        /// </summary>
        public int IdTipo { get; set; }
    }
}
