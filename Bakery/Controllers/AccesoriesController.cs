using Bakery.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Bakery.Controllers
{
    public class AccesoriesController : Controller
    {
        private BakeryAzureEntities db = new BakeryAzureEntities();

        // GET: Accesories
        public ActionResult Index()
        {
            return View(db.Accesories.ToList());
        }

        // GET: Accesories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accesory accesory = db.Accesories.Find(id);
            if (accesory == null)
            {
                return HttpNotFound();
            }
            return View(accesory);
        }

        // GET: Accesories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accesories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccesoryID,AccesoryType,Price")] Accesory accesory)
        {
            if (ModelState.IsValid)
            {
                db.Accesories.Add(accesory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accesory);
        }

        // GET: Accesories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accesory accesory = db.Accesories.Find(id);
            if (accesory == null)
            {
                return HttpNotFound();
            }
            return View(accesory);
        }

        // POST: Accesories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccesoryID,AccesoryType,Price")] Accesory accesory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accesory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accesory);
        }

        // GET: Accesories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accesory accesory = db.Accesories.Find(id);
            if (accesory == null)
            {
                return HttpNotFound();
            }
            return View(accesory);
        }

        // POST: Accesories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accesory accesory = db.Accesories.Find(id);
            db.Accesories.Remove(accesory);
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
