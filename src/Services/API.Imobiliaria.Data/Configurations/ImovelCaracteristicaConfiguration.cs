using API.Imobiliaria.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace API.Imobiliaria.Data.Configurations
{
    public class ImovelCaracteristicaConfiguration: BaseEntityConfiguration<ImovelCaracteristica>
    {
        public void Configure(EntityTypeBuilder<ImovelCaracteristica> builder)
        {
            base.Configure(builder);

            builder.ToTable("Imovelcaracteristicas");

            // ===== FKs =====
            builder.Property(i => i.ImovelId)
                   .HasColumnName("imovel_id")
                   .HasColumnType("uuid");

            builder.Property(i => i.CaracteristicaId)
                   .HasColumnName("caracteristica_id")
                   .HasColumnType("uuid");

            // ===== Relacionamentos =====
            builder.HasOne(i => i.Imovel)
                   .WithMany()
                   .HasForeignKey(i => i.ImovelId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.Caracteristica)
                   .WithMany()
                   .HasForeignKey(i => i.CaracteristicaId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
    