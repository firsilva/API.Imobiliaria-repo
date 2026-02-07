using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using API.Imobiliaria.Dominio.Entidades;

namespace API.Imobiliaria.Data.Configurations
{
    public class ClienteConfiguration : PessoaConfiguration<Cliente>
    {
        public override void Configure(EntityTypeBuilder<Cliente> builder)
        {
            base.Configure(builder);

            // ===== Cliente =====
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
                   .WithOne()
                   .HasForeignKey<Cliente>(c => c.EnderecoId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Propostas)
                   .WithOne(p => p.Cliente)
                   .HasForeignKey(p => p.ClienteId);

            // ===== Index =====
            builder.HasIndex(c => c.Email)
                   .IsUnique()
                   .HasFilter("\"excluido\" = false");

            builder.HasIndex(c => c.Documento)
                   .IsUnique()
                   .HasFilter("\"excluido\" = false");
        }
    }
}
