using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using API.Imobiliaria.Dominio.Entidades;

namespace API.Imobiliaria.Data.Configurations
{
    public class ImovelConfiguration : BaseEntityConfiguration<Imovel>
    {
        public void Configure(EntityTypeBuilder<Imovel> builder)
        {
            base.Configure(builder);

            builder.ToTable("imoveis");

            // ===== Propriedades =====
            builder.Property(i => i.Titulo)
                   .HasColumnName("titulo")
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(i => i.Descricao)
                   .HasColumnName("descricao")
                   .HasMaxLength(1000);

            builder.Property(i => i.Preco)
                   .HasColumnName("preco")
                   .HasColumnType("numeric(18,2)")
                   .IsRequired();

            builder.Property(i => i.ValorCondominio)
                   .HasColumnName("valor_condominio")
                   .HasColumnType("numeric(18,2)");

            builder.Property(i => i.ValorIPTU)
                   .HasColumnName("valor_iptu")
                   .HasColumnType("numeric(18,2)");

            builder.Property(i => i.AreaTotal)
                   .HasColumnName("area_total");

            builder.Property(i => i.AreaConstruida)
                   .HasColumnName("area_construida");

            builder.Property(i => i.QtdQuartos)
                   .HasColumnName("qtd_quartos");

            builder.Property(i => i.QtdBanheiros)
                   .HasColumnName("qtd_banheiros");

            builder.Property(i => i.VagasGaragem)
                   .HasColumnName("vagas_garagem");

            builder.Property(i => i.Status)
                   .HasColumnName("status")
                   .HasConversion<int>()
                   .IsRequired();

            builder.Property(i => i.Finalidade)
                   .HasColumnName("finalidade")
                   .HasConversion<int>()
                   .IsRequired();

            // ===== FKs =====
            builder.Property(i => i.TipoImovelId)
                   .HasColumnName("tipo_imovel_id")
                   .HasColumnType("uuid");

            builder.Property(i => i.EnderecoId)
                   .HasColumnName("endereco_id")
                   .HasColumnType("uuid");

            builder.Property(i => i.ProprietarioId)
                   .HasColumnName("proprietario_id")
                   .HasColumnType("uuid");

            // ===== Relacionamentos =====
            builder.HasOne(i => i.TipoImovel)
                   .WithMany()
                   .HasForeignKey(i => i.TipoImovelId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.Endereco)
                   .WithMany()
                   .HasForeignKey(i => i.EnderecoId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.Proprietario)
                   .WithMany()
                   .HasForeignKey(i => i.ProprietarioId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(i => i.Imagens)
                   .WithOne(img => img.Imovel)
                   .HasForeignKey(img => img.ImovelId);

            builder.HasMany(i => i.Caracteristicas)
                   .WithOne(c => c.Imovel)
                   .HasForeignKey(c => c.ImovelId);
        }
    }
}
