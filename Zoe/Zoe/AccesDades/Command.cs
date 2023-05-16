using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using MySql.Data.MySqlClient;

namespace Zoe.AccesDades
{
    internal class Command
    {
        private MySqlCommand cmd;
        private Connexio c;
        private string resultat;

        public string Select(string query)
        {
            c = new Connexio();
            MySqlConnection connexio = c.Connectar();   //obrim la connexio
            cmd = new MySqlCommand(query, connexio);    //creem objecte comand per executar la query

            MySqlDataReader dataReader = cmd.ExecuteReader();

            while(dataReader.Read())
            {
                int id = dataReader.GetInt32(0);
                resultat += id.ToString();
                resultat += "; " + dataReader.GetString(1);
            }
            dataReader.Close();
            connexio.Close();
            return resultat;
        }
    }
}
