using DDI_GestionEmpresa.Modelo;
using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Interaction logic for FormularioEmpresas.xaml
    /// </summary>
    public partial class FormularioEmpresas : Window
    {
        private Empresa empresa;
        private EmpresaCRUD empresaCRUD;
        bool editar;
        bool valido = true;

        // Constructores
        public FormularioEmpresas(bool editar)
        {
            InitializeComponent();
            empresaCRUD = new EmpresaCRUD();
            this.editar = editar;
        }

        public FormularioEmpresas(Empresa empresa, bool editar)
        {
            InitializeComponent();
            empresaCRUD = new EmpresaCRUD();
            this.empresa = empresa;
            this.editar = editar;

            rellenaCampos();
        }

        // Métodos

        /// <summary>
        /// Rellena los campos del formulario con los datos de una empresa a editar
        /// </summary>
        public void rellenaCampos()
        {
            tfCIF.Text = empresa.cif;
            tfNombreEmpresa.Text = empresa.nombre;
            tfDireccion.Text = empresa.direccion;
            tfCodPostal.Text = empresa.codPostal;
            tfLocalidad.Text = empresa.localidad;
            cbJornada.Text = empresa.jornada;
            cbModalidad.Text = empresa.modalidad;
            tfMail.Text = empresa.mail;
            tfDNIRL.Text = empresa.dniRepLegal;
            tfNombreRL.Text = empresa.nombreRepLegal;
            tfApellidosRL.Text = empresa.apellidoRepLegal;
            tfDNITL.Text = empresa.dniTutLab;
            tfNombreTL.Text = empresa.nombreTutLab;
            tfApellidosTL.Text = empresa.apellidoTutLab;
            tfTelefonoTL.Text = empresa.telefonoTutLab;
        }

        /// <summary>
        /// Crea un objeto empresa a partir de los campos de nuestro formulario
        /// </summary>
        public void leerEmpresa()
        {
            // Comprobamos los campos

            if (valido)
            {
                empresa = new Empresa(
                    tfCIF.Text, tfNombreEmpresa.Text, tfDireccion.Text, tfCodPostal.Text,
                    tfLocalidad.Text, (cbJornada.SelectedItem as ComboBoxItem)?.Content.ToString(),
                    (cbModalidad.SelectedItem as ComboBoxItem)?.Content.ToString(), tfMail.Text,
                    tfDNIRL.Text, tfNombreRL.Text, tfApellidosRL.Text, tfDNITL.Text, tfNombreTL.Text,
                    tfApellidosTL.Text, tfTelefonoTL.Text
                    );
            }
                
        }

        /// <summary>
        /// Limita campos de texto a 5
        /// </summary>
        public void TextBoxLimite5(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text.Length > 5)
            {
                textBox.Text = textBox.Text.Substring(0, 5);
                textBox.SelectionStart = 5;
            }
        }

        /// <summary>
        /// Limita campos de texto a 9
        /// </summary>
        public void TextBoxLimite9(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text.Length > 9)
            {
                textBox.Text = textBox.Text.Substring(0, 9);
                textBox.SelectionStart = 9;
            }
        }

        /// <summary>
        /// Limita campos de texto a 50
        /// </summary>
        public void TextBoxLimite50(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text.Length > 50)
            {
                textBox.Text = textBox.Text.Substring(0, 50);
                textBox.SelectionStart = 50;
            }
        }


        /// <summary>
        /// Acepta la operación de inserción o modificación de una empresa en la BBDD
        /// </summary>
        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                leerEmpresa();

                if (editar)
                {
                    empresaCRUD.UpdateEmpresa(empresa);
                    MessageBox.Show("Empresa actualizada con éxito", "EMPRESA ACTUALIZADA",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                } else
                {
                    empresaCRUD.InsertEmpresa(empresa);
                    MessageBox.Show("Empresa insertada con éxito", "EMPRESA INSERTADA",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                

                // Cerramos la ventana
                Button button = (Button)sender;
                Window window = Window.GetWindow(button);
                window.Close();

            }
            catch (Exception)
            {
                MessageBox.Show("Algunos de los campos son erroneos.\n" +
                    "No se ha podido insertar la empresa", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        /// <summary>
        /// Cierra la ventana
        /// </summary>
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Window window = Window.GetWindow(button);
            window.Close();
        }
    }
}
