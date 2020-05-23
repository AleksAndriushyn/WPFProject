using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Model;

namespace ViewModel
{
    public class ShopsViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //string _GetShopByName;
        //public string GetShopByName
        //{
        //    get => _GetShopByName;
        //    set
        //    {
        //        _GetShopByName = value;
        //        OnPropertyChanged("GetShopByName");
        //    }
        //}

        string _ChosenShop;
        public string ChosenShop
        {
            get => _ChosenShop;
            set
            {
                _ChosenShop = value;
                OnPropertyChanged("ChosenShop");
            }
        }

        string _storeName;
        public string storeName
        {
            get => _storeName;
            set
            {
                _storeName = value;
            }
        }

        //string _goodName;
        //public string goodName
        //{
        //    get => _goodName;
        //    set
        //    {
        //        _goodName = value;
        //    }
        //}

        string _bookGood;
        public string bookGood
        {
            get => _bookGood;
            set
            {
                _bookGood = value;
            }
        }

        //Command _AddShopCommand;
        //public ICommand AddShopCommand
        //{
        //    get
        //    {
        //        if (_AddShopCommand == null)
        //            _AddShopCommand = new Command(ExecuteAddShopCommand, CanExecuteAddShopCommand);
        //        return _AddShopCommand;
        //    }
        //}
        //private void ExecuteAddShopCommand(object parameter)
        //{
        //    Network.AddShop(storeName);
        //    //storeName = "Store";
        //    OnPropertyChanged("storeName");
        //}

        //private bool CanExecuteAddShopCommand(object parameter)
        //{
        //    return true;
        //}

        Command _AddShopsCommand;
        public ICommand AddShopsCommand
        {
            get
            {
                if (_AddShopsCommand == null)
                    _AddShopsCommand = new Command(ExecuteAddShopsCommand, CanExecuteAddShopsCommand);
                return _AddShopsCommand;
            }
        }
        private void ExecuteAddShopsCommand(object parameter)
        {
            Network.LoadShopsFromJson();
            StringBuilder sb = new StringBuilder("");
            foreach (var s in Network.shops)
            {
                sb.Append(s.name + "\n");
            }
            storeName = sb.ToString();
            OnPropertyChanged("storeName");
        }

        private bool CanExecuteAddShopsCommand(object parameter)
        {
            return true;
        }

        Command _GetShopByNameCommand;
        public ICommand GetShopByNameCommand
        {
            get
            {
                if (_GetShopByNameCommand == null)
                    _GetShopByNameCommand = new Command(ExecuteGetShopByNameCommand, CanExecuteGetShopByNameCommand);
                return _GetShopByNameCommand;
            }
        }
        private void ExecuteGetShopByNameCommand(object parameter)
        {
            Network.GetShopByName(storeName);
            OnPropertyChanged("storeName");
        }

        private bool CanExecuteGetShopByNameCommand(object parameter)
        {
            return true;
        }

        private void ExecuteGetGoodsCommand(object parameter)
        {
            Shop.AddGood(ChosenShop);
            Shop.GetGoods(ChosenShop);
            StringBuilder sb = new StringBuilder("");
            foreach (var good in Shop.Goods)
            {
                sb.Append(good.name + "Price: " + good.price + "\n");
            }
            ChosenShop = sb.ToString();
            OnPropertyChanged("ChosenShop");
        }

        private bool CanExecuteGetGoodsCommand(object parameter)
        {
            return true;
        }

        Command _GetGoodsCommand;
        public ICommand GetGoodsCommand
        {
            get
            {
                if (_GetGoodsCommand == null)
                    _GetGoodsCommand = new Command(ExecuteGetGoodsCommand, CanExecuteGetGoodsCommand);
                return _GetGoodsCommand;
            }
        }

        private void ExecuteBookItemCommand(object parameter)
        {
            Shop.BookItem(bookGood);
        }

        private bool CanExecuteBookItemCommand(object parameter)
        {
            return true;
        }

        Command _BookItemCommand;
        public ICommand BookItemCommand
        {
            get
            {
                if (_BookItemCommand == null)
                    _BookItemCommand = new Command(ExecuteBookItemCommand, CanExecuteBookItemCommand);
                return _BookItemCommand;
            }
        }

        //public string AddShop()
        //{
        //    return Network.AddShops();
        //}
        //public string GetShopByName(string ShopName)
        //{
        //    return Network.GetShopByName(ShopName);
        //}
    }
}
