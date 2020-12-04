using System;
using System.Collections.Generic;
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
    }
}