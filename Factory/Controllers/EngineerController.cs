using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
    public class EngineersController : Controller
    {
        private readonly FactoryContext _db;

        public EngineersController(FactoryContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Engineer> model = _db.Engineers;
                // .Include(engineer => engineer.Machine)
                // .ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Engineer engineer)
        {
            // if (engineer.MachineId == 0)
            // {
            //     return RedirectToAction("Create");
            // }
            _db.Engineers.Add(engineer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Engineer thisEngineer = _db.Engineers
                .Include(engineer => engineer.Machine)
                .FirstOrDefault(engineer => engineer.EngineerId == id);
            return View(thisEngineer);
        }

        

        // public ActionResult Edit(int id)
        // {
        //     Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
        //     ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
        //     return View(thisEngineer);
        // }

        // [HttpPost]
        // public ActionResult Edit(Engineer engineer)
        // {
        //     _db.Engineers.Update(engineer);
        //     _db.SaveChanges();
        //     return RedirectToAction("Index");
        // }

        // public ActionResult Delete(int id)
        // {
        //     Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
        //     return View(thisEngineer);
        // }

        // [HttpPost, ActionName("Delete")]
        // public ActionResult DeleteConfirmed(int id)
        // {
        //     Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
        //     _db.Engineers.Remove(thisEngineer);
        //     _db.SaveChanges();
        //     return RedirectToAction("Index");
        // }
    }
}