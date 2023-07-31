using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class ClientController : Controller
  {
    private readonly HairSalonContext _db;

    public ClientController(HairSalonContext db)
    {
      _db = db;
    }
    
    public ActionResult Create()
    {
      ViewBag.stylist_id = new SelectList(_db.Stylist, "stylist_id", "stylist_name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Client client)
    {
      if (client.stylist_id == 0)
      {
        return RedirectToAction("Create");
      }
      _db.Client.Add(client);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Client thisClient = _db.Client.Include(client => client.Stylist).FirstOrDefault(client => client.client_id ==id);
      return View(thisClient);
    }

    public ActionResult Edit(int id)
    {
      Client thisClient = _db.Client.FirstOrDefault(client => client.client_id == id);
      ViewBag.stylist_id = new SelectList(_db.Stylist, "stylist_id", "stylist_name");
      return View(thisClient);
    }

    [HttpPost]
    public ActionResult Edit(Client client)
    {
      _db.Client.Update(client);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Client thisClient = _db.Client.FirstOrDefault(client => client.client_id == id);
      return View(thisClient);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Client thisClient = _db.Client.FirstOrDefault(client => client.client_id == id);
      _db.Client.Remove(thisClient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}