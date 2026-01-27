using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using API.Imobiliaria.Dominio.Entidades;

namespace API.Imobiliaria.Data.Configurations
{
    public class CaracteristicaConfiguration : BaseEntityConfiguration<Caracteristica>
    {
        public void Configure(EntityTypeBuilder<Caracteristica> builder)
        {
            base.Configure(builder);

            builder.ToTable("caracteristicas");

            // ===== Propriedades =====
            builder.Property(c => c.Nome)
                   .HasColumnName("nome")
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasIndex(c => c.Nome)
                .IsUnique();
        }
    }
}
