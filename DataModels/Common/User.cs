using Microsoft.AspNetCore.Identity;

namespace ThesisPrototype.DataModels
{
    public class User : IdentityUser
    {
        public long UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}