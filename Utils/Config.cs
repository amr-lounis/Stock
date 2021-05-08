using Stock.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Stock.Utils
{
    public class Config
    {
        //-----------------------------------------------------------------------------------------------
        public Config()
        {
            db_mysql = new Config_mysql();
            company = new Config_company();
            software = new Config_software();
        }
        //-----------------------------------------------------------------------------------------------
        public Config_mysql db_mysql;
        public Config_company company;
        public Config_software software;
        //-----------------------------------------------------------------------------------------------
        public static void save(Config _Config)
        {
            CreateDirectories();
            try
            {
                WriteToBinaryFile(dir_home() + "Config_mysql.bin", _Config.db_mysql);
                WriteToBinaryFile(dir_home() + "Config_company.bin", _Config.company);
                WriteToBinaryFile(dir_home() + "Config_software.bin", _Config.software);
            }
            catch (Exception){}
        }
        //-----------------------------------------------------------------------------------------------
        public static Config load()
        {
            CreateDirectories();
            try
            {
                Config o = new Config();
                o.db_mysql = ReadFromBinaryFile<Config_mysql>(dir_home() + "Config_mysql.bin");
                o.company = ReadFromBinaryFile<Config_company>(dir_home() + "Config_company.bin");
                o.software = ReadFromBinaryFile<Config_software>(dir_home() + "Config_software.bin");
                return o;
            }
            catch (Exception)
            {
                var o = new Config();
                save(o);
                return o;
            }
        }
        //-----------------------------------------------------------------------------------------------
        public static string dir_home() { return Path.Combine(Directory.GetCurrentDirectory(), @"config\"); }
        public static string dir_backups() { return Path.Combine(dir_home(), @"backups\"); }
        public static string dir_Invoices() { return Path.Combine(dir_home(), @"invoices\"); }
        public static string dir_images() { return Path.Combine(dir_home(), @"images\"); }
        //----------------------------------------------------------------------------------------------- 
        private static void CreateDirectories(){
            try{
                string[] array_dir = { dir_home(), dir_backups(), dir_Invoices(), dir_images() };
                foreach (string dir in array_dir) if (!System.IO.Directory.Exists(dir)) System.IO.Directory.CreateDirectory(dir);
            }
            catch (Exception){}
        }
        //----------------------------------------------------------------------------------------------- 
        private static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }
        //----------------------------------------------------------------------------------------------- 
        private static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }
        //-----------------------------------------------------------------------------------------------
    }
    //----------------------------------------------------------------------------------------------- class Serializable
    #region class Serializable
    [Serializable]
    public class Config_mysql
    {
        public String Charset = "UTF8";
        public String Host = "localhost";
        public string db_name = "stock";
        public String UserID = "root";
        public String Password = "";
        public string sslM = "none";
        public int Port = 3306;
        public string getConnectionString()
        {
            return String.Format("server={0};port={1};user id={2}; password={3}; database={4}; SslMode={5}", Host, Port, UserID, Password, db_name, sslM);
        }
    }
    [Serializable]
    public class Config_company
    {
        public String NAME = "Company";
        public String ACTIVITY = "";
        public String NRC = "";
        public String NIF = "";
        public String DESCRIPTION = "";
        public String CREATE_DATE = "";
        public String ADDRESS = "";
        public String CITY = "";
        public String COUNTRY = "";
        public String PHONE = "";
        public String FAX = "";
        public String WEBSITE = "";
        public String EMAIL = "";
    }
    [Serializable]
    public class Config_software
    {
        public String activation_hash_add = "lounis_amar_inventory_management_system";
        public String language = "EN";
        public String currency = "DA";
        public int pageSizeSearch = 10;
    }
    #endregion
}
