using System.IO;
using Newtonsoft.Json;

namespace CMS.DAL
{
    public static class ConString
    {
        public static string GetValue()
        {
            return JsonConvert.DeserializeObject<Root>(new StreamReader(@".\Properties\appsettings.json", System.Text.Encoding.Default).ReadToEnd()).ConnectionStrings.DefaultConnection;
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
