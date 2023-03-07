using DDI_GestionEmpresa.ConexionBD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySqlConnector;
using System.Data.SqlClient;

namespace DDI_GestionEmpresa.Modelo
{
    public class AsignacionCRUD
    {
        private DatabaseConnection db;

        public AsignacionCRUD()
        {
            db = new DatabaseConnection();
        }

        public List<Alumno> GetAllAlumnos()
        {
            List<Alumno> alumnos = new List<Alumno>();
            string query = "SELECT * FROM alumnos";
            MySqlCommand cmd = new MySqlCommand(query, db.getConnection());

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
                db.closeConexion();
            }

            return alumnos;
        }


        public List<Empresa> GetAllEmpresas()
        {
            List<Empresa> empresas = new List<Empresa>();
            string query = "SELECT * FROM empresas";
            MySqlCommand cmd = new MySqlCommand(query, db.getConnection());

            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int idEmpresa = reader.GetInt32(0);
                    string cif = reader.GetString(1);
                    string nombre = reader.GetString(2);
                    string direccion = reader.GetString(3);
                    string codPostal = reader.GetString(4);
                    string localidad = reader.GetString(5);
                    string jornada = reader.GetString(6);
                    string modalidad = reader.GetString(7);
                    string mail = reader.GetString(8);
                    string dniRepLegal = reader.GetString(9);
                    string nombreRepLegal = reader.GetString(10);
                    string apellidoRepLegal = reader.GetString(11);
                    string dniTutLab = reader.GetString(12);
                    string nombreTutLab = reader.GetString(13);
                    string apellidoTutLab = reader.GetString(14);
                    string telefonoTutLab = reader.GetString(15);

                    Empresa empresa = new Empresa(idEmpresa, cif, nombre, direccion, codPostal, localidad,
                                                   jornada, modalidad, mail, dniRepLegal, nombreRepLegal,
                                                   apellidoRepLegal, dniTutLab, nombreTutLab, apellidoTutLab,
                                                   telefonoTutLab);
                    empresas.Add(empresa);
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

            return empresas;
        }

        public void InsertAsig(String apellidoAlumno, String nombreEmpresa, String nombreTutor)
        {
            int idAlumno = 0;
            int idEmpresa = 0;
            int idTutor = 0;

            string query = "SELECT * from alumnos WHERE apellido ='" + apellidoAlumno + "'";

            MySqlCommand cmd = new MySqlCommand(query, db.getConnection());


            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    idAlumno = reader.GetInt32(0);


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


            //   string query3 = "SELECT idEmpresa FROM empresas" + "WHERE nombre = " + nombreEmpresa;
            string query3 = "SELECT * from empresas WHERE nombre ='" + nombreEmpresa + "'";
            MySqlCommand cmd3 = new MySqlCommand(query3, db.getConnection());

            try
            {
                MySqlDataReader reader = cmd3.ExecuteReader();
                while (reader.Read())
                {

                    idEmpresa = reader.GetInt32(0);


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


            // string query4 = "SELECT idTutor FROM Tutores" + "WHERE nombre = " + nombreTutor;
            string query4 = "SELECT * from tutores WHERE nombre ='" + nombreTutor + "'";

            MySqlCommand cmd4 = new MySqlCommand(query4, db.getConnection());

            try
            {
                MySqlDataReader reader2 = cmd4.ExecuteReader();
                while (reader2.Read())
                {

                    idTutor = reader2.GetInt32(0);


                }
                reader2.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                db.closeConexion();
            }


            string query2 = "INSERT INTO asignaciones (idAlumno,idEmpresa,idTutor) VALUES(" + idAlumno + "," + idEmpresa + "," + idTutor + ")";

            MySqlCommand cmd2 = new MySqlCommand(query2, db.getConnection());

            try
            {
                cmd2.ExecuteNonQuery();

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



        public List<Asignacion> GetAddtabla()
        {
            List<Asignacion> asignacionlist = new List<Asignacion>();
           
            string query = "SELECT a.nombre, a.apellido, e.nombre, t.nombre FROM asignaciones asig LEFT JOIN alumnos a ON a.idAlumno = asig.idAlumno JOIN empresas e ON e.idEmpresa = asig.idEmpresa JOIN tutores t ON t.idTutor = asig.idTutor;";
         


            MySqlCommand cmd = new MySqlCommand(query, db.getConnection());

            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string nombreAlumno = reader.GetString(0);
                    string apellidoAlumno = reader.GetString(1);
                    string nombreEmpresa = reader.GetString(2);
                    string nombreTutor = reader.GetString(3);


                    Asignacion asignacion = new Asignacion(apellidoAlumno + ", " + nombreAlumno, nombreEmpresa, nombreTutor);
               


                    asignacionlist.Add(asignacion);
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
        
            return asignacionlist;
        }

    }
}


