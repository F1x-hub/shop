using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp37
{
    internal class Product
    {
        public int ProductId { get; set; }
        public string ProductManufacturer { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public override string ToString()
        {
            return $"ProductId: {ProductId} - Manufacturer: {ProductManufacturer} - Name: {ProductName} - Price: {Price} - {Quantity}";
        }
    }
}
