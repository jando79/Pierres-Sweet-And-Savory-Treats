using Microsoft.AspNetCore.Mvc;
using Pierres.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pierres.Controllers
{
    public class HomeController : Controller
    {
      private readonly PierresContext _db;

      public HomeController(PierresContext db)
      {
        _db = db;
      }

      [HttpGet("/")]
      public ActionResult Index()
      { 
        Treat[] treats = _db.Treats.ToArray();
        Flavor[] flavors = _db.Flavors.ToArray();
        Dictionary<string,object[]> model = new Dictionary<string, object[]>();
        model.Add("treats", treats);
        model.Add("flavors", flavors);
        return View(model);
      }
    }
}