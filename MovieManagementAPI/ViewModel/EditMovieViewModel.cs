using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagementAPI.ViewModel
{
    public class EditMovieViewModel : AddMovieViewModel
    {
        public int MovieId { get; set; }
    }
}
