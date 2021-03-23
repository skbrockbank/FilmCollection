using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            FilmCollectionDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<FilmCollectionDbContext>();

            //Check if there are any pending migrations and migrate them
            if (context.Database.GetPendingMigrations().Any())
            {
                //Commented this out because it was throwing an error saying that the Books table already exists
                context.Database.Migrate();
            }

        }
    }
}
