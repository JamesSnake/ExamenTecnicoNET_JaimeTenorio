using AWNegocioBanco.Models;
using EntidadNegocio.Moneda.Request;
using EntidadNegocio.Moneda.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AWNegocioBanco.Controllers
{
    public class MonedaController : Controller
    {
        // GET: Moneda
        public ActionResult Index()
        {
            SWNegocioBanco.SWNegocioBancoClient WS = new SWNegocioBanco.SWNegocioBancoClient();
            MonedaViewModel MonedaVW = new MonedaViewModel();
            MonedaResponse respuesta = new MonedaResponse();
            respuesta = WS.ConsultarMoneda(new MonedaRequest());
            if (respuesta.CodigoError == 0)
                MonedaVW.ListaMoneda = respuesta.ListaMoneda;

            return View(MonedaVW);
        }

        // GET: Moneda/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Moneda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Moneda/Create
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

        // GET: Moneda/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Moneda/Edit/5
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

        // GET: Moneda/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Moneda/Delete/5
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
