﻿using MySql.Data.MySqlClient;
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
                        Console.Beep();
                        Instance = new Entities();
                    }
                    Console.Beep();
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
        //    modelBuilder.Entity<permission>().ToTable("permissions");
        //    modelBuilder.Entity<role>().ToTable("roles");
        //    modelBuilder.Entity<rolepermission>().ToTable("rolepermissions");
        //    modelBuilder.Entity<product>().ToTable("products");
        //    modelBuilder.Entity<category>().ToTable("categorys");
        //    modelBuilder.Entity<productsold>().ToTable("productsolds");
        //    modelBuilder.Entity<invoicesold>().ToTable("invoicesolds");
        //    modelBuilder.Entity<stock>().ToTable("stocks");
        //}
    }
}
