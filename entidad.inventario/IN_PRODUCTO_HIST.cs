namespace entidad.inventario
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class IN_PRODUCTO_HIST
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IN_PRODUCTO_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string IN_PRODUCTO_CODIGO { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IN_CATEGORIA_ID { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IN_PROVEEDOR_ID { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IN_MARCA_ID { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IN_MEDIDA_ID { get; set; }

        [Key]
        [Column(Order = 6)]
        public string IN_DESCRIPCION { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IN_CANTIDAD { get; set; }

        [Key]
        [Column(Order = 8)]
        public float IN_PRECIO_UNITARIO { get; set; }

        [Key]
        [Column(Order = 9)]
        public string IN_USUARIO_INGRESO { get; set; }

        [Key]
        [Column(Order = 10)]
        public DateTime IN_FECHA_INGRESO { get; set; }

        [Key]
        [Column(Order = 11)]
        public string IN_USUARIO_MODIFICA { get; set; }

        [Key]
        [Column(Order = 12)]
        public DateTime IN_FECHA_ACTUALIZA { get; set; }
    }
}
