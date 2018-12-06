using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using ThesisPrototype.DatabaseApis;
using ThesisPrototype.DataModels;

namespace ThesisPrototype.Seeders
{
    public static class UserSeeder
    {
        /// <summary>
        /// Seeds the database and the ASP.NET identity system with some starting users.
        /// This is done in this separate class rather than in the PrototypeContext,
        /// because we need a UserManager in order to create the users, and this cannot be injected
        /// into the PrototypeContext OnModelCreating() method.
        /// </summary>
        public static void SeedUsers(UserManager<User> userManager)
        {
            using (var context = new PrototypeContext())
            {
                var usersToBeSeeded = new List<User>()
                {
                    new User() {UserId = 1, FirstName = "User", LastName = "1", UserName = "User1", Email = "user1@test.nl" },
                    new User() {UserId = 2, FirstName = "User", LastName = "2", UserName = "User2", Email = "user2@test.nl" },
                    new User() {UserId = 3, FirstName = "User", LastName = "3", UserName = "User3", Email = "user3@test.nl" }
                };

                foreach (var user in usersToBeSeeded)
                {
                    if (user.Email != null && userManager.FindByEmailAsync(user.Email).Result == null)
                    {
                        IdentityResult result = userManager.CreateAsync(user, password: "password").Result;

                        if (!result.Succeeded)
                        {
                            throw new Exception("User identity seeding failed.");
                        }
                    }
                }

            }

        }
    }
}
