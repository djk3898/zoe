using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using MySql.Data.MySqlClient;

namespace Zoe.AccesDades
{
    internal class Command
    {
        private MySqlCommand cmd;
        private Connexio c;
        private string resultatString;
        private bool resultatBool;

        private string Select(string query)
        {
            //obrim la connexio
            c = new Connexio();
            MySqlConnection connexio = c.Connectar();
            //executem la query
            cmd = new MySqlCommand(query, connexio);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            //comprovem les dades
            while (dataReader.Read())
            {
                int id = dataReader.GetInt32(0);
                resultatString += id.ToString();
                resultatString += "; " + dataReader.GetString(1);
            }
            //tanquem la connexio
            dataReader.Close();
            connexio.Close();
            return resultatString;
        }

        public bool VerificaUsuari(string query)
        {
            //obrim la connexio
            c = new Connexio();
            MySqlConnection connexio = c.Connectar();
            //executem la query
            cmd = new MySqlCommand(query, connexio);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            //comprovem les dades
            if (!(dataReader.Read()))
            {
                MessageBox.Show("Usuari o contrasenya incorrectes");
                resultatBool = false;
            }
            else resultatBool = true;
            //tanquem la connexio
            dataReader.Close();
            connexio.Close();
            return resultatBool;
        }
        public bool VerificaRol(string query)
        {
            //obrim la connexio
            c = new Connexio();
            MySqlConnection connexio = c.Connectar();
            //executem la query
            cmd = new MySqlCommand(query, connexio);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            //comprovem les dades
            if (dataReader.Read())
            {
                if (dataReader.GetInt32(0) == 1)
                    resultatBool = true;    //admin
                else resultatBool = false;  //client
            }
            //tanquem la connexio
            dataReader.Close();
            connexio.Close();
            return resultatBool;
        }
    }
}
