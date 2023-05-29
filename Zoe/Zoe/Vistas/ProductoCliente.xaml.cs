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
using Zoe.Clases.Negoci;

namespace Zoe.Vistas
{
    /// <summary>
    /// Lógica de interacción para ProductoCliente.xaml
    /// </summary>
    public partial class ProductoCliente : UserControl
    {
        Usuari client;
        Comanda pedido;
        public ProductoCliente(Usuari usuari)
        {
            InitializeComponent();
            client = usuari;
            pedido = new Comanda(client);
        }
        
        private void bttProducte1_Click(object sender, RoutedEventArgs e)
        {
            Pack p = new(1, "Caja desayuno gourmet", "Caja desayuno gourmet, también como merienda", 31);
            pedido.AfegirCarrito(p);

        }
    }
}
