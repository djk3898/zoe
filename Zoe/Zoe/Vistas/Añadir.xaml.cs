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
using Zoe.AccesDades;

namespace Zoe.Vistas
{
    /// <summary>
    /// Lógica de interacción para Añadir.xaml
    /// </summary>
    public partial class Añadir : UserControl
    {
        Botiga botiga;
        private Dictionary<Producte, int> prodPack = new();
        private List<string> prodPackList = new();
        public Añadir()
        {
            InitializeComponent();
            botiga = new Botiga();
        }

        private void btnAfegirProd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nom = txtboxNom.Text;
                string descripcio = txtboxDescripcio.Text;
                double preu = Convert.ToDouble(txtboxPreu.Text);
                int estoc = Convert.ToInt32(txtboxEstoc.Text);
                string categoria = txtboxCategoria.Text;
                string proveidor = txtboxProveidor.Text;
                botiga.AfegirProducte(nom, descripcio, preu, estoc, categoria, proveidor);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Faltan campos por rellenar o son incorrectos!");
            }            
        }
        private void btnAfegirPack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nom = txtboxNomPack.Text;
                string descripcio = txtboxDescripcioPack.Text;
                double preu = Convert.ToDouble(txtboxPreuPack.Text);
                botiga.AfegirPack(nom, descripcio, preu, prodPack, prodPackList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Faltan campos por rellenar o son incorrectos!");
            }
        }

        private void btnAfegirProdPack_Click(object sender, RoutedEventArgs e)
        {
            Command cmd = new();
            try
            {
                //creamos objeto producto a partir del nombre que ha indicado el usuario
                Producte p = new Producte(
                    cmd.SelectInt($"select id from Producte where nom = '{txtboxProdPack.Text}'"),
                    cmd.SelectString($"select nom from Producte where nom = '{txtboxProdPack.Text}'"),
                    cmd.SelectString($"select descripcio from Producte where nom = '{txtboxProdPack.Text}'"),
                    cmd.SelectDouble($"select preu from Producte where nom = '{txtboxProdPack.Text}'"),
                    cmd.SelectInt($"select estoc from Producte where nom = '{txtboxProdPack.Text}'"),
                    cmd.SelectString($"select nom from Categoria where id = (select id_categoria from Producte where nom = '{txtboxProdPack.Text}');"),
                    cmd.SelectString($"select nom from Proveidor where id = (select id_proveidor from Producte where nom = '{txtboxProdPack.Text}');"));
                //comprovamos si ya lo ha añadido antes
                if (prodPack.ContainsKey(p))
                {
                    prodPack.Remove(p);
                    prodPackList.Remove(p.Nom);
                }
                else
                {
                    //si no lo ha añadido antes lo añadimos al diccionario
                    prodPack.Add(p, 1);
                    prodPackList.Add(p.Nom);
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
