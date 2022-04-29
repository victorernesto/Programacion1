using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DATOS
{
    class CD_Producto
    {
        //Cambie el nombre de la class1 a CD-Conexion pero no melo cambio en el codigo
        private Class1 conexion = new Class1();
        SqlCommand comando = new SqlCommand();
        DataTable tabla = new DataTable();
        SqlDataReader Leer;

        public DataTable Mostrar()
        {

            comando.Connection = conexion.ABRIR();
            comando.CommandText = "MostrarProcuctos";
            comando.CommandType = CommandType.StoredProcedure;
            Leer = comando.ExecuteReader();
            tabla.Load(Leer);
            conexion.CERRAR();
            return tabla;

        }

        public void Insertar(string nombre, string desc, float precio, int cantida, int estado)
        {
            comando.Connection = conexion.ABRIR();
            comando.Parameters.AddWithValue("@nomprod", nombre);
            comando.Parameters.AddWithValue("@descripcion", desc);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@cantidad", cantida);
            comando.Parameters.AddWithValue("@estado", estado);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Actualizar(string nombre, string desc, float precio, int cantida, int estado)
        {
            comando.Connection = conexion.ABRIR();
            comando.CommandText = "ActualizarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nomprod", nombre);
            comando.Parameters.AddWithValue("@descripcion", desc);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@cantidad", cantida);
            comando.Parameters.AddWithValue("@estado", estado);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }   

        public void Eliminar(int id)
        {
            comando.Connection = conexion.ABRIR();
            comando.CommandText = " EliminarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idprod", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}
