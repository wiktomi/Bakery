using Bakery.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Bakery.Controllers
{
    public class FinishedOrdersController : Controller
    {
        private BakeryAzureEntities db = new BakeryAzureEntities();

        // GET: FinishedOrders
        public ActionResult Index()
        {
            var finishedOrders = db.FinishedOrders.Include(f => f.Customer).Include(f => f.Order).Include(f => f.OrderDetail);
            return View(finishedOrders.ToList());
        }

        // GET: FinishedOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinishedOrder finishedOrder = db.FinishedOrders.Find(id);
            if (finishedOrder == null)
            {
                return HttpNotFound();
            }
            return View(finishedOrder);
        }

        // GET: FinishedOrders/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName");
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID");
            ViewBag.OrderDetailsID = new SelectList(db.OrderDetails, "OrderDetailsID", "OrderDetailsID");
            return View();
        }

        // POST: FinishedOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FinishedOrderID,CustomerID,OrderID,OrderDetailsID")] FinishedOrder finishedOrder)
        {
            if (ModelState.IsValid)
            {
                db.FinishedOrders.Add(finishedOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", finishedOrder.CustomerID);
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID", finishedOrder.OrderID);
            ViewBag.OrderDetailsID = new SelectList(db.OrderDetails, "OrderDetailsID", "OrderDetailsID", finishedOrder.OrderDetailsID);
            return View(finishedOrder);
        }

        // GET: FinishedOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinishedOrder finishedOrder = db.FinishedOrders.Find(id);
            if (finishedOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", finishedOrder.CustomerID);
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID", finishedOrder.OrderID);
            ViewBag.OrderDetailsID = new SelectList(db.OrderDetails, "OrderDetailsID", "OrderDetailsID", finishedOrder.OrderDetailsID);
            return View(finishedOrder);
        }

        // POST: FinishedOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FinishedOrderID,CustomerID,OrderID,OrderDetailsID")] FinishedOrder finishedOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(finishedOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", finishedOrder.CustomerID);
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID", finishedOrder.OrderID);
            ViewBag.OrderDetailsID = new SelectList(db.OrderDetails, "OrderDetailsID", "OrderDetailsID", finishedOrder.OrderDetailsID);
            return View(finishedOrder);
        }

        // GET: FinishedOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinishedOrder finishedOrder = db.FinishedOrders.Find(id);
            if (finishedOrder == null)
            {
                return HttpNotFound();
            }
            return View(finishedOrder);
        }

        // POST: FinishedOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FinishedOrder finishedOrder = db.FinishedOrders.Find(id);
            db.FinishedOrders.Remove(finishedOrder);
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
