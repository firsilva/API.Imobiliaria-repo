using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using API.Imobiliaria.Dominio.Entidades;

namespace API.Imobiliaria.Data.Configurations
{
    public class ContratoConfiguration : BaseEntityConfiguration<Contrato>
    {
        public void Configure(EntityTypeBuilder<Contrato> builder)
        {
            base.Configure(builder);

            builder.ToTable("contratos");

            // ===== Contrato =====
            builder.Property(c => c.ImovelId)
                   .HasColumnName("imovel_id")
                   .HasColumnType("uuid");

            builder.HasOne(c => c.Imovel)
                   .WithMany()
                   .HasForeignKey(c => c.ImovelId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.ClienteId)
                   .HasColumnName("cliente_id")
                   .HasColumnType("uuid");

            builder.HasOne(c => c.Cliente)
                   .WithMany()
                   .HasForeignKey(c => c.ClienteId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.CorretorId)
                   .HasColumnName("corretor_id")
                   .HasColumnType("uuid");

            builder.HasOne(c => c.Corretor)
                   .WithMany()
                   .HasForeignKey(c => c.CorretorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.ValorFinal)
                   .HasColumnName("valor_final")
                   .HasColumnType("numeric(18,2)");

            builder.Property(c => c.DataInicio)
                   .HasColumnName("data_inicio")
                   .HasColumnType("timestamptz");

            builder.Property(c => c.DataFim)
                   .HasColumnName("data_fim")
                   .HasColumnType("timestamptz");

            builder.Property(c => c.Finalidade)
                   .HasColumnName("finalidade")
                   .HasConversion<int>()
                   .IsRequired();
        }
    }
}
