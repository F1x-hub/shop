using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp37
{
    internal class Shop
    {
        
        public int TotalPrice { get; set; }

        public override string ToString()
        {
            return $"TotalPrice: {TotalPrice}";
        }
        public void ShowProducts(List<Product> products)
        {
            foreach (var item in products) 
            {
                TotalPrice = 0;
                Console.WriteLine(item);
                TotalPrice += item.Price * item.Quantity;
                Console.WriteLine(this);
            }
        }
    }
}
