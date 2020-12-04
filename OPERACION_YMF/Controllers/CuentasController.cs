using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OPERACION_YMF.Context;
using OPERACION_YMF.Models;

namespace OPERACION_YMF.Controllers
{
    public class CuentasController : Controller
    {
        private BD_TRANSACCIONES db = new BD_TRANSACCIONES();

        // GET: CUENTAs
        public ActionResult Index()
        {
            return View(db.CUENTAs.ToList());
        }

        // GET: CUENTAs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CUENTA cUENTA = db.CUENTAs.Find(id);
            if (cUENTA == null)
            {
                return HttpNotFound();
            }

            return View(cUENTA);
        }

        // GET: CUENTAs/Create
        public ActionResult Create()
        {
            var model = new CuentaModel {Monedas = GetSelectListItems(), TipoCuentas = GetSelectListItemsTipoCuentas()};

            // Create a list of SelectListItems so these can be rendered on the page
            return View(model);
        }

        private IEnumerable<SelectListItem> GetSelectListItems()
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            selectList.Add(new SelectListItem()
            {
                Value = "1", Text = "Dollar"
            });
            selectList.Add(new SelectListItem()
            {
                Value = "2",
                Text = "Boliviano"
            });
          

            return selectList;
        }
        private IEnumerable<SelectListItem> GetSelectListItemsTipoCuentas()
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            selectList.Add(new SelectListItem()
            {
                Value = "1",
                Text = "Ahorro"
            });
            selectList.Add(new SelectListItem()
            {
                Value = "2",
                Text = "Credito"
            });


            return selectList;
        }
        // POST: CUENTAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NRO_CUENTA,TIPO,MONEDA,NOMBRE,SALDO")]
            CUENTA cUENTA)
        {
            if (ModelState.IsValid)
            {
                db.CUENTAs.Add(cUENTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cUENTA);
        }

        // GET: CUENTAs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CUENTA cUENTA = db.CUENTAs.Find(id);
            if (cUENTA == null)
            {
                return HttpNotFound();
            }

            return View(cUENTA);
        }

        // POST: CUENTAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NRO_CUENTA,TIPO,MONEDA,NOMBRE,SALDO")]
            CUENTA cUENTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUENTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cUENTA);
        }

        // GET: CUENTAs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CUENTA cUENTA = db.CUENTAs.Find(id);
            if (cUENTA == null)
            {
                return HttpNotFound();
            }

            return View(cUENTA);
        }

        // POST: CUENTAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CUENTA cuenta = db.CUENTAs.Find(id);
            db.CUENTAs.Remove(cuenta);
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