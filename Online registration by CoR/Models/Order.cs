using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Online_registration_by_CoR.Models
{
    public class Order : INotifyPropertyChanged
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

        public Order()
        {

        }

        public Order(string name, decimal price, decimal weight, decimal quantity, string imagePath, decimal sum)
        {
            Name = name;
            Price = price;
            Weight = weight;
            Quantity = quantity;
            ImagePath = imagePath;
            Sum = sum;
        }






        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public decimal Quantity { get; set; }


        public string ImagePath { get; set; }

        public decimal Sum { get; set; }
    }
}

