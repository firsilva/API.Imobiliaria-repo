using API.Imobiliaria.Data.Context;
using API.Imobiliaria.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Imobiliaria.Data.Data
{
    public static class UsuarioSeed
    {
        public static async Task SeedAsync(ImobiliariaDbContext context)
        {
            //if (context.Usuarios.Any())
            //    return;

            //var adminRole = context.Roles.First(r => r.Nome == "Admin");

            //var hasher = new PasswordHasher<Usuario>();

            //var admin = new Usuario
            //{
            //    Id = Guid.NewGuid(),
            //    Nome = "Administrador",
            //    Email = "admin@imobiliaria.com",
            //    RoleId = adminRole.Id,
            //    Ativo = true,
            //    CreatedAt = DateTime.UtcNow
            //};

            //admin.SenhaHash = hasher.HashPassword(admin, "Admin@123");

            //await context.Usuarios.AddAsync(admin);
            //await context.SaveChangesAsync();
        }
    }
}