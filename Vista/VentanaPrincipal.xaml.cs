using DDI_GestionEmpresa.Modelo;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private AsignacionCRUD asignacionCRUD;
        private EmpresaCRUD empresaCRUD;
        private List<Empresa> listaEmpresas;
        public Empresa empresaSeleccionada;
        private TutorCRUD tutorCRUD;
        
        public VentanaPrincipal()
        {   
            InitializeComponent();
            alumnoCRUD= new AlumnoCRUD();
            asignacionCRUD = new AsignacionCRUD();
            empresaCRUD= new EmpresaCRUD();
            listaEmpresas= new List<Empresa>();
            tutorCRUD = new TutorCRUD();

            cargarEmpresas();
            

          
            tablaAsig.ItemsSource = asignacionCRUD.GetAddtabla();

            foreach (Alumno a in asignacionCRUD.GetAllAlumnos())
            {
                cbEleccAlum.Items.Add(a.Apellido + ", " + a.Nombre);
            }
            foreach (Empresa e in asignacionCRUD.GetAllEmpresas())
            {
                cbEleccEmp.Items.Add(e.nombre);
            }
            foreach (Tutor t in asignacionCRUD.GetAllTutores())
            {
                cbEleccTutor.Items.Add(t.nombre);
            }
       
        }

        private void VentanaPrincipal_Loaded(object sender, RoutedEventArgs e)
        {
            tablaAlumno.ItemsSource = alumnoCRUD.GetAllAlumnosAsDataTable().DefaultView;
            tablaTutor.ItemsSource = tutorCRUD.GetAllTutoresAsDataTable().DefaultView;
        }

        // Pestaña empresas

        /// <summary>
        /// Carga las empresas almacenadas en nuestra base de datos en la tabla
        /// </summary>
        private void cargarEmpresas()
        {
            // Vaciamos la tabla por si estuviera previamente cargada
            tablaEmpresas.Items.Clear();
            tablaEmpresas.Items.Refresh();

            // Inicializamos una lista con las empresas registradas en nuestra BBDD
            listaEmpresas.Clear();
            listaEmpresas = empresaCRUD.GetAllEmpresas();

            // Recorremos la lista para ir añadiendola a la tabla
            for (int i = 0; i < listaEmpresas.Count(); i++)
            {
                tablaEmpresas.Items.Add(new Empresa
                (
                    listaEmpresas[i].idEmpresa,
                    listaEmpresas[i].cif,
                    listaEmpresas[i].nombre,
                    listaEmpresas[i].direccion,
                    listaEmpresas[i].codPostal,
                    listaEmpresas[i].localidad,
                    listaEmpresas[i].jornada,
                    listaEmpresas[i].modalidad,
                    listaEmpresas[i].mail,
                    listaEmpresas[i].dniRepLegal,
                    listaEmpresas[i].nombreRepLegal,
                    listaEmpresas[i].apellidoRepLegal,
                    listaEmpresas[i].dniTutLab,
                    listaEmpresas[i].nombreTutLab,
                    listaEmpresas[i].apellidoTutLab,
                    listaEmpresas[i].telefonoTutLab
                ));
            }
        }

        /// <summary>
        /// Crea un objeto empresa a partir del seleccionado en la lista
        /// </summary>

        private void tablaEmpresas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            empresaSeleccionada = (Empresa)tablaEmpresas.SelectedItem;
        }

        /// <summary>
        /// Lanza una ventana para la creación de un nuevo formulario
        /// </summary>
        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            FormularioEmpresas formularioEmpresas = new FormularioEmpresas(false);
            formularioEmpresas.ShowDialog();
            
        }


        // Pestaña alumnos

        //Comprobaciones en alumno

        private void btInsertAlumn_Click(object sender, RoutedEventArgs e)
        {
            if (!validaCamposAlumnos())
            {
                return;
            }

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

        private bool validaCamposAlumnos()
        {
            // Expresión regular para validar que codAlumno solo contenga números
            string regexCodAlumno = "^\\d+$";

            // Expresión regular para validar que dniAlumno contenga 8 números y una letra al final
            string regexDniAlumno = "^\\d{8}[A-Z]$";

            if (!Regex.IsMatch(tfCodAlumno.Text, regexCodAlumno))
            {
                MessageBox.Show("El campo de código de alumno solo puede contener números.");
                return false;
            }

            if (!Regex.IsMatch(tfDniAlumno.Text, regexDniAlumno))
            {
                MessageBox.Show("El campo de DNI de alumno debe contener 8 números y una letra al final.");
                return false;
            }

            if (!Regex.IsMatch(tfNombreAlumno.Text, "^(?!\\s*$).+"))
            {
                MessageBox.Show("El campo de nombre de alumno no puede estar vacío.");
                return false;
            }

            if (!Regex.IsMatch(tfApellidosAlumno.Text, "^(?!\\s*$).+"))
            {
                MessageBox.Show("El campo de apellidos de alumno no puede estar vacío.");
                return false;
            }

            if (dpFechaNacAlumno.SelectedDate == null)
            {
                MessageBox.Show("Debe seleccionar una fecha de nacimiento para el alumno.");
                return false;
            }

            return true;
        }


        private void btModiAlumn_Click(object sender, RoutedEventArgs e)
        {
            if (!validaCamposAlumnos())
            {
                return;
            }
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
        private void limpiaCamposAsig()
        {
            cbEleccAlum.Text = " ";
            cbEleccEmp.Text = " ";
            cbEleccTutor.Text = " ";
        }

        // Pestaña tutores
        private void btInsertTutores_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tfCodTutor.Text) || string.IsNullOrEmpty(tfNombreTutor.Text) || string.IsNullOrEmpty(tfTlfTutor.Text) || string.IsNullOrEmpty(tfEmailTutor.Text))
            {
                MessageBox.Show("ERROR: No debe dejar ningún campo vacío");
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(tfCodTutor.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("ERROR: El código de tutor no debe contener ninguna letra.");
                return;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(tfNombreTutor.Text, @"\d"))
            {
                MessageBox.Show("ERROR: El nombre no debe incluir ningún número.");
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(tfTlfTutor.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("ERROR: El teléfono no debe contener ninguna letra.");
                return;
            }

            int idTutores = int.Parse(tfCodTutor.Text);
            string nombre = tfNombreTutor.Text;
            string email = tfEmailTutor.Text;
            string telefono = tfTlfTutor.Text;
            Tutor tutor = new Tutor(idTutores, nombre, email, telefono);
            tutorCRUD.InsertTutor(tutor);
            MessageBox.Show("Tutor insertado correctamente");
            tablaTutor.ItemsSource = tutorCRUD.GetAllTutoresAsDataTable().DefaultView;

            limpiaCamposTutor();

        }

        private void btModiTutores_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tfCodTutor.Text) || string.IsNullOrEmpty(tfNombreTutor.Text) || string.IsNullOrEmpty(tfTlfTutor.Text) || string.IsNullOrEmpty(tfEmailTutor.Text))
            {
                MessageBox.Show("ERROR: No debe dejar ningún campo vacío");
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(tfCodTutor.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("ERROR: El código de tutor no debe contener ninguna letra.");
                return;
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(tfNombreTutor.Text, @"\d"))
            {
                MessageBox.Show("ERROR: El nombre no debe incluir ningún número.");
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(tfTlfTutor.Text, @"^[0-9]+$"))
            {
                MessageBox.Show("ERROR: El teléfono no debe contener ninguna letra.");
                return;
            }
            int idTutores = int.Parse(tfCodTutor.Text);
            string nombre = tfNombreTutor.Text;
            string email = tfEmailTutor.Text;
            string telefono = tfTlfTutor.Text;
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
                int idTutores = (int)rowView["idTutor"];
                string nombre= (string)rowView["nombre"];
                string email = (string)rowView["email"];
                string telefono = (string)rowView["telefono"];

                // Actualizamos los valores de los TextBox con los valores obtenidos
                tfCodTutor.Text = idTutores.ToString();
                tfNombreTutor.Text = nombre;
                tfEmailTutor.Text = email;
                tfTlfTutor.Text = telefono;
            }
        }

        private void limpiaCamposTutor()
        {
            tfCodTutor.Text = "";
            tfNombreTutor.Text = "";
            tfEmailTutor.Text = "";
            tfTlfTutor.Text = "";
        }
        // Limita campos de texto a 9
        public void TextBoxLimite9(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text.Length > 9)
            {
                textBox.Text = textBox.Text.Substring(0, 9);
                textBox.SelectionStart = 9;
            }
        }


        



        // Pestaña asignación
        private void btAnadirAsig_Click(object sender, RoutedEventArgs e)
        {
            string nombrecompletoAlumno = cbEleccAlum.Text;
            string[] nombrecompletoAlumno1 = nombrecompletoAlumno.Split(',');
            string nombreEmpresa = cbEleccEmp.Text;
            string nombrecompletoTutor = cbEleccTutor.Text;

            AsignacionCRUD asignacionCRUD = new AsignacionCRUD();
            asignacionCRUD.InsertAsig(nombrecompletoAlumno1[0], nombreEmpresa, nombrecompletoTutor);

            tablaAsig.ItemsSource = asignacionCRUD.GetAddtabla();
            limpiaCamposAsig();
      
        }

        private void tablaAsig_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
