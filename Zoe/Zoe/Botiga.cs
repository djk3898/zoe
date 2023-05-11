using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zoe
{
    public class Botiga
    {
        private string nom;
        private List<Producte> productes;
        private List<string> proveidors;
        private List<string> categories;

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public void AfegirProducte(int id, string nom, string proveidor)
        {




            Producte p = new Producte(id, nom, proveidor);
        }

        public void EliminarProducte(int id, string nom, string proveidor)
        {




            Producte p = new Producte(id, nom, proveidor);
        }
    }
}