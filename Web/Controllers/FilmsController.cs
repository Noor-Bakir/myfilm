using Core.Entities;
using System.Collections.Generic;
using Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels;
using Infrastructure;
using System.Security.Cryptography.X509Certificates;

namespace Web.Controllers
{
    public class FilmsController : Controller
    {
        private readonly IUnitOfWork<Film> _film;
        private readonly IHostingEnvironment _hosting;

        public FilmsController(IUnitOfWork<Film>film, IHostingEnvironment hosting)
        {
            _film = film;
            _hosting = hosting;
        }

        // GET: Films
        public IActionResult Index()
        {
            return View(_film.Entity.GetAll());
        }

        // GET: Films/Details/5
        public IActionResult Details(Guid? id)
        {
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

        // GET: Films/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Films/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FilmViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.File != null)
                {
                    string uploads = Path.Combine(_hosting.WebRootPath, @"img\image");
                    string fullPath = Path.Combine(uploads, model.File.FileName);
                    model.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                }

                Film filmitem = new Film
                {
                    FilmName = model.FilmName,
                    FilmLang = model.FilmName,
                    FilmTrans = model.FilmTrans,
                    FilmType = model.FilmType,
                    Filmtime = model.Filmtime,
                    FilmDate = model.FilmDate,
                    FilmDarg = model.FilmDarg,
                    FilmImage = model.File.FileName,
                    Filmstory= model.Filmstory,
                    FilmStar1 = model.FilmStar1,
                    
                };

                    _film.Entity.Insert(filmitem);
                    _film.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Films/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film =_film.Entity.GetById(id);
            if (film == null)
            {
                return NotFound();
            }
            FilmViewModel filmodel = new FilmViewModel
            {
                Id = film.Id,
                FilmName = film.FilmName,
                FilmLang = film.FilmLang,
                FilmTrans = film.FilmTrans,
                FilmType =film.FilmType,
                Filmtime = film.Filmtime,
                FilmDate = film.FilmDate,
                FilmDarg = film.FilmDarg,
                FilmImage = film.FilmImage,
                Filmstory = film.Filmstory,
                FilmStar1 =film.FilmStar1,
               
            };
            return View(filmodel);
        }

        // POST: Films/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id,FilmViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {

                    if (model.File != null)
                    {
                        string uploads = Path.Combine(_hosting.WebRootPath, @"img\image");
                        string fullPath = Path.Combine(uploads, model.File.FileName);
                        model.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                    }

                    Film film = new Film
                    {   Id = model.Id,
                        FilmName = model.FilmName,
                        FilmLang = model.FilmLang,
                        FilmTrans = model.FilmTrans,
                        FilmType = model.FilmType,
                        Filmtime = model.Filmtime,
                        FilmDate = model.FilmDate,
                        FilmDarg = model.FilmDarg,
                        FilmImage = model.File.FileName,
                        Filmstory = model.Filmstory,
                        FilmStar1 = model.FilmStar1,
                       
                    };

                    _film.Entity.Update(film);
                    _film.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Films/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film =_film.Entity.GetById(id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {

            _film.Entity.Delete(id);
            _film.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmExists(Guid id)
        {
            return _film.Entity.GetAll().Any(e => e.Id == id);
        }


       /* public ActionResult Search(string term)
        {
            var result = _film.Entity.Search(term);

            return View("Index", result);
        }*/
      
        [HttpPost]

        public ActionResult Search(FilmViewModel model)
        {
            if (!string.IsNullOrEmpty(model.FilmName))
            {
                model.Film = _film.FullTextSearchQuery(model.FilmName);
            }
            return View(model);
        }
        /* public ActionResult Search(string searchName)
         {
             /* var result = _film.Entity.GetAll().Any(e => e.FilmName.Contains(searchName));
                  || b.FilmDarg.Contains(searchName)
                            || b.FilmDate.Contains(searchName)
                            || b.FilmStar1.StarName.Contains(searchName)

                    || b.Filmtime.Contains(searchName)
                    || b.FilmName.Contains(searchName)
                    || b.FilmTrans.Contains(searchName));


             return View(_film.Entity.GetAll().Any(e => e.FilmName().Contains(searchName)));
         }*/
        /* public ActionResult Search(string searchName)
         {
             var result = _film.Search(searchName);

             return View("Index", result);
         }*/
        /* public async Task<IActionResult>Search(string searchName)
         {

             var result = from x in _film.Entity.GetAll() select x;
             if (!string.IsNullOrEmpty(searchName))
             {
                 result = result.Where(x => x.FilmName.Contains(searchName) || x.Filmstory.Contains(searchName)); 
             }
             return View(await result.AsNoTracking().ToListAsync());
         }*/

    }
}
