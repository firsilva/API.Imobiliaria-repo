using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using API.Imobiliaria.Dominio.Entidades;

namespace API.Imobiliaria.Data.Configurations
{
    public class ClienteConfiguration : BaseEntityConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            base.Configure(builder);

            builder.ToTable("clientes");

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

            // ===== Cliente =====
            builder.Property(c => c.UsuarioId)
                   .HasColumnName("usuario_id")
                   .HasColumnType("uuid");

            builder.HasOne(c => c.Usuario)
                   .WithMany()
                   .HasForeignKey(c => c.UsuarioId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Endereco)
                   .WithOne()
                   .HasForeignKey<Cliente>("endereco_id")
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Propostas)
                   .WithOne(p => p.Cliente)
                   .HasForeignKey(p => p.ClienteId);
        }
    }
}
