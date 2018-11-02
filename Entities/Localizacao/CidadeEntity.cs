namespace PetSaver.Entity.Localizacao
{
    public class CidadeEntity : BaseEntity
    {
        /// <summary>
        /// Nome da cidade
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Id do estado referente à cidade
        /// </summary>
        public int IdEstado { get; set; }
    }
}
