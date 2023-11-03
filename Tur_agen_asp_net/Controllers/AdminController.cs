using Microsoft.AspNetCore.Mvc;
using Tur_agen_asp_net.Models;
using Tur_agen_asp_net.ViewModels;
using Tur_agen_asp_net.Views.Admin;
//using Tur_agen_asp_net.Views.Admin;


namespace Tur_agen_asp_net.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApDbContext _context;

        public AdminController(ApDbContext context)
        {
            _context = context;
        }



        public async Task<IActionResult> AdminPanelAsync()
        {
            //var model = new AdminPanelModel(_context);
            //await model.OnGetAsync(); 
            //return View(model);
            //var model = new AdminPanelModel(_context);
            //await model.OnGetAsync();

            //if (model.Tour == null)
            //{
            //    // Handle the error here.
            //}

            //return View(model);
            //var model = new AdminPanelModel(_context);
            //if (model == null)
            //{
            //    // Handle the error here.
            //}

            //await model.OnGetAsync();

            //return View(model);
            var model = new AdminPanelModel(_context);
            if (model == null)
            {
                // Обрабатываем ошибку здесь, например, возвращаем сообщение об ошибке или перенаправляем на другую страницу.
                return NotFound();
            }

            await model.OnGetAsync();

            return View(model);
        }
  
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TourList()
        {
            var tours = _context.Tour.ToList();
            return View(tours);
        }

        public IActionResult UserList()
        {
            var users = _context.User.ToList();
            return View(users);
        }

        public IActionResult AddTour()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTour(Tour tour)
        {
            if (ModelState.IsValid)
            {
                _context.Tour.Add(tour);
                _context.SaveChanges();
                return RedirectToAction("TourList");
            }
            return View(tour);
        }

        public IActionResult EditTour(int id)
        {
            var tour = _context.Tour.Find(id);
            if (tour == null)
            {
                return NotFound();
            }
            return View(tour);
        }

        [HttpPost]
        public IActionResult EditTour(int id, Tour tour)
        {
            if (id != tour.id_tour)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Tour.Update(tour);
                _context.SaveChanges();
                return RedirectToAction("TourList");
            }
            return View(tour);
        }


        // Действие для удаления тура
        public IActionResult DeleteTour(int id)
        {
            var tour = _context.Tour.Find(id);
            if (tour == null)
            {
                return NotFound();
            }
            _context.Tour.Remove(tour);
            _context.SaveChanges();
            return RedirectToAction("TourList");
        }

    }
}
