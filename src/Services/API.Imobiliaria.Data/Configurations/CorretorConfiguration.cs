using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using API.Imobiliaria.Dominio.Entidades;

namespace API.Imobiliaria.Data.Configurations
{
    public class CorretorConfiguration : BaseEntityConfiguration<Corretor>
    {
        public void Configure(EntityTypeBuilder<Corretor> builder)
        {
            base.Configure(builder);

            builder.ToTable("corretores");

            builder.HasKey(c => c.Id);

            // ===== EntidadeBase =====
            builder.Property(c => c.Id)
                   .HasColumnName("id")
                   .HasColumnType("uuid");

            builder.Property(c => c.Excluido)
                   .HasColumnName("excluido")
                   .HasDefaultValue(false);

            builder.Property(c => c.DataRegistro)
                   .HasColumnName("data_registro")
                   .HasColumnType("timestamptz")
                   .IsRequired();

            builder.Property(c => c.DataAtualizacaoRegistro)
                   .HasColumnName("data_atualizacao_registro")
                   .HasColumnType("timestamptz");

            builder.Property(c => c.DataExclusao)
                   .HasColumnName("data_exclusao")
                   .HasColumnType("timestamptz");

            // ===== Corretor =====
            builder.Property(c => c.Creci)
                    .HasColumnName("creci")
                    .HasMaxLength(150)
                    .IsRequired();

            builder.Property(c => c.UsuarioId)
                   .HasColumnName("usuario_id")
                   .HasColumnType("uuid");

            builder.HasOne(c => c.Usuario)
                   .WithMany()
                   .HasForeignKey(c => c.UsuarioId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.EnderecoId)
                   .HasColumnName("endereco_id")
                   .HasColumnType("uuid");

            builder.HasOne(c => c.Endereco)
                   .WithMany()
                   .HasForeignKey(c => c.EnderecoId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Contratos)
                   .WithOne(ctt => ctt.Contrato)
                   .HasForeignKey(ctt => ctt.ImovelId);
        }
    }
}
