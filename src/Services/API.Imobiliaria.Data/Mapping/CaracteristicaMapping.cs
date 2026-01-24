using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using API.Imobiliaria.Dominio.Entidades;

namespace API.Imobiliaria.Data.Mapping
{
    public class CaracteristicaMapping : BaseMapping<Caracteristica>
    {
        public void Configure(EntityTypeBuilder<Caracteristica> builder)
        {
            builder.ToTable("caracteristica");

            builder.HasKey(c => c.Id);

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
