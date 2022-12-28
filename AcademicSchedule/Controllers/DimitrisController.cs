using AcademicSchedule.logic;
using AcademicSchedule.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicSchedule.Controllers
{
    public class DimitrisController : Controller
    {
        protected CDimitrisDM model = null;
        public IActionResult Index()
        {
           model = new CDimitrisDM();

            model.Load();

            return View(model);
        }

        public IActionResult Dimitris(string p_sCode)
        {
            model = new CDimitrisDM();
            model.Load();


            List<CDimitris> oFoundDimitris = model.Dimitriss.Where(x => x.Code == p_sCode).ToList();
            return RedirectToAction("Index");
        }
    }
}
