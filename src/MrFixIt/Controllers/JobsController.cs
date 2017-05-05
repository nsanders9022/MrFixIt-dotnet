using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MrFixIt.Models;
using Microsoft.EntityFrameworkCore;


namespace MrFixIt.Controllers
{
    public class JobsController : Controller
    {
        private MrFixItContext db = new MrFixItContext();

        //Displays Index page
        public IActionResult Index()
        {
            return View(db.Jobs.Include(workers => workers.Worker).ToList());
        }

        //Displays Create page
        public IActionResult Create()
        {
            return View();
        }

        //Posts a new job to the database
        [HttpPost]
        public IActionResult Create(Job job)
        {
            db.Jobs.Add(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Displays Claim partial
        public IActionResult Claim(int id)
        {
            var thisJob = db.Jobs.FirstOrDefault(jobs => jobs.JobId == id);
            return View(thisJob);
        }

        //Posts worker who claimed job to database
        [HttpPost]
        public IActionResult Claim(Job job)
        {
            job.Worker = db.Workers.FirstOrDefault(jobs => jobs.UserName == User.Identity.Name);
            db.Entry(job).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Displays activate parital and posts pendings change to database
        public IActionResult Activate(int id)
        {
            var thisJob = db.Jobs.FirstOrDefault(jobs => jobs.JobId == id);
            thisJob.Pending = true;
            db.Entry(thisJob).State = EntityState.Modified;
            db.SaveChanges();
            Console.WriteLine(thisJob.Pending);
            return View(thisJob);
        }

        //Displays complete partial and posts completed change to database
        public IActionResult Complete(int id)
        {
            var thisJob = db.Jobs.FirstOrDefault(jobs => jobs.JobId == id);
            thisJob.Completed = true;
            db.Entry(thisJob).State = EntityState.Modified;
            db.SaveChanges();
            Console.WriteLine(thisJob.Pending);
            return View(thisJob);
        }
    }
}
