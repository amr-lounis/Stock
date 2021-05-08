using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Dataset.Model
{
    public partial class Entities : DbContext
    {
        //********************************************************
        #region init
        private static string getConnectionString()
        {
            string _host = "localhost";
            string _database_name = "stock";
            string _user_id = "root";
            string _password = "";
            string _port = "3306";
            string _sslM = "none";

            return String.Format("server={0};port={1};user id={2}; password={3}; database={4}; SslMode={5}", _host, _port, _user_id, _password, _database_name, _sslM);
        }


        private Entities() // Entities = Constructor of calss model
               : base(new MySqlConnection(getConnectionString()), true)
        { }
        public Entities(string connString)
                : base(new MySqlConnection(connString), true)
        { }
        private static Entities Instance;
        public static object mutex = new object();
        public static Entities GetInstance()
        {
            lock (mutex)
            {
                if (Instance == null)
                {
                    Instance = new Entities();
                    if (!Instance.Database.Exists())
                    {
                        Console.WriteLine("creatre database");
                        Instance = new Entities();
                    }
                }
                return Instance;
            }
        }
        public static void recreate()
        {
            Instance.Dispose();
            Instance = null;
        }

        #endregion
        //********************************************************
    }
}
