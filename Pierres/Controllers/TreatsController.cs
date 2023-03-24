using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pierres.Models;
using System.Threading.Tasks;
using Pierres.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Pierres.Controllers
{
  //[Authorize]
  public class TreatsController : Controller
  {
    private readonly PierresContext _db;

    public TreatsController(PierresContext db)
    {
      _db = db;
    }

     public ActionResult Index()
    {
      List<Treat> model = _db.Treats
                              .Include(treat => treat.Flavor)
                              .ToList();
      return View(model);
    }

    public ActionResult Create() 
    { 
      ViewBag.Flavors = _db.Flavors.ToList();
      return View();
    }

    [HttpPost]
    public ActionResult Create(string treatType, List<int> wutFlavors)
    {
      Treat newTreat = new Treat();
      newTreat.TreatType = treatType;
      _db.Treats.Add(newTreat);
      _db.SaveChanges();

      if(wutFlavors.Count != 0)
      {
        foreach(int flavor in wutFlavors)
        {
          #nullable enable
          TreatFlavor? treat = _db.TreatFlavors.FirstOrDefault(treat => (treat.FlavorId== flavor && treat.TreatId == newTreat.TreatId));
          #nullable disable
          if(treat != null)
          {
            _db.TreatFlavors.Add(new TreatFlavor() { TreatId = newTreat.TreatId, FlavorId = flavor });
            _db.SaveChanges();
          }
        }
      }
    }

    public ActionResult Details(int id)
    {
      Treat thisTreat = _db.Treats
        .Include(treat => treat.JoinTreat)
        .ThenInclude(join => join.Flavor)
        .FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }

    public ActionResult Edit(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorType");
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult Edit(Treat treat)
    {
      _db.Treats.Update(treat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      _db.Treats.Remove(thisTreat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddFLavor(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treats => treats.TreatId == id);
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorType");
      return View(thisTreat);
    }

    [HttpPost]
    public ActionResult AddFlavor(Treat treat, int FlavorId)
    {
      #nullable enable
      TreatFlavor? joinEntity = _db.TreatFlavors.FirstOrDefault(join => (join.FlavorId == flavorId && join.TreatId == treat.TreatId));
      #nullable disable
      if (joinEntity == null && flavorId != 0)
      {
        _db.TreatFlavors.Add(new TreatFlavor() { FlavorId = flavorId, TreatId = treat.TreatId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = treat.TreatId });
    }

    [HttpPost]
    public ActionResult DeleteJoinTreat (int joinId)
    {
      TreatFlavor joinEntry = _db.TreatFlavors.FirstOrDefault(entry => entry.TreatFlavorId == joinId);
      _db.TreatFlavors.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
