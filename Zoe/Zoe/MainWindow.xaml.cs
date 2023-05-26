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
using Zoe.Vistas;

namespace Zoe
{
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e) 
        {
            Command login = new();
            Usuari usuari;
            string user = txtUser.Text;
            string contra = txtPass.Password;

            if (login.VerificaUsuari($"select nom, contrasenya from Usuari where nom = '{user}' and contrasenya = '{contra}'"))
            {
                if(login.VerificaRol($"select rol, nom, contrasenya from Usuari where nom = '{user}' and contrasenya = '{contra}'"))
                {
                    usuari = new("admin", user, contra);
                    //obra finestra admin
                    AdminVista finestraAdmin = new(usuari);
                    finestraAdmin.WindowState = WindowState.Maximized;
                    finestraAdmin.Show();
                    //tanca la finestra de login
                    this.Close();
                }
                else
                {
                    int id = login.SelectInt($"select id from Usuari where nom = '{user}' and contrasenya = '{contra}'");
                    string email = login.SelectString($"select email from Usuari where nom = '{user}' and contrasenya = '{contra}'");
                    string provincia = login.SelectString($"select provincia from Usuari where nom = '{user}' and contrasenya = '{contra}'");
                    string direccio = login.SelectString($"select direccio from Usuari where nom = '{user}' and contrasenya = '{contra}'");
                    int cp = login.SelectInt($"select cpostal from Usuari where nom = '{user}' and contrasenya = '{contra}'");
                    int telef = login.SelectInt($"select telefon from Usuari where nom = '{user}' and contrasenya = '{contra}'");
                    usuari = new(id, "client", user, contra, email, provincia, direccio, cp, telef);
                    //obra finestra client
                    ClienteVista finestraClient = new();
                    finestraClient.WindowState = WindowState.Maximized;
                    finestraClient.Show();
                    //tanca aquesta finestra
                    this.Close();
                }
            }
        }

        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            //obra finestra registre
            Registrar finestraNouUsuari = new();
            finestraNouUsuari.Show();
            //tanca la finestra login
            this.Close();
        }
       
    }
}
