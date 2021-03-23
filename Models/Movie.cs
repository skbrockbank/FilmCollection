using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }

        [Required(ErrorMessage = "Please enter a Category")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Please enter a Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter a Year")]
        public string Year { get; set; }
        [Required(ErrorMessage = "Please enter a Director")]
        public string Director { get; set; }
        [Required(ErrorMessage = "Please choose a Rating")]
        public string Rating { get; set; }
        [Required(ErrorMessage = "Please select whether this movie is Edited")]
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [StringLength(25)]
        public string Notes { get; set; }
    }
}
