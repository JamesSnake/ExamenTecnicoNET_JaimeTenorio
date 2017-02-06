using EntidadNegocio.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.Sucursal.Response
{
    [DataContract]
    public class SucursalResponse : GeneralResponse
    {
        [DataMember]
        public List<ENSucursal> ListaSucursal { get; set; }

        public SucursalResponse()
        {
            this.ListaSucursal = new List<ENSucursal>();
        }
    }
}
