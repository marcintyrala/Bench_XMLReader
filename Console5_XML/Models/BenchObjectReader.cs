using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Console5_XML.Models
{
    class BenchObjectReader
    {

        public static T ReadBenchObject<T>(string path)
        {
            T benchObject = default(T);

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            try
            {
                StreamReader reader = new StreamReader(path);
                benchObject = (T)serializer.Deserialize(reader);
                reader.Close();
                

            }
            catch {
                // throw new NotImplementedException();
                Console.WriteLine("Protected component on path: " + path);

            }

            return benchObject;
        }

        public static List<T> ReadAllBenchObjects<T>(string path,string pattern)
        {
           // List<String> allObjects = Directory.GetFiles(path, "*.xcamp", SearchOption.AllDirectories).ToList<String>();
            List<String> allBenchObjectsPath = Directory.GetFiles(path, pattern, SearchOption.AllDirectories).ToList<String>();

            List<T> allBenchObjects = new List<T>();

            foreach (var benchObjectPath in allBenchObjectsPath)
            {
                var device = BenchObjectReader.ReadBenchObject<T>(benchObjectPath);
                if (device != null)
                {
                    allBenchObjects.Add(device);
                    device.GetType().GetProperty("Path").SetValue(device,benchObjectPath);
                    
                }

            }

            return allBenchObjects;
        }


        public static void ListAllBenchObjects<T>(List<T> listOfComponents)
        {
            
            foreach (var item in listOfComponents)
            {

                var currentItemName =item.GetType().GetProperty("Name").GetValue(item);
                var currentItemPath = item.GetType().GetProperty("Path").GetValue(item).ToString();
                Console.Write(currentItemName);
                if (currentItemPath != null)
                    Console.WriteLine("\tPATH: \t" + System.IO.Directory.GetParent(currentItemPath).FullName);
                else Console.WriteLine("Path is null");

            }

}
    }
}
