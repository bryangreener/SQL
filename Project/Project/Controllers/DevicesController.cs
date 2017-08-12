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
    public class DevicesController : Controller
    {
        // new instance of database
        private FinalProjectEntities1 db = new FinalProjectEntities1();

        // GET: device
        public ActionResult Index()
        {
            DbSet<device> DevToFilter = db.devices;
            string filterID = "";
            string filterType = "";
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
            ViewBag.filterLoc = filterLoc;
            ViewBag.filterIns = filterIns;
            ViewBag.filterAct = filterAct;


            IEnumerable<device> filtered = DevToFilter.Where(dev => dev.id.ToString() == filterID &&
                                                                        dev.type.Contains(filterType) &&
                                                                        dev.location.Contains(filterLoc) &&
                                                                        dev.installedOn.ToString() == filterIns &&
                                                                        dev.active.ToString() == filterAct);
            IEnumerable<device> finalFiltered = filtered.ToList();
            //return View(finalFiltered);

            // This line returns the entire db entry ignoring filter since filtering isnt working.
            return View(db.devices.ToList());
        }

        // GET: device/details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            device dev = db.devices.Find(id);
            if (dev == null)
            {
                return HttpNotFound();
            }
            return View(dev);
        }
        // Filters
        [HttpPost, ActionName("Filter")]
        public ActionResult Filter()
        {
            string id = Request.Form.Get("id");
            string type = Request.Form.Get("type");
            string loc = Request.Form.Get("location");
            string ins = Request.Form.Get("installedOn");
            string act = Request.Form.Get("active");

            Session["id"] = id;
            Session["type"] = type;
            Session["location"] = loc;
            Session["installedOn"] = ins;
            Session["active"] = act;

            return RedirectToAction("Index");
        }
    }
}