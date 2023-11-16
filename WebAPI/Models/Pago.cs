using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Pago
    {
        public int IdPago { get; set; }
        public DateTime Fecha { get; set; }
        public int Monto { get; set; }
    }
}