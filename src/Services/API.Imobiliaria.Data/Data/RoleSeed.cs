using API.Imobiliaria.Data.Context;

namespace API.Imobiliaria.Data.Data
{
    public static class RoleSeed
    {
        public static async Task SeedAsync(ImobiliariaDbContext context)
        {
            //if (context.Roles.Any())
            //    return;
            //var roles = new[]
            //{
            //    new Role { Id = Guid.NewGuid(), Nome = "Admin" },
            //    new Role { Id = Guid.NewGuid(), Nome = "Corretor" },
            //    new Role { Id = Guid.NewGuid(), Nome = "Cliente" }
            //};

            //await context.Roles.AddRangeAsync(roles);
            //await context.SaveChangesAsync();
        }
    }
}
