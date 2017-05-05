using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MrFixIt.Models;
using Microsoft.EntityFrameworkCore;

namespace MrFixIt.Controllers
{
    public class WorkersController : Controller
    {
        private MrFixItContext db = new MrFixItContext();

        //Displays index page with list of jobs
        public IActionResult Index()
        {
            //finds the logged in worker in the database and checks to see if they have a Worker user name yet
            var thisWorker = db.Workers.Include(workers =>workers.Jobs).FirstOrDefault(users => users.UserName == User.Identity.Name);
            //if they do have a worker account they see the index
            if (thisWorker != null)
            {
                return View(thisWorker);
            }
            //if they have not finished their profile and do not have a worker user name they are directed to the create page
            else
            {
                return RedirectToAction("Create");
            }
        }

        //Displays create worker page
        public IActionResult Create()
        {
            return View();
        }

        //Adds new worker to the database
        [HttpPost]
        public IActionResult Create(Worker worker)
        {
            //sets the worker user name to the same name as the user name signed in using Identity
            worker.UserName = User.Identity.Name;
            worker.Available = true;
            db.Workers.Add(worker); 
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
