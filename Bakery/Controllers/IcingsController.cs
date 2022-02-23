using Bakery.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Bakery.Controllers
{
    public class IcingsController : Controller
    {
        private BakeryAzureEntities db = new BakeryAzureEntities();

        // GET: Icings
        public ActionResult Index()
        {
            return View(db.Icings.ToList());
        }

        // GET: Icings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Icing icing = db.Icings.Find(id);
            if (icing == null)
            {
                return HttpNotFound();
            }
            return View(icing);
        }

        // GET: Icings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Icings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IcingID,IcingsType,Price")] Icing icing)
        {
            if (ModelState.IsValid)
            {
                db.Icings.Add(icing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(icing);
        }

        // GET: Icings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Icing icing = db.Icings.Find(id);
            if (icing == null)
            {
                return HttpNotFound();
            }
            return View(icing);
        }

        // POST: Icings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IcingID,IcingsType,Price")] Icing icing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(icing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(icing);
        }

        // GET: Icings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Icing icing = db.Icings.Find(id);
            if (icing == null)
            {
                return HttpNotFound();
            }
            return View(icing);
        }

        // POST: Icings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Icing icing = db.Icings.Find(id);
            db.Icings.Remove(icing);
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
