using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Solucion_CAR.Models;

namespace Solucion_CAR.Controllers
{
    public class PagoesController : Controller
    {
        private BaseDatos_CAREntities db = new BaseDatos_CAREntities();

        // GET: Pagoes
        public ActionResult Index()
        {
            var pagoes = db.Pagoes.Include(p => p.Factura);
            return View(pagoes.ToList());
        }

        // GET: Pagoes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = db.Pagoes.Find(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            return View(pago);
        }

        // GET: Pagoes/Create
        public ActionResult Create()
        {
            ViewBag.facturaId = new SelectList(db.Facturas, "facturaId", "nombrecliente");
            return View();
        }

        // POST: Pagoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pagosId,facturaId,monto,fechadepago")] Pago pago)
        {
            if (ModelState.IsValid)
            {
                pago.pagosId = Guid.NewGuid();
                db.Pagoes.Add(pago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.facturaId = new SelectList(db.Facturas, "facturaId", "nombrecliente", pago.facturaId);
            return View(pago);
        }

        // GET: Pagoes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = db.Pagoes.Find(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            ViewBag.facturaId = new SelectList(db.Facturas, "facturaId", "nombrecliente", pago.facturaId);
            return View(pago);
        }

        // POST: Pagoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pagosId,facturaId,monto,fechadepago")] Pago pago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.facturaId = new SelectList(db.Facturas, "facturaId", "nombrecliente", pago.facturaId);
            return View(pago);
        }

        // GET: Pagoes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pago pago = db.Pagoes.Find(id);
            if (pago == null)
            {
                return HttpNotFound();
            }
            return View(pago);
        }

        // POST: Pagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Pago pago = db.Pagoes.Find(id);
            db.Pagoes.Remove(pago);
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
