using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TFWeb2018.Models;
using TFWeb2018.Models.DAO;

namespace TFWeb2018.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario

        private DAOJuegos DJ = new DAOJuegos();
        private DAOVenta DV = new DAOVenta();

        public ActionResult Index()
        {             
            //DV.AgregarVenta(18, 6, DateTime.Now.Date);
            return View(DJ.getJuegos());
        }


        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
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

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
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

        // GET: Usuario/Delete/5
        public ActionResult Delete(int idjuego, int idventas)
        {
            DDV.DeleteJuegoID(idjuego, idventas);
            return RedirectToAction("Carro_Ver");
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic her
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Carrito(int idjuego, int costo)
        {
            DDV.AgregarDetalle((int)(Session["idCompra"]), idjuego, costo, 1);            
            return View(DDV.GetVentasID(6,(int)(Session["idCompra"])));
        }

        DAODVenta DDV = new DAODVenta();

        public ActionResult Carro_Ver()
        {
            return View(DDV.GetVentasID(6, (int)(Session["idCompra"])));
        }

        public ActionResult Compras()
        {
            return View(DDV.getVentaID(6));
        }

       

    }
}
