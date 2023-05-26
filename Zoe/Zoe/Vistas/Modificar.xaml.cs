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
using Zoe.Negoci;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Zoe.Vistas
{
    /// <summary>
    /// Lógica de interacción para Modificar.xaml
    /// </summary>
    public partial class Modificar : UserControl
    {
        private Command cmd;
        Botiga botiga;
        //private Dictionary<Producte, int> prodPack = new();

        private List<string> prodPackList = new();
        private int idProd;
        private int idPack;

        public Modificar()
        {
            InitializeComponent();
        }

        private void btnModificarProd_Click(object sender, RoutedEventArgs e)
        {
            cmd = new();
            //busquem les id de categoria i proveidor
            int idCategoria, idProveidor;
            idCategoria = cmd.SelectInt($"select id from Categoria where nom = '{txtboxCategoria.Text}';");
            idProveidor = cmd.SelectInt($"select id from Proveidor where nom = '{txtboxProveidor.Text}';");

            //fem l'update
            if (cmd.Modificar($"update Producte set " +
                $"nom = '{txtboxNom.Text}', " +
                $"descripcio = '{txtboxDescripcio.Text}', " +
                $"preu = {txtboxPreu.Text.ToString().Replace(',', '.')}, " +
                $"estoc = {txtboxEstoc.Text}, " +
                $"id_categoria = {idCategoria}, " +
                $"id_proveidor = {idProveidor} " +
                $"where id = {idProd};"))
            {}
            else
                MessageBox.Show("Alguno de los datos no son correctos...");
        }

        private void btnModificarPack_Click(object sender, RoutedEventArgs e)
        {
            cmd = new();
            //agafem els productes del list
            string llistaProd = "";
            foreach (string p in prodPackList)
            {
                llistaProd += p + ", ";
            }
            //fem l'update
            if (cmd.Modificar($"update Pack set " +
                $"nom = '{txtboxNomPack.Text}', " +
                $"descripcio = '{txtboxDescripcioPack.Text}', " +
                $"preu = {txtboxPreuPack.Text.ToString().Replace(',', '.')}," +
                $"productes = '{llistaProd}'" +
                $"where id = {idPack};")) { }
            else
                MessageBox.Show("Alguno de los datos no son correctos...");
        }

        private void btnBuscarPack_Click(object sender, RoutedEventArgs e)
        {
            cmd = new();
            if (cmd.SelectString($"select nom from Pack where nom = '{txtboxNomPack.Text}';") != null)
            {
                txtboxDescripcioPack.Text = cmd.SelectString($"select descripcio from Pack where nom = '{txtboxNomPack.Text}';");
                txtboxPreuPack.Text = cmd.SelectString($"select preu from Pack where nom = '{txtboxNomPack.Text}';");

                try
                {
                    string prodString = cmd.SelectString($"select productes from Pack where nom = '{txtboxNomPack.Text}';");
                    prodPackList = prodString.Split(',').ToList();
                }
                catch (Exception ex)
                {
                    prodPackList = new();
                }

                //actualitzem listbox
                listboxProdPack.ItemsSource = null;
                listboxProdPack.ItemsSource = prodPackList;

                //guardem la id per si es modifica el nom del pack
                idPack = cmd.SelectInt($"select id from Pack where nom = '{txtboxNomPack.Text}';");
            }
            else
            {
                MessageBox.Show("Este producto no existe!");
                txtboxDescripcio.Text = "";
                txtboxPreu.Text = "";
                txtboxEstoc.Text = "";
                txtboxCategoria.Text = "";
                txtboxProveidor.Text = "";
            }
            txtboxNomPack.Focus();
            txtboxNomPack.SelectAll();
        }

        private void btnBuscarProd_Click(object sender, RoutedEventArgs e)
        {
            cmd = new();
            if(cmd.SelectString($"select nom from Producte where nom = '{txtboxNom.Text}';") != null)
            {
                txtboxDescripcio.Text = cmd.SelectString($"select descripcio from Producte where nom = '{txtboxNom.Text}';");
                txtboxPreu.Text = cmd.SelectString($"select preu from Producte where nom = '{txtboxNom.Text}';");
                txtboxEstoc.Text = cmd.SelectString($"select estoc from Producte where nom = '{txtboxNom.Text}';");
                txtboxCategoria.Text = cmd.SelectString($"select nom from Categoria where id = (select id_categoria from Producte where nom = '{txtboxNom.Text}');");
                txtboxProveidor.Text = cmd.SelectString($"select nom from Proveidor where id = (select id_proveidor from Producte where nom = '{txtboxNom.Text}');");
                //guardem la id per si es modifica el nom del producte
                idProd = cmd.SelectInt($"select id from Producte where nom = '{txtboxNom.Text}';");
            }
            else
            {
                MessageBox.Show("Este producto no existe!");
                txtboxDescripcio.Text = "";
                txtboxPreu.Text = "";
                txtboxEstoc.Text = "";
                txtboxCategoria.Text = "";
                txtboxProveidor.Text = "";
            }
            txtboxNom.Focus();
            txtboxNom.SelectAll();
        }

        private void btnAfegirProdPack_Click(object sender, RoutedEventArgs e)
        {
            Command cmd = new();
            try
            {
                //comprovamos si ya lo ha añadido antes
                if (prodPackList.Contains(txtboxProdPack.Text))
                {
                    prodPackList.Remove(txtboxProdPack.Text);
                }
                else
                {
                    //si no lo ha añadido antes lo añadimos al diccionario
                    prodPackList.Add(txtboxProdPack.Text);
                }
            }
            catch
            {
                //si no existe el producto salta error
                MessageBox.Show($"El producto {txtboxProdPack.Text} no existe!");
            }



            //actualitzem listbox
            listboxProdPack.ItemsSource = null;
            listboxProdPack.ItemsSource = prodPackList;

            txtboxProdPack.Focus();
            txtboxProdPack.SelectAll();
        }
    }
}
