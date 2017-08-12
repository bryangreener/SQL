using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using Project.Models;
using System.Data.Entity;

namespace Project.Controllers
{
    public class ComputerController : Controller
    {
        // new instance of database
        private FinalProjectEntities db = new FinalProjectEntities();
        
        // GET: Computer
        /*public ActionResult Index()
        {
            DbSet<computer> CompToFilter = db.computers;
            string filterID = "";
            string filterOS = "";
            string filterLoc = "";
            string filterIns = "";
            string filterAct = "";

            if (Session["id"] != null && !String.IsNullOrWhiteSpace((string)Session["id"]))
            {
                filterID = (string)Session["id"];
            }
            if (Session["os"] != null && !String.IsNullOrWhiteSpace((string)Session["os"]))
            {
                filterOS = (string)Session["os"];
            }
            if (Session["location"] != null && !String.IsNullOrWhiteSpace((string)Session["location"]))
            {
                filterLoc = (string)Session["location"];
            }
            if (Session["installedOn"] != null && !String.IsNullOrWhiteSpace((string)Session["installedOn"]))
            {
                filterIns = (string)Session["installedOn"];
            }
            if (Session["active"] != null && !String.IsNullOrWhiteSpace((string)Session["active"]))
            {
                filterAct = (string)Session["active"];
            }

            ViewBag.filterID = filterID;
            ViewBag.filterOS = filterOS;
            ViewBag.filterLoc = filterLoc;
            ViewBag.filterIns = filterIns;
            ViewBag.filterAct = filterAct;


            IEnumerable<computer> filtered = CompToFilter.Where(comp => comp.id.ToString() == filterID &&
                                                                        comp.os.Contains(filterOS) &&
                                                                        comp.location.Contains(filterLoc) &&
                                                                        comp.installedOn.ToString() == filterIns &&
                                                                        comp.active.ToString() == filterAct);
            IEnumerable<computer> finalFiltered = filtered.ToList();

            return View(finalFiltered);
        }*/

        public ActionResult Index()
        {
            return View(db.computers.ToList());
        }

        // GET: computer/details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            computer comp = db.computers.Find(id);
            if(comp == null)
            {
                return HttpNotFound();
            }
            return View(comp);
        }

        // GET: computer/create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Computers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,os,location,installedOn,active")] computer computer)
        {
            if(ModelState.IsValid)
            {
                /*
                device device = new device();
                device.id = computer.id;
                device.type = "Computer";
                device.location = computer.location;
                device.installedOn = Convert.ToDateTime(computer.installedOn);
                device.active = computer.active;*/
                db.devices.Add(new device()
                {
                    id = computer.id,
                    type = "Computer",
                    location = computer.location,
                    installedOn = Convert.ToDateTime(computer.installedOn),
                    active = computer.active
                });
                db.SaveChanges();
                //string device = $"{computer.id},Computer,{computer.location},{computer.installedOn},{computer.active}";
                db.computers.Add(computer);
                //db.Entry(computer).State = EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(computer);
        }

        // GET: computer/Edit/5
        public ActionResult Edit(string id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            computer computer = db.computers.Find(id.ToString());
            if(computer == null)
            {
                return HttpNotFound();
            }
            return View(computer);
        }

        // POST: computer/edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OS,Location,InstalledOn,Active")] computer computer)
        {
            if(ModelState.IsValid)
            {
                db.Entry(computer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(computer);
        }

        // GET: computer/delete/5
        public ActionResult Delete(string id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            computer computer = db.computers.Find(Convert.ToInt32(id));
            if(computer == null)
            {
                return HttpNotFound();
            }
            return View(computer);
        }

        // POST: computer/delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            computer computer = db.computers.Find(Convert.ToInt32(id));
            db.computers.Remove(computer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // Filters
        [HttpPost,ActionName("Filter")]
        public ActionResult Filter()
        {
            string id = Request.Form.Get("id");
            string os = Request.Form.Get("os");
            string loc = Request.Form.Get("location");
            string ins = Request.Form.Get("installedOn");
            string act = Request.Form.Get("active");

            Session["id"] = id;
            Session["os"] = os;
            Session["location"] = loc;
            Session["installedOn"] = ins;
            Session["active"] = act;

            return RedirectToAction("Index");
        }
    }
}