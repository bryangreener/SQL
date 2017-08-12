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
        private FinalProjectEntities1 db = new FinalProjectEntities1();
        
        // GET: Computer
        public ActionResult Index()
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
            //return View(finalFiltered);

            // This line returns the entire db entry ignoring filter since filtering isnt working.
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
                // Add new device to devices lsit with the information gathered from computer view
                db.devices.Add(new device()
                {
                    id = computer.id,
                    type = "Computer",
                    location = computer.location,
                    installedOn = computer.installedOn,
                    active = computer.active
                });

                // Save addition
                db.SaveChanges();

                // Add device to Computer relation and save
                db.computers.Add(computer);
                db.SaveChanges();

                // Return to index page
                return RedirectToAction("Index");
            }
            // Returns view
            return View(computer);
        }

        // GET: computer/Edit/5
        public ActionResult Edit(string id)
        {
            // Create computer object and populate with data from item in relation matching given ID
            computer computer = db.computers.Find(id);

            // Error handling
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if(computer == null)
            {
                return HttpNotFound();
            }

            // Return to view
            return View(computer);
        }

        // POST: computer/edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OS,Location,InstalledOn,Active")] computer computer)
        {
            if(ModelState.IsValid)
            {
                // Get old device info before deleting it
                var oldDev = db.devices.Find(computer.id);
                string oldType = oldDev.type;
                // delete old device
                db.devices.Remove(oldDev);

                // Modify computer row with new info gathered from edit view
                db.Entry(computer).State = EntityState.Modified;
                db.SaveChanges();

                // Add new device with updated info from computer row
                db.devices.Add(new device()
                {
                    id = computer.id,
                    type = oldType,
                    location = computer.location,
                    installedOn = computer.installedOn,
                    active = computer.active
                });
                
                // Save new information.
                db.SaveChanges();

                // Return to index
                return RedirectToAction("Index");
            }

            // Return view
            return View(computer);
        }

        // GET: computer/delete/5
        public ActionResult Delete(string id)
        {

            // Error handling
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Create new computer object and populate with data from db
            computer computer = db.computers.Find(id);

            // More error handling
            if(computer == null)
            {
                return HttpNotFound();
            }

            // Return view
            return View(computer);
        }

        // POST: computer/delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            // Create new computer and device objects and populate with db data
            computer computer = db.computers.Find(id);
            device device = db.devices.Find(id);

            // Remove computer
            db.computers.Remove(computer);
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