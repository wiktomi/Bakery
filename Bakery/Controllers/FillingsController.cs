using Bakery.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Bakery.Controllers
{
    public class FillingsController : Controller
    {
        private BakeryAzureEntities db = new BakeryAzureEntities();

        // GET: Fillings
        public ActionResult Index()
        {
            return View(db.Fillings.ToList());
        }

        // GET: Fillings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filling filling = db.Fillings.Find(id);
            if (filling == null)
            {
                return HttpNotFound();
            }
            return View(filling);
        }

        // GET: Fillings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fillings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FillingID,FillingType,Price")] Filling filling)
        {
            if (ModelState.IsValid)
            {
                db.Fillings.Add(filling);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(filling);
        }

        // GET: Fillings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filling filling = db.Fillings.Find(id);
            if (filling == null)
            {
                return HttpNotFound();
            }
            return View(filling);
        }

        // POST: Fillings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FillingID,FillingType,Price")] Filling filling)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filling).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(filling);
        }

        // GET: Fillings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filling filling = db.Fillings.Find(id);
            if (filling == null)
            {
                return HttpNotFound();
            }
            return View(filling);
        }

        // POST: Fillings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Filling filling = db.Fillings.Find(id);
            db.Fillings.Remove(filling);
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
