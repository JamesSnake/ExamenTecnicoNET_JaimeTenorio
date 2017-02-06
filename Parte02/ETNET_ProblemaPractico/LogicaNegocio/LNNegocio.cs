using AccesoData;
using EntidadNegocio.Banco.Request;
using EntidadNegocio.Banco.Response;
using EntidadNegocio.Estado.Request;
using EntidadNegocio.Estado.Response;
using EntidadNegocio.Moneda.Request;
using EntidadNegocio.Moneda.Response;
using EntidadNegocio.OrdenPago.Request;
using EntidadNegocio.OrdenPago.Response;
using EntidadNegocio.Sucursal.Request;
using EntidadNegocio.Sucursal.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class LNNegocio
    {
        #region Consultas

        public BancoResponse ConsultarBanco(BancoRequest filtro)
        {
            ADNegocio DA = new ADNegocio();
            return DA.ConsultarBanco(filtro);
        }

        public SucursalResponse ConsultarSucursal(SucursalRequest filtro)
        {
            ADNegocio DA = new ADNegocio();
            return DA.ConsultarSucursal(filtro);
        }

        public OrdenPagoResponse ConsultarOrdenPago(OrdenPagoRequest filtro)
        {
            ADNegocio DA = new ADNegocio();
            return DA.ConsultarOrdenPago(filtro);
        }

        public MonedaResponse ConsultarMoneda(MonedaRequest filtro)
        {
            ADNegocio DA = new ADNegocio();
            return DA.ConsultarMoneda(filtro);
        }

        public EstadoResponse ConsultarEstado(EstadoRequest filtro)
        {
            ADNegocio DA = new ADNegocio();
            return DA.ConsultarEstado(filtro);
        }
        #endregion

        #region Registro

        public BancoResponse RegistrarBanco(BancoRequest filtro)
        {
            ADNegocio DA = new ADNegocio();
            return DA.RegistrarBanco(filtro);
        }

        public SucursalResponse RegistrarSucursal(SucursalRequest filtro)
        {
            ADNegocio DA = new ADNegocio();
            return DA.RegistrarSucursal(filtro);
        }

        public EstadoResponse RegistrarEstado(EstadoRequest filtro)
        {
            ADNegocio DA = new ADNegocio();
            return DA.RegistrarEstado(filtro);
        }

        public MonedaResponse RegistrarMoneda(MonedaRequest filtro)
        {
            ADNegocio DA = new ADNegocio();
            return DA.RegistrarMoneda(filtro);
        }

        public OrdenPagoResponse RegistrarOrdenPago(OrdenPagoRequest filtro)
        {
            ADNegocio DA = new ADNegocio();
            return DA.RegistrarOrdenPago(filtro);
        }

        #endregion

        #region Actualizacion

        public BancoResponse ActualizarBanco(BancoRequest filtro)
        {
            ADNegocio DA = new ADNegocio();
            return DA.ActualizarBanco(filtro);
        }

        public SucursalResponse ActualizarSucursal(SucursalRequest filtro)
        {
            ADNegocio DA = new ADNegocio();
            return DA.ActualizarSucursal(filtro);
        }

        public EstadoResponse ActualizarEstado(EstadoRequest filtro)
        {
            ADNegocio DA = new ADNegocio();
            return DA.ActualizarEstado(filtro);
        }

        public MonedaResponse ActualizarMoneda(MonedaRequest filtro)
        {
            ADNegocio DA = new ADNegocio();
            return DA.ActualizarMoneda(filtro);
        }

        public OrdenPagoResponse ActualizarOrdenPago(OrdenPagoRequest filtro)
        {
            ADNegocio DA = new ADNegocio();
            return DA.ActualizarOrdenPago(filtro);
        }

        #endregion

        #region Eliminacion

        public BancoResponse EliminarBanco(BancoRequest filtro)
        {
            ADNegocio DA = new ADNegocio();
            return DA.EliminarBanco(filtro);
        }

        public SucursalResponse EliminarSucursal(SucursalRequest filtro)
        {
            ADNegocio DA = new ADNegocio();
            return DA.EliminarSucursal(filtro);
        }

        public EstadoResponse EliminarEstado(EstadoRequest filtro)
        {
            ADNegocio DA = new ADNegocio();
            return DA.EliminarEstado(filtro);
        }

        public MonedaResponse EliminarMoneda(MonedaRequest filtro)
        {
            ADNegocio DA = new ADNegocio();
            return DA.EliminarMoneda(filtro);
        }

        public OrdenPagoResponse EliminarOrdenPago(OrdenPagoRequest filtro)
        {
            ADNegocio DA = new ADNegocio();
            return DA.EliminarOrdenPago(filtro);
        }

        #endregion
    }
}
