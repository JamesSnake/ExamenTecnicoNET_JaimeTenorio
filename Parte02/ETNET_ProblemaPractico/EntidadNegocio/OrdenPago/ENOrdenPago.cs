using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.OrdenPago
{
    [DataContract]
    public class ENOrdenPago
    {
        [DataMember]
        public int? CodigoOrdenPago { get; set; }
        [DataMember]
        public int? CodigoSucursal { get; set; }
        [DataMember]
        public string Sucursal { get; set; }
        [DataMember]
        public decimal Monto { get; set; }
        [DataMember]
        public int? CodigoMoneda { get; set; }
        [DataMember]
        public string Moneda { get; set; }
        [DataMember]
        public int? CodigoEstado { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public DateTime FechaPago { get; set; } 
    }
}
