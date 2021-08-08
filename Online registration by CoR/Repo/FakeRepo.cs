using Online_registration_by_CoR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_registration_by_CoR.Repo
{
    public class FakeRepo
    {
        public List<Products> GetAll()
        {
            // ImageSource = new BitmapImage(new Uri(@"LogoFoodStore.png", UriKind.Relative));
            return new List<Products>
            {

                new Models.Products
                {
                    Name="Caldo de Galinha",
                    Weight=10,
                    Price=0.5M,
                    ImagePath="../../Images/p1.png",
                    Quantity=1,


                },

                new Models.Products
                {
                    Name="Forel",
                    Weight=10,
                    Price=5M,
                    ImagePath="../../Images/p2.png",
                    Quantity=1,

                },

                new Models.Products
                {
                    Name="Alyonka",
                    Weight=10,
                    Price=2M,
                    ImagePath="../../Images/p3.jpg",
                    Quantity=1,

                },

                new Models.Products
                {
                    Name="Fiorella",
                    Weight=10,
                    Price=0.5M,
                    ImagePath="../../Images/p4.jpg",
                    Quantity=1,

                },

                new Models.Products
                {
                    Name="Pistachios",
                    Weight=10,
                    Price=5M,
                    ImagePath="../../Images/p5.jpg",
                    Quantity=1,

                },

                new Models.Products
                {
                    Name="Azərçay",
                    Weight=100,
                    Price=2.5M,
                    ImagePath="../../Images/p6.jpg",
                    Quantity=1,

                },

            };
        }
    }
}
