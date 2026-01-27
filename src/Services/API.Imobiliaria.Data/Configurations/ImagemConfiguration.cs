using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using API.Imobiliaria.Dominio.Entidades;

namespace API.Imobiliaria.Data.Configurations
{
    public class ImagemImovelConfiguration : BaseEntityConfiguration<Imagem>
    {
        public void Configure(EntityTypeBuilder<Imagem> builder)
        {
            base.Configure(builder);

            builder.ToTable("imagens");

            builder.Property(x => x.Url).HasColumnName("url");
            builder.Property(x => x.ImagemBase64).HasColumnName("imagem_base");
            builder.Property(x => x.Capa).HasColumnName("capa").HasDefaultValue(false);

            builder.Property(i => i.ImovelId)
                   .HasColumnName("imovel_id")
                   .HasColumnType("uuid");

            builder.HasOne(a => a.Imovel)
                .WithMany()
                .HasForeignKey(a => a.ImovelId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
