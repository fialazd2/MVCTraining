using System.ComponentModel.DataAnnotations;

namespace Praha20191113.Web.Models
{
    public class DataAnnotationValidationViewModel
    {
        [Required]
        public string Required { get; set; }

        [StringLength(10, MinimumLength = 5)]
        public string StingLength { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Range(1,12)]
        public int Range { get; set; }

        [RegularExpression("\\D")]
        public string RegularExpression { get; set; }


    }
}