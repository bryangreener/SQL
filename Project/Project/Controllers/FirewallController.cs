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
    public class FirewallController : Controller
    {
        // new instance of database
        private FinalProjectEntities1 db = new FinalProjectEntities1();

        // GET: Firewall
        public ActionResult Index()
        {
            /*DbSet<firewall> FWToFilter = db.firewalls;
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


            IEnumerable<firewall> filtered = FWToFilter.Where(fw => fw.id.ToString() == filterID &&
                                                                        fw.intIP.Contains(filterIntIP) &&
                                                                        fw.extIP.Contains(filterExtIP) &&
                                                                        fw.dns.Contains(filterDNS) &&
                                                                        fw.network.Contains(filterNetwork) &&
                                                                        fw.location.Contains(filterLoc) &&
                                                                        fw.installedOn.ToString() == filterIns &&
                                                                        fw.active.ToString() == filterAct);
            IEnumerable<firewall> finalFiltered = filtered.ToList();
            //return View(finalFiltered);
            */
            // This line returns the entire db entry ignoring filter since filtering isnt working.
            return View(db.firewalls.ToList());
        }

        // GET: firewall/details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            firewall fw = db.firewalls.Find(id);
            if (fw == null)
            {
                return HttpNotFound();
            }
            return View(fw);
        }

        // GET: firewall/create
        public ActionResult Create()
        {
            return View();
        }

        // POST: firewall/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,intIP,extIP,dns,network,location,installedOn,active")] firewall firewall)
        {
            if (ModelState.IsValid)
            {
                // Add new device to devices lsit with the information gathered from firewall view
                db.devices.Add(new device()
                {
                    id = firewall.id,
                    type = "Firewall",
                    location = firewall.location,
                    installedOn = firewall.installedOn,
                    active = firewall.active
                });

                // Save addition
                db.SaveChanges();

                // Add device to firewall relation and save
                db.firewalls.Add(firewall);
                db.SaveChanges();

                // Return to index page
                return RedirectToAction("Index");
            }
            // Returns view
            return View(firewall);
        }

        // GET: firewall/Edit/5
        public ActionResult Edit(string id)
        {
            // Create firewall object and populate with data from item in relation matching given ID
            firewall firewall = db.firewalls.Find(id);

            // Error handling
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (firewall == null)
            {
                return HttpNotFound();
            }

            // Return to view
            return View(firewall);
        }

        // POST: firewall/edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,intIP,extIP,dns,network,location,installedOn,active")] firewall firewall)
        {
            if (ModelState.IsValid)
            {
                // Get old device info before deleting it
                var oldDev = db.devices.Find(firewall.id);
                string oldType = oldDev.type;
                // delete old device
                db.devices.Remove(oldDev);

                // Modify firewall row with new info gathered from edit view
                db.Entry(firewall).State = EntityState.Modified;
                db.SaveChanges();

                // Add new device with updated info from firewall row
                db.devices.Add(new device()
                {
                    id = firewall.id,
                    type = oldType,
                    location = firewall.location,
                    installedOn = firewall.installedOn,
                    active = firewall.active
                });

                // Save new information.
                db.SaveChanges();

                // Return to index
                return RedirectToAction("Index");
            }

            // Return view
            return View(firewall);
        }

        // GET: firewall/delete/5
        public ActionResult Delete(string id)
        {

            // Error handling
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Create new firewall object and populate with data from db
            firewall firewall = db.firewalls.Find(id);

            // More error handling
            if (firewall == null)
            {
                return HttpNotFound();
            }

            // Return view
            return View(firewall);
        }

        // POST: firewall/delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            // Create new firewall and device objects and populate with db data
            firewall firewall = db.firewalls.Find(id);
            device device = db.devices.Find(id);

            // Remove firewall
            db.firewalls.Remove(firewall);
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