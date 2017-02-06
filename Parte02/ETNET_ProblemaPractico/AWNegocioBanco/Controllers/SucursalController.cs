using AWNegocioBanco.Models;
using EntidadNegocio.Banco.Request;
using EntidadNegocio.Banco.Response;
using EntidadNegocio.Sucursal.Request;
using EntidadNegocio.Sucursal.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AWNegocioBanco.Controllers
{
    public class SucursalController : Controller
    {
        // GET: Sucursal
        public ActionResult Index()
        {
            SWNegocioBanco.SWNegocioBancoClient WS = new SWNegocioBanco.SWNegocioBancoClient();
            SucursalViewModel SucursalVW = new SucursalViewModel();
            SucursalResponse respuesta = new SucursalResponse();
            respuesta = WS.ConsultarSucursal(new SucursalRequest());
            if (respuesta.CodigoError == 0)
                SucursalVW.ListaSucursal = respuesta.ListaSucursal;

            return View(SucursalVW);
        }

        // GET: Sucursal/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sucursal/Create
        public ActionResult Create()
        {
            SWNegocioBanco.SWNegocioBancoClient WS = new SWNegocioBanco.SWNegocioBancoClient();
            SucursalViewModel SucursalVW = new SucursalViewModel();
            BancoResponse respuesta = new BancoResponse();
            respuesta = WS.ConsultarBanco(new BancoRequest());
            if (respuesta.CodigoError == 0)
                SucursalVW.ListaBancoCombo = respuesta.ListaBanco.Select( e => new BancoViewModel { CodigoBanco = e.CodigoBanco,Nombre = e.Nombre}).ToList();

            return View(SucursalVW);
        }

        // POST: Sucursal/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                SWNegocioBanco.SWNegocioBancoClient WS = new SWNegocioBanco.SWNegocioBancoClient();
                SucursalResponse respuesta = new SucursalResponse();
                respuesta = WS.RegistrarSucursal(new SucursalRequest
                {
                    CodigoBanco = Int32.Parse(collection["CodigoBanco"]),
                    Nombre = collection["Nombre"],
                    Direccion = collection["Direccion"],
                    FechaRegistro = DateTime.Now
                });
                //if (respuesta.CodigoError == 0) 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sucursal/Edit/5
        public ActionResult Edit(SucursalViewModel item)
        {

            SWNegocioBanco.SWNegocioBancoClient WS = new SWNegocioBanco.SWNegocioBancoClient();
            BancoResponse respuesta = new BancoResponse();
            respuesta = WS.ConsultarBanco(new BancoRequest());
            if (respuesta.CodigoError == 0)
                item.ListaBancoCombo = respuesta.ListaBanco.Select(e => new BancoViewModel { CodigoBanco = e.CodigoBanco, Nombre = e.Nombre }).ToList();

            return View(item);
        }

        // POST: Sucursal/Edit/5
        [HttpPost]
        public ActionResult Edit(SucursalViewModel item, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                SWNegocioBanco.SWNegocioBancoClient WS = new SWNegocioBanco.SWNegocioBancoClient();
                SucursalResponse respuesta = new SucursalResponse();
                respuesta = WS.ActualizarSucursal(new SucursalRequest
                {
                    CodigoSucursal = item.CodigoSucursal,
                    CodigoBanco = item.CodigoBanco,
                    Nombre = item.Nombre,
                    Direccion = item.Direccion,
                    FechaRegistro = item.FechaRegistro
                });
                //if (respuesta.CodigoError == 0) 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sucursal/Delete/5
        public ActionResult Delete(SucursalViewModel item)
        {
            return View(item);
        }

        // POST: Sucursal/Delete/5
        [HttpPost]
        public ActionResult Delete(SucursalViewModel item, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                SWNegocioBanco.SWNegocioBancoClient WS = new SWNegocioBanco.SWNegocioBancoClient();
                SucursalResponse respuesta = new SucursalResponse();
                respuesta = WS.EliminarSucursal(new SucursalRequest
                {
                    CodigoSucursal = item.CodigoSucursal
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
