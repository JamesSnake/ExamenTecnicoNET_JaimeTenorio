using EntidadNegocio.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.Moneda.Response
{
    [DataContract]
    public class MonedaResponse : GeneralResponse
    {
        [DataMember]
        public List<ENMoneda> ListaMoneda { get; set; }

        public MonedaResponse()
        {
            this.ListaMoneda = new List<ENMoneda>();
        }
    }
}
