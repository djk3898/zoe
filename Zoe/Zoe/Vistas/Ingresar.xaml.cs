using Org.BouncyCastle.Crypto.Paddings;
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
    /// Lógica de interacción para Ingresar.xaml
    /// </summary>
    public partial class Ingresar : Window
    {
        public Ingresar()
        {
            InitializeComponent();
            
        }

        
        public decimal Total { get; set; }
        public decimal Efectivo { get; set; }
        private void bttCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bttOk_Click(object sender, RoutedEventArgs e)
        { bool esnum = decimal.TryParse(txtBoxNuevaCantidad.Text, out decimal result );
            if (esnum)
            {
                Total = decimal.Parse(txtBoxNuevaCantidad.Text);
                Efectivo = decimal.Parse(txtBoxNuevaCantidad.Text);
                this.Close();
            }
            else this.Close();
        }
    }
}
