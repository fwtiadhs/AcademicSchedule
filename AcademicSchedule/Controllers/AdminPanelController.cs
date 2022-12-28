using AcademicSchedule.logic;
using AcademicSchedule.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicSchedule.Controllers
{
    public class AdminPanelController : Controller
    {
        protected CAdminPanelDM model = null;
        public IActionResult Index()
        {
            model = new CAdminPanelDM();

            model.Load();

            return View(model);
        }
        public IActionResult AdminPanel(byte p_sSem)
        {
            model = new CAdminPanelDM();
            model.Load();


            List <CAdminPanel> oFoundAdmin = model.AdminPanel.Where(x => x.Semester == p_sSem).ToList();
            return RedirectToAction("Index");

            if(oFoundAdmin.Count == p_sSem)
            {
                oFoundAdmin[p_sSem].Name += "Μαθημα";
            }
        }
    }
}
