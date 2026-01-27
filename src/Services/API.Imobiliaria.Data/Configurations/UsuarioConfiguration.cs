using API.Imobiliaria.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace API.Imobiliaria.Data.Configurations
{
    internal class UsuarioConfiguration : BaseEntityConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            base.Configure(builder);

            builder.ToTable("usuarios");

            // ===== Propriedades =====
            builder.Property(i => i.Nome)
                   .HasColumnName("nome")
                   .HasMaxLength(500);

            builder.Property(i => i.Email)
                   .HasColumnName("email")
                   .HasMaxLength(500);

            builder.Property(i => i.Email)
                   .HasColumnName("senha_hash")
                   .HasMaxLength(50);

            builder.Property(i => i.Email)
                   .HasColumnName("senha_salt")
                   .HasMaxLength(50);

            // ===== Relacionamentos =====
            builder.Property(u => u.RoleId)
                .HasColumnName("role_id")
                .HasColumnType("uuid");

            builder.HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
