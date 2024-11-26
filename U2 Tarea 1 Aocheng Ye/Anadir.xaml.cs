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
using System.Windows.Navigation;
using System.Windows.Shapes;
using U2_Tarea_1_Aocheng_Ye.dao;
using U2_Tarea_1_Aocheng_Ye.dto;

namespace U2_Tarea_1_Aocheng_Ye
{
    /// <summary>
    /// Lógica de interacción para Anadir.xaml
    /// </summary>
    public partial class Anadir : UserControl
    {
        public Anadir()
        {
            InitializeComponent();
        }

        private void btnAnadir_Click(object sender, RoutedEventArgs e)
        {
            bool datosValidos = true;
            if (string.IsNullOrEmpty(txtBoxTitulo.Text))
            {
                MessageBox.Show("Se ha producido un error.\nLos campos título y autor son obligatorios.");
                txtBoxTitulo.Background=Brushes.Red;
                datosValidos = false;
            }
            if (string.IsNullOrEmpty(txtBoxAutor.Text))
            {
                MessageBox.Show("Se ha producido un error.\nLos campos título y autor son obligatorios.");
                txtBoxAutor.Background = Brushes.Red;
                datosValidos = false;
            }
            Boolean enVenta = false;
            if (checkBoxVenta.IsChecked == true) { 
                       enVenta = true;
            }

            DateTime fecha;
            if (dataPickerFecha.SelectedDate == null)
            {
                fecha = DateTime.Now;
            }
            else
            {
                fecha = dataPickerFecha.SelectedDate.Value;
            }

            if (datosValidos)
            {
                Libro nuevoLibro = new Libro(
                    txtBoxTitulo.Text,
                    txtBoxAutor.Text,
                    txtBoxEditorial.Text,
                    fecha,
                    txtBoxImagen.Text,
                    txtBoxDescripcion.Text,
                    float.Parse(txtBoxPrecio.Text),
                    int.Parse(txtBoxUnidades.Text),
                    enVenta
                );
                DaoLibro daoLibro = new DaoLibro();
                daoLibro.insertarLibro(nuevoLibro);
            }
        }
    }
}
