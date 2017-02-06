using EntidadNegocio.OrdenPago;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWNegocioBanco.Models
{
    public class OrdenPagoViewModel : ENOrdenPago
    {
        public List<ENOrdenPago> ListaOrdenPago { get; set; }

        //public List<BancoViewModel> ListaBancoCombo { get; set; }
        public List<SucursalViewModel> ListaSucursalCombo { get; set; }
        public List<MonedaViewModel> ListaMonedaCombo { get; set; }
        public List<EstadoViewModel> ListaEstadoCombo { get; set; }
    }
}