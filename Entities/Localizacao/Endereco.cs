namespace Entities.Localizacao
{
    public class Endereco : BaseEntity
    {
        /// <summary>
        /// Logradouro do endereço
        /// </summary>
        public string Logradouro { get; set; }

        /// <summary>
        /// Número do endereço
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Complemento do endereço. Ex.: Apto 703
        /// </summary>
        public string Complemento { get; set; }

        /// <summary>
        /// Bairro do endereço
        /// </summary>
        public string Bairro { get; set; }

        /// <summary>
        /// Id da cidade do endereço
        /// </summary>
        public int IdCidade { get; set; }

        /// <summary>
        /// Id do estado do endereço
        /// </summary>
        public int IdEstado { get; set; }
    }
}
