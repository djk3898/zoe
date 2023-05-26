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

namespace Zoe.Vistas
{
    /// <summary>
    /// Lógica de interacción para ClienteVista.xaml
    /// </summary>
    public partial class ClienteVista : Window
    {
        public ClienteVista()
        {
            InitializeComponent();
        }
        private void panelArrastraryMover(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void btnMaximizar_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else WindowState = WindowState.Normal;
        }
        private void Productos_click(object sender, RoutedEventArgs e)
            {
                Producto prod = new Producto();
                grid.Children.Add(prod);
                grid.Visibility = Visibility.Visible;

            }

            private void Categoria_click(object sender, RoutedEventArgs e)
            {
                Categoria catg = new Categoria();
                grid.Children.Add(catg);
                grid.Visibility = Visibility.Visible;

            }

            private void Pedido_click(object sender, RoutedEventArgs e)
            {
                Pedido pedido = new Pedido();
                grid.Children.Add(pedido);
                grid.Visibility = Visibility.Visible;

            }
      
    }
    }

