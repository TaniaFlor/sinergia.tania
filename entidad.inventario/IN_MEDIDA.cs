namespace entidad.inventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class IN_MEDIDA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IN_MEDIDA()
        {
            IN_PRODUCTO = new HashSet<IN_PRODUCTO>();
        }

        [Key]
        public int IN_ID_MEDIDA { get; set; }

        [Required]
        public string IN_DETALLE_MEDIDA { get; set; }

        [Required]
        [StringLength(1)]
        public string IN_ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IN_PRODUCTO> IN_PRODUCTO { get; set; }
    }
}
