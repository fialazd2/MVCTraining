using System;

namespace Praha20191113.Web.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Director { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public DateTime? ReleasedDate { get; set; }

        //Language
        public int? LanguageID { get; set; }
        public virtual Language Language { get; set; }
    }
}
