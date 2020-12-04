using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OPERACION_YMF.Context;
using OPERACION_YMF.Models;

namespace OPERACION_YMF.Controllers
{
    public class AbonoRetiroController : Controller
    {
        private BD_TRANSACCIONES db = new BD_TRANSACCIONES();

        public ActionResult Index()
        {
            var cuentas = db.CUENTAs.ToList();

            var model = new AbonoRetiroModel();
            model.Cuentas = GetSelectAccounts(cuentas);

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
        public ActionResult Deposito([Bind(Include = "NRO_CUENTA,SALDO")] AbonoRetiroModel cuenta)
        {
            if (ModelState.IsValid)
            {
                var movimiento = new MOVIMIENTO();
                movimiento.TIPO = "A";
                movimiento.NRO_CUENTA = cuenta.NRO_CUENTA;
                movimiento.IMPORTE = cuenta.SALDO;
                movimiento.FECHA = DateTime.Now;

                db.MOVIMIENTOes.Add(movimiento);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Retiro([Bind(Include = "NRO_CUENTA,SALDO")] AbonoRetiroModel cuenta)
        {
            if (ModelState.IsValid)
            {
                var movimiento = new MOVIMIENTO();
                movimiento.TIPO = "D";
                movimiento.NRO_CUENTA = cuenta.NRO_CUENTA;
                movimiento.IMPORTE = cuenta.SALDO;
                movimiento.FECHA = DateTime.Now;
                db.MOVIMIENTOes.Add(movimiento);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}