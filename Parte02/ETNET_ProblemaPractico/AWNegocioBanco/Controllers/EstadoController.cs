using AWNegocioBanco.Models;
using EntidadNegocio.Estado.Request;
using EntidadNegocio.Estado.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AWNegocioBanco.Controllers
{
    public class EstadoController : Controller
    {
        // GET: Estado
        public ActionResult Index()
        {
            SWNegocioBanco.SWNegocioBancoClient WS = new SWNegocioBanco.SWNegocioBancoClient();
            EstadoViewModel EstadoVW = new EstadoViewModel();
            EstadoResponse respuesta = new EstadoResponse();
            respuesta = WS.ConsultarEstado(new EstadoRequest());
            if (respuesta.CodigoError == 0)
                EstadoVW.ListaEstado = respuesta.ListaEstado;

            return View(EstadoVW);
        }

        // GET: Estado/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Estado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estado/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Estado/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Estado/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Estado/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Estado/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
