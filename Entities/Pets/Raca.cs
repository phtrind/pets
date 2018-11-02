namespace Entities.Pets
{
    public class Raca : BaseEntity
    {
        /// <summary>
        /// Nome da raça. Ex.: Viralata, Pug, etc
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Id do animal. Ex.: Cachorro, Gato, etc
        /// </summary>
        public int IdAnimal { get; set; }
    }
}
