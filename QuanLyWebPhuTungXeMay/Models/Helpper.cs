using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace QuanLyWebPhuTungXeMay
{
    class Helpper<T> where T : class
    {
        public static T ReadFile(string filename)
        {
            var fullpath = Path.Combine(Common.FullPath, filename);
            var data = "";
            using (StreamReader sr = File.OpenText(fullpath))
            {
                data = sr.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<T>(data);
        }
        public static void WriteFile(string filename, object data)
        {
            var serializeObject = JsonConvert.SerializeObject(data);
            var fullpath = Path.Combine(Common.FullPath, filename);
            using (StreamWriter sw = File.CreateText(fullpath))
            {
                sw.WriteLine(serializeObject);
            }
        }
    }
}
