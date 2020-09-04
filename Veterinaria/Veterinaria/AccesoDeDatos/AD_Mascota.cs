using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Veterinaria.Models;
//(9) Creamos la Carpeta de Acceso a la base de datos para intorducir los insert list up date delete//
//(10)creamos clases con metodos estaticos//
//(11)creamos el mwtodo insert//
//(20) compiamos la lista y modificamos para el update//
namespace Veterinaria.AccesoDeDatos
{
    public class AD_Mascota
    {
        public static bool InsertarNuevaMascota(Mascota mas)
        {
            bool resultado = false;
            string cadenaConexion = @"Data Source=DESKTOP-8CLB531\SQLEXPRESS;Initial Catalog=ABMVeterinaria;Integrated Security=True";

            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "INSERT INTO Mascotas VALUES(@nombremascota, @nombredueño, @edad , @telefono)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("nombremascota", mas.NombreMascota1);
                cmd.Parameters.AddWithValue("nombredueño", mas.NombreDueño1);
                cmd.Parameters.AddWithValue("edad", mas.Edad1);
                cmd.Parameters.AddWithValue("telefono", mas.Telefono1);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }
            return resultado;
        }

        public static bool ActualizarDatosMascota(Mascota mas)
        {
            bool resultado = false;
            string cadenaConexion = @"Data Source=DESKTOP-8CLB531\SQLEXPRESS;Initial Catalog=ABMVeterinaria;Integrated Security=True";

            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "UPDATE mascotas set NombreMascota = @nombremascota, NombreDueño = @nombredueño, Edad = @edad, Telefono = @telefono WHERE Id = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("nombremascota", mas.NombreMascota1);
                cmd.Parameters.AddWithValue("nombredueño", mas.NombreDueño1);
                cmd.Parameters.AddWithValue("edad", mas.Edad1);
                cmd.Parameters.AddWithValue("telefono", mas.Telefono1);
                cmd.Parameters.AddWithValue("id", mas.Id1);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();
                resultado = true;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }
            return resultado;
        }

        public static List<Mascota> ObtenerListasMascotas()
        {
            List<Mascota> resultado = new List<Mascota>();
            string cadenaConexion = @"Data Source=DESKTOP-8CLB531\SQLEXPRESS;Initial Catalog=ABMVeterinaria;Integrated Security=True";

            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "SELECT * FROM mascotas";
                cmd.Parameters.Clear();
            

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                if(dr != null)
                {
                    while(dr.Read())
                    {
                        Mascota aux = new Mascota();
                        aux.Id1 = int.Parse(dr["Id"].ToString());
                        aux.NombreMascota1 = dr["NombreMascota"].ToString();
                        aux.NombreDueño1 = dr["NombreDueño"].ToString();
                        aux.Edad1 = int.Parse(dr["Edad"].ToString());
                        aux.Telefono1 = dr["Telefono"].ToString();

                        resultado.Add(aux);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }
            return resultado;
        }

        public static Mascota ObtenerMascota(int idMascota)
        {
            Mascota resultado = new Mascota();
            string cadenaConexion = @"Data Source=DESKTOP-8CLB531\SQLEXPRESS;Initial Catalog=ABMVeterinaria;Integrated Security=True";

            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                string consulta = "SELECT * FROM mascotas WHERE Id = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", idMascota);


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;

                cn.Open();
                cmd.Connection = cn;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    while (dr.Read())
                    {                               
                        resultado.Id1 = int.Parse(dr["Id"].ToString());
                        resultado.NombreMascota1 = dr["NombreMascota"].ToString();
                        resultado.NombreDueño1 = dr["NombreDueño"].ToString();
                        resultado.Edad1 = int.Parse(dr["Edad"].ToString());
                        resultado.Telefono1 = dr["Telefono"].ToString();

                       
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                cn.Close();
            }
            return resultado;
        }
    }
}