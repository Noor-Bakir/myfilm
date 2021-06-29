using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class HomeViewModel
    {
        

        //  public Film Film { get; set; }
        public List<Film> Film{ get; set; }
       public List<FilmStar1> FilmStar1 { get; set; }
    }
}
