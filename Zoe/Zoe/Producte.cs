using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

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
        public int Estoc
        {
            get { return estoc; }
            set { estoc = value; }
        }

        public Producte(int id, string n, string p)
        {
            this.id = id;
            nom = n;
            proveidor = p;
        }
        public Producte(int id, string n, string p, string d) : this(id, n, p)
        {
            descripcio = d;
        }
    }
}