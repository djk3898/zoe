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
using Zoe.AccesDades;
using Zoe.Clases.Negoci;
using Zoe.Vistas;

namespace Zoe.Vistas
{
    
    public partial class AdminVista : Window
    {
        public AdminVista()
        {
            InitializeComponent();
            //Un error que detectamos es que cuando abriamos la pestaña principal ocupaba todo el espacio incluso la barra de tareas
            //la solución mas acertada es definir/ limitar el espacio de trabajo de la ventana
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
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

        private void Inicio_click(object sender, RoutedEventArgs e)
        {
            Inicio ini = new Inicio();
            grid.Children.Add(ini);
            grid.Visibility = Visibility.Visible;
        }

        private void modificar_click(object sender, RoutedEventArgs e)
        {
            Modificar modi = new Modificar();
            grid.Children.Add(modi);
            grid.Visibility = Visibility.Visible;
        }

        private void Productos_click(object sender, RoutedEventArgs e)
        {
            Producto prod = new Producto();
            grid.Children.Add(prod);
            grid.Visibility = Visibility.Visible;

        }

        private void Categoria_click(object sender, RoutedEventArgs e)
        {
            categoria catg = new categoria();
            grid.Children.Add(catg);
            grid.Visibility = Visibility.Visible;

        }

        private void Añadir_click(object sender, RoutedEventArgs e)
        {
            Añadir añadir = new Añadir();
            grid.Children.Add(añadir);
            grid.Visibility = Visibility.Visible;

        }

        private void Eliminar_click(object sender, RoutedEventArgs e)
        {
            Eliminar eliminar = new Eliminar();
            grid.Children.Add(eliminar);
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
