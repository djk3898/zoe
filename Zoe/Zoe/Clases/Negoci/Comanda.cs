using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zoe.Clases.Negoci
{
    public class Comanda
    {
        private int numComanda;
        private DateTime data;
        private List<Pack> packs;
        private Usuari comprador;
        private double total;

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

        public Comanda(DateTime d, List<Pack> p, Usuari u)
        {
            data = d;
            packs = p;
            comprador = u;
            numComanda = GenerarNumComanda();
        }

        private int GenerarNumComanda()
        {
            return Convert.ToInt32(data) + comprador.Id;
        }
        public string GenerarFactura()
        {
            return "";
        }
        public string ToString() { return ""; }
    }
}