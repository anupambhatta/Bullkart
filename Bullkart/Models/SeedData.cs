using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bullkart.Models
{

    public static class SeedData
    {

        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Categories.Any())
            {
                Category movies = new Category
                {
                    //CategoryId = 1,
                    CategoryName = "Movies",
                    Description = "Movies discs",
                };
                Category men = new Category
                {
                    //CategoryId = 2,
                    CategoryName = "Men",
                    Description = "Men related clothes, shoes",
                };
                Category women = new Category
                {
                    //CategoryId = 3,
                    CategoryName = "Women",
                    Description = "Women related clothes, shoes",
                    Catalogs = new System.Collections.Generic.List<Catalog> {new Catalog
                                                                                {
                                                                                    //CatalogId = 1,
                                                                                    CatalogName = "Jeans",
                                                                                    Description = "Women's jeans",
                                                                                }
                                                                            }
                };
                Category accessories = new Category
                {
                    //CategoryId = 4,
                    CategoryName = "Accessories",
                    Description = "Unisex accessories",
                };
                context.Categories.AddRange(movies, men, women, accessories);
                Catalog jeans = new Catalog
                {
                    CatalogId = 1,
                    CatalogName = "Jeans",
                    Description = "Women's jeans",
                    Category = women
                };
                //context.Catalogs.Add(jeans);
            
                context.SaveChanges();
            }
        }
    }
}
