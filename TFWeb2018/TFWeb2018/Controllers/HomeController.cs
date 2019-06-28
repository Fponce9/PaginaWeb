using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TFWeb2018.Models;
using TFWeb2018.Models.DAO;

namespace TFWeb2018.Controllers
{
    public class HomeController : Controller
    {
        DAOVenta DV = new DAOVenta();
        public ActionResult Index()
        {
            var list = DV.GetVentas();
            int id = list.Count;
            Session["idCompra"] = id + 2;            
            DV.AgregarVenta((int)(Session["idCompra"]), 6, DateTime.Now.Date);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "La mejor pagina web de videojuegos del Perú.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Iniciar_Sesion()
        {
            return View();
        }

        UsuarioController uc = new UsuarioController();
        DAOPersona DP = new DAOPersona();
        [HttpPost]
        public ActionResult Iniciar_Sesion(Persona person)
        {
            Session["Sesion"] = 0;  
            if (DP.ValidarLogIn(person.Username, person.Password))
            {
                if (person.Username == "admin")
                    Session["Sesion"] = 2;
                else
                    Session["Sesion"] = 1;
                
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Iniciar_Sesion");
        }

        public ActionResult Home_Logout()
        {
            Session["Sesion"] = 0;
            return View();
        }

        public ActionResult crear_cuenta()
        {
            return View();
        }

        DAOUsuario DU = new DAOUsuario();
        [HttpPost]
        public ActionResult crear_cuenta(Persona person)
        {
            List<Persona> lst = DP.getallPersonas();
            DU.addUsuario(lst.Count + 2,"Default", "Default", person.Nombre, person.Edad, person.Correo, person.Username, person.Password);
            return RedirectToAction("Iniciar_Sesion");
        }
    }
}