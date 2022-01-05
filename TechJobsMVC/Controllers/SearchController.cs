using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view. 
      [HttpPost]
        public IActionResult Results(string column, string searchTerm)
        {
            List<Job> jobs;
            if (searchTerm == null || searchTerm.Equals(""))
            { 
                jobs = JobData.FindAll();
                ViewBag.title_results = "All Jobs";
               /* ViewBag.columns = ListController.ColumnChoices;*/
                



            }
          
            else
            {
                
                jobs = JobData.FindByColumnAndValue(column, searchTerm );
                ViewBag.title_results = "Jobs with " + columnChoices[column] + ": " + searchTerm;
               /* ViewBag.columns = ListController.ColumnChoices;*/

             }
   
           
            ViewBag.jobs_results = jobs;

            return View("index");

        }
        /*  ViewBag.results = jobs;
         public IActionResult Jobs(string column, string value)
      {
          List<Job> jobs;
          if (column.ToLower().Equals("all"))
          {
              jobs = JobData.FindAll();
              ViewBag.title = "All Jobs";
          }
          else
          {
              jobs = JobData.FindByColumnAndValue(column, value);
              ViewBag.title = "Jobs with " + ColumnChoices[column] + ": " + value;
          }
          ViewBag.jobs = jobs;
        ViewBag.columns = ListController.ColumnChoices;
          return View();
      }
         */



    }
}
