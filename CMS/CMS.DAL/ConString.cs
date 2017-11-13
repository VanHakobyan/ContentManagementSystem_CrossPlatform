using System.IO;
using Newtonsoft.Json;

namespace CMS.DAL
{
    public static class ConString
    {
        public static string GetValue()
        {
            return JsonConvert.DeserializeObject<Root>(File.ReadAllText($"{Directory.GetCurrentDirectory()}\\appsettings.json")).ConnectionStrings.DefaultConnection;
        }
        public class Root
        {
            public Connectionstrings ConnectionStrings { get; set; }
        }

        public class Connectionstrings
        {
            public string DefaultConnection { get; set; }
        }
    }
}
