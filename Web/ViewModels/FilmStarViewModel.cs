using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class FilmStarViewModel :EntityBase
    {
        public string StarName  { get; set; }
        public string Film { get; set; }
        public string Starimage { get; set; }
   
        public IFormFile File { get; set; }
    }
    
}
