using API.Imobiliaria.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Imobiliaria.Data.Configurations
{
    public class PessoaConfiguration<TPessoa> : BaseEntityConfiguration<TPessoa> where TPessoa : Pessoa
    {
        public override void Configure(EntityTypeBuilder<TPessoa> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Nome)
                   .HasColumnName("nome")
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(p => p.Email)
                   .HasColumnName("email")
                   .HasMaxLength(150);

            builder.Property(p => p.Telefone)
                   .HasColumnName("telefone")
                   .HasMaxLength(20);

            builder.Property(p => p.Documento)
                   .HasColumnName("documento")
                   .HasMaxLength(20);
        }
    }
}
