using API.Imobiliaria.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace API.Imobiliaria.Data.Configurations
{
    public class TipoImovelConfiguration : BaseEntityConfiguration<TipoImovel>
    {
        public void Configure(EntityTypeBuilder<TipoImovel> builder)
        {
            base.Configure(builder);

            builder.ToTable("tipoimoveis");

            // ===== Propriedades =====
            builder.Property(i => i.Nome)
                   .HasColumnName("nome")
                   .HasMaxLength(1000);
        }
    }
}
