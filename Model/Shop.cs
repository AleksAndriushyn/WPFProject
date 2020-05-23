using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Shop
    {
        public int id;
        public string name;
        public static List<Good> Goods = new List<Good>();
        public Shop() { }
        public Shop(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public static void AddGood(string storeName)
        {
            List<Good> StoreGoods = FileDownloader.LoadStore<Good>();
            List<Good> ElectronicGoods = FileDownloader.LoadElectronics<Good>();
            List<Good> AptekaGoods = FileDownloader.LoadApteka<Good>();

            if (storeName == "Electronics")
            {
                foreach (Good g in ElectronicGoods)
                {
                    Goods.Add(g);
                }
            }

            if (storeName == "Apteka")
            {
                foreach (Good g in AptekaGoods)
                {
                    Goods.Add(g);
                }
            }

            if (storeName == "Store")
            {
                foreach (Good g in StoreGoods)
                {
                    Goods.Add(g);
                }
            } 
        }

        public void AddGoods(List<Good> newList)
        {
            Goods = newList;
        }

        public static string GetGoods(string storeName)
        {
            string allGoods = "";

            if (storeName == "Electronics")
            {
                foreach (var x in Goods)
                {
                    allGoods += "Name: " + x.name + ", Price: " + x.price + ", Availability: " + x.availbl + "." + "\n";
                }
                return allGoods;
            }

            else if (storeName == "Apteka")
            {
                foreach (var x in Goods)
                {
                    allGoods += "Name: " + x.name + ", Price: " + x.price + ", Availability: " + x.availbl + "." + "\n";
                }
                return allGoods;
            }

            else if (storeName == "Store")
            {
                foreach (var x in Goods)
                {
                    allGoods += "Name: " + x.name + ", Price: " + x.price + ", Availability: " + x.availbl + "." + "\n";
                }
                return allGoods;
            }
            return allGoods;
        }

        public static string BookItem(string bookGood)
        {
            Booking booking = new Booking(DateTime.Now.AddDays(7), DateTime.Now);

            string answer = $"You've booked the {bookGood} {booking.date}.\n" +
                    $"Your booking will expire {booking.validity}." +
                    $"\nCome to the store from Monday-Friday from 9:00 to 21:00.";

            return answer;
        }
    }
}
