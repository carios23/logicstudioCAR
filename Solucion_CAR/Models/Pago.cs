//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Solucion_CAR.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pago
    {
        public System.Guid pagosId { get; set; }
        public Nullable<System.Guid> facturaId { get; set; }
        public Nullable<bool> pagada { get; set; }
        public Nullable<System.DateTime> fechadepago { get; set; }
    
        public virtual Factura Factura { get; set; }
    }
}
