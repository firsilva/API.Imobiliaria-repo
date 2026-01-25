using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using API.Imobiliaria.Dominio.Entidades;

namespace API.Imobiliaria.Data.Configurations
{
    public class ImagemImovelConfiguration : BaseEntityConfiguration<Imagem>
    {
        public void Configure(EntityTypeBuilder<Imagem> builder)
        {
            builder.ToTable("imagem");
            builder.HasKey(x => x.Id);

            //EntidadeImagem
            builder.Property(x => x.ImagemBase64).HasColumnType("TEXT").IsRequired();
            builder.Property(x => x.Capa).HasColumnType("BOOL").IsRequired();
            builder.Property(x => x.ImovelId).HasColumnType("uuid").IsRequired();

            //EntidadeBase
            builder.Property(x => x.DataRegistro).HasColumnType("TIMESTAMP").IsRequired();
            builder.Property(x => x.DataAtualizacaoRegistro).HasColumnType("TIMESTAMP");
            builder.Property(x => x.DataExclusao).HasColumnType("TIMESTAMP");
            builder.Property(x => x.Excluido).HasColumnType("BOOL");

            builder.HasOne(a => a.Imovel)
                .WithMany(a => a.Imagem)
                .HasForeignKey(a => a.ImovelId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
