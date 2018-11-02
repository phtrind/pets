namespace PetSaver.Entity.Anuncios
{
    public class AnuncioEntity : BaseEntity
    {
        /// <summary>
        /// Id do status em que o anúncio se encontra. Ex.: Em análise, Pendente, Ativo, Finalizado.
        /// </summary>
        public int IdStatus { get; set; }

        /// <summary>
        /// Id do tipo do anúncio. Ex.: Doação, Pet perdido, Pet encontrado.
        /// </summary>
        public int IdTipo { get; set; }

        /// <summary>
        /// Id do pet referente ao anúncio
        /// </summary>
        public int IdPet { get; set; }

        /// <summary>
        /// Id da localização do anúncio
        /// </summary>
        public int? IdLocalizacao { get; set; }

        /// <summary>
        /// Id do estado do anúncio
        /// </summary>
        public int IdEstado { get; set; }

        /// <summary>
        /// Id da cidade do anúncio
        /// </summary>
        public int IdCidade { get; set; }

        /// <summary>
        /// Id do usuário que é dono do anúncio
        /// </summary>
        public int IdUsuario { get; set; }
    }
}
