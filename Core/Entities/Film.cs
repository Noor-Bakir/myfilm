using System;
using System.Collections.Generic;

namespace Core.Entities
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
        public string Filmq { get; set; }
        public string Filmstory { get; set; }
        public FilmStar1 FilmStar1 { get; set; }
        public FilmStar2 FilmStar2 { get; set; }
        

        public static object Search(string term)
        {
            throw new NotImplementedException();
        }
    }
}
