using EntidadNegocio.Sucursal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AWNegocioBanco.Models
{
    public class SucursalViewModel : ENSucursal
    {
        public List<BancoViewModel> ListaBancoCombo { get; set; }

        public List<ENSucursal> ListaSucursal { get; set; }
    }
}