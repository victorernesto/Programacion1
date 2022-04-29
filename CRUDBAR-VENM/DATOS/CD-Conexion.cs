using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DATOS
{
    public class Class1
    {
        private SqlConnection conexion = new SqlConnection("SERVER=LAPTOP-BMEUKCRG; DATABASE=Proyecto1; integrated security=true");

        public SqlConnection CERRAR()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
            return conexion;


        }

        public SqlConnection ABRIR()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
            return conexion;


        }
    }
}
