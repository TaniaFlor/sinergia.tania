namespace entidad.inventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class IN_CATEGORIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IN_CATEGORIA()
        {
            IN_PRODUCTO = new HashSet<IN_PRODUCTO>();
            IN_PRODUCTO1 = new HashSet<IN_PRODUCTO>();
        }

        [Key]
        public int IN_CATEGORIA_ID { get; set; }

        public string IN_DESCRIPCION_CATEGORIA { get; set; }

        [StringLength(1)]
        public string IN_ESTADO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IN_PRODUCTO> IN_PRODUCTO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IN_PRODUCTO> IN_PRODUCTO1 { get; set; }
    }
}
