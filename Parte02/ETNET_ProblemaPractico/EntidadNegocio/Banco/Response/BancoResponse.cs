using EntidadNegocio.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.Banco.Response
{
    [DataContract]
    public class BancoResponse : GeneralResponse
    {
        [DataMember]
        public List<ENBanco> ListaBanco { get; set; }

        public BancoResponse()
        {
            this.ListaBanco = new List<ENBanco>();
        }
    }
}
