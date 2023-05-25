using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Zoe
{
    public class Usuari
    {
        private string rol;
        private int id;
        private string nom;
        private string contra;

        private string email;
        private string provincia;
        private string direccio;
        private int cPostal;
        private int telf;

        public int Id
        {
            get { return id; }
        }
        public string Email
        {
            get { return email; }
        }
        public string Provincia
        {
            get { return provincia; }
        }
        public string Direccio
        {
            get { return direccio; }
        }
        public int CP
        {
            get { return cPostal; }
        }
        public int Telefon
        {
            get { return telf; }
        }
        public Usuari() { }
        public Usuari(string r, string n, string c)
        {
            rol = r;
            nom = n;
            contra = c;
        }
        public Usuari(string r, string n, string c, string e, string p, string d, int cp, int t) : this(r, n, c)
        {
            email = e;
            provincia = p;
            direccio = d;
            cPostal = cp;
            telf = t;
            id = GenerarIdUsuari();
        }
        private int GenerarIdUsuari()
        {
            return Convert.ToInt32(rol) + telf;
        }
    }
}