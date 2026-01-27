using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using API.Imobiliaria.Dominio.Entidades;

namespace API.Imobiliaria.Data.Configurations
{
    public class ProprietarioConfiguration : BaseEntityConfiguration<Proprietario>
    {
        public void Configure(EntityTypeBuilder<Proprietario> builder)
        {
            base.Configure(builder);

            builder.ToTable("proprietarios");

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

            // ===== FKs =====
            builder.Property(i => i.EnderecoId)
                   .HasColumnName("endereco_id")
                   .HasColumnType("uuid");

            // ===== Relacionamentos =====
            builder.HasOne(i => i.Endereco)
                   .WithMany()
                   .HasForeignKey(i => i.EnderecoId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Imoveis)
                   .WithOne(c => c.Proprietario)
                   .HasForeignKey(c => c.ProprietarioId);
        }
    }
}
