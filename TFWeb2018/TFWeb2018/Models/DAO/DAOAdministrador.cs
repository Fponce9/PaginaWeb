using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFWeb2018.Models.DAO
{
    public class DAOAdministrador
    {
        public void AddAdmin(int id, int sueldo, string nombre, int edad, string correo,
           string username, string password)
        {
            TParcialEntities2 tstDb = new TParcialEntities2();
            Administrador admin = new Administrador
            {
                Sueldo = sueldo,
                Id_Admin = id
            };
            Persona p = new Persona
            {
                Id_Persona = id,
                Nombre = nombre,
                Edad = edad,
                Correo = correo,
                Username = username,
                Password = password
            };

            tstDb.Persona.Add(p);

            tstDb.Administrador.Add(admin);
            tstDb.SaveChanges();
        }
    }
}