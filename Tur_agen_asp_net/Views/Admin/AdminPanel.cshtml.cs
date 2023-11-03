using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tur_agen_asp_net.Models;

namespace Tur_agen_asp_net.Views.Admin
{
    public class AdminPanelModel : PageModel
    {
        //private readonly ApDbContext _context;

        //public AdminPanelModel(ApDbContext context)
        //{
        //    _context = context;
        //}

        //public IList<Tour> Tour { get;set; } = default!;

        //public async Task OnGetAsync()
        //{
        //    //if (_context.Tour != null)
        //    //{
        //    //    Tour = await _context.Tour.ToListAsync();
        //    //}
        //    if (_context.Tour != null)
        //    {
        //        Tour = await _context.Tour.ToListAsync();
        //    }
        //    else
        //    {
        //        // Handle the error here.
        //    }
        // }

        private readonly ApDbContext _context;

        public AdminPanelModel(ApDbContext context)
        {
            _context = context;
        }

        public IList<Tour> Tour { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Tour.Count() == 0)
            {
                // Handle the error here.
            }

            Tour = await _context.Tour.ToListAsync();
        }

    }
}
