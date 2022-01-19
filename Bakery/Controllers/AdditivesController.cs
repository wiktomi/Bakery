using Bakery.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Bakery.Controllers
{
    public class AdditivesController : Controller
    {
        private BakeryAzureEntities db = new BakeryAzureEntities();

        // GET: Additives
        public ActionResult Index()
        {
            return View(db.Additives.ToList());
        }

        // GET: Additives/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Additive additive = db.Additives.Find(id);
            if (additive == null)
            {
                return HttpNotFound();
            }
            return View(additive);
        }

        // GET: Additives/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Additives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdditionID,AdditionType,Price")] Additive additive)
        {
            if (ModelState.IsValid)
            {
                db.Additives.Add(additive);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(additive);
        }

        // GET: Additives/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Additive additive = db.Additives.Find(id);
            if (additive == null)
            {
                return HttpNotFound();
            }
            return View(additive);
        }

        // POST: Additives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdditionID,AdditionType,Price")] Additive additive)
        {
            if (ModelState.IsValid)
            {
                db.Entry(additive).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(additive);
        }

        // GET: Additives/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Additive additive = db.Additives.Find(id);
            if (additive == null)
            {
                return HttpNotFound();
            }
            return View(additive);
        }

        // POST: Additives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Additive additive = db.Additives.Find(id);
            db.Additives.Remove(additive);
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
