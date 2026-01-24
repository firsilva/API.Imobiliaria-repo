using API.Imobiliaria.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace API.Imobiliaria.Data.Context
{
    public class ImobiliariaDbContext : DbContext
    {
        public ImobiliariaDbContext(DbContextOptions<ImobiliariaDbContext> options) : base(options) { }

        public DbSet<Caracteristica> Caracteristicas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Corretor> Corretores { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Imagem> Imagens { get; set; }
        public DbSet<Imovel> Imoveis { get; set; }
        public DbSet<ImovelCaracteristica> ImovelCaracteristicas { get; set; }
        public DbSet<Proposta> Propostas { get; set; }
        public DbSet<Proprietario> Proprietarios { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TipoImovel> TiposImovel { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ImobiliariaDbContext).Assembly); 
            
            base.OnModelCreating(modelBuilder);            
        }

        private static void ConfigureSoftDeleteFilter<TEntity>(ModelBuilder builder) where TEntity : EntidadeBase
        {
            builder.Entity<TEntity>().HasQueryFilter(e => !e.Excluido);
        }

        public async Task<bool> CommitAsync()
        {
            AplicarAuditoria();
            return await SaveChangesAsync() > 0;
        }

        public override int SaveChanges()
        {
            AplicarAuditoria();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AplicarAuditoria();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void AplicarAuditoria()
        {
            var entries = ChangeTracker.Entries<EntidadeBase>();

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Criar();
                        break;

                    case EntityState.Modified:
                        entry.Entity.AtualizarDataAtualizacao();
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.Desativar();
                        break;
                }
            }
        }
    }
}
