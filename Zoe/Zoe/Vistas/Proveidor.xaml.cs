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
using Zoe.Negoci;

namespace Zoe.Vistas
{
    /// <summary>
    /// Lógica de interacción para Proveidors.xaml
    /// </summary>
    public partial class Proveidor : UserControl
    {
        Botiga botiga = new Botiga();
        public Proveidor()
        {
            InitializeComponent();
            dataGridProveidors.ItemsSource = botiga.Proveidors;
        }

        private void btnAfegir_Click(object sender, RoutedEventArgs e)
        {
            botiga.AfegirProveidor(txtBox_Nom.Text);
            dataGridProveidors.ItemsSource = null;
            dataGridProveidors.ItemsSource = botiga.Proveidors;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            botiga.EliminarProveidor(txtBox_Nom.Text);
            dataGridProveidors.ItemsSource = null;
            dataGridProveidors.ItemsSource = botiga.Proveidors;
        }
    }
}
