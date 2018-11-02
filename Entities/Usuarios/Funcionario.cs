using System;

namespace Entities.Usuarios
{
    public class Funcionario : Pessoa
    {
        /// <summary>
        /// Data em que o funcionário foi admitido
        /// </summary>
        public DateTime DataAdmissao { get; set; }

        /// <summary>
        /// Nível de acesso do funcionário no sistema
        /// </summary>
        public int IdTipo { get; set; }
    }
}
