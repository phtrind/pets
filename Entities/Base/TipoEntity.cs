namespace PetSaver.Entity
{
    public class TipoEntity : BaseEntity
    {
        /// <summary>
        /// Descrição do tipo. Ex.: Pet perdido, Doação, Funcionário, etc
        /// </summary>
        public virtual string Descricao { get; set; }
    }
}
