using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using API.Imobiliaria.Dominio.Entidades;

namespace API.Imobiliaria.Data.Mapping
{
    public class ProprietarioMapping : BaseMapping<Proprietario>
    {
        public void Configure(EntityTypeBuilder<Proprietario> builder)
        {
            builder.ToTable("proprietario");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).HasColumnType("NVARCHAR(500)").IsRequired();
            builder.Property(x => x.Email).HasColumnType("NVARCHAR(500)").IsRequired();
            builder.Property(x => x.Telefone).HasColumnType("NVARCHAR(15)").IsRequired();
            builder.Property(x => x.Documento).HasColumnType("NVARCHAR(15)").IsRequired();

            builder.Property(x => x.DataRegistro).HasColumnType("TIMESTAMP").IsRequired();
            builder.Property(x => x.DataAtualizacaoRegistro).HasColumnType("TIMESTAMP");
            builder.Property(x => x.DataExclusao).HasColumnType("TIMESTAMP");
            builder.Property(x => x.Excluido).HasColumnType("BOOL");
        }
    }
}
