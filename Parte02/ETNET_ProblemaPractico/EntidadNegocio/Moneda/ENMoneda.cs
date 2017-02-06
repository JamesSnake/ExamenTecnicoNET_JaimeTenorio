using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.Moneda
{
    [DataContract]
    public class ENMoneda
    {
        [DataMember]
        public int? CodigoMoneda { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Abreviatura { get; set; }
         
    }
}
