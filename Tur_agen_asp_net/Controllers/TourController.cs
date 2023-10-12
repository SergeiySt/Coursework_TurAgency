using Microsoft.AspNetCore.Mvc;
using Tur_agen_asp_net.Models;

namespace Tur_agen_asp_net.Controllers
{
    public class TourController : Controller
    {
        private readonly ApDbContext _context;

        public TourController(ApDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tour tour)
        {
            if (ModelState.IsValid)
            {
                _context.Tours.Add(tour);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tour);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Получите тур с заданным идентификатором из базы данных
            var tour = _context.Tours.FirstOrDefault(t => t.id_tour == id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }

        [HttpPost]
        public IActionResult Edit(int id, Tour tour)
        {
            if (ModelState.IsValid)
            {
                // Обновите данные тура в базе данных
                var existingTour = _context.Tours.FirstOrDefault(t => t.id_tour == id);
                if (existingTour == null)
                {
                    return NotFound();
                }

                existingTour.TName_tour = tour.TName_tour;
                existingTour.TCountry = tour.TCountry;
                existingTour.TTown = tour.TTown;
                existingTour.TDescription = tour.TDescription;
                existingTour.TPrice = tour.TPrice;
                existingTour.TCount = tour.TCount;
                existingTour.TUrl = tour.TUrl;

                _context.Tours.Update(existingTour);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(tour);
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            // Найдите тур с заданным идентификатором и удалите его из базы данных
            var tour = _context.Tours.FirstOrDefault(t => t.id_tour == id);
            if (tour != null)
            {
                _context.Tours.Remove(tour);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
