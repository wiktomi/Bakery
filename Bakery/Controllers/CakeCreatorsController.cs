using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Bakery.Models;

namespace Bakery.Controllers
{
    public class CakeCreatorsController : Controller
    {
        private BakeryAzureEntities db = new BakeryAzureEntities();

        // GET: CakeCreators
        public ActionResult Index()
        {
            var cakeCreators = db.CakeCreators.Include(c => c.Accesory).Include(c => c.Additive).Include(c => c.Cream).Include(c => c.Filling).Include(c => c.Finish).Include(c => c.Icing).Include(c => c.Level).Include(c => c.Shape).Include(c => c.SpongeCake);
            return View(cakeCreators.ToList());
        }

        // GET: CakeCreators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CakeCreator cakeCreator = db.CakeCreators.Find(id);
            if (cakeCreator == null)
            {
                return HttpNotFound();
            }
            return View(cakeCreator);
        }

        // GET: CakeCreators/Create
        public ActionResult Create()
        {
            ViewBag.AccesoryID = new SelectList(db.Accesories, "AccesoryID", "AccesoryType");
            ViewBag.AdditionID = new SelectList(db.Additives, "AdditionID", "AdditionType");
            ViewBag.CreamID = new SelectList(db.Creams, "CreamID", "CreamsType");
            ViewBag.FillingID = new SelectList(db.Fillings, "FillingID", "FillingType");
            ViewBag.FinishID = new SelectList(db.Finishes, "FinishID", "FinishType");
            ViewBag.IcingID = new SelectList(db.Icings, "IcingID", "IcingsType");
            ViewBag.LevelID = new SelectList(db.Levels, "LevelID", "LevelID");
            ViewBag.ShapeID = new SelectList(db.Shapes, "ShapeID", "ShapeName");
            ViewBag.SpongeCakeID = new SelectList(db.SpongeCakes, "SpongeCakeID", "SpongeCakeType");
            return View();
        }

        // POST: CakeCreators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CakeCreatorID,ShapeID,LevelID,SpongeCakeID,CreamID,FillingID,IcingID,FinishID,AdditionID,AccesoryID")] CakeCreator cakeCreator)
        {
            if (ModelState.IsValid)
            {
                db.CakeCreators.Add(cakeCreator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccesoryID = new SelectList(db.Accesories, "AccesoryID", "AccesoryType", cakeCreator.AccesoryID);
            ViewBag.AdditionID = new SelectList(db.Additives, "AdditionID", "AdditionType", cakeCreator.AdditionID);
            ViewBag.CreamID = new SelectList(db.Creams, "CreamID", "CreamsType", cakeCreator.CreamID);
            ViewBag.FillingID = new SelectList(db.Fillings, "FillingID", "FillingType", cakeCreator.FillingID);
            ViewBag.FinishID = new SelectList(db.Finishes, "FinishID", "FinishType", cakeCreator.FinishID);
            ViewBag.IcingID = new SelectList(db.Icings, "IcingID", "IcingsType", cakeCreator.IcingID);
            ViewBag.LevelID = new SelectList(db.Levels, "LevelID", "LevelID", cakeCreator.LevelID);
            ViewBag.ShapeID = new SelectList(db.Shapes, "ShapeID", "ShapeName", cakeCreator.ShapeID);
            ViewBag.SpongeCakeID = new SelectList(db.SpongeCakes, "SpongeCakeID", "SpongeCakeType", cakeCreator.SpongeCakeID);
            return View(cakeCreator);
        }

        // GET: CakeCreators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CakeCreator cakeCreator = db.CakeCreators.Find(id);
            if (cakeCreator == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccesoryID = new SelectList(db.Accesories, "AccesoryID", "AccesoryType", cakeCreator.AccesoryID);
            ViewBag.AdditionID = new SelectList(db.Additives, "AdditionID", "AdditionType", cakeCreator.AdditionID);
            ViewBag.CreamID = new SelectList(db.Creams, "CreamID", "CreamsType", cakeCreator.CreamID);
            ViewBag.FillingID = new SelectList(db.Fillings, "FillingID", "FillingType", cakeCreator.FillingID);
            ViewBag.FinishID = new SelectList(db.Finishes, "FinishID", "FinishType", cakeCreator.FinishID);
            ViewBag.IcingID = new SelectList(db.Icings, "IcingID", "IcingsType", cakeCreator.IcingID);
            ViewBag.LevelID = new SelectList(db.Levels, "LevelID", "LevelID", cakeCreator.LevelID);
            ViewBag.ShapeID = new SelectList(db.Shapes, "ShapeID", "ShapeName", cakeCreator.ShapeID);
            ViewBag.SpongeCakeID = new SelectList(db.SpongeCakes, "SpongeCakeID", "SpongeCakeType", cakeCreator.SpongeCakeID);
            return View(cakeCreator);
        }

        // POST: CakeCreators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CakeCreatorID,ShapeID,LevelID,SpongeCakeID,CreamID,FillingID,IcingID,FinishID,AdditionID,AccesoryID")] CakeCreator cakeCreator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cakeCreator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccesoryID = new SelectList(db.Accesories, "AccesoryID", "AccesoryType", cakeCreator.AccesoryID);
            ViewBag.AdditionID = new SelectList(db.Additives, "AdditionID", "AdditionType", cakeCreator.AdditionID);
            ViewBag.CreamID = new SelectList(db.Creams, "CreamID", "CreamsType", cakeCreator.CreamID);
            ViewBag.FillingID = new SelectList(db.Fillings, "FillingID", "FillingType", cakeCreator.FillingID);
            ViewBag.FinishID = new SelectList(db.Finishes, "FinishID", "FinishType", cakeCreator.FinishID);
            ViewBag.IcingID = new SelectList(db.Icings, "IcingID", "IcingsType", cakeCreator.IcingID);
            ViewBag.LevelID = new SelectList(db.Levels, "LevelID", "LevelID", cakeCreator.LevelID);
            ViewBag.ShapeID = new SelectList(db.Shapes, "ShapeID", "ShapeName", cakeCreator.ShapeID);
            ViewBag.SpongeCakeID = new SelectList(db.SpongeCakes, "SpongeCakeID", "SpongeCakeType", cakeCreator.SpongeCakeID);
            return View(cakeCreator);
        }

        // GET: CakeCreators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CakeCreator cakeCreator = db.CakeCreators.Find(id);
            if (cakeCreator == null)
            {
                return HttpNotFound();
            }
            return View(cakeCreator);
        }

        // POST: CakeCreators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CakeCreator cakeCreator = db.CakeCreators.Find(id);
            db.CakeCreators.Remove(cakeCreator);
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
