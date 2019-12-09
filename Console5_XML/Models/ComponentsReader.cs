using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Console5_XML.Models
{
    class ComponentsReader
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ComponentsReader()
        {
        }


        /// <summary>
        /// Read single component
        /// </summary>
        /// <param name="path">component .xdev file path</param>
        /// <returns>Returns single component instance</returns>
        public Component ReadComponent(string path)
        {

            Component device = null;

            XmlSerializer serializer = new XmlSerializer(typeof(Component));
            try
            {
                StreamReader reader = new StreamReader(path);
                device = (Component)serializer.Deserialize(reader);
                reader.Close();

                return device;
            }
            catch { return device; }
        }


        /// <summary>
        /// Read all components in bench/components by default
        /// </summary>
        /// <param name="benchPath">General path to all components</param>
        /// <returns>List of all components deserialized</returns>
        public List<Component> ReadAllComponents(string benchPath = @"C:\bench_backup_22-11-2019\Components")
        {
            List<String> allfiles2 = Directory.GetFiles(benchPath, "*.xdev", SearchOption.AllDirectories).ToList<String>();

            List<Component> allDevices = new List<Component>();

            foreach (var filePath in allfiles2)
            {
                var device = ReadComponent(filePath);
                if (device != null)
                {
                    allDevices.Add(device);

                    device.Path = filePath;
                }
                else
                {
                    allDevices.Add(new Component() { Name = "Protected method" });
                    Console.WriteLine("Error on path: " + filePath);
                }
            }

            return allDevices;

        }
    }
}

