using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Zoe.Vistas;

namespace Zoe
{
    public class Producte
    {
        private int id;
        private string nom;
        private string descripcio;
        private string proveidor;
        private string categoria;
        private int estoc;
        private double preu;

        public int Id
        {
            get { return id; }
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public string Descripcio
        {
            get { return descripcio; }
            set
            {
                if (value.Length < 151)
                    descripcio = value;
                else
                    MessageBox.Show("La descripció ha de ser de 150 caràcters màxim.");
            }
        }
        public double Preu
        {
            get { return preu; }
            set { preu = value; }
        }
        public int Estoc
        {
            get { return estoc; }
            set { estoc = value; }
        }
        public Producte( int id,string nom, string descripcio, double preu, int estoc, string categoria, string proveidor)
        {
            this.id = id;
            this.nom = nom;
            if (descripcio.Length < 151)
                this.descripcio = descripcio;
            else
                MessageBox.Show("La descripción tiene que ser de 150 carácteres como máximo.");
            this.preu = preu;
            this.estoc = estoc;
            this.categoria = categoria;
            this.proveidor = proveidor;
        }

    }

}
