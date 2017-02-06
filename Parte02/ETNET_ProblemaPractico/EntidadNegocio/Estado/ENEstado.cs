using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.Estado
{
    [DataContract]
    public class ENEstado
    {
        [DataMember]
        public int? CodigoEstado { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Abreviatura { get; set; }
    }
}
