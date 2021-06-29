using System;
using System.Collections.Generic;
using System.Text;
namespace core.Entities
{
    public class Film : EntityBase
    {
        public string FilmName { get; set; }
        public string FilmLang { get; set; }
        public string FilmTrans { get; set; }
        public string FilmType { get; set; }
        public string Filmtime { get; set; }
        public string FilmDate { get; set; }
        public string FilmDarg { get; set; }
        public string FilmImage { get; set; }
        public string FilmStar1 { get; set; }
        public string FilmStar2 { get; set; }
    }
}
