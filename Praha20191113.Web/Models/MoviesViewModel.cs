using System;
using System.ComponentModel.DataAnnotations;

namespace Praha20191113.Web.Models
{
    public class MoviesViewModel
    {
        public int Id { get; set; }
        //[Display(Name ="MovieTitle", ResourceType =typeof(Localiza))]
        [Required]
        public string Title { get; set; }
        public Genre Genre { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ReleasedDate { get; set; }
        public string Director { get; set; }
        public string Language { get; set; }
    }

    public enum Genre
    {
        //[Display(Name = "Hokus pokus")]
        Comedy,
        //[Display(Name = "Hokus pokus Thriller")]
        Thriller
    }
}