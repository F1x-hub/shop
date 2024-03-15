using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp37
{
    internal class Admin : Person
    {
        

        internal void AddProduct(Person person, List<Product> products)
        {
            if (person != null)
            {
                Console.Write("Enter Manufacturer: ");
                string manufacturer = Console.ReadLine();
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Price: ");
                int price = int.Parse(Console.ReadLine());
                Console.Write("Enter Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                int productId = products.Count + 1;
                Product product = new Product
                {
                    ProductId = productId,
                    ProductManufacturer = manufacturer,
                    ProductName = name,
                    Price = price,
                    Quantity = quantity
                };
                products.Add(product);
            }
        }
        internal void UpdateProduct(Person person, List<Product> products)
        {
            if (person != null)
            {
                products.ForEach(p => Console.WriteLine(p));
                Console.Write("Choose Product By Name: ");
                string Name = Console.ReadLine();
                var product = products.FirstOrDefault(p => p.ProductName == Name);

                
                Console.Write("Enter Manufacturer: ");
                string manufacturer = Console.ReadLine();
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Price: ");
                int price = int.Parse(Console.ReadLine());
                Console.Write("Enter Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                if (product != null) 
                {
                    product.ProductName = name;
                    product.ProductManufacturer = manufacturer;
                    product.Price = price;
                    product.Quantity = quantity;
                }

            }
        }
        internal void DeleteProduct(Person person, List<Product> products)
        {
            if (person != null)
            {
                products.ForEach(p => Console.WriteLine(p));
                Console.Write("Choose Product By Name: ");
                string Name = Console.ReadLine();
                var product = products.FirstOrDefault(p => p.ProductName == Name);
                if (product != null)
                {
                    products.Remove(product);
                }
            }
        }
    }
    
}
