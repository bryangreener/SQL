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
    public class RouterController : Controller
    {
        // new instance of database
        private FinalProjectEntities db = new FinalProjectEntities();

        // GET: router
        public ActionResult Index()
        {
            DbSet<router> RToFilter = db.routers;
            string filterID = "";
            string filterIntIP = "";
            string filterExtIP = "";
            string filterDNS = "";
            string filterNetwork = "";
            string filterLoc = "";
            string filterIns = "";
            string filterAct = "";

            if (Session["id"] != null && !String.IsNullOrWhiteSpace((string)Session["id"]))
            {
                filterID = (string)Session["id"];
            }
            if (Session["intIP"] != null && !String.IsNullOrWhiteSpace((string)Session["intIP"]))
            {
                filterIntIP = (string)Session["intIP"];
            }
            if (Session["extIP"] != null && !String.IsNullOrWhiteSpace((string)Session["extIP"]))
            {
                filterExtIP = (string)Session["extIP"];
            }
            if (Session["dns"] != null && !String.IsNullOrWhiteSpace((string)Session["dns"]))
            {
                filterDNS = (string)Session["dns"];
            }
            if (Session["network"] != null && !String.IsNullOrWhiteSpace((string)Session["network"]))
            {
                filterNetwork = (string)Session["network"];
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
            ViewBag.filterIntIP = filterIntIP;
            ViewBag.filterExtIP = filterExtIP;
            ViewBag.filterDNS = filterDNS;
            ViewBag.filterNetwork = filterNetwork;
            ViewBag.filterLoc = filterLoc;
            ViewBag.filterIns = filterIns;
            ViewBag.filterAct = filterAct;


            IEnumerable<router> filtered = RToFilter.Where(r => r.id.ToString() == filterID &&
                                                                        r.intIP.ToString() == filterIntIP &&
                                                                        r.extIP.ToString() == filterExtIP &&
                                                                        r.dns.ToString() == filterDNS &&
                                                                        r.network.ToString() == filterNetwork &&
                                                                        r.location.Contains(filterLoc) &&
                                                                        r.installedOn.ToString() == filterIns &&
                                                                        r.active.ToString() == filterAct);
            IEnumerable<router> finalFiltered = filtered.ToList();
            //return View(finalFiltered);

            // This line returns the entire db entry ignoring filter since filtering isnt working.
            return View(db.routers.ToList());
        }

        // GET: router/details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            router r = db.routers.Find(Convert.ToInt32(id));
            if (r == null)
            {
                return HttpNotFound();
            }
            return View(r);
        }

        // GET: router/create
        public ActionResult Create()
        {
            return View();
        }

        // POST: router/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,os,location,installedOn,active")] router router)
        {
            if (ModelState.IsValid)
            {
                // Add new device to devices lsit with the information gathered from router view
                db.devices.Add(new device()
                {
                    id = router.id,
                    type = "Router",
                    location = router.location,
                    installedOn = Convert.ToDateTime(router.installedOn),
                    active = router.active
                });

                // Save addition
                db.SaveChanges();

                // Add device to router relation and save
                db.routers.Add(router);
                db.SaveChanges();

                // Return to index page
                return RedirectToAction("Index");
            }
            // Returns view
            return View(router);
        }

        // GET: router/Edit/5
        public ActionResult Edit(string id)
        {
            // Create router object and populate with data from item in relation matching given ID
            router router = db.routers.Find(Convert.ToInt32(id));

            // Error handling
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (router == null)
            {
                return HttpNotFound();
            }

            // Return to view
            return View(router);
        }

        // POST: router/edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OS,Location,InstalledOn,Active")] router router)
        {
            if (ModelState.IsValid)
            {
                // Get old device info before deleting it
                var oldDev = db.devices.Find(Convert.ToInt32(router.id));
                string oldType = oldDev.type;
                // delete old device
                db.devices.Remove(oldDev);

                // Modify router row with new info gathered from edit view
                db.Entry(router).State = EntityState.Modified;
                db.SaveChanges();

                // Add new device with updated info from router row
                db.devices.Add(new device()
                {
                    id = router.id,
                    type = oldType,
                    location = router.location,
                    installedOn = Convert.ToDateTime(router.installedOn),
                    active = router.active
                });

                // Save new information.
                db.SaveChanges();

                // Return to index
                return RedirectToAction("Index");
            }

            // Return view
            return View(router);
        }

        // GET: router/delete/5
        public ActionResult Delete(string id)
        {

            // Error handling
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Create new router object and populate with data from db
            router router = db.routers.Find(Convert.ToInt32(id));

            // More error handling
            if (router == null)
            {
                return HttpNotFound();
            }

            // Return view
            return View(router);
        }

        // POST: router/delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            // Create new router and device objects and populate with db data
            router router = db.routers.Find(Convert.ToInt32(id));
            device device = db.devices.Find(Convert.ToInt32(id));

            // Remove router
            db.routers.Remove(router);
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
            string intIP = Request.Form.Get("intIP");
            string extIP = Request.Form.Get("extIP");
            string dns = Request.Form.Get("dns");
            string network = Request.Form.Get("network");
            string loc = Request.Form.Get("location");
            string ins = Request.Form.Get("installedOn");
            string act = Request.Form.Get("active");

            Session["id"] = id;
            Session["intIP"] = intIP;
            Session["extIP"] = extIP;
            Session["dns"] = dns;
            Session["network"] = network;
            Session["location"] = loc;
            Session["installedOn"] = ins;
            Session["active"] = act;

            return RedirectToAction("Index");
        }
    }
}