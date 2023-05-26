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

namespace Zoe.Vistas
{
    /// <summary>
    /// Lógica de interacción para Eliminar.xaml
    /// </summary>
    public partial class Eliminar : UserControl
    {
        private Botiga botiga;
        private Command cmd;
        private List<string> prodPackList;
        private int idPack;
        private int idProd;
        public Eliminar()
        {
            InitializeComponent();
            botiga = new();
        }

        private void btnEliminarProd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Producte p = new Producte(idProd, txtboxNom.Text, txtboxDescripcio.Text, Convert.ToDouble(txtboxPreu.Text), Convert.ToInt32(txtboxEstoc.Text), txtboxCategoria.Text, txtboxProveidor.Text);
                cmd = new Command();
                botiga.EliminarProducte(p);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se ha podido eliminar el producto {txtboxNom.Text}...\nERROR: {ex.Message}");
            }
        }

        private void btnEliminarPack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pack p = new Pack(idPack, txtboxNomPack.Text, txtboxDescripcioPack.Text, Convert.ToDouble(txtboxPreuPack.Text));
                cmd = new Command();
                botiga.EliminarPack(p);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se ha podido eliminar el pack {txtboxNomPack.Text}...\nERROR: {ex.Message}");
            }
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

                //guardem la id per eliminar el pack
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
            if (cmd.SelectString($"select nom from Producte where nom = '{txtboxNom.Text}';") != null)
            {
                txtboxDescripcio.Text = cmd.SelectString($"select descripcio from Producte where nom = '{txtboxNom.Text}';");
                txtboxPreu.Text = cmd.SelectString($"select preu from Producte where nom = '{txtboxNom.Text}';");
                txtboxEstoc.Text = cmd.SelectString($"select estoc from Producte where nom = '{txtboxNom.Text}';");
                txtboxCategoria.Text = cmd.SelectString($"select nom from Categoria where id = (select id_categoria from Producte where nom = '{txtboxNom.Text}');");
                txtboxProveidor.Text = cmd.SelectString($"select nom from Proveidor where id = (select id_proveidor from Producte where nom = '{txtboxNom.Text}');");
                //guardem la id per eliminar el producte
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
    }
}
