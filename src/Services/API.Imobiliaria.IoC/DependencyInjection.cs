using API.Imobiliaria.Aplicacao.Cliente;
using API.Imobiliaria.Data.Context;
using API.Imobiliaria.Data.Repository;
using API.Imobiliaria.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace API.Imobiliaria.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ImobiliariaDbContext>(options =>
                options.UseNpgsql(connectionString));

            // 2️⃣ Registrar Repositórios genéricos
            //services.AddScoped(typeof(Repository<>));
            services.AddScoped<Repository<Cliente>>();

            services.AddScoped<IClienteService, ClienteService>();

            return services;
        }
    }
}
