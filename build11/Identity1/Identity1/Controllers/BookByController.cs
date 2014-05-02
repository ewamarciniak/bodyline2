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
    public class BookByController : Controller
    {
        private Model1Container db = new Model1Container();

        // GET: /BookBy/
        public ActionResult Index()
        {
            var bookedbies = db.BookedBies.Include(b => b.GymClass);
            return View(bookedbies.ToList());
        }

        // GET: /BookBy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookedBy bookedby = db.BookedBies.Find(id);
            if (bookedby == null)
            {
                return HttpNotFound();
            }
            return View(bookedby);
        }

        // GET: /BookBy/Create
        public ActionResult Create()
        {
            ViewBag.GymClassId = new SelectList(db.GymClasses, "Id", "Id");
            return View();
        }

        // POST: /BookBy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,MembershipNo,GymClassId")] BookedBy bookedby)
        {
            if (ModelState.IsValid)
            {
                db.BookedBies.Add(bookedby);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GymClassId = new SelectList(db.GymClasses, "Id", "Id", bookedby.GymClassId);
            return View(bookedby);
        }

        // GET: /BookBy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookedBy bookedby = db.BookedBies.Find(id);
            if (bookedby == null)
            {
                return HttpNotFound();
            }
            ViewBag.GymClassId = new SelectList(db.GymClasses, "Id", "Id", bookedby.GymClassId);
            return View(bookedby);
        }

        // POST: /BookBy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,MembershipNo,GymClassId")] BookedBy bookedby)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookedby).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GymClassId = new SelectList(db.GymClasses, "Id", "Id", bookedby.GymClassId);
            return View(bookedby);
        }

        // GET: /BookBy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookedBy bookedby = db.BookedBies.Find(id);
            if (bookedby == null)
            {
                return HttpNotFound();
            }
            return View(bookedby);
        }

        // POST: /BookBy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookedBy bookedby = db.BookedBies.Find(id);
            db.BookedBies.Remove(bookedby);
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
