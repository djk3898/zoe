using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Lógica de interacción para PedidosCliente.xaml
    /// </summary>
    public partial class PedidosCliente : UserControl
    {
        public PedidosCliente()
        {
            InitializeComponent();
            Pedido n = new Pedido();
            //gridPedidos.ItemsSource=
        }

       
        void Existe(string producto)
        {

        }
       
        
        private void AgregarProducto()
        {
            string producto ;
            decimal cantidad; 
        }
        decimal efectivo, cambio, total;

        private void bttAnular_Click(object sender, RoutedEventArgs e)
        {
            efectivo = 0;
            gridPedidos.Items.Clear();

        }

        private void bttEfectivo_Click(object sender, RoutedEventArgs e)
        {
            var selecion = gridPedidos.SelectedItem;
            if(selecion!= null)
            {
                //var celda = gridPedidos;
                //var id = (celda.Colum.GetCellContent(celda.Item) as TextBlock).Text;
                var ingresar = new Ingresar();
                ingresar.ShowDialog();

                if (ingresar.Total > 0)
                {
                    gridPedidos.Items.Remove(selecion);
                    //Agregar(id, ingresar.Total);
                }
            }
        }

        private void bttModificarCantidad_Click(object sender, RoutedEventArgs e)
        {
            var cantidad = new Ingresar();
            cantidad.ShowDialog();
            if (cantidad.Efectivo > 0)
            {
                efectivo = cantidad.Efectivo;
            }

        }

       

        private void bttEliminar_Click(object sender, RoutedEventArgs e)
        {
            var seleccionado = gridPedidos.SelectedItem;
            if (seleccionado != null)
            {
                gridPedidos.Items.Remove(seleccionado);
                if (gridPedidos.Items.Count < 1)
                    efectivo = 0;
            }
        }
    }
}
