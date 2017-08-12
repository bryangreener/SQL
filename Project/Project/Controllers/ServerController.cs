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
    public class ServerController : Controller
    {
        // new instance of database
        private FinalProjectEntities db = new FinalProjectEntities();

        // GET: Server
        public ActionResult Index()
        {
            DbSet<server> ServToFilter = db.servers;
            string filterID = "";
            string filterOS = "";
            string filterIP1 = "";
            string filterIP2 = "";
            string filterIP3 = "";
            string filterIP4 = "";
            string filterDNS = "";
            string filterNetwork = "";
            string filterRoles = "";
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
            if (Session["ip1"] != null && !String.IsNullOrWhiteSpace((string)Session["ip1"]))
            {
                filterIP1 = (string)Session["ip1"];
            }
            if (Session["ip2"] != null && !String.IsNullOrWhiteSpace((string)Session["ip2"]))
            {
                filterIP2 = (string)Session["ip2"];
            }
            if (Session["ip3"] != null && !String.IsNullOrWhiteSpace((string)Session["ip3"]))
            {
                filterIP3 = (string)Session["ip3"];
            }
            if (Session["ip4"] != null && !String.IsNullOrWhiteSpace((string)Session["ip4"]))
            {
                filterIP4 = (string)Session["ip4"];
            }
            if (Session["dns"] != null && !String.IsNullOrWhiteSpace((string)Session["dns"]))
            {
                filterDNS = (string)Session["dns"];
            }
            if (Session["network"] != null && !String.IsNullOrWhiteSpace((string)Session["network"]))
            {
                filterNetwork = (string)Session["network"];
            }
            if (Session["roles"] != null && !String.IsNullOrWhiteSpace((string)Session["roles"]))
            {
                filterRoles = (string)Session["roles"];
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
            ViewBag.filterIP1 = filterIP1;
            ViewBag.filterIP2 = filterIP2;
            ViewBag.filterIP3 = filterIP3;
            ViewBag.filterIP4 = filterIP4;
            ViewBag.filterDNS = filterDNS;
            ViewBag.filterNetwork = filterNetwork;
            ViewBag.filterRoles = filterRoles;
            ViewBag.filterLoc = filterLoc;
            ViewBag.filterIns = filterIns;
            ViewBag.filterAct = filterAct;


            IEnumerable<server> filtered = ServToFilter.Where(serv => serv.id.ToString() == filterID &&
                                                                        serv.os.Contains(filterOS) &&
                                                                        serv.ip1.ToString() == filterIP1 &&
                                                                        serv.ip2.ToString() == filterIP2 &&
                                                                        serv.ip3.ToString() == filterIP3 &&
                                                                        serv.ip4.ToString() == filterIP4 &&
                                                                        serv.dns.ToString() == filterDNS &&
                                                                        serv.network.ToString() == filterNetwork &&
                                                                        serv.roles.Contains(filterRoles) &&
                                                                        serv.location.Contains(filterLoc) &&
                                                                        serv.installedOn.ToString() == filterIns &&
                                                                        serv.active.ToString() == filterAct);
            IEnumerable<server> finalFiltered = filtered.ToList();
            //return View(finalFiltered);

            // This line returns the entire db entry ignoring filter since filtering isnt working.
            return View(db.servers.ToList());
        }

        // GET: server/details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            server serv = db.servers.Find(Convert.ToInt32(id));
            if (serv == null)
            {
                return HttpNotFound();
            }
            return View(serv);
        }

        // GET: server/create
        public ActionResult Create()
        {
            return View();
        }

        // POST: server/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,os,ip1,ip2,ip3,ip4,dns,network,roles,location,installedOn,active")] server server)
        {
            if (ModelState.IsValid)
            {
                // Add new device to devices lsit with the information gathered from server view
                db.devices.Add(new device()
                {
                    id = server.id,
                    type = "Server",
                    location = server.location,
                    installedOn = Convert.ToDateTime(server.installedOn),
                    active = server.active
                });

                // Save addition
                db.SaveChanges();

                // Add device to Server relation and save
                db.servers.Add(server);
                db.SaveChanges();

                // Return to index page
                return RedirectToAction("Index");
            }
            // Returns view
            return View(server);
        }

        // GET: server/Edit/5
        public ActionResult Edit(string id)
        {
            // Create server object and populate with data from item in relation matching given ID
            server server = db.servers.Find(Convert.ToInt32(id));

            // Error handling
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (server == null)
            {
                return HttpNotFound();
            }

            // Return to view
            return View(server);
        }

        // POST: server/edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,os,ip1,ip2,ip3,ip4,dns,network,roles,location,installedOn,active")] server server)
        {
            if (ModelState.IsValid)
            {
                // Get old device info before deleting it
                var oldDev = db.devices.Find(Convert.ToInt32(server.id));
                string oldType = oldDev.type;
                // delete old device
                db.devices.Remove(oldDev);

                // Modify server row with new info gathered from edit view
                db.Entry(server).State = EntityState.Modified;
                db.SaveChanges();

                // Add new device with updated info from server row
                db.devices.Add(new device()
                {
                    id = server.id,
                    type = oldType,
                    location = server.location,
                    installedOn = Convert.ToDateTime(server.installedOn),
                    active = server.active
                });

                // Save new information.
                db.SaveChanges();

                // Return to index
                return RedirectToAction("Index");
            }

            // Return view
            return View(server);
        }

        // GET: server/delete/5
        public ActionResult Delete(string id)
        {

            // Error handling
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Create new server object and populate with data from db
            server server = db.servers.Find(Convert.ToInt32(id));

            // More error handling
            if (server == null)
            {
                return HttpNotFound();
            }

            // Return view
            return View(server);
        }

        // POST: server/delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            // Create new server and device objects and populate with db data
            server server = db.servers.Find(Convert.ToInt32(id));
            device device = db.devices.Find(Convert.ToInt32(id));

            // Remove server
            db.servers.Remove(server);
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
            string os = Request.Form.Get("os");
            string ip1 = Request.Form.Get("ip1");
            string ip2 = Request.Form.Get("ip2");
            string ip3 = Request.Form.Get("ip3");
            string ip4 = Request.Form.Get("ip4");
            string dns = Request.Form.Get("dns");
            string network = Request.Form.Get("network");
            string roles = Request.Form.Get("roles");
            string loc = Request.Form.Get("location");
            string ins = Request.Form.Get("installedOn");
            string act = Request.Form.Get("active");

            Session["id"] = id;
            Session["os"] = os;
            Session["ip1"] = ip1;
            Session["ip2"] = ip2;
            Session["ip3"] = ip3;
            Session["ip4"] = ip4;
            Session["dns"] = dns;
            Session["network"] = network;
            Session["roles"] = roles;
            Session["location"] = loc;
            Session["installedOn"] = ins;
            Session["active"] = act;

            return RedirectToAction("Index");
        }
    }
}