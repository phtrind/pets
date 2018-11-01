namespace Entities
{
    public class Animal : BaseEntity
    {
        public string Nome { get; set; }
        public bool Destaque { get; set; }

        public int IdTipo { get; set; }
    }
}
