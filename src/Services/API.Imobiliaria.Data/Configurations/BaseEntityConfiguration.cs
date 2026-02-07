using API.Imobiliaria.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Imobiliaria.Data.Configurations
{
    public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntidadeBase
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("id")
                   .HasColumnType("uuid")
                   .ValueGeneratedNever();

            builder.Property(e => e.Excluido)
                   .HasColumnName("excluido")
                   .HasDefaultValue(false);

            builder.Property(e => e.DataRegistro)
                   .HasColumnName("data_registro")
                   .HasColumnType("timestamptz")
                   .IsRequired();

            builder.Property(e => e.DataAtualizacaoRegistro)
                   .HasColumnName("data_atualizacao_registro")
                   .HasColumnType("timestamptz");

            builder.Property(e => e.DataExclusao)
                   .HasColumnName("data_exclusao")
                   .HasColumnType("timestamptz");
        }
    }
}
