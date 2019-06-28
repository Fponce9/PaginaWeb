using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFWeb2018.Models.DAO
{
    public class DAOUsuario
    {
        public bool addUsuario(int id, string apodo, string descripcion, string nombre, int edad, string correo,
            string username, string password)
        {

            TParcialEntities2 tstDb = new TParcialEntities2();
            UsuariosCreae uc = new UsuariosCreae();
            Usuario user = new Usuario
            {
                Id_Usuario = id,
                Apodo = apodo,
                Descripcion = descripcion,
                Saldo = 0,

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
            
            if (uc.TieneMasDeDieciOcho(p.Edad))
            {
                tstDb.Persona.Add(p);
                tstDb.Usuario.Add(user);
                tstDb.SaveChanges();
                return true;
            }
            return false;
        }
        public void deleteUsuario(int idPersona)
        {
            TParcialEntities2 tstDb = new TParcialEntities2();
            Usuario user = new Usuario();
            user.Id_Usuario = idPersona;
            tstDb.Entry(user).State = System.Data.Entity.EntityState.Deleted;
            tstDb.SaveChanges();
        }
    }
}