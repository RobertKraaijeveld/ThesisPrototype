using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ThesisPrototype.ViewModels
{
    [BindProperties]
    public class ShipCreateViewModel
    {
        [Required, DataType(DataType.Text)]
        public string ShipName { get; set; }

        [Required, DataType(DataType.ImageUrl)]
        public string ImageName { get; set; }

        [Required, DataType(DataType.Text)]
        public string CountryName { get; set; }

        [Required, MaxLength(7)]
        public string ImoNumber { get; set; }
    }
}
