using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Windows;
using Zoe.Vistas;

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
                    MessageBox.Show("La descripción tiene que ser de 150 carácteres como máximo.");
            }
        }
        public double Preu
        {
            get { return preu; }
        }

        public Pack(int id, string n, string d, double p, Dictionary<Producte, int> prod)
        {
            this.id = id;
            nom = n;
            if(d.Length < 151)
                descripcio = d;
            else
                MessageBox.Show("La descripción tiene que ser de 150 carácteres como máximo.");
            preu = p;
            productes = prod;
        }
        public void AfegirProducte(Producte prod, int quantitat)
        {
            productes.Add(prod, quantitat);
            CalcularPreu();
        }

        private void CalcularPreu()
        {
            foreach (KeyValuePair<Producte, int> prod in productes)
            {
                preu += prod.Key.Preu * prod.Value;
            }
        }
        
    }
}