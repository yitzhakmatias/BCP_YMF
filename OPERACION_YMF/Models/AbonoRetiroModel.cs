using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OPERACION_YMF.Models
{
    public class AbonoRetiroModel
    {
        public IEnumerable<SelectListItem> Cuentas { get; set; }
        public string NRO_CUENTA { get; set; }
        public decimal SALDO { get; set; }
    }
}