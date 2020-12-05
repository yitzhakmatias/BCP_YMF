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
        public ActionResult Index([Bind(Include = "NRO_CUENTA_ORIGEN,SALDO_ORIGEN, NRO_CUENTA_DESTINO, SALDO_DESTINO")] TransferenciaModel transferenciaModel, string aceptar, string cancelar)
        {
            
            if (ModelState.IsValid)
            {
                if (aceptar != null)
                {
                    CUENTA origen = db.CUENTAs.Find(transferenciaModel.NRO_CUENTA_DESTINO);
                    origen.SALDO = origen.SALDO!=null?  origen.SALDO.Value - transferenciaModel.SALDO_DESTINO: -transferenciaModel.SALDO_DESTINO;
                    db.Entry(origen).State = EntityState.Modified;

                    var destino = db.CUENTAs.Find(transferenciaModel.NRO_CUENTA_ORIGEN);
                    if (destino != null)
                    {
                        destino.SALDO = destino.SALDO.Value + transferenciaModel.SALDO_ORIGEN;
                        db.Entry(destino).State = EntityState.Modified;
                    }

                    db.SaveChanges(); 
                }
                
            }

            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult Aceptar([Bind(Include = "NRO_CUENTA_ORIGEN,SALDO_ORIGEN, NRO_CUENTA_DESTINO, SALDO_DESTINO")] TransferenciaModel transferenciaModel, string submit)
        {
            if (ModelState.IsValid)
            {

                CUENTA origen = db.CUENTAs.Find(transferenciaModel.NRO_CUENTA_DESTINO);
                if (origen.SALDO != null) origen.SALDO = origen.SALDO.Value - transferenciaModel.SALDO_DESTINO;
                db.Entry(origen).State = EntityState.Modified;

                var destino = db.CUENTAs.Find(transferenciaModel.NRO_CUENTA_ORIGEN);
                destino.SALDO = destino.SALDO.Value + transferenciaModel.SALDO_ORIGEN;
                db.Entry(destino).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}