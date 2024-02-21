using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
namespace C_CLASS25._11._2
{
    static class StatisticsManager
    {
        public static void runStatistics()
        {
            PrintManger.printEnterFileName();

            string fileName = Console.ReadLine();
            string filePath = $"..\\..\\{fileName}.json";

            if (fileName != null && File.Exists(filePath))
            {
                writeStatistics(fileName, filePath);
            }
            else
            {
                Console.WriteLine($"\nFile '{fileName?.ToString()}.json' not found.");
            }

            PrintManger.pressEnterMainMenu();
            Console.ReadLine();
        }
        private static void writeStatistics(string fileName, string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                Statistics statistics = JsonSerializer.Deserialize<Statistics>(fileStream);

                PrintManger.printStat(statistics, fileName);
            }
        }
    }
}