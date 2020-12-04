using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OPERACION_YMF.Models
{
    public class CuentaModel
    {

        public string NRO_CUENTA { get; set; }

        public IEnumerable<SelectListItem> TipoCuentas { get; set; }
        public string TIPO { get; set; }
        public IEnumerable<SelectListItem> Monedas { get; set; }
        public string MONEDA { get; set; }
        public string NOMBRE { get; set; }
        public string SALDO { get; set; }
    }
}