using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TFWeb2018.Models.DAO
{
    public class DAOVenta
    {
        public bool AgregarVenta(int Id_Venta, int ID_Usuario, DateTime fecha)
        {
            TParcialEntities2 tstdb = new TParcialEntities2();
            Venta venta = new Venta
            {
                Id_Venta = Id_Venta,
                Id_Usuario = ID_Usuario,
                Fecha = fecha
            };
            tstdb.Venta.Add(venta);
            tstdb.SaveChanges();
            return true;
        }

        public List<Venta> GetVentas()
        {
            List<Venta> lstventa = new List<Venta>();
            TParcialEntities2 tstdb = new TParcialEntities2();
            var lst = from k in tstdb.Venta select k;
            foreach (var item in lst)
            {
                Venta v = new Venta();
                v.Id_Venta = item.Id_Venta;
                lstventa.Add(v);
            }
            return lstventa;
        }
    }
}