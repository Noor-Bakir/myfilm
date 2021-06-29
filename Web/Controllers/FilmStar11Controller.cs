using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infrastructure;
using Core.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Web.ViewModels;
using System.IO;

namespace Web.Controllers
{
    public class FilmStar11Controller : Controller
    {
        private readonly IUnitOfWork<FilmStar1> _film;
        private readonly IHostingEnvironment _hosting;

        public FilmStar11Controller(IUnitOfWork<FilmStar1> film, IHostingEnvironment hosting)
        {
            _film = film;
            _hosting = hosting;
        }


        // GET: FilmStar11
        public IActionResult Index()
        {
            return View(_film.Entity.GetAll());
        }

        // GET: FilmStar11/Details/5
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


        // GET: FilmStar11/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: FilmStar11/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FilmStarViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.File != null)
                {
                    string uploads = Path.Combine(_hosting.WebRootPath, @"img\image");
                    string fullPath = Path.Combine(uploads, model.File.FileName);
                    model.File.CopyTo(new FileStream(fullPath, FileMode.Create));
                }

                FilmStar1 filmitem = new FilmStar1
                {
                    StarName = model.StarName,
                    Film = model.Film,
                    Starimage = model.File.FileName,
                    
                };

                _film.Entity.Insert(filmitem);
                _film.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        // GET: FilmStar11/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Film = _film.Entity.GetById(id);
            if (Film == null)
            {
                return NotFound();
            }
            FilmViewModel filmodel = new FilmViewModel
            {
                Id = Film.Id,
                StarName = Film.StarName,
                Film = Film.Film,
                Starimage = Film.Starimage,
              

            };
            return View(filmodel);
        }

        // POST: FilmStar11/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, FilmStarViewModel model)
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

                    FilmStar1 Film = new FilmStar1
                    {
                        Id = model.Id,
                        StarName = model.StarName,
                        Film = model.Film,
                        Starimage = model.File.FileName,

                    };

                    _film.Entity.Update(Film);
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

        private bool FilmExists(Guid id)
        {
            throw new NotImplementedException();
        }

        // GET: FilmStar11/Delete/5
        public IActionResult Delete(Guid? id)
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

        // POST: FilmStar11/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {

            _film.Entity.Delete(id);
            _film.Save();
            return RedirectToAction(nameof(Index));
        }


        private bool FilmStar1Exists(Guid id)
        {
            return _film.Entity.GetAll().Any(e => e.Id == id);
        }
    }
}
