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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ISWNegocioBanco" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ISWNegocioBanco
    {
        #region Consultas

        [OperationContract]
        BancoResponse ConsultarBanco(BancoRequest filtro);

        [OperationContract]
        SucursalResponse ConsultarSucursal(SucursalRequest filtro);

        [OperationContract]
        OrdenPagoResponse ConsultarOrdenPago(OrdenPagoRequest filtro);

        [OperationContract]
        MonedaResponse ConsultarMoneda(MonedaRequest filtro);

        [OperationContract]
        EstadoResponse ConsultarEstado(EstadoRequest filtro);
        #endregion

        #region Registro

        [OperationContract]
        BancoResponse RegistrarBanco(BancoRequest filtro);

        [OperationContract]
        SucursalResponse RegistrarSucursal(SucursalRequest filtro);

        [OperationContract]
        EstadoResponse RegistrarEstado(EstadoRequest filtro);

        [OperationContract]
        MonedaResponse RegistrarMoneda(MonedaRequest filtro);

        [OperationContract]
        OrdenPagoResponse RegistrarOrdenPago(OrdenPagoRequest filtro);

        #endregion

        #region Actualizacion

        [OperationContract]
        BancoResponse ActualizarBanco(BancoRequest filtro);

        [OperationContract]
        SucursalResponse ActualizarSucursal(SucursalRequest filtro);

        [OperationContract]
        EstadoResponse ActualizarEstado(EstadoRequest filtro);

        [OperationContract]
        MonedaResponse ActualizarMoneda(MonedaRequest filtro);

        [OperationContract]
        OrdenPagoResponse ActualizarOrdenPago(OrdenPagoRequest filtro);

        #endregion

        #region Eliminacion

        [OperationContract]
        BancoResponse EliminarBanco(BancoRequest filtro);

        [OperationContract]
        SucursalResponse EliminarSucursal(SucursalRequest filtro);

        [OperationContract]
        EstadoResponse EliminarEstado(EstadoRequest filtro);

        [OperationContract]
        MonedaResponse EliminarMoneda(MonedaRequest filtro);

        [OperationContract]
        OrdenPagoResponse EliminarOrdenPago(OrdenPagoRequest filtro);

        #endregion
    }
}
