namespace entidad.inventario
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelSinInventario : DbContext
    {
        public ModelSinInventario()
            : base("name=ModelSinInventario")
        {
        }

        public virtual DbSet<IN_CATEGORIA> IN_CATEGORIA { get; set; }
        public virtual DbSet<IN_MARCA> IN_MARCA { get; set; }
        public virtual DbSet<IN_MEDIDA> IN_MEDIDA { get; set; }
        public virtual DbSet<IN_PRODUCTO> IN_PRODUCTO { get; set; }
        public virtual DbSet<IN_PROVEEDOR> IN_PROVEEDOR { get; set; }
        public virtual DbSet<IN_PRODUCTO_HIST> IN_PRODUCTO_HIST { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IN_CATEGORIA>()
                .Property(e => e.IN_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<IN_CATEGORIA>()
                .HasMany(e => e.IN_PRODUCTO)
                .WithRequired(e => e.IN_CATEGORIA)
                .HasForeignKey(e => e.IN_CATEGORIA_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IN_CATEGORIA>()
                .HasMany(e => e.IN_PRODUCTO1)
                .WithRequired(e => e.IN_CATEGORIA1)
                .HasForeignKey(e => e.IN_CATEGORIA_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IN_MARCA>()
                .Property(e => e.IN_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<IN_MARCA>()
                .HasMany(e => e.IN_PRODUCTO)
                .WithRequired(e => e.IN_MARCA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IN_MEDIDA>()
                .Property(e => e.IN_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<IN_MEDIDA>()
                .HasMany(e => e.IN_PRODUCTO)
                .WithRequired(e => e.IN_MEDIDA)
                .HasForeignKey(e => e.IN_MEDIDA_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IN_PRODUCTO>()
                .Property(e => e.IN_PRODUCTO_CODIGO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<IN_PROVEEDOR>()
                .Property(e => e.IN_RUC)
                .IsFixedLength();

            modelBuilder.Entity<IN_PROVEEDOR>()
                .Property(e => e.IN_ESTADO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<IN_PROVEEDOR>()
                .HasMany(e => e.IN_PRODUCTO)
                .WithRequired(e => e.IN_PROVEEDOR)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<IN_PRODUCTO_HIST>()
                .Property(e => e.IN_PRODUCTO_CODIGO)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
