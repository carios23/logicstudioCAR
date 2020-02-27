using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solucion_CAR.Models
{
    public class FacturaMasterDetailModel
    {
        public Factura Factura { get; set; }
        public List<Detalle> Detalles { get; set; }

        public List<Pago> Pagoes { get; set; }
        public decimal? TotalDetalles { get; set; }
        public decimal? TotalPagoes { get; set; }
        public decimal? Saldo { get; set; }
    }
}