namespace Sandwitch.Domain.Dtos
{
    /// <summary>
    /// Represents a <see cref="ArenalDto"/> class.
    /// </summary>
    public class ArenalDto
    {
        /// <summary>
        /// Gets or Sets <see cref="Id"/>
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="LastModified"/>
        /// </summary>
        public DateTime? LastModified { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="Name"/>
        /// </summary>
        public string Name { get; set; }        

        /// <summary>
        /// Gets or Sets <see cref="Poblaciones"/>
        /// </summary>
        public virtual ICollection<CatalogDto> Poblaciones { get; set; } = [];

        /// <summary>
        /// Gets or Sets <see cref="LastHistorico"/>
        /// </summary>
        public virtual HistoricoDto LastHistorico { get; set; }
    }
}
