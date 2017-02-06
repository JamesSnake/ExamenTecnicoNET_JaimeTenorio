using EntidadNegocio.Estado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWNegocioBanco.Models
{
    public class EstadoViewModel : ENEstado
    {
        public List<ENEstado> ListaEstado { get; set; }
    }
}