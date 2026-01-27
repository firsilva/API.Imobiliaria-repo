using API.Imobiliaria.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace API.Imobiliaria.Data.Configurations
{
    public class RoleConfiguration : BaseEntityConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);

            builder.ToTable("roles");

            // ===== Propriedades =====
            builder.Property(i => i.Nome)
                   .HasColumnName("nome")
                   .HasMaxLength(1000);
        }
    }
}
