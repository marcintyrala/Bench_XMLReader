using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Console5_XML.Models;

namespace Console5_XML
{
    class Program
    {
        static void Main(string[] args)
        {

            string campaignsPath = @"C:\bench_backup_22-11-2019\Campaigns";
            string searchCampaignsPattern = "*.xcamp";

            string componentsPath = @"C:\bench_backup_22-11-2019\Components";
            string searchComponentsPattern = "*.xdev";

            // Read Campaigns
            Console.WriteLine("\n\n List of all Campaigns: \n\n");
            List<CampaignDescription> listOfCampaigns = BenchObjectReader.ReadAllBenchObjects<CampaignDescription>(campaignsPath, searchCampaignsPattern);
            BenchObjectReader.ListAllBenchObjects<CampaignDescription>(listOfCampaigns);
            // Read Components
            Console.WriteLine("\n\n List of all Components: \n\n");

            List<Component> listOfComponents = BenchObjectReader.ReadAllBenchObjects<Component>(componentsPath, searchComponentsPattern);
            BenchObjectReader.ListAllBenchObjects<Component>(listOfComponents);
            Console.Read();
        }
    }
}
