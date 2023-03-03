using DDI_GestionEmpresa.ConexionBD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySqlConnector;

namespace DDI_GestionEmpresa.Modelo
{
    public class AlumnoCRUD
    {
        private DatabaseConnection databaseConnection;

        public AlumnoCRUD()
        {
            databaseConnection = new DatabaseConnection();
        }

        public List<Alumno> GetAllAlumnos()
        {
            List<Alumno> alumnos = new List<Alumno>();
            string query = "SELECT * FROM alumnos";
            MySqlCommand cmd = new MySqlCommand(query, databaseConnection.getConnection());

            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int idAlumno = reader.GetInt32(0);
                    string dni = reader.GetString(1);
                    string nombre = reader.GetString(2);
                    string apellido = reader.GetString(3);
                    DateTime fechaNacimiento = reader.GetDateTime(4);
                    Alumno alumno = new Alumno(idAlumno, dni, nombre, apellido, fechaNacimiento);
                    alumnos.Add(alumno);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                databaseConnection.closeConexion();
            }

            return alumnos;
        }
        public DataTable GetAllAlumnosAsDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IdAlumno", typeof(int));
            dt.Columns.Add("Dni", typeof(string));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("Apellido", typeof(string));
            dt.Columns.Add("FechaNacimiento", typeof(DateTime));

            foreach (Alumno a in GetAllAlumnos())
            {
                dt.Rows.Add(a.IdAlumno, a.Dni, a.Nombre, a.Apellido, a.FechaNacimiento);
            }

            return dt;
        }
        public void InsertAlumno(Alumno alumno)
        {
            string query = "INSERT INTO alumnos Values (?,?,?,?,?);";
            MySqlCommand cmd = new MySqlCommand(query, databaseConnection.getConnection());
            cmd.Parameters.AddWithValue("@idAlumno", alumno.IdAlumno);
            cmd.Parameters.AddWithValue("@dni", alumno.Dni);
            cmd.Parameters.AddWithValue("@nombre", alumno.Nombre);
            cmd.Parameters.AddWithValue("@apellido", alumno.Apellido);
            cmd.Parameters.AddWithValue("@fechaNacimiento", alumno.FechaNacimiento);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                databaseConnection.closeConexion();

            }
        }

        public void UpdateAlumno(Alumno alumno)
        {
            string query = "UPDATE alumnos SET dni=@dni, nombre=@nombre, apellido=@apellido, fechaNac=@fechaNacimiento " +
                "WHERE idalumno=@idAlumno";
            MySqlCommand cmd = new MySqlCommand(query, databaseConnection.getConnection());
            cmd.Parameters.AddWithValue("@idAlumno", alumno.IdAlumno);
            cmd.Parameters.AddWithValue("@dni", alumno.Dni);
            cmd.Parameters.AddWithValue("@nombre", alumno.Nombre);
            cmd.Parameters.AddWithValue("@apellido", alumno.Apellido);
            cmd.Parameters.AddWithValue("@fechaNacimiento", alumno.FechaNacimiento);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                databaseConnection.closeConexion();
            }
        }

        public void DeleteAlumno(int idAlumno)
        {
            string query = "DELETE FROM alumnos WHERE idalumno=@idAlumno";
            MySqlCommand cmd = new MySqlCommand(query, databaseConnection.getConnection());
            cmd.Parameters.AddWithValue("@idAlumno", idAlumno);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                databaseConnection.closeConexion();
            }
        }
    }
}
