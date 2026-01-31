using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using API.Imobiliaria.Dominio.Entidades;

namespace API.Imobiliaria.Data.Configurations
{
    public class EnderecoMapping : BaseEntityConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("enderecos");

            builder.Property(e => e.Logradouro).HasColumnName("logradouro").HasMaxLength(500).IsRequired();
            builder.Property(e => e.Numero).HasColumnName("numero").HasMaxLength(10).IsRequired();
            builder.Property(e => e.Complemento).HasColumnName("complemento").HasMaxLength(10);

            builder.Property(e => e.Bairro).HasColumnName("bairro").HasMaxLength(500).IsRequired();
            builder.Property(e => e.Cidade).HasColumnName("cidade").HasMaxLength(250).IsRequired();
            builder.Property(e => e.Estado).HasColumnName("estado").HasMaxLength(2).IsRequired();
            builder.Property(e => e.CEP).HasColumnName("cep").HasMaxLength(9).IsRequired();

            builder.Property(e => e.Latitude).HasColumnName("latitude");
            builder.Property(e => e.Longitude).HasColumnName("longitude");

            base.Configure(builder);
        }
    }
}
