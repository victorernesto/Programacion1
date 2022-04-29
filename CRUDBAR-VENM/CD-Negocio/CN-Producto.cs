using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using DATOS;


namespace CD_Negocio
{
    public class Class1
    {
        private CD_Producto objetoCD = new CD_Producto();

        public DataTable Leerprod()
        {
            DataTable tabla = new DataTable();
            tabla = object.Mostrar();

            return tabla;

        }

        public void IsnProd(string nombrep,string descripcion, string precio, string cantida,string estado)
        {
            object.Insertar(nombrep, descripcion, Convert.ToDouble(precio), Convert.ToInt32(cantida), Convert.ToInt32(estado));

        }

        public void ActPro(string nombrep, string descripcion, string precio, string cantida, string estado)
        {
            object.Actualizar(nombrep, descripcion, Convert.ToDouble(precio), Convert.ToInt32(cantida), Convert.ToInt32(estado));
        }

        public void EliPro(string idproducto)
        {
            object.Eliminar(Convert.ToInt32(idproducto));
        }
    }
}
