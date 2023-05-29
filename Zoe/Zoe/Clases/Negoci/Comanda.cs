using System;
using System.Collections.Generic;
using Zoe.AccesDades;

namespace Zoe.Clases.Negoci
{
    public class Comanda
    {
        private int numComanda;
        private DateTime data=DateTime.Now;
        private List<Pack> packs;
        private Usuari comprador;
        private double preuTotal;

        int idComprador;
        string packsAdmin;
        string productesAdmin;

        public Pack Pack
        {
            get => default;
            set
            {
            }
        }

        public Usuari Usuari
        {
            get => default;
            set
            {
            }
        }
        public int NumComanda
        {
            get { return numComanda; }
        }
        public int IdComprador
        {
            get { return idComprador; }
        }
        public DateTime Data
        {
            get { return data; }
        }
        public double Total
        {
            get { return preuTotal; }
        }
        public string Packs
        {
            get { return packsAdmin; }
        }
        public string Productes
        {
            get { return productesAdmin; }
        }
        public Comanda(int id, int usuari, DateTime data, double total, string packs, string productes)    //amb aquest constructor creem un objecte comanda per a l'admin
        {
            numComanda = id;
            idComprador = usuari;
            this.data = data;
            preuTotal = total;
            packsAdmin = packs;
            productesAdmin = productes;
        }
        public Comanda(Usuari u)  //amb aquest constructor creem un objecte comanda per al client
        {
            numComanda = GenerarNumComanda();
            data = DateTime.Today;
            comprador = u;
        }

        private int GenerarNumComanda()
        {
            string dataTostrign = data.ToString("yyyyMMdd");

            return int.Parse(dataTostrign) + comprador.Id;
        }
        public void AfegirCarrito(Pack p)
        {
            packs.Add(p);
            PreuTotal();
            data = DateTime.Today;
        }
        private void PreuTotal()
        {
            preuTotal = 0;
            foreach (Pack pack in packs)
            {
                preuTotal += pack.Preu;
            }
        }
        public void GenerarFactura()  //amb aquest metode guardem la comanda a la bbdd perque la pugui veure l'admin, i a més actualitzem l'estoc de productes
        {
            Command cmd = new Command();
            string packsLlista = "", productesLlista = "";
            foreach (Pack pack in packs)
            {
                packsLlista += pack.Nom + ", ";
                foreach (Producte p in pack.Productes.Keys)
                {
                    productesLlista += p.Nom + ", ";
                }
            }
            cmd.GuardarComanda($"insert into Comanda values({numComanda}, {comprador.Id}, {data.ToString("yyyy-mm-dd hh-mm-ss")}, {Convert.ToDecimal(preuTotal)}, '{packsLlista}', '{productesLlista}');");
        }

        public string ToString() //amb aquest metode el client pot visualitzar la comanda
        {
            string factura;

            factura = $"************************************************\n";
            factura += $"\tZOE\n";
            factura += $"Usuari:{comprador}\tData: {data}\nNº comanda: {numComanda}\n";
            factura += $"************************************************\n";
            foreach (Pack pack in packs)
            {
                factura += $"{Pack.Nom}................................{Pack.Preu}\n{Pack.Descripcio}\n";
            }
            factura += "*************************************************\n";
            factura += $"TOTAL................................{preuTotal}\n";
            factura += "*************************************************";
            return factura;
        }
    }
}