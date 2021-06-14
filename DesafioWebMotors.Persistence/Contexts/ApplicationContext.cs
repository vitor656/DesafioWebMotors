using System;
using DesafioWebMotors.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DesafioWebMotors.Persistence.Contexts
{
    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnuncioWebmotor> AnuncioWebmotors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AnuncioWebmotor>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("tb_AnuncioWebmotors");

                entity.Property(e => e.Ano).HasColumnName("ano");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("marca");

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("modelo");

                entity.Property(e => e.Observacao)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("observacao");

                entity.Property(e => e.Quilometragem).HasColumnName("quilometragem");

                entity.Property(e => e.Versao)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("versao");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
