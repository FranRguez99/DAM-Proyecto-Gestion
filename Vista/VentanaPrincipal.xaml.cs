using DDI_GestionEmpresa.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DDI_GestionEmpresa.Vista
{
    
    public partial class VentanaPrincipal : Window
    {

        // Atributos
        private AlumnoCRUD alumnoCRUD;
        private TutorCRUD tutorCRUD;
        public VentanaPrincipal()
        {
            InitializeComponent();
            alumnoCRUD= new AlumnoCRUD();
            tutorCRUD = new TutorCRUD();
        }

        private void VentanaPrincipal_Loaded(object sender, RoutedEventArgs e)
        {
            tablaAlumno.ItemsSource = alumnoCRUD.GetAllAlumnosAsDataTable().DefaultView;
        }

        // Pestaña empresas

        // Pestaña alumnos

        private void btInsertAlumn_Click(object sender, RoutedEventArgs e)
        {
            int idAlumno = int.Parse(tfCodAlumno.Text);
            string dni = tfDniAlumno.Text;
            string nombre = tfNombreAlumno.Text;
            string apellido = tfApellidosAlumno.Text;
            DateTime fechaNacimiento = dpFechaNacAlumno.SelectedDate.Value;
            Alumno alumno = new Alumno(idAlumno, dni, nombre, apellido, fechaNacimiento);
            alumnoCRUD.InsertAlumno(alumno);
            MessageBox.Show("Alumno insertado correctamente");
            tablaAlumno.ItemsSource = alumnoCRUD.GetAllAlumnosAsDataTable().DefaultView;

            limpiaCamposAlumno();

        }
 
        private void btModiAlumn_Click(object sender, RoutedEventArgs e)
        {
            int idAlumno = int.Parse(tfCodAlumno.Text);
            string dni = tfDniAlumno.Text;
            string nombre = tfNombreAlumno.Text;
            string apellido = tfApellidosAlumno.Text;
            DateTime fechaNacimiento = dpFechaNacAlumno.SelectedDate.Value;
            Alumno alumno = new Alumno(idAlumno, dni, nombre, apellido, fechaNacimiento);
            alumnoCRUD.UpdateAlumno(alumno);
            MessageBox.Show("Alumno actualizado correctamente");
            tablaAlumno.ItemsSource = alumnoCRUD.GetAllAlumnosAsDataTable().DefaultView;
            limpiaCamposAlumno();

        }

        private void btElimAlumn_Click(object sender, RoutedEventArgs e)
        {
            int idAlumno = int.Parse(tfCodAlumno.Text);
            alumnoCRUD.DeleteAlumno(idAlumno);
            MessageBox.Show("Alumno eliminado correctamente");
            tablaAlumno.ItemsSource = alumnoCRUD.GetAllAlumnosAsDataTable().DefaultView;
            limpiaCamposAlumno();

        }

        private void tablaAlumno_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            // Obtenemos la fila seleccionada del DataGrid
            DataRowView rowView = tablaAlumno.SelectedItem as DataRowView;

            // Comprobamos que se ha seleccionado alguna fila
            if (rowView != null)
            {
                // Obtenemos los valores de las celdas de la fila seleccionada
                int idAlumno = (int)rowView["idalumno"];
                string dni = (string)rowView["dni"];
                string nombre = (string)rowView["nombre"];
                string apellido = (string)rowView["apellido"];
                DateTime fechaNacimiento = (DateTime)rowView["fechaNacimiento"];

                // Actualizamos los valores de los TextBox con los valores obtenidos
                tfCodAlumno.Text = idAlumno.ToString();
                tfDniAlumno.Text = dni;
                tfNombreAlumno.Text = nombre;
                tfApellidosAlumno.Text = apellido;
                dpFechaNacAlumno.SelectedDate = fechaNacimiento;
            }
        }

        private void limpiaCamposAlumno()
        {
            tfCodAlumno.Text = "";
            tfDniAlumno.Text = "";
            tfNombreAlumno.Text = "";
            tfApellidosAlumno.Text = "";
            dpFechaNacAlumno.SelectedDate = null;
        }

        // Pestaña tutores
        private void btInsertTutores_Click(object sender, RoutedEventArgs e)
        {
            int idTutores = int.Parse(tfCodTutor.Text);
            string nombre = tfNombreTutor.Text;
            string email = tfEmailTutor.Text;
            int telefono = Int32.Parse(tfTlfTutor.Text);
            Tutor tutor = new Tutor(idTutores, nombre, email, telefono);
            tutorCRUD.InsertTutor(tutor);
            MessageBox.Show("Tutor insertado correctamente");
            tablaTutor.ItemsSource = tutorCRUD.GetAllTutoresAsDataTable().DefaultView;

            limpiaCamposTutor();

        }

        private void btModiTutores_Click(object sender, RoutedEventArgs e)
        {
            int idTutores = int.Parse(tfCodTutor.Text);
            string nombre = tfNombreTutor.Text;
            string email = tfEmailTutor.Text;
            int telefono = Int32.Parse(tfTlfTutor.Text);
            Tutor tutor = new Tutor(idTutores, nombre, email, telefono);
            tutorCRUD.UpdateTutor(tutor);
            MessageBox.Show("Tutor actualizado correctamente");
            tablaTutor.ItemsSource = tutorCRUD.GetAllTutoresAsDataTable().DefaultView;
            limpiaCamposTutor();

        }

        private void btElimTutores_Click(object sender, RoutedEventArgs e)
        {
            int idTutores = int.Parse(tfCodTutor.Text);
            tutorCRUD.DeleteTutor(idTutores);
            MessageBox.Show("Tutor eliminado correctamente");
            tablaTutor.ItemsSource = tutorCRUD.GetAllTutoresAsDataTable().DefaultView;
            limpiaCamposTutor();

        }

        private void tablaTutores_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            // Obtenemos la fila seleccionada del DataGrid
            DataRowView rowView = tablaTutor.SelectedItem as DataRowView;

            // Comprobamos que se ha seleccionado alguna fila
            if (rowView != null)
            {
                // Obtenemos los valores de las celdas de la fila seleccionada
                int idTutores = (int)rowView["idTutores"];
                string nombre= (string)rowView["nombre"];
                string email = (string)rowView["email"];
                int telefono = (int)rowView["telefono"];

                // Actualizamos los valores de los TextBox con los valores obtenidos
                tfCodTutor.Text = idTutores.ToString();
                tfNombreTutor.Text = nombre;
                tfEmailTutor.Text = email;
                tfTlfTutor.Text = telefono.ToString();
            }
        }

        private void limpiaCamposTutor()
        {
            tfCodTutor.Text = "";
            tfNombreTutor.Text = "";
            tfEmailTutor.Text = "";
            tfTlfTutor.Text = "";
        }

        // Pestaña asignación

    }
}
