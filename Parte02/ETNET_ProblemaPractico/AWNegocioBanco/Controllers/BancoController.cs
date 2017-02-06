using AWNegocioBanco.Models;
using EntidadNegocio.Banco.Request;
using EntidadNegocio.Banco.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AWNegocioBanco.Controllers
{
    public class BancoController : Controller
    {
        // GET: Banco
        public ActionResult Index()
        {
            SWNegocioBanco.SWNegocioBancoClient  WS = new SWNegocioBanco.SWNegocioBancoClient();
            BancoViewModel BancoVW = new BancoViewModel();
            BancoResponse respuesta = new BancoResponse();
            respuesta = WS.ConsultarBanco(new BancoRequest());
            if (respuesta.CodigoError == 0)
                BancoVW.ListaBanco = respuesta.ListaBanco;

            return View(BancoVW);
        }

        // GET: Banco/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Banco/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Banco/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                SWNegocioBanco.SWNegocioBancoClient WS = new SWNegocioBanco.SWNegocioBancoClient();
                BancoResponse respuesta = new BancoResponse();
                respuesta = WS.RegistrarBanco(new BancoRequest {
                     Nombre = collection["Nombre"],
                     Direccion = collection["Direccion"],
                     FechaRegistro = DateTime.Parse(collection["FechaRegistro"])
                });
                //if (respuesta.CodigoError == 0)     
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Banco/Edit/5
        public ActionResult Edit(BancoViewModel  item)
        {
            return View(item);
        }

        // POST: Banco/Edit/5
        [HttpPost]
        public ActionResult Edit(BancoViewModel item, FormCollection collection)
        { //int id,
            try
            {
                // TODO: Add update logic here
                SWNegocioBanco.SWNegocioBancoClient WS = new SWNegocioBanco.SWNegocioBancoClient();
                BancoResponse respuesta = new BancoResponse();
                respuesta = WS.ActualizarBanco(new BancoRequest
                {
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

        // GET: Banco/Delete/5
        public ActionResult Delete(BancoViewModel item)
        {
            return View(item);
        }

        // POST: Banco/Delete/5
        [HttpPost]
        public ActionResult Delete(BancoViewModel item, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                SWNegocioBanco.SWNegocioBancoClient WS = new SWNegocioBanco.SWNegocioBancoClient();
                BancoResponse respuesta = new BancoResponse();
                respuesta = WS.EliminarBanco(new BancoRequest
                {
                    CodigoBanco = item.CodigoBanco
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
