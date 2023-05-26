using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private int resultatInt;
        private double resultatDouble;
        private bool resultatBool;
        private DateTime resultatDate;
        
        //SELECT
        public string SelectString(string query)
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
                string dada = dataReader.GetString(0);
                resultatString = dada;
            }
            //tanquem la connexio
            dataReader.Close();
            connexio.Close();
            return resultatString;
        }
        public int SelectInt(string query)
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
                int dada = dataReader.GetInt32(0);
                resultatInt = dada;
            }
            //tanquem la connexio
            dataReader.Close();
            connexio.Close();
            return resultatInt;
        }
        public double SelectDouble(string query)
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
                double dada = Convert.ToDouble(dataReader.GetDecimal(0).ToString("0.00"));
                resultatDouble = dada;
            }
            //tanquem la connexio
            dataReader.Close();
            connexio.Close();
            return resultatDouble;
        }
        public DateTime SelectDate(string query)
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
                DateTime dada = dataReader.GetDateTime(0);
                resultatDate = dada;
            }
            //tanquem la connexio
            dataReader.Close();
            connexio.Close();
            return resultatDate;
        }

        //USUARIS
        public bool VerificarEmail(string email)
        {
            string pattern = @"^[\w\.-]+@[\w\.-]+\.\w+$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
        public bool VerificarTelf(string telf)
        {
            string pattern = @"^(?:\d{3}\d{2}\d{2}\d{2})$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(telf);
        }
        public bool VerificarCP(string cp)
        {
            string pattern = @"^(0[1-9]|[1-4]\d|5[0-2])\d{3}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(cp);
        }
        public bool VerificarContra(string contra)
        {
            string pattern = @"^(?=.*[A-Za-z])(?=.*\d).{8,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(contra);
        }

        public bool VerificaUsuari(string query)
        {
            //obrim la connexio
            c = new Connexio();
            try
            {
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
            catch (Exception ex)
            { return false; }
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

        public void GuardarComanda(string query)
        {
            //obrim la connexio
            c = new Connexio();
            MySqlConnection connexio = c.Connectar();
            //executem la query
            cmd = new MySqlCommand(query, connexio);
            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();
                connexio.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                connexio.Close();
            }
        }

        public bool Afegir(string query)
        {
            //obrim la connexio
            c = new Connexio();
            MySqlConnection connexio = c.Connectar();
            //executem la query
            cmd = new MySqlCommand(query, connexio);
            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();
                connexio.Close();
                MessageBox.Show("Creado!");
                return true;
            }
            catch (MySql.Data.MySqlClient.MySqlException dadesDuplicades)
            {
                MessageBox.Show("Ya existe!");
                connexio.Close();
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                connexio.Close();
                return false;
            }
        }

        public bool Eliminar(string query)
        {
            //obrim la connexio
            c = new Connexio();
            MySqlConnection connexio = c.Connectar();
            //executem la query
            cmd = new MySqlCommand(query, connexio);
            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();
                connexio.Close();
                MessageBox.Show("Eliminado!");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                connexio.Close();
                return false;
            }
        }
    }
}
