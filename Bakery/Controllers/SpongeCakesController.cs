using Bakery.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Bakery.Controllers
{
    public class SpongeCakesController : Controller
    {
        private BakeryAzureEntities db = new BakeryAzureEntities();

        // GET: SpongeCakes
        public ActionResult Index()
        {
            return View(db.SpongeCakes.ToList());
        }

        // GET: SpongeCakes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpongeCake spongeCake = db.SpongeCakes.Find(id);
            if (spongeCake == null)
            {
                return HttpNotFound();
            }
            return View(spongeCake);
        }

        // GET: SpongeCakes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpongeCakes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpongeCakeID,SpongeCakeType,Price")] SpongeCake spongeCake)
        {
            if (ModelState.IsValid)
            {
                db.SpongeCakes.Add(spongeCake);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(spongeCake);
        }

        // GET: SpongeCakes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpongeCake spongeCake = db.SpongeCakes.Find(id);
            if (spongeCake == null)
            {
                return HttpNotFound();
            }
            return View(spongeCake);
        }

        // POST: SpongeCakes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpongeCakeID,SpongeCakeType,Price")] SpongeCake spongeCake)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spongeCake).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(spongeCake);
        }

        // GET: SpongeCakes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpongeCake spongeCake = db.SpongeCakes.Find(id);
            if (spongeCake == null)
            {
                return HttpNotFound();
            }
            return View(spongeCake);
        }

        // POST: SpongeCakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SpongeCake spongeCake = db.SpongeCakes.Find(id);
            db.SpongeCakes.Remove(spongeCake);
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
