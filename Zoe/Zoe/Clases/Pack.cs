using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Windows;

namespace Zoe
{
    public class Pack
    {
        private int id;
        private string nom;
        private string descripcio;
        private double preu;

        private Dictionary<Producte, int> productes; //productes + quantitat

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

        public Pack(int id, string n, Dictionary<Producte, int> p)
        {
            this.id = id;
            nom = n;
            productes = p;
            if (descripcio == null)
                descripcio = string.Empty;
        }
        public Pack(int id, string n, Dictionary<Producte, int> p, string d) : this(id, n, p)
        {
            descripcio = d;
        }

        private void CalcularPreu()
        {

        }
        
    }
}