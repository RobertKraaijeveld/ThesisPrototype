using System.Collections.Generic;
using System.Linq;
using ThesisPrototype.DatabaseApis;
using ThesisPrototype.DataModels;

namespace ThesisPrototype.Seeders
{
    public static class ShipSeeder
    {
        public static void SeedShips()
        {
            using (var context = new PrototypeContext())
            {
                var shipsToBeSeeded = new List<Ship>()
                {
                    new Ship
                    {
                        UserId = 1,
                        Name = "Waage",
                        ImageName = "ship1.jpg",
                        CountryName = "Germany",
                        ImoNumber = 1111111
                    },
                    new Ship
                    {
                        UserId = 2,
                        Name = "Grüblein",
                        ImageName = "ship2.jpg",
                        CountryName = "Germany",
                        ImoNumber = 1111112
                    },
                    new Ship
                    {
                        UserId = 3,
                        Name = "Schlauer Fuchs",
                        ImageName = "ship3.jpg",
                        CountryName = "Germany",
                        ImoNumber = 1111113
                    },
                    new Ship
                    {
                        UserId = 3,
                        Name = "Mandritto",
                        ImageName = "ship4.jpg",
                        CountryName = "Italy",
                        ImoNumber = 1111114
                    },
                    new Ship
                    {
                        UserId = 3,
                        Name = "Sottani",
                        ImageName = "ship5.jpg",
                        CountryName = "Italy",
                        ImoNumber = 1111115
                    }
                };


                foreach (var shipToBeAdded in shipsToBeSeeded)
                {
                    if (context.Ships.Any(x => x.ImoNumber == shipToBeAdded.ImoNumber) == false)
                    {
                        context.Ships.Add(shipToBeAdded);
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
