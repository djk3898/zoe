using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Zoe.AccesDades;
using Zoe.Clases.Negoci;
using Zoe.Vistas;

namespace Zoe.Negoci
{
    public class Botiga
    {
        private string nom;
        private List<Producte> productes;
        private List<Pack> packs;
        private List<string> comandes;
        private List<string> proveidors;
        private List<string> categories;

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public void AfegirComanda(Comanda comanda)
        {
            comandes.Add(comanda.ToString());
        }

        public void AfegirProducte(string nom, string descripcio, double preu, int estoc, string categoria, string proveidor)
        {
            Command afegir = new Command();
            int id;
            int idCategoria = 0;
            int idProveidor = 0;
            try
            {
                idCategoria = afegir.SelectInt($"select id from Categoria where nom = {categoria}");
                idProveidor = afegir.SelectInt($"select id from Proveidor where nom = {proveidor}");
            }
            catch ( Exception e ) { MessageBox.Show("Ha habido algun problema con la categoria/proveidor"); }

            if (afegir.Afegir($"insert into Producte(nom, descripcio, preu, estoc, id_categoria, id_proveidor) values({nom}, {descripcio}, {preu}, {estoc}, {idCategoria}, {idProveidor});"))
            {
                id = afegir.SelectInt($"select id from Producte where nom = {nom} and descripcio = {descripcio}");
                Producte p = new Producte(id, nom, descripcio, preu, estoc, categoria, proveidor);
                productes.Add(p);
            }
            else
            {
                MessageBox.Show("Ha habido algun problema durante la creación del producto");
            }
        }

        public void EliminarProducte(Producte producte)
        {
            Command eliminar = new Command();
            if (eliminar.Eliminar($"delete Producte where id = {producte.Id}"))
            {
                productes.Remove(producte);
            }
            else
            {
                MessageBox.Show("Ha habido algun problema durante la eliminación del producto");
            }
        }
        public void AfegirPack(string nom, string descripcio, double preu, Dictionary<Producte, int> prod)
        {
            Command afegir = new Command();
            int id;

            if (afegir.Afegir($"insert into Pack(nom, descripcio, preu) values({nom}, {descripcio}, {preu});"))
            {
                id = afegir.SelectInt($"select id from Pack where nom = {nom} and descripcio = {descripcio}");
                Pack p = new Pack(id, nom, descripcio, preu, prod);
                packs.Add(p);
            }
            else
            {
                MessageBox.Show("Ha habido algun problema durante la creación del pack");
            }
        }

        public void EliminarPack(Pack pack)
        {
            Command eliminar = new Command();
            if (eliminar.Eliminar($"delete Pack where id = {pack.Id}"))
            {
                packs.Remove(pack);
            }
            else
            {
                MessageBox.Show("Ha habido algun problema durante la eliminación del pack");
            }
        }

        public void AfegirProveidor(string proveidor)
        {
            Command afegir = new Command();
            if(afegir.Afegir($"insert into Proveidor(nom) values({proveidor});"))
            {
                proveidors.Add(proveidor);
            }
            else
            {
                MessageBox.Show("Ha habido algun problema durante la creación del proveedor");
            }
        }
        public void EliminarProveidor(string proveidor)
        {
            Command eliminar = new Command();
            if (eliminar.Eliminar($"delete Proveidor where nom = {proveidor}"))
            {
                proveidors.Remove(proveidor);
            }
            else
            {
                MessageBox.Show("Ha habido algun problema durante la eliminación del proveedor");
            }
        }
        
        public void AfegirCategoria(string categoria)
        {
            Command afegir = new Command();
            if (afegir.Afegir($"insert into Categoria(nom) values({categoria});"))
            {
                categories.Add(categoria);
            }
            else
            {
                MessageBox.Show("Ha habido algun problema durante la creación de la categoria");
            }
        }
        public void EliminarCategoria(string categoria)
        {
            Command eliminar = new Command();
            if (eliminar.Eliminar($"delete Categoria where nom = {categoria}"))
            {
                categories.Remove(categoria);
            }
            else
            {
                MessageBox.Show("Ha habido algun problema durante la eliminación de la categoria");
            }
        }
    }
}