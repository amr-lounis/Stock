using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Controllers
{
    public class Helper
    {
        public static DateTime DateTimeFromString(string _DateTime)
        {
            try
            {
                return DateTime.ParseExact(_DateTime, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                return DateTime.Now;
            }
        }
        public static string DateTimeToString(DateTime _DateTime)
        {
            return _DateTime.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
        }
        public static double DoubleFromString(string _Double)
        {
            try
            {
                return double.Parse(_Double);
            }
            catch (Exception)
            {
                return 0f;
            }
        }

        static Random r = new Random();
        public static string random()
        {
            int a = 0, b = 999;
            return string.Format("{0}", r.Next(a, b));
        }
        public static string GetPropertyString(object obj, string p_property_name)
        {
            System.Reflection.PropertyInfo pi = obj.GetType().GetProperty(p_property_name);
            return (string)(pi.GetValue(obj, null));
        }
        public static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }
        public static T ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (T)binaryFormatter.Deserialize(stream);
            }
        }

    }
}
