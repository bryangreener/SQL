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
    public class SwitchController : Controller
    {
        // new instance of database
        private FinalProjectEntities db = new FinalProjectEntities();

        // GET: switch
        public ActionResult Index()
        {
            DbSet<@switch> SWToFilter = db.switches;
            string filterID = "";
            string filterType = "";
            string filterIP = "";
            string filterLoc = "";
            string filterIns = "";
            string filterAct = "";

            if (Session["id"] != null && !String.IsNullOrWhiteSpace((string)Session["id"]))
            {
                filterID = (string)Session["id"];
            }
            if (Session["type"] != null && !String.IsNullOrWhiteSpace((string)Session["type"]))
            {
                filterType = (string)Session["type"];
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
            ViewBag.filterType = filterType;
            ViewBag.filterIP = filterIP;
            ViewBag.filterLoc = filterLoc;
            ViewBag.filterIns = filterIns;
            ViewBag.filterAct = filterAct;


            IEnumerable<@switch> filtered = SWToFilter.Where(sw => sw.id.ToString() == filterID &&
                                                                        sw.type.ToString() == filterType &&
                                                                        sw.ip.ToString() == filterIP &&
                                                                        sw.location.Contains(filterLoc) &&
                                                                        sw.installedOn.ToString() == filterIns &&
                                                                        sw.active.ToString() == filterAct);
            IEnumerable<@switch> finalFiltered = filtered.ToList();
            //return View(finalFiltered);

            // This line returns the entire db entry ignoring filter since filtering isnt working.
            return View(db.switches.ToList());
        }

        // GET: switch/details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            @switch sw = db.switches.Find(Convert.ToInt32(id));
            if (sw == null)
            {
                return HttpNotFound();
            }
            return View(sw);
        }

        // GET: switch/create
        public ActionResult Create()
        {
            return View();
        }

        // POST: switch/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,os,location,installedOn,active")] @switch sw)
        {
            if (ModelState.IsValid)
            {
                // Add new device to devices lsit with the information gathered from switch view
                db.devices.Add(new device()
                {
                    id = sw.id,
                    type = "Switch",
                    location = sw.location,
                    installedOn = Convert.ToDateTime(sw.installedOn),
                    active = sw.active
                });

                // Save addition
                db.SaveChanges();

                // Add device to switch relation and save
                db.switches.Add(sw);
                db.SaveChanges();

                // Return to index page
                return RedirectToAction("Index");
            }
            // Returns view
            return View(sw);
        }

        // GET: switch/Edit/5
        public ActionResult Edit(string id)
        {
            // Create switch object and populate with data from item in relation matching given ID
            @switch sw = db.switches.Find(Convert.ToInt32(id));

            // Error handling
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (sw == null)
            {
                return HttpNotFound();
            }

            // Return to view
            return View(sw);
        }

        // POST: switch/edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OS,Location,InstalledOn,Active")] @switch sw)
        {
            if (ModelState.IsValid)
            {
                // Get old device info before deleting it
                var oldDev = db.devices.Find(Convert.ToInt32(sw.id));
                string oldType = oldDev.type;
                // delete old device
                db.devices.Remove(oldDev);

                // Modify switch row with new info gathered from edit view
                db.Entry(sw).State = EntityState.Modified;
                db.SaveChanges();

                // Add new device with updated info from switch row
                db.devices.Add(new device()
                {
                    id = sw.id,
                    type = oldType,
                    location = sw.location,
                    installedOn = Convert.ToDateTime(sw.installedOn),
                    active = sw.active
                });

                // Save new information.
                db.SaveChanges();

                // Return to index
                return RedirectToAction("Index");
            }

            // Return view
            return View(sw);
        }

        // GET: switch/delete/5
        public ActionResult Delete(string id)
        {

            // Error handling
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Create new switch object and populate with data from db
            @switch sw = db.switches.Find(Convert.ToInt32(id));

            // More error handling
            if (sw == null)
            {
                return HttpNotFound();
            }

            // Return view
            return View(sw);
        }

        // POST: switch/delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            // Create new switch and device objects and populate with db data
            @switch sw = db.switches.Find(Convert.ToInt32(id));
            device device = db.devices.Find(Convert.ToInt32(id));

            // Remove switch
            db.switches.Remove(sw);
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
            string type = Request.Form.Get("type");
            string ip = Request.Form.Get("ip");
            string loc = Request.Form.Get("location");
            string ins = Request.Form.Get("installedOn");
            string act = Request.Form.Get("active");

            Session["id"] = id;
            Session["type"] = type;
            Session["ip"] = ip;
            Session["location"] = loc;
            Session["installedOn"] = ins;
            Session["active"] = act;

            return RedirectToAction("Index");
        }
    }
}