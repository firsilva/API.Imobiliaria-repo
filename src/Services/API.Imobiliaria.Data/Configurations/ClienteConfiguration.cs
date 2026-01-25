using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using API.Imobiliaria.Dominio.Entidades;

namespace API.Imobiliaria.Data.Configurations
{
    public class ClienteConfiguration : BaseEntityConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("cliente");

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
