using RecipeWebsite.Data.Enum;
using RecipeWebsite.Models;


namespace RecipeWebsite.Data
{
    public class Seed
    {
        #region Application Data
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                #region Collections Seed Data
                if (!context.Collections.Any())
                {
                    context.Collections.AddRange(new List<Collection>()
                    {
                        new Collection()
                        {
                            Title = "Veg Recipe Collection",
                            Image = "https://res.cloudinary.com/dnoegfkl2/image/upload/v1698121205/fff1w64fa1dmefblmrxd.webp",
                            Description = "This is a Collection where all Veg Recipe posts appear.",
                            CollectionCategory = CollectionCategory.Veg
                         },

                        new Collection()
                        {
                            Title = "NonVeg Recipe Collection",
                            Image = "https://res.cloudinary.com/dnoegfkl2/image/upload/v1698122243/wkqqeoulqzcrp184pzz3.webp",
                            Description = "This is a Collection where all NonVeg Recipe posts appear.",
                            CollectionCategory = CollectionCategory.NonVeg
                        },

                        new Collection()
                        {
                            Title = "Breakfast Recipe Collection",
                            Image = "https://res.cloudinary.com/dnoegfkl2/image/upload/v1688648695/cld-sample-4.jpg",
                            Description = "This is a Collection where all Breakfast Recipe posts appear.",
                            CollectionCategory = CollectionCategory.Breakfast
                        },

                        new Collection()
                        {
                            Title = "Lunch Recipe Collection",
                            Image = "https://res.cloudinary.com/dnoegfkl2/image/upload/v1698123174/wyxnw1sa4nax8lafjclq.jpg",
                            Description = "This is a Collection where all Lunch Recipe posts appear.",
                            CollectionCategory = CollectionCategory.Lunch
                        },

                        new Collection()
                        {
                            Title = "Dinner Recipe Collection",
                            Image = "https://res.cloudinary.com/dnoegfkl2/image/upload/v1698123431/xs9ugyhsujdxbis3hbtb.jpg",
                            Description = "This is a Collection where all Dinner Recipe posts appear.",
                            CollectionCategory = CollectionCategory.Dinner
                        },

                        new Collection()
                        {
                            Title = "Sweets Recipe Collection",
                            Image = "https://res.cloudinary.com/dnoegfkl2/image/upload/v1698123501/ovtqa5jigpxvtjfzursz.webp",
                            Description = "This is a Collection where all Sweets Recipe posts appear.",
                            CollectionCategory = CollectionCategory.Special
                        }
                    });
                    context.SaveChanges();
                }
                #endregion

