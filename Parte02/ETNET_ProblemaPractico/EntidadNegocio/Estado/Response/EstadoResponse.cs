using EntidadNegocio.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.Estado.Response
{
    [DataContract]
    public class EstadoResponse : GeneralResponse
    {
        [DataMember]
        public List<ENEstado> ListaEstado { get; set; }

        public EstadoResponse()
        {
            this.ListaEstado = new List<ENEstado>();
        }
    }
}
