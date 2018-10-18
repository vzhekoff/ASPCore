using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cars.Data;
using Cars.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpPost]
        [AutoValidateAntiforgeryToken]
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (null == id)
            {
                return NotFound();
            }

            var serviceType = await dbc.ServiceTypes.SingleOrDefaultAsync(s => s.Id == id);

            if (null == serviceType)
            {
                return NotFound();
            }

            return View(serviceType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (null == id)
            {
                return NotFound();
            }

            var serviceType = await dbc.ServiceTypes.SingleOrDefaultAsync(s => s.Id == id);

            if (null == serviceType)
            {
                return NotFound();
            }

            return View(serviceType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, ServiceType serviceType)
        {
            if (id != serviceType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                dbc.Update(serviceType);
                await dbc.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(serviceType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (null == id)
            {
                return NotFound();
            }

            var serviceType = await dbc.ServiceTypes.SingleOrDefaultAsync(s => s.Id == id);

            if (null == serviceType)
            {
                return NotFound();
            }

            return View(serviceType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var serviceType = await dbc.ServiceTypes.SingleOrDefaultAsync(s => s.Id == id);

            if (null == serviceType)
            {
                return NotFound();
            }

            dbc.Remove(serviceType);
            await dbc.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View(dbc.ServiceTypes.ToList());
        }
    }
}