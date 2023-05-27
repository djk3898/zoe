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
        //private string nom;
        private List<Producte> productes = new();
        private List<Pack> packs = new();
        private List<Comanda> comandes = new();
        private List<string> proveidors = new();
        private List<string> categories = new();

        public Botiga()
        {
            Command cmd = new Command();
            //Actulitza productes
            for(int i = 1; i <= cmd.SelectInt("select max(id) from Producte;"); i++)
            {
                if (cmd.SelectInt($"select id from Producte where id = {i};") == i)
                {
                    Producte p = new Producte(i, cmd.SelectString($"select nom from Producte where id = {i}"),
                    cmd.SelectString($"select descripcio from Producte where id = {i}"),
                    cmd.SelectDouble($"select preu from Producte where id = {i}"),
                    cmd.SelectInt($"select estoc from Producte where id = {i}"),
                    cmd.SelectString($"select nom from Categoria where id = (select id_categoria from Producte where id = {i});"),
                    cmd.SelectString($"select nom from Proveidor where id = (select id_proveidor from Producte where id = {i});"));
                    productes.Add(p);
                }
            }
            //packs
            for (int i = 1; i <= cmd.SelectInt("select max(id) from Pack;"); i++)
            {
                if (cmd.SelectInt($"select id from Pack where id = {i};") == i)
                {
                    Pack p = new Pack(i, cmd.SelectString($"select nom from Pack where id = {i}"),
                    cmd.SelectString($"select descripcio from Pack where id = {i}"),
                    cmd.SelectDouble($"select preu from Pack where id = {i}"));
                    packs.Add(p);
                }
            }
            //comandes
            for (int i = 1; i <= cmd.SelectInt("select max(id) from Comanda;"); i++)
            {
                if (cmd.SelectInt($"select id from Comanda where id = {i};") == i)
                {
                    Comanda c = new Comanda(i, cmd.SelectInt($"select id_usuari from Comanda where id = {i};"),
                    cmd.SelectDate($"select data_compra from Comanda where id = {i};"),
                    cmd.SelectDouble($"select preu_total from Comanda where id = {i};"),
                    cmd.SelectString($"select packs from Comanda where id = {i};"),
                    cmd.SelectString($"select productes from Comanda where id = {i};"));
                    comandes.Add(c);
                }
            }
            //proveidors
            for (int i = 1; i <= cmd.SelectInt("select max(id) from Proveidor;"); i++)
            {
                if(cmd.SelectInt($"select id from Proveidor where id = {i};") == i)
                {
                    string p = cmd.SelectString($"select nom from Proveidor where id = {i}");
                    proveidors.Add(p);
                }
            }
            //categories
            for (int i = 1; i <= cmd.SelectInt("select max(id) from Categoria;"); i++)
            {
                if (cmd.SelectInt($"select id from Categoria where id = {i};") == i)
                {
                    string c = cmd.SelectString($"select nom from Categoria where id = {i}");
                    categories.Add(c);
                }
            }
        }

        //public string Nom
        //{
        //    get { return nom; }
        //    set { nom = value; }
        //}
        public List<Producte> Productes
        {
            get { return productes; }
        }
        public List<Pack> Packs
        {
            get { return packs; }
        }
        public List<Comanda> Comandes 
        {
            get { return comandes; }
        }
        public List<string> Proveidors
        {
            get { return proveidors; }
        }
        public List<string> Categories
        {
            get { return categories; }
        }

        public string ConvertirPreu(double preu)
        {
            //Aquest mètode converteix el preu en double passat per l'usuari (ex. 1,9) a un valor valid per la bbdd (ex. 1.9)
            return preu.ToString().Replace(',', '.');
        }

        public void AfegirComanda(Comanda comanda)
        {
            comandes.Add(comanda);
        }

        public void AfegirProducte(string nom, string descripcio, double preu, int estoc, string categoria, string proveidor)
        {
            Command afegir = new Command();
            int id;
            int idCategoria = 0;
            int idProveidor = 0;
            try
            {
                idCategoria = afegir.SelectInt($"select id from Categoria where nom = '{categoria}'");
                idProveidor = afegir.SelectInt($"select id from Proveidor where nom = '{proveidor}'");
                if (idCategoria == 0 || idProveidor == 0)
                    throw new Exception();                    
            }
            catch ( Exception e ) { MessageBox.Show("Ha habido algun problema con la categoria/proveidor"); }

            if (afegir.Afegir($"insert into Producte(nom, descripcio, preu, estoc, id_categoria, id_proveidor) values('{nom}', '{descripcio}', {ConvertirPreu(preu)}, {estoc}, {idCategoria}, {idProveidor});"))
            {
                id = afegir.SelectInt($"select id from Producte where nom = '{nom}' and descripcio = '{descripcio}'");
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
            if (eliminar.Eliminar($"delete from Producte where id = {producte.Id};"))
            {
                productes.Remove(producte);
            }
            else
            {
                MessageBox.Show("Ha habido algun problema durante la eliminación del producto");
            }
        }
        public void AfegirPack(string nom, string descripcio, double preu, Dictionary<Producte, int> prod, List<string> prodList)
        {
            Command afegir = new Command();
            int id;
            string llistaProd = "";
            foreach (string p  in prodList) {
                llistaProd += p + ", ";
            }

            if (afegir.Afegir($"insert into Pack(nom, descripcio, preu, productes) values('{nom}', '{descripcio}', {ConvertirPreu(preu)}, '{llistaProd}');"))
            {
                id = afegir.SelectInt($"select id from Pack where nom = '{nom}' and descripcio = '{descripcio}'");
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
            if (eliminar.Eliminar($"delete from Pack where id = {pack.Id};"))
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
            if(afegir.Afegir($"insert into Proveidor(nom) values('{proveidor}');"))
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
            if (eliminar.Eliminar($"delete from Proveidor where nom = '{proveidor}';"))
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
            if (afegir.Afegir($"insert into Categoria(nom) values('{categoria}');"))
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
            if (eliminar.Eliminar($"delete from Categoria where nom = '{categoria}';"))
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