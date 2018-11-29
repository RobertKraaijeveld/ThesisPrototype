using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ThesisPrototype
{
    public class User : IdentityUser
    {
        [IsPrimaryKey]
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Vessel> Vessels { get; set; }
    }
}