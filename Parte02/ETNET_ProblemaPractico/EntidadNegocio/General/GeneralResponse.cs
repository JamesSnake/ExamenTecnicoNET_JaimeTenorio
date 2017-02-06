using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntidadNegocio.General
{
    [DataContract]
    public class GeneralResponse
    {
        [DataMember]
        public int CodigoError { get; set; }
        [DataMember]
        public string DescripcionError { get; set; }

        public GeneralResponse()
        {
            this.CodigoError = 0;
            this.DescripcionError = "";
        }
    }

    
}
