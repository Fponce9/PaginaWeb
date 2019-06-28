using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFWeb2018.Models.DAO
{
    public class DAOJuegos
    {
        public List<Juego> getJuegos()
        {
            TParcialEntities2 tstDb = new TParcialEntities2();
            List<Juego> lstjuego = new List<Juego>();
            var lstPersonas = from k in tstDb.Juego select k;
            foreach (var item in lstPersonas)
            {
                Juego game = new Juego();
                game.Nombre = item.Nombre;
                game.Precio = item.Precio;
                game.Descripcion = item.Descripcion;
                game.Id_Juego = item.Id_Juego;
                game.Foto = item.Foto;
                lstjuego.Add(game);
            }
            return lstjuego;
        }
        public Juego getJuego(int ID)
        {
            TParcialEntities2 tstDb = new TParcialEntities2();
            Juego Objuego = new Juego();
            var lstPersonas = from k in tstDb.Juego where k.Id_Juego == ID select k;
            foreach (var item in lstPersonas)
            {
                Objuego.Nombre = item.Nombre;
                Objuego.Precio = item.Precio;
                Objuego.Descripcion = item.Descripcion;
                Objuego.Id_Juego = item.Id_Juego;
                Objuego.Foto = item.Foto;
            }
            return Objuego;
        }

        public void addJuego(int id, string Nombre, int Precio, string Descripcion)
        {
            TParcialEntities2 tstDb = new TParcialEntities2();
            string foto = "/Fotos/07.jpg";
            Juego jogo = new Juego
            {
                Id_Juego = id,
                Nombre = Nombre,
                Precio = Precio,
                Descripcion = Descripcion,
                Foto = foto
            };
            tstDb.Juego.Add(jogo);
            tstDb.SaveChanges();
        }

        public void deleteJuego(int id)
        {
            TParcialEntities2 tstDb = new TParcialEntities2();
            Juego guemu = new Juego();
            guemu.Id_Juego = id;
            tstDb.Entry(guemu).State = System.Data.Entity.EntityState.Deleted;
            tstDb.SaveChanges();
        }
    }
}