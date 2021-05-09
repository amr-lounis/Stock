using MySql.Data.MySqlClient;
using Stock.Controllers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Dataset.Model
{
    public partial class Entities : DbContext
    {
        //********************************************************
        #region init
        private Entities() // Entities = Constructor of calss model
               : base(new MySqlConnection(Config_CD.load().db_mysql.getConnectionString()), true)
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
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //    modelBuilder.Entity<user>().ToTable("users");
        //    modelBuilder.Entity<unit>().ToTable("units");
        //    modelBuilder.Entity<sold_products>().ToTable("sold_products");
        //    modelBuilder.Entity<roles_permissions>().ToTable("roles_permissions");
        //    modelBuilder.Entity<product>().ToTable("products");
        //    modelBuilder.Entity<permission>().ToTable("permissions");
        //    modelBuilder.Entity<invoice>().ToTable("invoices");
        //    modelBuilder.Entity<category>().ToTable("categorys");
        //}
    }
}
