using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class FilmViewModel :EntityBase
    {
        internal string Starimage;

        public string FilmName { get; set; }
        public string FilmLang { get; set; }
        public string FilmTrans { get; set; }
        public string FilmType { get; set; }
        public string Filmtime { get; set; }
        public string FilmDate { get; set; }
        public string FilmDarg { get; set; }
        public string FilmImage { get; set; }
        public string Filmstory { get; set; }
        //public FilmStar1 FilmStar1 { get; set; }
       // public FilmStar2 FilmStar2 { get; set; }
        public Guid Id { get; set; }
        public IFormFile File { get; set; }
        public string StarName { get; internal set; }
        public string Film { get; internal set; }
       
        public FilmStar1 FilmStar1 { get;  set; }
    }
}
