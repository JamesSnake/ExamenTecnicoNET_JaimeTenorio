using AWNegocioBanco.Models;
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
using System.Web;
using System.Web.Mvc;

namespace AWNegocioBanco.Controllers
{
    public class OrdenPagoController : Controller
    {
        // GET: OrdenPago
        public ActionResult Index()
        {
            SWNegocioBanco.SWNegocioBancoClient WS = new SWNegocioBanco.SWNegocioBancoClient();
            OrdenPagoViewModel OrdenPagoVW = new OrdenPagoViewModel();
            OrdenPagoResponse respuesta = new OrdenPagoResponse();
            respuesta = WS.ConsultarOrdenPago(new OrdenPagoRequest());
            if (respuesta.CodigoError == 0)
                OrdenPagoVW.ListaOrdenPago = respuesta.ListaOrdenPago;

            return View(OrdenPagoVW);
        }

        // GET: OrdenPago/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrdenPago/Create
        public ActionResult Create()
        {
            SWNegocioBanco.SWNegocioBancoClient WS = new SWNegocioBanco.SWNegocioBancoClient();
            OrdenPagoViewModel OrdenPagoVW = new OrdenPagoViewModel();

            SucursalResponse respuestaSucursal = new SucursalResponse();
            respuestaSucursal = WS.ConsultarSucursal(new SucursalRequest());
            if (respuestaSucursal.CodigoError == 0)
                OrdenPagoVW.ListaSucursalCombo = respuestaSucursal.ListaSucursal.Select(e => new SucursalViewModel { CodigoSucursal = e.CodigoSucursal, Nombre = e.Nombre }).ToList();

            MonedaResponse respuestaMoneda = new MonedaResponse();
            respuestaMoneda = WS.ConsultarMoneda(new MonedaRequest());
            if (respuestaMoneda.CodigoError == 0)
                OrdenPagoVW.ListaMonedaCombo = respuestaMoneda.ListaMoneda.Select(e => new MonedaViewModel { CodigoMoneda = e.CodigoMoneda, Nombre = e.Nombre }).ToList(); ;

            EstadoResponse respuestaEstado = new EstadoResponse();
            respuestaEstado = WS.ConsultarEstado(new EstadoRequest());
            if (respuestaEstado.CodigoError == 0)
                OrdenPagoVW.ListaEstadoCombo = respuestaEstado.ListaEstado.Select(e => new EstadoViewModel { CodigoEstado = e.CodigoEstado, Nombre = e.Nombre }).ToList();

            return View(OrdenPagoVW);
        }

        // POST: OrdenPago/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                SWNegocioBanco.SWNegocioBancoClient WS = new SWNegocioBanco.SWNegocioBancoClient();
                OrdenPagoResponse respuesta = new OrdenPagoResponse();
                respuesta = WS.RegistrarOrdenPago(new OrdenPagoRequest
                {
                    CodigoSucursal = Int32.Parse(collection["CodigoSucursal"]),
                    Monto = Decimal.Parse(collection["Monto"]),
                    CodigoMoneda = Int32.Parse(collection["CodigoMoneda"]),
                    CodigoEstado = Int32.Parse(collection["CodigoEstado"]),
                    FechaPago = DateTime.Parse(collection["FechaPago"])
                });
                //if (respuesta.CodigoError == 0) 

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdenPago/Edit/5
        public ActionResult Edit(OrdenPagoViewModel item)
        {
            SWNegocioBanco.SWNegocioBancoClient WS = new SWNegocioBanco.SWNegocioBancoClient();

            SucursalResponse respuestaSucursal = new SucursalResponse();
            respuestaSucursal = WS.ConsultarSucursal(new SucursalRequest());
            if (respuestaSucursal.CodigoError == 0)
                item.ListaSucursalCombo = respuestaSucursal.ListaSucursal.Select(e => new SucursalViewModel { CodigoSucursal = e.CodigoSucursal, Nombre = e.Nombre }).ToList();

            MonedaResponse respuestaMoneda = new MonedaResponse();
            respuestaMoneda = WS.ConsultarMoneda(new MonedaRequest());
            if (respuestaMoneda.CodigoError == 0)
                item.ListaMonedaCombo = respuestaMoneda.ListaMoneda.Select(e => new MonedaViewModel { CodigoMoneda = e.CodigoMoneda, Nombre = e.Nombre }).ToList(); ;

            EstadoResponse respuestaEstado = new EstadoResponse();
            respuestaEstado = WS.ConsultarEstado(new EstadoRequest());
            if (respuestaEstado.CodigoError == 0)
                item.ListaEstadoCombo = respuestaEstado.ListaEstado.Select(e => new EstadoViewModel { CodigoEstado = e.CodigoEstado, Nombre = e.Nombre }).ToList();

            return View(item);
        }

        // POST: OrdenPago/Edit/5
        [HttpPost]
        public ActionResult Edit(OrdenPagoViewModel item, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                SWNegocioBanco.SWNegocioBancoClient WS = new SWNegocioBanco.SWNegocioBancoClient();
                OrdenPagoResponse respuesta = new OrdenPagoResponse();
                respuesta = WS.ActualizarOrdenPago(new OrdenPagoRequest
                {
                    CodigoOrdenPago = item.CodigoOrdenPago,
                    CodigoSucursal = item.CodigoSucursal,
                    Monto = item.Monto,
                    CodigoMoneda = item.CodigoMoneda,
                    CodigoEstado = item.CodigoEstado,
                    FechaPago = item.FechaPago
                });
                //if (respuesta.CodigoError == 0)

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdenPago/Delete/5
        public ActionResult Delete(OrdenPagoViewModel item)
        {
            return View(item);
        }

        // POST: OrdenPago/Delete/5
        [HttpPost]
        public ActionResult Delete(OrdenPagoViewModel item,FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                SWNegocioBanco.SWNegocioBancoClient WS = new SWNegocioBanco.SWNegocioBancoClient();
                OrdenPagoResponse respuesta = new OrdenPagoResponse();
                respuesta = WS.EliminarOrdenPago(new OrdenPagoRequest
                {
                    CodigoOrdenPago = item.CodigoOrdenPago
                });
                //if (respuesta.CodigoError == 0)

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
