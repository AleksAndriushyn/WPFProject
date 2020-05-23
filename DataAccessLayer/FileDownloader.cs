using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Newtonsoft.Json;

namespace DataAccessLayer
{
    public class FileDownloader
    {
        public static List<T> LoadStore<T>()
        {
            var path = ConfigurationManager.ConnectionStrings["StoreGoods"].ConnectionString;
            var SomeList = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path));
            return SomeList;
        }
        public static List<T> LoadElectronics<T>()
        {
            var path = ConfigurationManager.ConnectionStrings["ElectronicsGoods"].ConnectionString;
            var SomeList = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path));
            return SomeList;
        }
        public static List<T> LoadApteka<T>()
        {
            var path = ConfigurationManager.ConnectionStrings["AptekaGoods"].ConnectionString;
            var SomeList = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path));
            return SomeList;
        }
        public static List<T> LoadShops<T>()
        {
            var path = ConfigurationManager.ConnectionStrings["Shops"].ConnectionString;
            var SomeList = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(path));
            return SomeList;
        }
    }
}
