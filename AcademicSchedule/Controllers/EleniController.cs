using AcademicSchedule.logic;
using AcademicSchedule.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace AcademicSchedule.Controllers
{
    public class EleniController : Controller
    {
        protected EleniDM model = null;
        public IActionResult Index()
        {
            model = new EleniDM();

            model.Load();

            return View(model);
        }
    }
}
