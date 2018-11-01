namespace Entities.Pets
{
    public class Pet : BaseEntity
    {
        public string Nome { get; set; }
        public decimal Peso { get; set; }
        public bool? Vacinado { get; set; }
        public bool? Vermifugado { get; set; }
        public bool? Castrado { get; set; }
        public string Descricao { get; set; }

        public int IdAnimal { get; set; }
        public int IdSexo { get; set; }
        public int IdRaca { get; set; }
        public int? IdIdade { get; set; }
        public int IdPorte { get; set; }
        public int? IdPelo { get; set; }
        public int IdCorPrimaria { get; set; }
        public int? IdCorSecundaria { get; set; }
    }
}
