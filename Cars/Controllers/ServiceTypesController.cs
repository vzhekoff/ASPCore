using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cars.Data;
using Cars.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Controllers
{
    public class ServiceTypesController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ApplicationDbContext dbc;

        /// <summary>
        /// 
        /// </summary>
        public ServiceTypesController(ApplicationDbContext dbcArg)
        {
            dbc = dbcArg;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing && (null != dbc))
            {
                dbc.Dispose();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Create (ServiceType serviceType)
        {
            if (ModelState.IsValid)
            {
                dbc.Add(serviceType);

                await dbc.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(serviceType);
        }

        public IActionResult Index()
        {
            return View(dbc.ServiceTypes.ToList());
        }
    }
}