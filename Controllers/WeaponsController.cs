using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeaponShop.Models;

namespace WeaponShop.Controllers
{
    public class WeaponsController : Controller
    {
        private WeaponDBContext db = new WeaponDBContext();

        // GET: Weapons
        public ActionResult Index()
        {
            var weapons = db.Weapons.Include(w => w.WeaponCategory);
            return View(weapons.ToList());
        }

        // GET: Weapons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weapons weapons = db.Weapons.Find(id);
            if (weapons == null)
            {
                return HttpNotFound();
            }
            return View(weapons);
        }

        // GET: Weapons/Create
        public ActionResult Create()
        {
            ViewBag.WeaponCategoryId = new SelectList(db.WeaponCategories, "Id", "Name");
            return View();
        }

        // POST: Weapons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,WeaponCategoryId,Name,Description,Calibre,Price,PublishedOnSite,isEnabled")] Weapons weapons)
        {
            if (ModelState.IsValid)
            {
                db.Weapons.Add(weapons);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WeaponCategoryId = new SelectList(db.WeaponCategories, "Id", "Name", weapons.WeaponCategoryId);
            return View(weapons);
        }

        // GET: Weapons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weapons weapons = db.Weapons.Find(id);
            if (weapons == null)
            {
                return HttpNotFound();
            }
            ViewBag.WeaponCategoryId = new SelectList(db.WeaponCategories, "Id", "Name", weapons.WeaponCategoryId);
            return View(weapons);
        }

        // POST: Weapons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,WeaponCategoryId,Name,Description,Calibre,Price,PublishedOnSite,isEnabled")] Weapons weapons)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weapons).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WeaponCategoryId = new SelectList(db.WeaponCategories, "Id", "Name", weapons.WeaponCategoryId);
            return View(weapons);
        }

        // GET: Weapons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Weapons weapons = db.Weapons.Find(id);
            if (weapons == null)
            {
                return HttpNotFound();
            }
            return View(weapons);
        }

        // POST: Weapons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Weapons weapons = db.Weapons.Find(id);
            db.Weapons.Remove(weapons);
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
