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


        //public IActionResult Index()
        //{
        //    ViewBag.ShowTourManagement = true;
        //    var tours = _context.Tour.ToList();
        //    return View(tours);
        //}

        public IActionResult TourList(string successMessage)
        {
            // Здесь вы можете получить список всех туров из базы данных
            var tours = _context.Tour.ToList();

            // Передайте список туров и сообщение об успешном добавлении в представление
            ViewBag.Tours = tours;
            ViewBag.SuccessMessage = successMessage;

            return View(tours);
        }

        [HttpGet]
        public IActionResult Create()
        {
            // Создайте представление для создания нового тура
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tour tour)
        {
            if (ModelState.IsValid)
            {
                _context.Tour.Add(tour);
                _context.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("TourList", new { successMessage = "Тур успешно добавлен." });
            }
            return View(tour);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Получите тур с заданным идентификатором из базы данных
            var tour = _context.Tour.FirstOrDefault(t => t.id_tour == id);
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
                var existingTour = _context.Tour.FirstOrDefault(t => t.id_tour == id);
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

                _context.Tour.Update(existingTour);
                _context.SaveChanges();

                return RedirectToAction("TourList", new { successMessage = "Тур успешно обновлено." });
            }
            return View(tour);
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            // Найдите тур с заданным идентификатором и удалите его из базы данных
            var tour = _context.Tour.FirstOrDefault(t => t.id_tour == id);
            if (tour != null)
            {
                _context.Tour.Remove(tour);
                _context.SaveChanges();
            }

            return RedirectToAction("TourList", new { successMessage = "Тур успешно удалено." });
        }
    }
}
