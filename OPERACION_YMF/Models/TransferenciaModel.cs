using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OPERACION_YMF.Models
{
    public class TransferenciaModel
    {
        public IEnumerable<SelectListItem> CuentaOrigen { get; set; }
        public string NRO_CUENTA_ORIGEN{ get; set; }

        public decimal SALDO_ORIGEN { get; set; }

        public IEnumerable<SelectListItem> CuentaDestino { get; set; }
        public string NRO_CUENTA_DESTINO { get; set; }
        public decimal SALDO_DESTINO { get; set; }
    }
}