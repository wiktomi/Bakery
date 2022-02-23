using Bakery.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Bakery.Controllers
{
    public class CreamsController : Controller
    {
        private BakeryAzureEntities db = new BakeryAzureEntities();

        // GET: Creams
        public ActionResult Index()
        {
            return View(db.Creams.ToList());
        }

        // GET: Creams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cream cream = db.Creams.Find(id);
            if (cream == null)
            {
                return HttpNotFound();
            }
            return View(cream);
        }

        // GET: Creams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Creams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CreamID,CreamsType,Price")] Cream cream)
        {
            if (ModelState.IsValid)
            {
                db.Creams.Add(cream);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cream);
        }

        // GET: Creams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cream cream = db.Creams.Find(id);
            if (cream == null)
            {
                return HttpNotFound();
            }
            return View(cream);
        }

        // POST: Creams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CreamID,CreamsType,Price")] Cream cream)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cream).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cream);
        }

        // GET: Creams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cream cream = db.Creams.Find(id);
            if (cream == null)
            {
                return HttpNotFound();
            }
            return View(cream);
        }

        // POST: Creams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cream cream = db.Creams.Find(id);
            db.Creams.Remove(cream);
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
