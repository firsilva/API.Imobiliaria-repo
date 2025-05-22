using API.Imobiliaria.Data.Mapping;
using API.Imobiliaria.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace API.Imobiliaria.Data.Context
{
    public class ImobiliariaContext : DbContext
    {
        public ImobiliariaContext(DbContextOptions<ImobiliariaContext> options) : base(options) { }

        public DbSet<Casa> Casa { get; set; }
        public DbSet<Apartamento> Apartamento { get; set; }
        public DbSet<Galpao> Galpao { get; set; }
        public DbSet<SalaComercial> SalaComercial { get; set; }
        public DbSet<Terreno> Terreno { get; set; }
        public DbSet<Imagem> Imagem { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ImobiliariaContext).Assembly);

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CasaMapping());
        }

        public async Task<bool> CommitAsync()
        {
            var success = await SaveChangesAsync() > 0;

            if (success)
            {
                await SaveChangesAsync();
            }

            return success;
        }
    }
}
