using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WSVentas.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Concepto> Conceptos { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("User Id=userventas;Password=userventas;Data Source=localhost:51521/ventareal");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("USERVENTAS")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("CLIENTE");

                entity.Property(e => e.Id)
                    .HasColumnType("INT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.Entity<Concepto>(entity =>
            {
                entity.ToTable("CONCEPTO");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Cantidad)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CANTIDAD")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.IdProducto)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID_PRODUCTO");

                entity.Property(e => e.IdVenta)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID_VENTA");

                entity.Property(e => e.Importe)
                    .HasColumnType("NUMBER(16,2)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IMPORTE")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Preciounitario)
                    .HasColumnType("NUMBER(16,2)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRECIOUNITARIO")
                    .HasDefaultValueSql("0 ");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Conceptos)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONCEPTO_PRODUCTO_FK");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.Conceptos)
                    .HasForeignKey(d => d.IdVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONCEPTO_VENTA_FK");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("PRODUCTO");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Costo)
                    .HasColumnType("NUMBER(16,2)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COSTO")
                    .HasDefaultValueSql("NULL ");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Preciounitario)
                    .HasColumnType("NUMBER(16,2)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRECIOUNITARIO")
                    .HasDefaultValueSql("NULL ");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.ToTable("VENTA");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Fecha)
                    .HasColumnType("DATE")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("FECHA");

                entity.Property(e => e.IdCliente)
                    .HasColumnType("INT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID_CLIENTE");

                entity.Property(e => e.Total)
                    .HasColumnType("NUMBER(16,2)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TOTAL")
                    .HasDefaultValueSql("NULL ");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("VENTA_CLIENTE_FK");
            });

            modelBuilder.HasSequence("CLIENTE_SEQ");

            modelBuilder.HasSequence("CONCEPTO_ID_SEQ");

            modelBuilder.HasSequence("CONCEPTO_SEQ");

            modelBuilder.HasSequence("PRODUCTO_ID_SEQ");

            modelBuilder.HasSequence("PRODUCTO_SEQ");

            modelBuilder.HasSequence("VENTA_ID_SEQ");

            modelBuilder.HasSequence("VENTA_SEQ");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
