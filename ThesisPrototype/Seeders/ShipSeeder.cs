using System;
using System.Collections.Generic;
using System.Linq;
using ThesisPrototype.DatabaseApis;
using ThesisPrototype.DataModels;

namespace ThesisPrototype.Seeders
{
    public static class ShipSeeder
    {
        private readonly static int AMOUNT_OF_SHIPS_TO_SEED = 35;

        /// <summary>
        /// Seeds the EF-powered MySQL database with 35 ships.
        /// </summary>
        public static void SeedShips()
        {
            using (var context = new PrototypeContext())
            {
                var firstUserId = context.Users.First().UserId;

                var random = new Random();
                var countryNames = new string[6] { "Nederland", "Deutschland", "United States of America", "United Kingdom", "Italia", "San Marino" };
                var namesPrefixes = new string[6] { "H.M.S.", "H.N.L.M.S.", "F.S.", "F.G.S.", "U.S.S.", "I.J.N." };
                var namesPostfixes = new string[] { "Knuth", "Russell", "Newell", "Stonebraker", "Beck", "Torvalds", "Thompson", "Tukey", "Babbage", "Boole",  "Lovelace", "Cormack", "Neumann", "Codd", "Dijkstra", "Liskov", "Haskell", "Turing", "Curry" };
                var usedNames = new HashSet<string>();

                for (int i = 0; i < AMOUNT_OF_SHIPS_TO_SEED; i++)
                {
                    var country = countryNames[random.Next(0, countryNames.Length)];

                    var newShip = new Ship()
                    {
                        ShipId = i + 1,
                        ImoNumber = i + 1, 
                        Name = GetRandomShipName(namesPrefixes, namesPostfixes, random, usedNames),
                        ImageName = "0.jpg",
                        CountryName = country,
                        UserId = firstUserId
                    };

                    if (context.Ships.Any(x => x.ShipId == newShip.ShipId) == false)
                    {
                        context.Ships.Add(newShip);
                    }
                }
                context.SaveChanges();
            }
        }

        private static string GetRandomShipName(string[] prefixes, string[] postfixes, 
                                                Random random, HashSet<string> existingNames)
        {
            var randomName = $"{prefixes[random.Next(0, prefixes.Length)]} {postfixes[random.Next(0, postfixes.Length)]}";

            if(existingNames.Contains(randomName))
            {
                return GetRandomShipName(prefixes, postfixes, random, existingNames);
            }
            else
            {
                existingNames.Add(randomName);
                return randomName;
            }
        }
    }
}
