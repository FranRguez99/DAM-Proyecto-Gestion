using DDI_GestionEmpresa.ConexionBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySqlConnector;

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
            string query = "INSERT INTO empresas Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?);";
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


    }
}
