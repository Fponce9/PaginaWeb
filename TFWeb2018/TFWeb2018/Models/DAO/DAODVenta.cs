using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFWeb2018.Models.DAO
{
    public class DAODVenta
    {
        public void AgregarDetalle(int ID_Venta, int ID_Juego, int importe, int Cantidad)
        {
            TParcialEntities2 tstDb = new TParcialEntities2();

            Detalle_Venta DV = new Detalle_Venta
            {
                Id_Juego = ID_Juego,
                Id_Venta = ID_Venta,
                Importe = importe,
                Cantidad = Cantidad
            };

            tstDb.Detalle_Venta.Add(DV);
            tstDb.SaveChanges();
        }
        public List<Juego> getVentaID(int ID)
        {
            List<Juego> vtn = new List<Juego>();
            TParcialEntities2 tstDb = new TParcialEntities2();
            var lstPersonas = from k in tstDb.Venta
                              join j in tstDb.Detalle_Venta
        on k.Id_Venta equals j.Id_Venta
                              join l in tstDb.Juego on j.Id_Juego equals l.Id_Juego
                              where k.Id_Usuario == ID
                              select new
                              { Venta = k, Detalle_Venta = j, Juego = l };

            foreach (var item in lstPersonas)
            {
                Juego v = new Juego();
                v.Id_Juego = item.Venta.Id_Venta;
                v.Nombre = item.Juego.Nombre;
                v.Precio = item.Detalle_Venta.Importe;
                v.Descripcion = item.Juego.Descripcion;
                v.Foto = item.Venta.Fecha.ToString();
                vtn.Add(v);
            }
            return vtn;
        }
        public List<Juego> getAllVentas()
        {
            List<Juego> vtn = new List<Juego>();
            TParcialEntities2 tstDb = new TParcialEntities2();
            var lstPersonas = from k in tstDb.Venta
                              join j in tstDb.Detalle_Venta
                              on k.Id_Venta equals j.Id_Venta
                              join l in tstDb.Juego on j.Id_Juego equals l.Id_Juego
                              select new
                              { Venta = k, Detalle_Venta = j, Juego = l };

            foreach (var item in lstPersonas)
            {
                Juego v = new Juego();
                v.Id_Juego = item.Venta.Id_Venta;
                v.Nombre = item.Juego.Nombre;
                v.Precio = item.Detalle_Venta.Importe;
                v.Descripcion = item.Juego.Descripcion;
                vtn.Add(v);
            }
            return vtn;
        }

        public List<Juego> GetVentasID( int ID, int IDVenta)
        {
            List<Juego> vtn = new List<Juego>();
            TParcialEntities2 tstDb = new TParcialEntities2();
            var lstPersonas = from k in tstDb.Venta
                              join j in tstDb.Detalle_Venta
            on k.Id_Venta equals j.Id_Venta
                              join l in tstDb.Juego on j.Id_Juego equals l.Id_Juego
                              where k.Id_Usuario == ID && j.Id_Venta == IDVenta
                              select new
                              { Venta = k, Detalle_Venta = j, Juego = l };

            foreach (var item in lstPersonas)
            {
                Juego v = new Juego();
                v.Id_Juego = item.Detalle_Venta.Id_Juego;
                v.Nombre = item.Juego.Nombre;
                v.Precio = item.Detalle_Venta.Importe;
                v.Descripcion = item.Juego.Descripcion;
                vtn.Add(v);
            }
            return vtn;
        }

        public void DeleteJuegoID(int idjuego, int idventa)
        {
            TParcialEntities2 tstDb = new TParcialEntities2();
            Detalle_Venta detalle = new Detalle_Venta();
            detalle.Id_Juego = idjuego;
            detalle.Id_Venta = idventa;
            tstDb.Entry(detalle).State = System.Data.Entity.EntityState.Deleted;
            tstDb.SaveChanges();
        }
    }
}