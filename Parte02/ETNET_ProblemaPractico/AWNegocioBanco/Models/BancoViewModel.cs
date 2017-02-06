using EntidadNegocio.Banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWNegocioBanco.Models
{
    public class BancoViewModel : ENBanco
    {
        public List<ENBanco> ListaBanco { get; set; }
    }
}