using EntidadNegocio.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.OrdenPago.Response
{
    [DataContract]
    public class OrdenPagoResponse: GeneralResponse
    {
        [DataMember]
        public List<ENOrdenPago> ListaOrdenPago { get; set; }

        public OrdenPagoResponse()
        {
            this.ListaOrdenPago = new List<ENOrdenPago>();
        }
    }
}
