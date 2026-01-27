using API.Imobiliaria.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Imobiliaria.Data.Configurations
{
    public class PropostaConfiguration : BaseEntityConfiguration<Proposta>
    {
        public void Configure(EntityTypeBuilder<Proposta> builder)
        {
            base.Configure(builder);

            builder.ToTable("propostas");

            // ===== Propriedades =====

            builder.Property(i => i.Valor)
                   .HasColumnName("valor")
                   .HasColumnType("numeric(18,2)")
                   .IsRequired();

            builder.Property(i => i.Status)
                   .HasColumnName("status")
                   .HasConversion<int>()
                   .IsRequired();

            builder.Property(i => i.DataProposta)
                   .HasColumnName("data_proposta")
                   .HasColumnType("timestamptz")
                   .IsRequired();

            // ===== FKs =====
            builder.Property(i => i.ImovelId)
                   .HasColumnName("imovel_id")
                   .HasColumnType("uuid");

            builder.Property(i => i.ClienteId)
                   .HasColumnName("cliente_id")
                   .HasColumnType("uuid");

            // ===== Relacionamentos =====
            builder.HasOne(i => i.Imovel)
                   .WithMany()
                   .HasForeignKey(i => i.ImovelId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.Cliente)
                   .WithMany()
                   .HasForeignKey(i => i.ClienteId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
