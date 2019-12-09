using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Console5_XML.Models
{
    class CampaignsReader
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public CampaignsReader()
        {
        }


        /// <summary>
        /// Read single Campaign
        /// </summary>
        /// <param name="path">component .xdev file path</param>
        /// <returns>Returns single component instance</returns>
        public CampaignDescription ReadCampaign(string path)
        {

            CampaignDescription campaign = null;

            XmlSerializer serializer = new XmlSerializer(typeof(CampaignDescription));
            try
            {
                StreamReader reader = new StreamReader(path);
                campaign = (CampaignDescription)serializer.Deserialize(reader);
                reader.Close();

                return campaign;
            }
            catch { return campaign; }
        }


        /// <summary>
        /// Read all Campaigns in bench/Campaigns by default
        /// </summary>
        /// <param name="benchPath">General path to all components</param>
        /// <returns>List of all components deserialized</returns>
        public List<CampaignDescription> ReadAllComponents(string benchPath = @"C:\bench_backup_22-11-2019\Components")
        {
            List<String> allfiles2 = Directory.GetFiles(benchPath, "*.xcamp", SearchOption.AllDirectories).ToList<String>();

            List<CampaignDescription> allCampaigns = new List<CampaignDescription>();

            foreach (var filePath in allfiles2)
            {
                var device = ReadCampaign(filePath);
                if (device != null)
                {
                    allCampaigns.Add(device);

                    device.Path = filePath;
                }
                else
                {
                   // allDevices.Add(new Campaign() { Name = "Protected method" });
                    Console.WriteLine("Error on path: " + filePath);
                }
            }

            return allCampaigns;

        }
    }
}

