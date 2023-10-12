using Microsoft.AspNetCore.Mvc;
using Tur_agen_asp_net.Models;

namespace Tur_agen_asp_net.Controllers
{
    public class TourController : Controller
    {
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
                // Добавьте новый тур в базу данных
                using (var context = new ApDbContext(/* передайте соответствующие опции */))
                {
                    context.Tours.Add(tour);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            return View(tour);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Получите тур с заданным идентификатором из базы данных
            using (var context = new ApDbContext(/* передайте соответствующие опции */))
            {
                var tour = context.Tours.FirstOrDefault(t => t.id_tour == id);
                if (tour == null)
                {
                    return NotFound();
                }

                return View(tour);
            }
        }

        [HttpPost]
        public IActionResult Edit(int id, Tour tour)
        {
            if (ModelState.IsValid)
            {
                // Обновите данные тура в базе данных
                using (var context = new ApDbContext(/* передайте соответствующие опции */))
                {
                    context.Tours.Update(tour);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            return View(tour);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            // Найдите тур с заданным идентификатором и удалите его из базы данных
            using (var context = new ApDbContext(/* передайте соответствующие опции */))
            {
                var tour = context.Tours.FirstOrDefault(t => t.id_tour == id);
                if (tour != null)
                {
                    context.Tours.Remove(tour);
                    context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
