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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Registrar : Window
    {
        public Registrar()
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

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            Command register = new();
            string user = txtUser.Text;
            string contra = txtPass.Password;
            string email = txtEmail.Text;
            string telf = txtTelf.Text;
            string prov = txtProvincia.Text;
            string direc = txtDireccio.Text;
            string cp = txtCodiPostal.Text;

            //comprova que l'usuari ha entrat bé les dades
            if (user != "" && contra != "" && email != "" && register.VerificarEmail(email)
                && telf != "" && register.VerificarTelf(telf)
                && prov != "" && direc != "" 
                && cp != "" && register.VerificarCP(cp))
            {
                //verifica que la contrasenya no és feble
                if(register.VerificarContra(contra))
                {
                    if (register.Afegir($"insert into Usuari (rol, nom, contrasenya, email, telefon, provincia, direccio, cpostal) " +
                        $"values(2, '{user}', '{contra}', '{email}', {telf}, '{prov}', '{direc}', {cp});"))
                    {
                        //obra finestra login
                        MainWindow finestraLogin = new();
                        finestraLogin.Show();
                        //tanca la finestra de registrar
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ha habido algun problema durante la creación del usuario");
                    }
                }
                else
                {
                    MessageBox.Show("La contraseña debe tener:\n\t·Al menos una mayúscula o minúscula\n\t·Al menos un número\n\t·Longitud mínima de 8 caracteres.");
                }
            }
            else {
                MessageBox.Show("Algun campo esta vacío o en un formato incorrecto");
            }
            
        }
    }
}
