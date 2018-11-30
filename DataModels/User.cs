using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ThesisPrototype
{
    public class User : IdentityUser
    {
        public long UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Ship> Vessels { get; set; }
    }
}