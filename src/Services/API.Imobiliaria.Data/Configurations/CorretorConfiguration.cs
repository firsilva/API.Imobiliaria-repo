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

            // ===== Pessoa =====
            builder.Property(c => c.Nome)
                   .HasColumnName("nome")
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(c => c.Email)
                   .HasColumnName("email")
                   .HasMaxLength(150);

            builder.Property(c => c.Telefone)
                   .HasColumnName("telefone")
                   .HasMaxLength(20);

            builder.Property(c => c.Documento)
                   .HasColumnName("documento")
                   .HasMaxLength(20);

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
                   .WithOne(ctt => ctt.Corretor)
                   .HasForeignKey(ctt => ctt.CorretorId);
        }
    }
}
