namespace Entities.Usuarios
{
    public class Contribuicoes : BaseEntity
    {
        public decimal Valor { get; set; }

        public int IdUsuario { get; set; }
        public int IdStatus { get; set; }
    }
}
