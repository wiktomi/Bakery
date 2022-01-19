using Bakery.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Bakery.Controllers
{
    public class FinishesController : Controller
    {
        private BakeryAzureEntities db = new BakeryAzureEntities();

        // GET: Finishes
        public ActionResult Index()
        {
            return View(db.Finishes.ToList());
        }

        // GET: Finishes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Finish finish = db.Finishes.Find(id);
            if (finish == null)
            {
                return HttpNotFound();
            }
            return View(finish);
        }

        // GET: Finishes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Finishes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FinishID,FinishType,Price")] Finish finish)
        {
            if (ModelState.IsValid)
            {
                db.Finishes.Add(finish);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(finish);
        }

        // GET: Finishes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Finish finish = db.Finishes.Find(id);
            if (finish == null)
            {
                return HttpNotFound();
            }
            return View(finish);
        }

        // POST: Finishes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FinishID,FinishType,Price")] Finish finish)
        {
            if (ModelState.IsValid)
            {
                db.Entry(finish).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(finish);
        }

        // GET: Finishes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Finish finish = db.Finishes.Find(id);
            if (finish == null)
            {
                return HttpNotFound();
            }
            return View(finish);
        }

        // POST: Finishes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Finish finish = db.Finishes.Find(id);
            db.Finishes.Remove(finish);
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
