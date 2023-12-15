using At_C__2023.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace At_C__2023.Data
{
    public class AFlor
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using IServiceScope Scope = applicationBuilder.ApplicationServices.CreateScope();
            var context = Scope.ServiceProvider.GetService<At_C__2023Context>();

            bool v = context.Database.EnsureCreated();

            if (!context.Flor.Any())
            {

                context.Flor.AddRange(new List<Flor>()
                    {
                        new Flor()
                        {
                            

                            Nome = "Margarida",

                            Especie = "Alstro-Emeria",

                            Quantidade = 1
                        }

                    });
            }
            context.SaveChanges();
        }
    }
}