                #region Posts Seed Data
                if (!context.Posts.Any())
                {
                    context.Posts.AddRange(new List<Post>()
                    {
                        #region Veg Posts
                        new Post()
                        {
                            Title = "Chakli Recipe",
                            Image = "https://res.cloudinary.com/dnoegfkl2/image/upload/v1698124034/jqnnxzkwcw948c5xq38b.jpg",
                            Description = "Chakli is a type of veg festive recipe.",
                            PostCategory = PostCategory.Veg,
                            Recipe = "Chakli is a type of veg festive recipe. It is mailny created in Indian households while celebrating Gods or Diwali!"
                        },

                        new Post()
                        {
                            Title = "Shankarpali Recipe",
                            Image = "https://res.cloudinary.com/dnoegfkl2/image/upload/v1698124141/yevzdzkedcqlijkxyig4.jpg",
                            Description = "Shankarpali is a type of veg festive recipe.",
                            PostCategory = PostCategory.Veg,
                            Recipe = "ShankarPali in Marathi or SharkarPare in Hindi language is a type of veg festive recipe. It is mailny created in Indian households while celebrating Gods or Diwali!"
                        },

                        new Post()
                        {
                            Title = "Pulao Recipe",
                            Image = "https://res.cloudinary.com/dnoegfkl2/image/upload/v1698124232/gq0i1kyvbpv7xg0pfxxi.jpg",
                            Description = "Pulao is a celebration in and of itself.",
                            PostCategory = PostCategory.Veg,
                            Recipe = "Pulao is one the the most beloved veg recipe of the people. People eat it to celebrate an occasion or even simpally just because they want to. Every bite is full of joy so savour it."
                        },

                        new Post()
                        {
                            Title = "Karanji Recipe",
                            Image = "https://res.cloudinary.com/dnoegfkl2/image/upload/v1698124411/unb93dde2gnrwvokx39e.jpg",
                            Description = "Karanji is a type of veg festive recipe. It is mailny created in Indian households while celebrating Gods or Diwali!",
                            PostCategory = PostCategory.Veg,
                            Recipe = "Karanji is a type of veg festive recipe. It is mailny created in Indian households while celebrating Gods or Diwali!"
                        },

                        new Post()
                        {
                            Title = "Chivda Recipe",
                            Image = "https://res.cloudinary.com/dnoegfkl2/image/upload/v1698124517/jheovpbrlfzuy4abnrlu.webp",
                            Description = "Chivda is a type of veg snack but also often seen as a festive recipe.",
                            PostCategory = PostCategory.Veg,
                            Recipe = "Chivda is a type of dry snack people just make to eat whenever. It is also created in Indian households while celebrating Gods or Diwali!"
                        },
                        #endregion

                        #region NonVeg Posts
                        new Post()
                        {
                            Title = "Biryani Recipe",
                            Image = "https://res.cloudinary.com/dnoegfkl2/image/upload/v1698125569/dwlefkftkt8mla2xieke.webp",
                            Description = "Pulao is a celebration in and of itself.",
                            PostCategory = PostCategory.NonVeg,
                            Recipe = "Pulao is one the the most beloved NonVeg recipe of the people. People eat it to celebrate an occasion or even simpally just because they want to. Every bite is full of joy so savour it."
                        },

                        new Post()
                        {
                            Title = "Shrimp Recipe",
                            Image = "https://res.cloudinary.com/dnoegfkl2/image/upload/v1698125693/pos1z1kqopbjyvsomu3o.jpg",
                            Description = "Shrimp is a NonVeg Recipe.",
                            PostCategory = PostCategory.NonVeg,
                            Recipe = "It is a one of a kind recipe and tasts awsome!"
                        },

                        new Post()
                        {
                            Title = "Bombayduck Recipe",
                            Image = "https://res.cloudinary.com/dnoegfkl2/image/upload/v1698125805/z1rqoyejbgyzyb2o4j49.jpg",
                            Description = "Bombayduck is a NonVeg Recipe. Also, it is not a literal duck.",
                            PostCategory = PostCategory.NonVeg,
                            Recipe = "As the name suggests, it is a fish ( not a duck ) only found in Bombay. Shame, really, as most people dont get to taste this beautifull dish."
                        },

                        new Post()
                        {
                            Title = "Pomfret Recipe",
                            Image = "https://res.cloudinary.com/dnoegfkl2/image/upload/v1698125944/wzqni5zks1paapmh1tp7.webp",
                            Description = "Pomfret is a NonVeg Recipe.",
                            PostCategory = PostCategory.NonVeg,
                            Recipe = "Pomfret is a fish even if little expensive, worth every coin. Just need to have fresh materials( especially the fish ) and know how how to cook it properly."
                        },

                        new Post()
                        {
                            Title = "Chikan Masala Recipe",
                            Image = "https://res.cloudinary.com/dnoegfkl2/image/upload/v1698126017/knnvyjdojpj7msdvuwub.webp",
                            Description = "Chikan Masala Recipe is a NonVeg Recipe. If you havent eaten Chikan Masala, you havent eaten chicken.( slightly exagerated... )",
                            PostCategory = PostCategory.NonVeg,
                            Recipe = "Once eaten Chikan Masala, you cannot turn back.( slightly exagerated... )"
                        }
                        #endregion
                    });
                    context.SaveChanges();
                }
                #endregion

            }

        }
        #endregion

        #region Application Users

        //public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        //{
        //    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        //    {

        //        //Roles
        //        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        //        if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        //        if (!await roleManager.RoleExistsAsync(UserRoles.User))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        //        // Users Seed
        //        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

        //        // Admin
        //        string adminUserEmail = "omkardalvideveloper@gmail.com";

        //        var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
        //        if (adminUser == null)
        //        {
        //            var newAdminUser = new AppUser()
        //            {
        //                FirstName = Omkar,
        //                LastName = Devloper,
        //                UserName = "omkardalvidev",
        //                Email = adminUserEmail,
        //                EmailConfirmed = true
        //            };
        //            await userManager.CreateAsync(newAdminUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
        //        }

        //        // User
        //        string appUserEmail = "user@etickets.com";

        //        var appUser = await userManager.FindByEmailAsync(appUserEmail);
        //        if (appUser == null)
        //        {
        //            var newAppUser = new AppUser()
        //            {
        //                FirstName = App,
        //                LastName = User,
        //                UserName = "app-user",
        //                Email = appUserEmail,
        //                EmailConfirmed = true
        //            };
        //            await userManager.CreateAsync(newAppUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
        //        }
        //    }
        //}
        #endregion
    }
}
