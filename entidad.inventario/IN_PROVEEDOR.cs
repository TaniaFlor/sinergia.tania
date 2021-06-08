namespace entidad.inventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class IN_PROVEEDOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IN_PROVEEDOR()
        {
            IN_PRODUCTO = new HashSet<IN_PRODUCTO>();
        }

        [Key]
        public int IN_PROVEEDOR_ID { get; set; }

        [Required]
        [StringLength(13)]
        public string IN_RUC { get; set; }

        public string IN_DETALLE_PROVEEDOR { get; set; }

        [Required]
        [StringLength(1)]
        public string IN_ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IN_PRODUCTO> IN_PRODUCTO { get; set; }
    }
}
