namespace Entities.Usuarios
{
    public class Usuario : Pessoa
    {
        /// <summary>
        /// Pessoa jurídida ou Pessoa Física
        /// </summary>
        public int IdTipo { get; set; }
    }
}
