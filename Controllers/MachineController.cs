using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class MachinesController : Controller
  {
    private readonly FactoryContext _db;

    public MachinesController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      IEnumerable<Machine> sortedMachines = _db.Machines.OrderBy(machine => machine.MachineName);
      return View(sortedMachines.ToList());
    }

    public ActionResult Create()
    {
        ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
    return View();
    }

    [HttpPost]
    public ActionResult Create(Machine machine, int EngineerId)
    {
      _db.Machines.Add(machine);
      _db.SaveChanges();
      if (EngineerId !=0)
      {
        _db.EngineerMachines.Add(new EngineerMachine() { EngineerId = EngineerId, MachineId = machine.MachineId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  public ActionResult Details(int id)
{
    var thisMachine = _db.Machines
        .Include(machine => machine.JoinEntities)
            .ThenInclude(join => join.Engineer) // Use ThenInclude to include the Engineer entities
        .FirstOrDefault(machine => machine.MachineId == id);

    return View(thisMachine);
}


    public ActionResult Edit(int id)
    {
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Edit (Machine machine)
    {
      _db.Entry(machine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = machine.MachineId });
    }

     public ActionResult AddEngineer(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Name");
      return View(thisMachine);
    }
    
    [HttpPost]
    public ActionResult AddEngineer(Machine machine, int EngineerId)
    {
      if (EngineerId != 0)
      {
        _db.EngineerMachines.Add(new EngineerMachine() { EngineerId = EngineerId, MachineId = machine.MachineId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }
    

    public ActionResult Delete(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost, ActionName("Delete")]

    public ActionResult DeleteConfirmed(int id)
    {
      Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]

    public ActionResult DeleteEngineer(int joinId)
    {
      var joinEntry = _db.EngineerMachines.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
      _db.EngineerMachines.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = joinEntry.MachineId });
    }

  }
}