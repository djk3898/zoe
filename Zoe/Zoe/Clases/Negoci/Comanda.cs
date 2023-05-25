using System;
using System.Collections.Generic;

namespace Zoe.Clases.Negoci
{
    public class Comanda
    {
        private int numComanda;
        private DateTime data;
        private List<Pack> packs;
        private Usuari comprador;
        private double preuTotal;

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

        public Comanda(List<Pack> p, Usuari u)
        {
            numComanda = GenerarNumComanda();
            data = DateTime.Today;
            packs = p;
            comprador = u;
            PreuTotal();
        }

        private int GenerarNumComanda()
        {
            return Convert.ToInt32(data) + comprador.Id;
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
        //public string GenerarFactura()
        public string ToString() 
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