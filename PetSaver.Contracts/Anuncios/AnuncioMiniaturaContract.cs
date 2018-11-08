namespace PetSaver.Contracts.Anuncios
{
    public class AnuncioMiniaturaContract
    {
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string Idade { get; set; }
        public string Localizacao { get; set; }
        public byte[] Foto { get; set; }
    }
}
