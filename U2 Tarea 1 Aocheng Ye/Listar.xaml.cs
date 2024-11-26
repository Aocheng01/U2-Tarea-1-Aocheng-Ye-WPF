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
    /// Lógica de interacción para Listar.xaml
    /// </summary>
    public partial class Listar : UserControl
    {
        public Listar()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            DaoLibro daoLibro = new DaoLibro();
            List<Libro> listaLibros = daoLibro.listarLibros();

            dataGridView1.ItemsSource = listaLibros;

        }
    }
}
