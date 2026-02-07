using API.Imobiliaria.Aplicacao.ClienteApplication;
using API.Imobiliaria.Aplicacao.ClienteApplication.Mappings;
using API.Imobiliaria.Data.Context;
using API.Imobiliaria.Data.Repository;
using API.Imobiliaria.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace API.Imobiliaria.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException(
                    "Connection string 'DefaultConnection' não encontrada.");

            services.AddDbContext<ImobiliariaDbContext>(options =>
                options.UseNpgsql(
                    connectionString,
                    x => x.MigrationsAssembly("API.Imobiliaria.Data")
                ).UseSnakeCaseNamingConvention());

            services.AddScoped<Repository<Cliente>>();
            services.AddScoped<IClienteService, ClienteService>();

            return services;
        }
    }
}