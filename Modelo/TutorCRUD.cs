using DDI_GestionEmpresa.ConexionBD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySqlConnector;

namespace DDI_GestionEmpresa.Modelo
{
    public class TutorCRUD
    {
        private DatabaseConnection db;

        public TutorCRUD()
        {
            db = new DatabaseConnection();
        }

        public List<Tutor> GetAllTutores()
        {
            List<Tutor> tutores = new List<Tutor>();
            string query = "SELECT * FROM tutores";
            MySqlCommand cmd = new MySqlCommand(query, db.getConnection());

            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int idTutor = reader.GetInt32(0);
                    string nombre = reader.GetString(1);
                    string email = reader.GetString(2);
                    string telefono = reader.GetString(3);
                    Tutor tutor = new Tutor(idTutor, nombre, email, telefono);
                    tutores.Add(tutor);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                db.closeConexion();
            }

            return tutores;
        }
        public DataTable GetAllTutoresAsDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idTutor", typeof(int));
            dt.Columns.Add("nombre", typeof(string));
            dt.Columns.Add("email", typeof(string));
            dt.Columns.Add("telefono", typeof(string));

            foreach (Tutor t in GetAllTutores())
            {
                dt.Rows.Add(t.idTutor, t.nombre, t.email, t.telefono);
            }

            return dt;
        }
        public void InsertTutor(Tutor tutor)
        {
            string query = "INSERT INTO tutores Values (?,?,?,?);";
            MySqlCommand cmd = new MySqlCommand(query, db.getConnection());
            cmd.Parameters.AddWithValue("@idTutor", tutor.idTutor);
            cmd.Parameters.AddWithValue("@nombre", tutor.nombre);
            cmd.Parameters.AddWithValue("@email", tutor.email);
            cmd.Parameters.AddWithValue("@telefono", tutor.telefono);
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
                db.closeConexion();

            }
        }

        public void UpdateTutor(Tutor tutor)
        {
            string query = "UPDATE tutores SET nombre=@nombre, email=@email, telefono=@telefono" +
                " WHERE idTutor=@idTutor";
            MySqlCommand cmd = new MySqlCommand(query, db.getConnection());
            cmd.Parameters.AddWithValue("@idTutor", tutor.idTutor);
            cmd.Parameters.AddWithValue("@nombre", tutor.nombre);
            cmd.Parameters.AddWithValue("@email", tutor.email);
            cmd.Parameters.AddWithValue("@telefono", tutor.telefono);

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
                db.closeConexion();
            }
        }

        public void DeleteTutor(int idTutor)
        {
            string query = "DELETE FROM tutores WHERE idTutor=@idTutor";
            MySqlCommand cmd = new MySqlCommand(query, db.getConnection());
            cmd.Parameters.AddWithValue("@idTutor", idTutor);

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
                db.closeConexion();
            }
        }
    }
}