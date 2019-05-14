using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;
using LibraryData;
using LibraryData.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Authorize]
    public class PatronController : Controller
    {
        private IPatron _patron;

        public PatronController(IPatron patron)
        {
            _patron = patron;
        }

        public IActionResult Index()
        {
            var allPatrons = _patron.GetAll();

            var mappedPatrons = allPatrons.Select(p => new PatronDetailVM
            {
                ID = p.ID,
                FirstName = p.FirstName,
                LastName = p.LastName,

            }).ToList();

            var model = new ListPatron()
            {
                Patrons = mappedPatrons
            };
        
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var patron = _patron.Get(id);

            var model = new PatronDetailVM()
            {
                ID = patron.ID,
                FirstName = patron.FirstName,
                LastName = patron.LastName,
                Since = patron.Created,
                CheckoutsHistory = _patron.GetCheckoutHistory(id),
                Checkouts = _patron.GetCheckouts(id).ToList() ?? new List<Checkout>()
            };

            return View(model);
        }

        public IActionResult Remove(int id)
        {
            _patron.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            Patron patron = new Patron();
            return View(patron);
        }

        [HttpPost]
        public IActionResult Add(Patron patron)
        {
            Patron newPatron = new Patron()
            {
                FirstName = patron.FirstName,
                LastName = patron.LastName,
                DataOfBirth = patron.DataOfBirth,
                Created = DateTime.Now
            };
            if (ModelState.IsValid)
            {
                _patron.Add(newPatron);      
                return RedirectToAction("Index");
            }
            return View(newPatron);
        }

    }
}