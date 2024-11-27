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
    /// Lógica de interacción para Consultar.xaml
    /// </summary>
    public partial class Consultar : UserControl
    {
        public Consultar()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DaoLibro daoLibro = new DaoLibro();
            Libro libro = null;

            //Con operador ternario 
            int? id = string.IsNullOrEmpty(txtBoxID.Text) ? (int?)null : int.Parse(txtBoxID.Text);

            string titulo = string.IsNullOrEmpty(textBoxBuscarTitulo.Text) ? null : textBoxBuscarTitulo.Text;



            libro = daoLibro.buscarLibro(id, titulo);
            if (libro == null)
            {
                MessageBox.Show("No se encontró el libro con el id: " + txtBoxID.Text + " o con título: " + textBoxBuscarTitulo.Text);
            }
            else
            {
                txtBoxTitulo.Text = libro.titulo;
                txtBoxPrecio.Text = libro.precio.ToString();
                txtBoxDescripcion.Text = libro.descripcion;
                txtBoxEditorial.Text = libro.editorial;
                dataPickerFecha.SelectedDate = libro.fecha_publicacion;
                txtBoxImagen.Text = libro.imagen;
                txtBoxUnidades.Text = libro.unidades.ToString();
                txtBoxAutor.Text = libro.autor;
                checkBoxVenta.IsChecked = libro.enventa;

                btnEliminar.Visibility = Visibility.Visible;
                btnModificar.Visibility = Visibility.Visible;

            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DaoLibro daoLibro = new DaoLibro();
                bool enVenta = false;
                if (checkBoxVenta.IsChecked == true)
                {
                    enVenta = true;
                }

                // Crear el nuevo libro con los datos ingresados
                Libro libroNuevo = new Libro(
                    txtBoxTitulo.Text,
                    txtBoxAutor.Text,
                    txtBoxEditorial.Text,
                    dataPickerFecha.SelectedDate.Value,
                    txtBoxImagen.Text,
                    txtBoxDescripcion.Text,
                    float.Parse(txtBoxPrecio.Text),
                    int.Parse(txtBoxUnidades.Text),
                    enVenta
                );

                // Intentar modificar el libro
                daoLibro.modificarLibro(int.Parse(txtBoxID.Text), libroNuevo);

                // Notificar al usuario y limpiar los campos
                MessageBox.Show("Libro Modificado Correctamente");
                txtBoxTitulo.Clear();
                txtBoxAutor.Clear();
                txtBoxEditorial.Clear();
                txtBoxImagen.Clear();
                txtBoxDescripcion.Clear();
                txtBoxPrecio.Clear();
                txtBoxUnidades.Clear();
                txtBoxID.Clear();
                textBoxBuscarTitulo.Clear();

                txtBoxID.Background = new SolidColorBrush(Colors.White);
                textBoxBuscarTitulo.Background = new SolidColorBrush(Colors.White);
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Error de formato: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show($"Error: Uno o más campos no han sido llenados correctamente. {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ha ocurrido un error inesperado: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult respuesta = MessageBox.Show(
                  "¿Estás seguro de que quieres eliminar este libro?",
                  "Confirmar Borrado de Libro",
                  MessageBoxButton.YesNo,
                  MessageBoxImage.Warning);

            if (respuesta == MessageBoxResult.Yes)
            {
                DaoLibro daoLibro = new DaoLibro();
                daoLibro.eliminarLibro(int.Parse(txtBoxID.Text));
                MessageBox.Show("Libro Eliminado Correctamente");

            }
            else
            {
                MessageBox.Show("ID no válido.", "Error: ", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            txtBoxTitulo.Clear();
            txtBoxAutor.Clear();
            txtBoxEditorial.Clear();
            txtBoxImagen.Clear();
            txtBoxDescripcion.Clear();
            txtBoxPrecio.Clear();
            txtBoxUnidades.Clear();
            txtBoxID.Clear();
            textBoxBuscarTitulo.Clear();
        }
    }
}
