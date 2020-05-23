using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Network
    {
        public static List<Shop> shops = new List<Shop>();
        public static void LoadShopsFromJson()
        {
            List<Shop> ShopJson = FileDownloader.LoadShops<Shop>();
            foreach (var s in ShopJson)
            {
                shops.Add(s);
            }
        }
        public static string AddShop(string name)
        {
            foreach (var x in shops)
            {
                if (name == x.name)
                {
                    return name;
                }
            }
            return name;
        }
        public static string GetShopByName(string StoreName)
        {
            if (StoreName == "Electronics")
            {
                Shop.AddGood(StoreName);
                return Shop.GetGoods(StoreName);
            }
            else if (StoreName == "Apteka")
            {
                Shop.AddGood(StoreName);
                return Shop.GetGoods(StoreName);
            }
            else if (StoreName == "Store")
            {
                Shop.AddGood(StoreName);
                return Shop.GetGoods(StoreName);
            }
            else throw new Exception();
        }
    }
}
