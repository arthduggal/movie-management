using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagementAPI.Model
{
    public class Movie
    {

        public int MovieId { get; set; }

        [Required(ErrorMessage = "Movie's Name is Mandatory")]
        public string MovieName { get; set; }

        [Required(ErrorMessage = " Movie's Description is Mandatory")]
        public string MovieDescription { get; set; }

        [Required (ErrorMessage ="Movie Language is required")]

        public string MovieLanguage { get; set; }

        [Required(ErrorMessage = "Book Category is Mandatory")]
        public string MovieCategory { get; set; }

        [Required(ErrorMessage = "Date time is Mandatory")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Movie Rental Price is Mandatory")]
        public double MovieRentalPrice { get; set; }

        [Required(ErrorMessage = "Movie Created by is Mandatory")]
        public string CreatedBy { get; set; }



    }
}
