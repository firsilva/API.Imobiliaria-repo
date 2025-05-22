using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using API.Imobiliaria.Dominio.Entidades;

namespace API.Imobiliaria.Data.Mapping
{
    public class GalpaoMapping : IEntityTypeConfiguration<Galpao>
    {
        public void Configure(EntityTypeBuilder<Galpao> builder)
        {
            builder.ToTable("galpao");
            builder.HasKey(x => x.Id);

            //Entidade Galpao
            builder.Property(x => x.TemVagaCarga).HasColumnType("BOOL").IsRequired();

            //Entidade Imovel
            builder.Property(x => x.Titulo).HasColumnType("VARCHAR(250)").IsRequired();
            builder.Property(x => x.Descricao).HasColumnType("VARCHAR(500)").IsRequired();
            builder.Property(x => x.Preco).HasColumnType("DECIMAL").IsRequired();
            builder.Property(x => x.Bairro).HasColumnType("VARCHAR(500)").IsRequired();
            builder.Property(x => x.Cidade).HasColumnType("VARCHAR(250)").IsRequired();
            builder.Property(x => x.Estado).HasColumnType("VARCHAR(2)").IsRequired();
            builder.Property(x => x.CEP).HasColumnType("VARCHAR(9)").IsRequired();
            builder.Property(x => x.AreaTotal).HasColumnType("DECIMAL)").IsRequired();
            builder.Property(x => x.AreaConstruida).HasColumnType("DECIMAL").IsRequired();
            builder.Property(x => x.TipoImovel).HasColumnType("SMALLINT").IsRequired();
            builder.Property(x => x.Status).HasColumnType("VARCHAR(100)").IsRequired();

            //EntidadeBase
            builder.Property(x => x.DataRegistro).HasColumnType("TIMESTAMP").IsRequired();
            builder.Property(x => x.DataAtualizacaoRegistro).HasColumnType("TIMESTAMP");
            builder.Property(x => x.DataExclusao).HasColumnType("TIMESTAMP");
            builder.Property(x => x.Excluido).HasColumnType("BOOL");
        }
    }
}
