namespace PetSaver.Entity.Usuarios
{
    public class UsuarioEntity : PessoaEntity
    {
        /// <summary>
        /// Pessoa jurídida ou Pessoa Física
        /// </summary>
        public int IdTipo { get; set; }
    }
}
