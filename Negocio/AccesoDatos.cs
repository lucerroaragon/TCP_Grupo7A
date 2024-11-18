using System;
using System.Data.SqlClient;

namespace Negocio
{
    public class AccesoDatos
    {
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public AccesoDatos()
        {

            // Cambiar la cadena de conexión según el entorno
            // Ejemplo: conexión con SQL Server
            //conexion = new SqlConnection("server=.\\LABORATORIO3; database=PUNTORECICLAJE_BD; integrated security=true");
            //conexion = new SqlConnection("Server=localhost,1433; Database=PUNTORECICLAJE_BD; User Id=sa; Password=17513169Marie..; TrustServerCertificate=True;");

            // Pedro
            //conexion = new SqlConnection("Server=localhost,1433; Database=PUNTORECICLAJE_BD; User Id=sa; Password=17513169Marie..; TrustServerCertificate=True;");

            //Lu
            //conexion = new SqlConnection("server=.\\LABORATORIO3; database=PUNTOSRECICLAJE_BD; integrated security=true");

            // Maxi
            conexion = new SqlConnection("server=.\\SQLExpress; database=PUNTORECICLAJE_BD; integrated security=true");



            comando = new SqlCommand();
        }

        public void setearProcedimiento(string procedimiento)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = procedimiento;
        }

        public void agregarParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    conexion.Open();

                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la lectura de datos", ex);
            }
        }

        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                    conexion.Open();

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar la acción en la base de datos", ex);
            }
            finally
            {
                conexion.Close();
            }
        }

        public object ejecutarEscalar()
        {
            object resultado = null;

            try
            {
                resultado = comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar la consulta escalar", ex);
            }

            return resultado;
        }

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();

            if (conexion.State != System.Data.ConnectionState.Closed)
                conexion.Close();
        }

        internal int ejecutarAccionEscalar()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                return (int)comando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
