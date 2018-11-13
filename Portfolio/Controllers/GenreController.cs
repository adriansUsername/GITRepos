using DataAccessLayer;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class GenreController : Controller
    {
        GenreDataAccess genreDA = new GenreDataAccess();
        ErrorDataAccess errorDA = new ErrorDataAccess();

        // GET FOR CHANGING THE GENRES
        [HttpGet]
        public ActionResult UpdateGenres()
        {
            GenreViewModel viewModel = new GenreViewModel();
            
            try
            {
                viewModel.genreList = MapperModel.map(genreDA.viewGenres());
            }
            catch (Exception error)
            {
                // log the error to the error data access
                errorDA.addError(error);
            }

            return View(viewModel);
        }

        // POST FOR CHANGING THE GENRES
        [HttpPost]
        public ActionResult UpdateGenres(GenreViewModel viewModel)
        {
            try
            {
                foreach(GenreModel genreFromTable in viewModel.genreList)
                {
                    // delete if selected and update if not
                    if (genreFromTable.isSelected)
                        genreDA.deleteGenre(genreFromTable.genreID);
                    else
                        genreDA.updateGenre(MapperModel.map(genreFromTable));
                }
            }
            catch (Exception error)
            {
                // log the error to the error data access
                errorDA.addError(error);
            }

            return RedirectToAction("UpdateGenres");
        }
    }
}