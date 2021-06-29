using System;
using System.Linq;
using Core.Entities;
using Core.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork<Film> _film;
        private readonly IUnitOfWork<FilmStar1> _filmst;

        public HomeController(
          IUnitOfWork<Film> film)
        {
            _film = film;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                Film = _film.Entity.GetAll().ToList(),
               
            };

            return View(homeViewModel);


        }
        public IActionResult Login()
        {

            return View();
        }
        public IActionResult Filmpage(Guid? id)
        {     // GET: Films/Details/5
            
                if (id == null)
                {
                    return NotFound();
                }

                var film = _film.Entity.GetById(id);

                if (film == null)
                {
                    return NotFound();
                }

                return View(film);
            
          
        }
       /* public HomeController(
        IUnitOfWork<FilmStar1> filmst)
        {
            _filmst = filmst;
        }
        public IActionResult FilmStar(Guid? id)
        {     // GET: Films/Details/5

            if (id == null)
            {
                return NotFound();
            }

            var film = _filmst.Entity.GetById(id);

            if (film == null)
            {
                return NotFound();
            }

            return View(film);


        }
        */

    }
}
