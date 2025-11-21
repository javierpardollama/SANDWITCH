namespace Sandwitch.Domain.Dtos
{
    /// <summary>
    /// Represents a <see cref="HistoricoDto"/> class.
    /// </summary>
    public class HistoricoDto
    {
        /// <summary>
        ///     Gets or Sets <see cref="Id" />
        /// </summary>      
        public int Id { get; set; }

        /// <summary>
        ///     Gets or Sets <see cref="LastModified" />
        /// </summary>    
        public DateTime? LastModified { get; set; }

        /// <summary>
        ///     Gets or Sets <see cref="Viento" />
        /// </summary>      
        public virtual CatalogDto Viento { get; set; }

        /// <summary>
        ///     Gets or Sets <see cref="Bandera" />
        /// </summary>       
        public virtual CatalogDto Bandera { get; set; }

        /// <summary>
        ///     Gets or Sets <see cref="Arenal" />
        /// </summary>       
        public virtual CatalogDto Arenal { get; set; }

        /// <summary>
        ///     Gets or Sets <see cref="Velocidad" />
        /// </summary>       
        public double Velocidad { get; set; }

        /// <summary>
        ///     Gets or Sets <see cref="Temperatura" />
        /// </summary>       
        public double Temperatura { get; set; }

        /// <summary>
        ///     Gets or Sets <see cref="BajaMarAlba" />
        /// </summary>       
        public TimeSpan BajaMarAlba { get; set; }

        /// <summary>
        ///     Gets or Sets <see cref="BajaMarOcaso" />
        /// </summary>       
        public TimeSpan BajaMarOcaso { get; set; }

        /// <summary>
        ///     Gets or Sets <see cref="AltaMarAlba" />
        /// </summary>      
        public TimeSpan AltaMarAlba { get; set; }

        /// <summary>
        ///     Gets or Sets <see cref="AltaMarOcaso" />
        /// </summary>      
        public TimeSpan AltaMarOcaso { get; set; }
    }
}
