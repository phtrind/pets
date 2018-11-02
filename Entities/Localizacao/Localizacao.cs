namespace Entities.Localizacao
{
    public class Localizacao : BaseEntity
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
