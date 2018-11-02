namespace Entities.Usuarios
{
    public class Contribuicoes : BaseEntity
    {
        /// <summary>
        /// Valor da contribuição
        /// </summary>
        public decimal Valor { get; set; }

        /// <summary>
        /// Id do usuário responsável pela contribuição
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Id do status da contribuição
        /// </summary>
        public int IdStatus { get; set; }
    }
}
