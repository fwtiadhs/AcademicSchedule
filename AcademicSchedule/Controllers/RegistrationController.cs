using AcademicSchedule.logic;
using AcademicSchedule.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AcademicSchedule.Controllers
{
    public class RegistrationController : Controller
    {
        protected CRegistrationDM model = null;
        public IActionResult Index()
        {
            model = new CRegistrationDM();

            model.Load();

            return View(model);

        }
        public IActionResult TestView(byte p_sSem)
        {
            model = new CRegistrationDM();
            model.Load();


            List<CRegistration> oFoundRegistration = model.Registration.Where(x => x.Semester == p_sSem).ToList();
            
            var oGroups = model.Registration.GroupBy(x => x.Semester).ToList();
            foreach(var oGroup in oGroups)
            {
                Debug.WriteLine(oGroup.Key);
                    foreach(var oRow in oGroup.ToList())
                {
                    Debug.WriteLine(oRow.Name);
                }
            }
            return RedirectToAction("Index");
        }

    }
}
