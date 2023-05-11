using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Zoe.AccesDades
{
    public class Connexio
    {
        //Atributs
        MySqlConnection connexio;
        static string servidor = "";
        static string port = "";
        static string usuari = "";
        static string contra = "";
        static string baseDades = "";

        string stringConnexio = $"server={servidor};port={port};user={usuari};password={contra};database={baseDades};";

        public MySqlConnection Connectar()
        {
            try
            {
                connexio = new(stringConnexio);
                connexio.Open();

            }
            catch(Exception dbConnectionFail) {
                MessageBox.Show("ERROR\nNo s'ha pogut obrir la connexió amb la BBDD");
            }
            finally
            {
                if(connexio != null)
                {
                    connexio.Close();
                }
            }
        }
    }
}
