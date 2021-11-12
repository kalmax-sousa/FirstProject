using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirstProject.Data;
using Model.Entities;

namespace WebApp.Controllers
{
    public class Clients2Controller : Controller
    {
        private readonly ApplicationContext _context;

        public Clients2Controller(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Clients2
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clients.ToListAsync());
        }

    }
}
