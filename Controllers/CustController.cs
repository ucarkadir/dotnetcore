using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Customer.Services;
using Customer.Models;

namespace Customer.Controllers
{
 
 // CustController => ICustService : Bağlı (Dependency injection) hale getirdik.
   public class CustController : Controller
   {
       
               // ICustService referenasını(pointer) tutar
        private readonly ICustService _custService;

        public CustController(ICustService custService)
        {
            _custService = custService;
        }

                //public IActionResult Index()
        public async Task<IActionResult> Index()
        {
            var custs = await _custService.GetCustItemsAsync();


            var model = new CustViewModel()
            {
                Custs = custs
            };

            return View(model);
        }

       
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCust(Cust newCust)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var successful = await _custService.AddCustAsync(newCust);
            if (!successful) 
            {
                return BadRequest("Müşteri eklenemedi.");
            }

            return RedirectToAction("Index");
        }


        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DelCust(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var successful = await _custService.DelCustAsync(id);
            if (!successful)
            {
                return BadRequest("Silme işlemi yapılamadı.");
            }

            return RedirectToAction("Index");
        }


   }
}