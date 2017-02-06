using EntidadNegocio.Moneda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWNegocioBanco.Models
{
    public class MonedaViewModel : ENMoneda
    {
        public List<ENMoneda> ListaMoneda { get; set; }
    }
}