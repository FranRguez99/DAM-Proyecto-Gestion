using DDI_GestionEmpresa.ConexionBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySqlConnector;
using System.Data;

namespace DDI_GestionEmpresa.Modelo
{
    public class EmpresaCRUD
    {
        private DatabaseConnection databaseConnection;

        public EmpresaCRUD()
        {
            databaseConnection = new DatabaseConnection();
        }

        public void InsertEmpresa(Empresa empresa)
        {

            string query = "INSERT INTO empresas Values (@idEmpresa, @cif, @nombre, @direccion, @codPostal, @localidad, @jornada, @modalidad, @mail, @dniRepLegal, @nombreRepLegal, @apellidoRepLegal, @dniTutLab, @nombreTutLab, @apellidoTutLab, @telefonoTutLab);";
            MySqlCommand mySqlCommand = new MySqlCommand(query, databaseConnection.getConnection());
            mySqlCommand.Parameters.AddWithValue("@idEmpresa", empresa.idEmpresa);
            mySqlCommand.Parameters.AddWithValue("@cif", empresa.cif);
            mySqlCommand.Parameters.AddWithValue("@nombre", empresa.nombre);
            mySqlCommand.Parameters.AddWithValue("@direccion", empresa.direccion);
            mySqlCommand.Parameters.AddWithValue("@codPostal", empresa.codPostal);
            mySqlCommand.Parameters.AddWithValue("@localidad", empresa.localidad);
            mySqlCommand.Parameters.AddWithValue("@jornada", empresa.jornada);
            mySqlCommand.Parameters.AddWithValue("@modalidad", empresa.modalidad);
            mySqlCommand.Parameters.AddWithValue("@mail", empresa.mail);
            mySqlCommand.Parameters.AddWithValue("@dniRepLegal", empresa.dniRepLegal);
            mySqlCommand.Parameters.AddWithValue("@nombreRepLegal", empresa.nombreRepLegal);
            mySqlCommand.Parameters.AddWithValue("@apellidoRepLegal", empresa.apellidoRepLegal);
            mySqlCommand.Parameters.AddWithValue("@dniTutLab", empresa.dniTutLab);
            mySqlCommand.Parameters.AddWithValue("@nombreTutLab", empresa.nombreTutLab);
            mySqlCommand.Parameters.AddWithValue("@apellidoTutLab", empresa.apellidoTutLab);
            mySqlCommand.Parameters.AddWithValue("@telefonoTutLab", empresa.telefonoTutLab);

            try
            {
                mySqlCommand.ExecuteNonQuery();
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

        public int cuentaEmpresas()
        {
            List<Empresa> listaEmpresas = new List<Empresa>();
            listaEmpresas = GetAllEmpresas();
            Console.WriteLine(listaEmpresas.Count.ToString());
            return listaEmpresas.Count();
        }

        public void UpdateEmpresa(Empresa empresa)
        {
            string query = "UPDATE empresas SET cif=@cif, nombre=@nombre, direccion=@direccion, codPostal=@codPostal, " +
                           "localidad=@localidad, jornada=@jornada, modalidad=@modalidad, mail=@mail, " +
                           "dniRepLegal=@dniRepLegal, nombreRepLegal=@nombreRepLegal, apellidoRepLegal=@apellidoRepLegal, " +
                           "dniTutLab=@dniTutLab, nombreTutLab=@nombreTutLab, apellidoTutLab=@apellidoTutLab, " +
                           "telefonoTutLab=@telefonoTutLab WHERE cif=@cif";
            MySqlCommand cmd = new MySqlCommand(query, databaseConnection.getConnection());
            cmd.Parameters.AddWithValue("@idEmpresa", empresa.idEmpresa);
            cmd.Parameters.AddWithValue("@cif", empresa.cif);
            cmd.Parameters.AddWithValue("@nombre", empresa.nombre);
            cmd.Parameters.AddWithValue("@direccion", empresa.direccion);
            cmd.Parameters.AddWithValue("@codPostal", empresa.codPostal);
            cmd.Parameters.AddWithValue("@localidad", empresa.localidad);
            cmd.Parameters.AddWithValue("@jornada", empresa.jornada);
            cmd.Parameters.AddWithValue("@modalidad", empresa.modalidad);
            cmd.Parameters.AddWithValue("@mail", empresa.mail);
            cmd.Parameters.AddWithValue("@dniRepLegal", empresa.dniRepLegal);
            cmd.Parameters.AddWithValue("@nombreRepLegal", empresa.nombreRepLegal);
            cmd.Parameters.AddWithValue("@apellidoRepLegal", empresa.apellidoRepLegal);
            cmd.Parameters.AddWithValue("@dniTutLab", empresa.dniTutLab);
            cmd.Parameters.AddWithValue("@nombreTutLab", empresa.nombreTutLab);
            cmd.Parameters.AddWithValue("@apellidoTutLab", empresa.apellidoTutLab);
            cmd.Parameters.AddWithValue("@telefonoTutLab", empresa.telefonoTutLab);

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

        public void DeleteEmpresa(Empresa empresa)
        {
            string query = "DELETE FROM empresas WHERE idEmpresa=@idEmpresa";
            MySqlCommand cmd = new MySqlCommand(query, databaseConnection.getConnection());
            cmd.Parameters.AddWithValue("@idEmpresa", empresa.idEmpresa);

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

        public List<Empresa> GetAllEmpresas()
        {
            List<Empresa> empresas = new List<Empresa>();
            string query = "SELECT * FROM empresas";
            MySqlCommand cmd = new MySqlCommand(query, databaseConnection.getConnection());

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
                databaseConnection.closeConexion();
            }

            return empresas;
        }


    }
}

