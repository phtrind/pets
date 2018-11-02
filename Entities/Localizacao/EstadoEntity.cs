namespace PetSaver.Entity.Localizacao
{
    public class EstadoEntity : BaseEntity
    {
        /// <summary>
        /// Sigla do estado. Ex.: MG, SP, etc
        /// </summary>
        public string Sigla { get; set; }

        /// <summary>
        /// Nome do estado
        /// </summary>
        public string Nome { get; set; }
    }
}
