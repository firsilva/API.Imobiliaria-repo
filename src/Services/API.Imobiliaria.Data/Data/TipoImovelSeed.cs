using API.Imobiliaria.Data.Context;
using API.Imobiliaria.Dominio.Entidades;

namespace API.Imobiliaria.Data.Data
{
    public static class TipoImovelSeed
    {
        public static async Task SeedAsync(ImobiliariaContext context)
        {
        //    if (context.TiposImoveis.Any())
        //        return;

        //    var tipos = new List<TipoImovel>
        //{
        //    new() { Id = Guid.NewGuid(), Nome = "Casa" },
        //    new() { Id = Guid.NewGuid(), Nome = "Apartamento" },
        //    new() { Id = Guid.NewGuid(), Nome = "Terreno" },
        //    new() { Id = Guid.NewGuid(), Nome = "Galpão" },
        //    new() { Id = Guid.NewGuid(), Nome = "Sala Comercial" }
        //};

        //    await context.TiposImoveis.AddRangeAsync(tipos);
        //    await context.SaveChangesAsync();
        }
    }
}
