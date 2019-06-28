using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFWeb2018.Models.DAO
{
    public class DAOPersona
    {
        public bool ValidarLogIn(string User, string Password)
        {
            TParcialEntities2 tstDb = new TParcialEntities2();
            var lstPersonas = from k in tstDb.Persona where k.Username == User select k;
            foreach (var item in lstPersonas)
            {
                if (item.Username == User && item.Password == Password)
                    return true;
            }
            return false;
        }

        public Persona getPersona(string User)
        {
            TParcialEntities2    tstDb = new TParcialEntities2();
            Persona p = new Persona();
            var lstPersonas = from k in tstDb.Persona where k.Username == User select k;
            foreach (var item in lstPersonas)
            {
                if (item.Username == User)
                {
                    p.Id_Persona = item.Id_Persona;
                    p.Nombre = item.Nombre;
                    p.Usuario = item.Usuario;
                    p.Correo = item.Correo;
                    p.Password = item.Password;
                }
            }
            return p;
        }

        public List<Persona> getallPersonas()
        {
            TParcialEntities2 tstDb = new TParcialEntities2();
            List<Persona> lst = new List<Persona>();
            var lstPersonas = from k in tstDb.Persona select k;
            foreach (var item in lstPersonas)
            {

                Persona p = new Persona();
                p.Id_Persona = item.Id_Persona;
                p.Nombre = item.Nombre;
                p.Username = item.Username;
                p.Correo = item.Correo;
                p.Password = item.Password;
                p.Edad = item.Edad;
                lst.Add(p);
            }
            return lst;
        }

        public void deletePersona(int idPersona)
        {
            TParcialEntities2 tstDb = new TParcialEntities2();
            Persona person = new Persona();
            person.Id_Persona = idPersona;
            tstDb.Entry(person).State = System.Data.Entity.EntityState.Deleted;
            tstDb.SaveChanges();
        }
    }
}