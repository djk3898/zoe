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
        private MySqlConnection connexio;
        private static string servidor = "192.168.1.92";
        private static string port = "3306";
        private static string usuari = "zoe";
        private static string contra = "zoe";
        private static string baseDades = "zoe";

        private string stringConnexio = $"server={servidor};port={port};user={usuari};password={contra};database={baseDades};";

        public MySqlConnection Connectar()
        {
            connexio = null;
            try
            {
                connexio = new(stringConnexio);
                connexio.Open();
                //MessageBox.Show("Connexio establerta");
                return connexio;
            }
            catch(Exception dbConnectionFail) {
                MessageBox.Show("ERROR\nNo s'ha pogut obrir la connexió amb la BBDD");
                return connexio;
            }

            if(connexio != null)
            {
                connexio.Close();
            }
        }
    }
}
