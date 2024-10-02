using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Lab_4
{
    public class JsonFileHandler
    {
        public static void CreateJsonFile(string filePath, List<Entrant> entrants)
        {
            string json = JsonConvert.SerializeObject(entrants, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static string ReadJsonFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
