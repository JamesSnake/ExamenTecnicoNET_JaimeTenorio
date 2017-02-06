using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.Banco
{
    [DataContract]
    public class ENBanco
    {
        [DataMember]
        public int? CodigoBanco { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
    }
}
