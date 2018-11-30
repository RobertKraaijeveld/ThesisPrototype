using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThesisPrototype
{
    public class Ship 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ShipId { get; set; }

        public string Name { get; set; }
        public string ImageName { get; set; }

        public string CountryName { get; set; }      
        public int ImoNumber { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }

    }
}