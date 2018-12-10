using Microsoft.AspNetCore.Identity;

namespace ThesisPrototype.DataModels
{
    /// <summary>
    /// An EF entity representing a single User. 
    /// Inherits from IdentityUser so that ASP.NET methods for identification and authentication can be used with it.
    /// </summary>
    public class User : IdentityUser
    {
        public long UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}