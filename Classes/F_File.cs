using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Xml.Serialization;

namespace Stock.Classes
{
    public class F_File
    {
        //****************************************************************************************************************
        static string thisPath = System.Reflection.Assembly.GetEntryAssembly().Location;
        #region browser
        public static string browserFile(string p_filter)//"image | *.png;*.jpg;"//"Database | *.FDB;"//"Database | *.FBK;"
        {
            OpenFileDialog mOpenFileDialog = new OpenFileDialog();
            mOpenFileDialog.FileName = "";
            mOpenFileDialog.Filter = p_filter;
            mOpenFileDialog.InitialDirectory = System.Reflection.Assembly.GetEntryAssembly().Location;
            if (mOpenFileDialog.ShowDialog() == true)
            {
                String path = mOpenFileDialog.FileName;
                return path;
            }
            else
            {
                return "";
            }
        }
        public static string browserFileCrete(string p_filter)//"Database | *.fdb;"
        {
            SaveFileDialog mSaveFileDialog = new SaveFileDialog();
            mSaveFileDialog.FileName = "";
            mSaveFileDialog.Filter = p_filter;
            mSaveFileDialog.InitialDirectory = System.Reflection.Assembly.GetEntryAssembly().Location;
            if (mSaveFileDialog.ShowDialog() == true)
            {
                String path = mSaveFileDialog.FileName;
                return path;
            }
            else
            {
                return "";
            }
        }
        #endregion
        //****************************************************************************************************************
        #region file
        public static byte[] FileRead_Bytes(string p_Path)
        {
            try
            {
                FileStream fs = new FileStream(p_Path, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] bytes = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
                return bytes;
            }
            catch(Exception e)
            {
                LogError(e);
                return null;
            }
        }
        public static void FileWrite(byte[] p_bytes , String p_path)
        {
            try
            {
                FileStream fs = new FileStream(p_path, FileMode.OpenOrCreate, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(p_bytes);
                bw.Close();
                fs.Close();
            }
            catch (Exception e)
            {
                LogError(e);
            }
        }
        public static void FileFromStram(Stream stream, string destPath)
        {
            try
            {
                using (var fileStream = new FileStream(destPath, FileMode.Create, FileAccess.Write))
                {
                    stream.CopyTo(fileStream);
                }
            }
            catch (Exception e)
            {
                LogError(e);
            }
        }
        #endregion
        //****************************************************************************************************************
        #region string
        public static string ByteArrayToString(byte[] ba)
        {
            return BitConverter.ToString(ba).Replace("-", "");
        }
        public static String FileToString(String p_path)
        {
            FileStream fs = new FileStream(p_path, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            fs.Close();
            return sr.ReadToEnd();
        }
        public static byte [] StringToByte(String p_String)
        {
            return Encoding.ASCII.GetBytes(p_String);
        }
        public static String StringFromByte(byte[] p_bytes)
        {
            return Encoding.ASCII.GetString(p_bytes);
        }
        public static String StringFromStream(Stream p_Stream)
        {
            using (StreamReader reader = new StreamReader(p_Stream))
            {
                return reader.ReadToEnd();
            }
        }
        #endregion
        //****************************************************************************************************************
        #region Serialize
        public static void SerializeObject<T>(T serializableObject, string fileName)
        {
            if (serializableObject == null) { return; }

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
                using (MemoryStream stream = new MemoryStream())
                {
                    serializer.Serialize(stream, serializableObject);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(fileName);
                }
            }
            catch (Exception ex)
            {
                DialogError.Error(""+ex);
            }
        }

        public static T DeSerializeObject<T>(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) { return default(T); }

            T objectOut = default(T);

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                string xmlString = xmlDocument.OuterXml;

                using (StringReader read = new StringReader(xmlString))
                {
                    Type outType = typeof(T);

                    XmlSerializer serializer = new XmlSerializer(outType);
                    using (XmlReader reader = new XmlTextReader(read))
                    {
                        objectOut = (T)serializer.Deserialize(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Beep(); DialogError.Error("" + ex);
            }

            return objectOut;
        }

        //****************************************************************************************************************
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
        //****************************************************************************************************************
        #endregion
        //****************************************************************************************************************
        #region object
        public static double GetPropertyDouble(object obj, string p_property_name)
        {
            System.Reflection.PropertyInfo pi = obj.GetType().GetProperty(p_property_name);
            return (double)(pi.GetValue(obj, null));
        }
        public static int GetPropertyInt(object obj, string p_property_name)
        {
            System.Reflection.PropertyInfo pi = obj.GetType().GetProperty(p_property_name);
            return (Int32)(pi.GetValue(obj, null));
        }
        public static string GetPropertyString(object obj, string p_property_name)
        {
            System.Reflection.PropertyInfo pi = obj.GetType().GetProperty(p_property_name);
            return (string)(pi.GetValue(obj, null));
        }
        //****************************************************************************************************************
        #endregion
        //****************************************************************************************************************
        #region Log
        private static void Log(string p_string,string p_fileName)
        {
            try
            {
                File.AppendAllText(Path.Combine(thisPath, p_fileName) , p_string + Environment.NewLine);
            }
            catch (Exception e)
            {
                DialogError.Error(e.StackTrace);
            }
        }
        //
        public static void LogError(Exception e)
        {
            Log("----------" + F_Time.DateTime2String_yyyy_MM_dd_HH_mm_ss(DateTime.Now) + "----------\n" +
                "{\n" +
                    e.StackTrace +
                "\n}" +
                "\n"
                , "LogError.txt");
            Console.Beep();
        }
        public static void LogInformation(String p_Message)
        {
            Log("Information ----------" + F_Time.DateTime2String_yyyy_MM_dd_HH_mm_ss(DateTime.Now) + "----------\n" +
                "{\n" +
                 "    "+ p_Message +
                "\n}" +
                "\n"
                , "LogInformation.txt");
        }
        #endregion
        //****************************************************************************************************************
        #region PictureCompany
        public static byte[] PictureCompanyGet()
        {
            String mPath = Path.Combine(thisPath, "company.png");
            if (File.Exists(mPath))
            {
                return F_File.FileRead_Bytes(mPath);
            }
            //else
            //{
            //    var mImage = Image2Bytes(Properties.Resources.DefaultCompany);
            //    F_File.FileWrite(mImage, mPath);
            //    return mImage;
            //}
            return null;
        }
        //
        public static string PictureCompanyGetbase64()
        {
            return Convert.ToBase64String(PictureCompanyGet());
        }
        public static void PictureCompanySet(byte[] p_bitmapImage)
        {
            String mPath = Path.Combine(thisPath, "company.png");
            F_File.FileWrite(p_bitmapImage, mPath);
        }
        #endregion
        #region Convert
        public static BitmapImage Bytes2BitmapImage(byte[] imageData, int new_width, int new_height)
        {
            if (imageData == null || imageData.Length == 0) return new BitmapImage();
            return Stream2BitmapImage(new MemoryStream(imageData), new_width, new_height);
        }
        public static BitmapImage Stream2BitmapImage(MemoryStream p_stream, int new_width, int new_height)
        {
            var image = new BitmapImage();
            p_stream.Position = 0;
            image.BeginInit();
            image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.UriSource = null;
            image.StreamSource = p_stream;
            image.DecodePixelWidth = new_width;
            image.DecodePixelHeight = new_height;
            image.EndInit();
            image.Freeze();
            return image;
        }
        public static byte[] BitmapImage2Bytes(BitmapImage bitmapImage)
        {
            bitmapImage = Resize_BitmapImage(bitmapImage, 100, 100);
            byte[] data;
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }
        public static byte[] Image2Bytes(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        #endregion
        #region resize
        public static BitmapImage Resize_BitmapImage(BitmapImage bitmapImage, int new_width, int new_height)
        {
            byte[] imageData;
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                imageData = ms.ToArray();
            }
            if (imageData == null || imageData.Length == 0) return new BitmapImage();
            return Stream2BitmapImage(new MemoryStream(imageData), new_width, new_height);
        }
        public static Bitmap Resize_Bitmap(Bitmap image, int new_width, int new_height)
        {
            double scale = Math.Min(new_width / image.Width, new_height / image.Height);
            var bmp = new Bitmap((int)new_width, (int)new_height);
            var graph = Graphics.FromImage(bmp);
            var scaleWidth = (int)(image.Width * scale);
            var scaleHeight = (int)(image.Height * scale);
            var brush = new SolidBrush(System.Drawing.Color.Black);
            graph.FillRectangle(brush, new RectangleF(0, 0, new_width, new_height));
            graph.DrawImage(image, ((int)new_width - scaleWidth) / 2, ((int)new_height - scaleHeight) / 2, scaleWidth, scaleHeight);
            return image;
        }
        #endregion
    }
}
