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
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFNegocio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "SWNegocioBanco" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione SWNegocioBanco.svc o SWNegocioBanco.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class SWNegocioBanco : ISWNegocioBanco
    {
        #region Consultas

        public BancoResponse ConsultarBanco(BancoRequest filtro)
        {
            LNNegocio LN = new LNNegocio();
            return LN.ConsultarBanco(filtro);
        }

        public SucursalResponse ConsultarSucursal(SucursalRequest filtro)
        {
            LNNegocio LN = new LNNegocio();
            return LN.ConsultarSucursal(filtro);
        }

        public OrdenPagoResponse ConsultarOrdenPago(OrdenPagoRequest filtro)
        {
            LNNegocio LN = new LNNegocio();
            return LN.ConsultarOrdenPago(filtro);
        }

        public MonedaResponse ConsultarMoneda(MonedaRequest filtro)
        {
            LNNegocio LN = new LNNegocio();
            return LN.ConsultarMoneda(filtro);
        }

        public EstadoResponse ConsultarEstado(EstadoRequest filtro)
        {
            LNNegocio LN = new LNNegocio();
            return LN.ConsultarEstado(filtro);
        }
        #endregion

        #region Registro

        public BancoResponse RegistrarBanco(BancoRequest filtro)
        {
            LNNegocio LN = new LNNegocio();
            return LN.RegistrarBanco(filtro);
        }

        public SucursalResponse RegistrarSucursal(SucursalRequest filtro)
        {
            LNNegocio LN = new LNNegocio();
            return LN.RegistrarSucursal(filtro);
        }

        public EstadoResponse RegistrarEstado(EstadoRequest filtro)
        {
            LNNegocio LN = new LNNegocio();
            return LN.RegistrarEstado(filtro);
        }

        public MonedaResponse RegistrarMoneda(MonedaRequest filtro)
        {
            LNNegocio LN = new LNNegocio();
            return LN.RegistrarMoneda(filtro);
        }

        public OrdenPagoResponse RegistrarOrdenPago(OrdenPagoRequest filtro)
        {
            LNNegocio LN = new LNNegocio();
            return LN.RegistrarOrdenPago(filtro);
        }

        #endregion

        #region Actualizacion

        public BancoResponse ActualizarBanco(BancoRequest filtro)
        {
            LNNegocio LN = new LNNegocio();
            return LN.ActualizarBanco(filtro);
        }

        public SucursalResponse ActualizarSucursal(SucursalRequest filtro)
        {
            LNNegocio LN = new LNNegocio();
            return LN.ActualizarSucursal(filtro);
        }

        public EstadoResponse ActualizarEstado(EstadoRequest filtro)
        {
            LNNegocio LN = new LNNegocio();
            return LN.ActualizarEstado(filtro);
        }

        public MonedaResponse ActualizarMoneda(MonedaRequest filtro)
        {
            LNNegocio LN = new LNNegocio();
            return LN.ActualizarMoneda(filtro);
        }

        public OrdenPagoResponse ActualizarOrdenPago(OrdenPagoRequest filtro)
        {
            LNNegocio DA = new LNNegocio();
            return DA.ActualizarOrdenPago(filtro);
        }

        #endregion

        #region Eliminacion

        public BancoResponse EliminarBanco(BancoRequest filtro)
        {
            LNNegocio LN = new LNNegocio();
            return LN.EliminarBanco(filtro);
        }

        public SucursalResponse EliminarSucursal(SucursalRequest filtro)
        {
            LNNegocio LN = new LNNegocio();
            return LN.EliminarSucursal(filtro);
        }

        public EstadoResponse EliminarEstado(EstadoRequest filtro)
        {
            LNNegocio LN = new LNNegocio();
            return LN.EliminarEstado(filtro);
        }

        public MonedaResponse EliminarMoneda(MonedaRequest filtro)
        {
            LNNegocio LN = new LNNegocio();
            return LN.EliminarMoneda(filtro);
        }

        public OrdenPagoResponse EliminarOrdenPago(OrdenPagoRequest filtro)
        {
            LNNegocio LN = new LNNegocio();
            return LN.EliminarOrdenPago(filtro);
        }

        #endregion
    }
}
