using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Online_registration_by_CoR.Models
{
    public class Products : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnpropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public Products()
        {
                
        }

        public Products(string name, decimal price, decimal weight, decimal quantity, string imagePath, decimal sum)
        {
            Name = name;
            Price = price;
            Weight = weight;
            Quantity = quantity;
            ImagePath = imagePath;
            Sum = sum;
        }

        public string _Name;
        public decimal _Price;
        public decimal _Weight;
        public decimal _Quantity = 0;
        public decimal _sum = 0;
        public string _imagePath;




        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public decimal Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        public decimal Weight
        {
            get { return _Weight; }
            set { _Weight = value;  }
        }
        public decimal Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }


        public string ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value;  }
        }

        public decimal Sum
        {
            get { return _sum; }
            set { _sum = value; }
        }
    }
}
