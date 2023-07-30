using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class StylistController : Controller
  {
    private readonly HairSalonContext _db;

    public StylistController(HairSalonContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Stylist> model = _db.Stylist.ToList();
      return View(model);
    }
    
    public ActionResult Create ()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create (Stylist stylist)
    {
      _db.Stylist.Add(stylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult stylist_details(int id)
    {
      Stylist thisStylist = _db.Stylist.Include(stylist_details => stylist.Client).FirstOrDefault(Stylist => stylist_details.stylist_id == id);
      return View(thisStylist);
    }

    public ActionResult (int id)
    {
      Stylist thisStylist = _db.Stylist.FirstOrDefault(stylist_details => stylist_details.stylist_id == id);
      return View(thisStylist);
    }

    [HttpPost]
    public ActionResult Edit(Stylist stylist)
    {
      _db.Stylist.Update(stylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Stylist thisStylist = _db.Stylist.FirstOrDefault(Stylist => Stylist.stylist_id == id);
      return View(thisStylist);
    }

    [HttpPst, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Stylist thisStylist = _db.Stylist.FirstOrDefault(Stylist => Stylist.stylist_id == id);
      _db.Stylist.Remove(thisStylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}