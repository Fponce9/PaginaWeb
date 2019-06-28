using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TFWeb2018.Models;
using TFWeb2018.Models.DAO;

namespace TFWeb2018.Controllers
{
    public class AdministradorController : Controller
    {
        // GET: Administador
        public ActionResult Index()
        {
            return View();
        }

        // GET: Administador/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Administador/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Administador/Create
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

        // GET: Administador/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administador/Edit/5
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

        // GET: Administador/Delete/5
        public ActionResult Delete(int id)
        {
            DJ.deleteJuego(id);
            return RedirectToAction("Juegos");
        }

        // POST: Administador/Delete/5
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

        DAOPersona DP = new DAOPersona();

        public ActionResult Control_Usuarios()
        {
            return View(DP.getallPersonas());
        }
        DAOJuegos DJ = new DAOJuegos();
        public ActionResult Juegos()
        {
            return View(DJ.getJuegos());
        }

        public ActionResult Juegos_new()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Juegos_new(Juego juego, HttpPostedFileBase fileBase)
        {
            
            DJ.addJuego(7, juego.Nombre, juego.Precio, juego.Descripcion);
            return RedirectToAction("Juegos");
        }
        DAOUsuario DU = new DAOUsuario();
        public ActionResult Delete_User(int idPersona)
        {
            DU.deleteUsuario(idPersona);
            DP.deletePersona(idPersona);            
            return RedirectToAction("Control_Usuarios");
        }

    }
}
