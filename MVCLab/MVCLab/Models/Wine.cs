using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MVCLab.Models
{
    public class Wine
    {
        public int ID { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string Designation { get; set; }
        public int Points { get; set; }
        public decimal Price { get; set; }
        public string Region_1 { get; set; }
        public string Region_2 { get; set; }
        public string Variety { get; set; }
        public string Winery { get; set; }

        /// <summary>
        /// Reads the csv data file, and queries the data for wines that are within the requested price and point range.
        /// </summary>
        /// <param name="price">The maximum price</param>
        /// <param name="points">The minimum points</param>
        /// <returns>The list of wines within the range requested</returns>
        public static List<Wine> GetWineList(int price, int points)
        {
            var reader = new StreamReader(File.OpenRead("../wine.csv"));
            List<Wine> wines = new List<Wine>();
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                // This Regex came from stack overflow: https://stackoverflow.com/questions/6542996/how-to-split-csv-whose-columns-may-contain
                string[] data = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

                wines.Add(new Wine()
                {
                    ID = Convert.ToInt32(data[0]),
                    Country = data[1],
                    Description = data[2],
                    Designation = data[3],
                    Points = int.TryParse(data[4], out int point) ? point : -1,
                    Price = Decimal.TryParse(data[5], out Decimal cost) ? cost : Decimal.MaxValue,
                    Region_1 = data[6],
                    Region_2 = data[7],
                    Variety = data[8],
                    Winery = data[9]    
                });

            }
            
            List<Wine> wineList = wines.Where(wine => (wine.Points >= points && wine.Price <= price)).ToList();
            return wineList;
        }
       
    }
}
