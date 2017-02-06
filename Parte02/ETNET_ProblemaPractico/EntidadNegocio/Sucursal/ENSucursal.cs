using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.Sucursal
{
    [DataContract]
    public class ENSucursal
    {
        [DataMember]
        public int? CodigoSucursal { get; set; }
        [DataMember]
        public int? CodigoBanco { get; set; }
        [DataMember]
        public string Banco { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public DateTime FechaRegistro { get; set; }
    }
}
