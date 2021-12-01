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
    public class WeaponCategoriesController : Controller
    {
        private WeaponDBContext db = new WeaponDBContext();

        // GET: WeaponCategories
        public ActionResult Index(string searchWord)
        {

            var weaponCategories = from c in db.WeaponCategories
                                   select c;
            if (!String.IsNullOrEmpty(searchWord))
            {
                weaponCategories = weaponCategories.Where(s => s.Name.Contains(searchWord));
            }
            return View(weaponCategories);
        }

        // GET: WeaponCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeaponCategory weaponCategory = db.WeaponCategories.Find(id);
            if (weaponCategory == null)
            {
                return HttpNotFound();
            }
            return View(weaponCategory);
        }

        // GET: WeaponCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WeaponCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,SortableId,CreatedBy,CreatedOn")] WeaponCategory weaponCategory)
        {
            if (ModelState.IsValid)
            {
                db.WeaponCategories.Add(weaponCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(weaponCategory);
        }

        // GET: WeaponCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeaponCategory weaponCategory = db.WeaponCategories.Find(id);
            if (weaponCategory == null)
            {
                return HttpNotFound();
            }
            return View(weaponCategory);
        }

        // POST: WeaponCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,SortableId,CreatedBy,CreatedOn")] WeaponCategory weaponCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(weaponCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(weaponCategory);
        }

        // GET: WeaponCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WeaponCategory weaponCategory = db.WeaponCategories.Find(id);
            if (weaponCategory == null)
            {
                return HttpNotFound();
            }
            return View(weaponCategory);
        }

        // POST: WeaponCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WeaponCategory weaponCategory = db.WeaponCategories.Find(id);
            db.WeaponCategories.Remove(weaponCategory);
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
