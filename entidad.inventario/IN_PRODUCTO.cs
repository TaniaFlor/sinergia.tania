namespace entidad.inventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class IN_PRODUCTO
    {
        [Key]
        public int IN_PRODUCTO_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string IN_PRODUCTO_CODIGO { get; set; }

        public int IN_CATEGORIA_ID { get; set; }

        public int IN_PROVEEDOR_ID { get; set; }

        public int IN_MARCA_ID { get; set; }

        public int IN_MEDIDA_ID { get; set; }

        [Required]
        public string IN_DESCRIPCION { get; set; }

        public int IN_CANTIDAD { get; set; }

        public decimal IN_PRECIO_UNITARIO { get; set; }

        public virtual IN_CATEGORIA IN_CATEGORIA { get; set; }

        public virtual IN_CATEGORIA IN_CATEGORIA1 { get; set; }

        public virtual IN_MARCA IN_MARCA { get; set; }

        public virtual IN_MEDIDA IN_MEDIDA { get; set; }

        public virtual IN_PROVEEDOR IN_PROVEEDOR { get; set; }
    }
}
