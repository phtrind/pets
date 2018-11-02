namespace PetSaver.Entity.Pets
{
    public class PetEntity : BaseEntity
    {
        /// <summary>
        /// Nome do Pet
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Peso do Pet
        /// </summary>
        public decimal Peso { get; set; }

        /// <summary>
        /// Se o Pet é vacinado ou não
        /// </summary>
        public bool? Vacinado { get; set; }

        /// <summary>
        /// Se o Pet é vermifugado ou não
        /// </summary>
        public bool? Vermifugado { get; set; }

        /// <summary>
        /// Se o pet é castrado ou não
        /// </summary>
        public bool? Castrado { get; set; }

        /// <summary>
        /// Descrição do Pet
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Id do tipo de animal. Ex.: Cachorro, Gato, etc
        /// </summary>
        public int IdAnimal { get; set; }

        /// <summary>
        /// Id da raça do pet
        /// </summary>
        public int? IdRaca { get; set; }

        /// <summary>
        /// Id do sexo do Pet. Ex.: Macho, Fêmea
        /// </summary>
        public int? IdSexo { get; set; }

        /// <summary>
        /// Id da idade do Pet. Ex.: Senior, Adulto, etc
        /// </summary>
        public int? IdIdade { get; set; }

        /// <summary>
        /// Id do porte do Pet. Ex.: Pequeno, Médio, Grande
        /// </summary>
        public int IdPorte { get; set; }

        /// <summary>
        /// Id do tamanho do pelo do Pet. Ex.: Curto, Médio, Longo
        /// </summary>
        public int? IdPelo { get; set; }

        /// <summary>
        /// Id da cor principal do Pet. Ex.: Amarelo, Branco, Preto
        /// </summary>
        public int IdCorPrimaria { get; set; }

        /// <summary>
        /// Id da cor secundária do Pet. Ex.: Amarelo, Branco, Preto
        /// </summary>
        public int? IdCorSecundaria { get; set; }
    }
}
