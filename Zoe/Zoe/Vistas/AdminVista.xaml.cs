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

namespace Zoe.Vistas
{
    
    public partial class AdminVista : Window
    {
        private Usuari admin;
        public AdminVista(Usuari admin)
        {
            InitializeComponent();
            //Un error que detectamos es que cuando abriamos la pestaña principal ocupaba todo el espacio incluso la barra de tareas
            //la solución mas acertada es definir/ limitar el espacio de trabajo de la ventana
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            this.admin = admin;
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
    }
}
