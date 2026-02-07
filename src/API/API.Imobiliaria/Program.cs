using API.Imobiliaria.Aplicacao.ClienteApplication;
using API.Imobiliaria.Data.Context;
using API.Imobiliaria.Data.Data;
using API.Imobiliaria.Data.Repository;
using API.Imobiliaria.Dominio.Entidades;
using API.Imobiliaria.IoC;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Imobiliaria
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddInfrastructure(builder.Configuration);

            //builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,

            //        ValidIssuer = builder.Configuration["Jwt:Issuer"],
            //        ValidAudience = builder.Configuration["Jwt:Audience"],
            //        IssuerSigningKey = new SymmetricSecurityKey(
            //            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            //    };
            //});

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();

            //Aplicar as Migrations toda vez que rodar a primeira vez
            //using (var scope = app.Services.CreateScope())
            //{
            //    var context = scope.ServiceProvider.GetRequiredService<ImobiliariaContext>();
            //    context.Database.Migrate();

            //    await RoleSeed.SeedAsync(context);
            //    await UsuarioSeed.SeedAsync(context);
            //    await TipoImovelSeed.SeedAsync(context);
            //}

            app.Services
               .GetRequiredService<IMapper>()
               .ConfigurationProvider
               .AssertConfigurationIsValid();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DefaultModelsExpandDepth(-1);
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
