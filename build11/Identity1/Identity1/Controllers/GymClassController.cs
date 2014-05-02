using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Identity1.Models;

namespace Identity1.Controllers
{
    public class GymClassController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: /GymClass/
        public ActionResult Index()
        {
            var gymclasses = db.GymClasses.Include(g => g.Activity).Include(g => g.Room);
            return View(gymclasses.ToList());
        }

        // GET: /GymClass/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GymClass gymclass = db.GymClasses.Find(id);
            if (gymclass == null)
            {
                return HttpNotFound();
            }
            return View(gymclass);
        }

        // GET: /GymClass/Create
        public ActionResult Create()
        {
            ViewBag.ActivityId = new SelectList(db.Activities, "Id", "ActivityName");
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "RoomName");
            return View();
        }

        // POST: /GymClass/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Date,StartTime,Duration,ActivityId,RoomId")] GymClass gymclass)
        {
            if (ModelState.IsValid)
            {
                db.GymClasses.Add(gymclass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActivityId = new SelectList(db.Activities, "Id", "ActivityName", gymclass.ActivityId);
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "RoomName", gymclass.RoomId);
            return View(gymclass);
        }

        // GET: /GymClass/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GymClass gymclass = db.GymClasses.Find(id);
            if (gymclass == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActivityId = new SelectList(db.Activities, "Id", "ActivityName", gymclass.ActivityId);
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "RoomName", gymclass.RoomId);
            return View(gymclass);
        }

        // POST: /GymClass/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Date,StartTime,Duration,ActivityId,RoomId")] GymClass gymclass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gymclass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActivityId = new SelectList(db.Activities, "Id", "ActivityName", gymclass.ActivityId);
            ViewBag.RoomId = new SelectList(db.Rooms, "Id", "RoomName", gymclass.RoomId);
            return View(gymclass);
        }

        // GET: /GymClass/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GymClass gymclass = db.GymClasses.Find(id);
            if (gymclass == null)
            {
                return HttpNotFound();
            }
            return View(gymclass);
        }

        // POST: /GymClass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GymClass gymclass = db.GymClasses.Find(id);
            db.GymClasses.Remove(gymclass);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
