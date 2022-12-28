using AcademicSchedule.logic;
using AcademicSchedule.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademicSchedule.Controllers
{
    public class ExampleController : Controller
    {
        protected CExampleDM model = null;

        // -----------------------------------------------------------------------------------------------------------------------------         
        // GET: ExampleController
        public IActionResult Index()   
        {
            // [PANTELIS]: Remember that HTTP is session-less. Each time an action is called the protected field model will be null
            model = new CExampleDM();
            model.Load();

            // [PANTELIS] The controller gives the model to the view, in order to render some information in the UI --->
            return View(model);
        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        // GET: ExampleController/Clone
        /* [PANTELIS] 
         * For the action name you must use the same as in asp-action=""
         * For any parameters you must use the same name as in asp-route-{parameter name}
         */
        public IActionResult Clone(string p_sCode)   
        {
            // [PANTELIS]: Remember that HTTP is session-less. Each time an action is called the protected field model will be null
            model = new CExampleDM();
            model.Load(); 

            // [PANTELIS]: Some LINQ with the lambda expression to search the list using the property Code of the objects for the value p_sCode
            // The following logic is here only for the sake of this example. The good practice is to create a method InsertClone() in the model,
            // do the search-if-insert logic and return a boolean true/false for the success
            List<CExample> oFoundExample = model.Examples.Where(x => x.Code == p_sCode).ToList();

            if (oFoundExample.Count == 1)
            {
                oFoundExample[0].Description += " (Αντίγραφο)";
                model.Insert(oFoundExample[0]);
                // [PANTELIS]: Show the Index view after the successfull completion of this controller action
                return RedirectToAction("Index");
            }
            else
                // [PANTELIS]: Otherwise show a view with some message 
                return RedirectToAction("CloneFailed");
        }
        // -----------------------------------------------------------------------------------------------------------------------------         
        // [PANTELIS]: For RedirectToAction to work we need the corresponding action, that is only showing the view.
        public IActionResult CloneFailed()
        {
            return View();
        }
        // -----------------------------------------------------------------------------------------------------------------------------         
    }
}
