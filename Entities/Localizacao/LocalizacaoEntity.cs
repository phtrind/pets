namespace PetSaver.Entity.Localizacao
{
    public class LocalizacaoEntity : BaseEntity
    {
        /// <summary>
        /// Latitude da localização
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude da localização
        /// </summary>
        public double Longitude { get; set; }
    }
}
