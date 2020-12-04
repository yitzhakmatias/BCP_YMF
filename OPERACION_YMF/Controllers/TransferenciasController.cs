using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OPERACION_YMF.Context;
using OPERACION_YMF.Models;

namespace OPERACION_YMF.Controllers
{
    public class TransferenciasController : Controller
    {

        private BD_TRANSACCIONES db = new BD_TRANSACCIONES();
        // GET: Transferencias
        public ActionResult Index()
        {
            var cuentas = db.CUENTAs.ToList();

            var model = new TransferenciaModel();
            model.CuentaOrigen = GetSelectAccounts(cuentas);
            model.CuentaDestino = GetSelectAccounts(cuentas);

            return View(model);
           
        }
        private IEnumerable<SelectListItem> GetSelectAccounts(List<CUENTA> cuentas)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            foreach (var itemCuenta in cuentas)
            {
                selectList.Add(new SelectListItem()
                {
                    Value = itemCuenta.NRO_CUENTA,
                    Text = itemCuenta.NRO_CUENTA
                });
            }

            return selectList;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Aceptar([Bind(Include = "NRO_CUENTA_ORIGEN,SALDO_ORIGEN, NRO_CUENTA_DESTINO, SALDO_DESTINO")] TransferenciaModel transferenciaModel)
        {
            if (ModelState.IsValid)
            {

                var origen = db.CUENTAs.Find(transferenciaModel.NRO_CUENTA_DESTINO);
                origen.SALDO = origen.SALDO - transferenciaModel.SALDO_DESTINO;
                db.Entry(origen).State = EntityState.Modified;

                var destino = db.CUENTAs.Find(transferenciaModel.NRO_CUENTA_ORIGEN);
                destino.SALDO = destino.SALDO + transferenciaModel.SALDO_ORIGEN;
                db.Entry(destino).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}