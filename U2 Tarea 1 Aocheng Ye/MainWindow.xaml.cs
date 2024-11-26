using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace U2_Tarea_1_Aocheng_Ye
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AbrirWindowEnPanel(UserControl panelacargar)

        {

            if (this.Contenedor.Children.Count > 0)

                this.Contenedor.Children.RemoveAt(0);

            UserControl pc = panelacargar as UserControl;

            this.Contenedor.Children.Add(pc);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AbrirWindowEnPanel(new Principal());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AbrirWindowEnPanel(new Anadir());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AbrirWindowEnPanel(new Consultar());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AbrirWindowEnPanel(new Listar());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}