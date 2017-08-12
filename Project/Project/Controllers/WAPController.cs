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
    public class WAPController : Controller
    {
        // new instance of database
        private FinalProjectEntities db = new FinalProjectEntities();

        // GET: wap
        public ActionResult Index()
        {
            DbSet<wap> WToFilter = db.waps;
            string filterID = "";
            string filterIP = "";
            string filterLoc = "";
            string filterIns = "";
            string filterAct = "";

            if (Session["id"] != null && !String.IsNullOrWhiteSpace((string)Session["id"]))
            {
                filterID = (string)Session["id"];
            }
            if (Session["ip"] != null && !String.IsNullOrWhiteSpace((string)Session["ip"]))
            {
                filterIP = (string)Session["ip"];
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
            ViewBag.filterIP = filterIP;
            ViewBag.filterLoc = filterLoc;
            ViewBag.filterIns = filterIns;
            ViewBag.filterAct = filterAct;


            IEnumerable<wap> filtered = WToFilter.Where(w => w.id.ToString() == filterID &&
                                                                        w.ip.ToString() == filterIP &&
                                                                        w.location.Contains(filterLoc) &&
                                                                        w.installedOn.ToString() == filterIns &&
                                                                        w.active.ToString() == filterAct);
            IEnumerable<wap> finalFiltered = filtered.ToList();
            //return View(finalFiltered);

            // This line returns the entire db entry ignoring filter since filtering isnt working.
            return View(db.waps.ToList());
        }

        // GET: wap/details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            wap w = db.waps.Find(Convert.ToInt32(id));
            if (w == null)
            {
                return HttpNotFound();
            }
            return View(w);
        }

        // GET: wap/create
        public ActionResult Create()
        {
            return View();
        }

        // POST: wap/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,os,location,installedOn,active")] wap wap)
        {
            if (ModelState.IsValid)
            {
                // Add new device to devices lsit with the information gathered from wap view
                db.devices.Add(new device()
                {
                    id = wap.id,
                    type = "WAP",
                    location = wap.location,
                    installedOn = Convert.ToDateTime(wap.installedOn),
                    active = wap.active
                });

                // Save addition
                db.SaveChanges();

                // Add device to wap relation and save
                db.waps.Add(wap);
                db.SaveChanges();

                // Return to index page
                return RedirectToAction("Index");
            }
            // Returns view
            return View(wap);
        }

        // GET: wap/Edit/5
        public ActionResult Edit(string id)
        {
            // Create wap object and populate with data from item in relation matching given ID
            wap wap = db.waps.Find(Convert.ToInt32(id));

            // Error handling
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (wap == null)
            {
                return HttpNotFound();
            }

            // Return to view
            return View(wap);
        }

        // POST: wap/edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OS,Location,InstalledOn,Active")] wap wap)
        {
            if (ModelState.IsValid)
            {
                // Get old device info before deleting it
                var oldDev = db.devices.Find(Convert.ToInt32(wap.id));
                string oldType = oldDev.type;
                // delete old device
                db.devices.Remove(oldDev);

                // Modify wap row with new info gathered from edit view
                db.Entry(wap).State = EntityState.Modified;
                db.SaveChanges();

                // Add new device with updated info from wap row
                db.devices.Add(new device()
                {
                    id = wap.id,
                    type = oldType,
                    location = wap.location,
                    installedOn = Convert.ToDateTime(wap.installedOn),
                    active = wap.active
                });

                // Save new information.
                db.SaveChanges();

                // Return to index
                return RedirectToAction("Index");
            }

            // Return view
            return View(wap);
        }

        // GET: wap/delete/5
        public ActionResult Delete(string id)
        {

            // Error handling
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Create new wap object and populate with data from db
            wap wap = db.waps.Find(Convert.ToInt32(id));

            // More error handling
            if (wap == null)
            {
                return HttpNotFound();
            }

            // Return view
            return View(wap);
        }

        // POST: wap/delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            // Create new wap and device objects and populate with db data
            wap wap = db.waps.Find(Convert.ToInt32(id));
            device device = db.devices.Find(Convert.ToInt32(id));

            // Remove wap
            db.waps.Remove(wap);
            db.SaveChanges();

            // Remove device
            db.devices.Remove(device);
            db.SaveChanges();

            // Return to index
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            // Garbage collection
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // Filters
        [HttpPost, ActionName("Filter")]
        public ActionResult Filter()
        {
            string id = Request.Form.Get("id");
            string ip = Request.Form.Get("ip");
            string loc = Request.Form.Get("location");
            string ins = Request.Form.Get("installedOn");
            string act = Request.Form.Get("active");

            Session["id"] = id;
            Session["ip"] = ip;
            Session["location"] = loc;
            Session["installedOn"] = ins;
            Session["active"] = act;

            return RedirectToAction("Index");
        }
    }
}