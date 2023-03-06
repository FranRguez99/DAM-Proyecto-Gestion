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
        }

        public void leerEmpresa()
        {
            
                empresa = new Empresa(
                    int.Parse(tfCodEmpresa.Text), tfCIF.Text, tfNombreEmpresa.Text,
                    tfDireccion.Text, tfCodPostal.Text, tfLocalidad.Text, cbJornada.SelectedItem.ToString(),
                    cbModalidad.SelectedItem.ToString(), tfMail.Text, tfDNIRL.Text, tfNombreRL.Text, tfApellidosRL.Text,
                    tfDNITL.Text, tfNombreTL.Text, tfApellidosTL.Text, tfTelefonoTL.Text
                    );
                
            
            
           
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                leerEmpresa();
                empresaCRUD.InsertEmpresa(empresa);
                MessageBox.Show("Empresa insertada con éxito", "EMPRESA INSERTADA",
                    MessageBoxButton.OK, MessageBoxImage.Error);

                // Cerramos la ventana
                Button button = (Button)sender;
                Window window = Window.GetWindow(button);
                window.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Algunos de los campos son erroneos.\n" +
                    "No se ha podido insertar la empresa", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);

            }


        }

        
    }
}
