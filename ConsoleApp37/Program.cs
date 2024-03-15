using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp37
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>() 
            {
                new Product(){ProductId = 1, ProductManufacturer = "asdasd" , ProductName = "ssss", Price = 2000, Quantity = 54},
                new Product(){ProductId = 2, ProductManufacturer = "gdfg" , ProductName = "gas", Price = 300, Quantity = 34},
                new Product(){ProductId = 3, ProductManufacturer = "nbygf" , ProductName = "sasd", Price = 100, Quantity = 67},
                new Product(){ProductId = 4, ProductManufacturer = "fdff" , ProductName = "ase", Price = 4657, Quantity = 586},
                new Product(){ProductId = 5, ProductManufacturer = "gggg" , ProductName = "jhtyj", Price = 5000, Quantity = 12},
            };
            List<Person> people = new List<Person>() 
            {
                new User(){Id = 1 , UserName = "ika" , Password = "ika" , UserType = "User"},
                new User(){Id = 2 , UserName = "dd" , Password = "dd" , UserType = "User"},
                new Admin(){Id = 3 , UserName = "sss" , Password = "sss" , UserType = "Admin"},
            };
            Shop shop = new Shop();
            List<Buy<Product>> buy = new List<Buy<Product>>();
            Admin admin = new Admin();

            ShopMenu(people, products, buy, admin);



        }
        static void ShopMenu(List<Person> people, List<Product> products, List<Buy<Product>> buy, Admin admin)
        {
            int control = 0;
            while (control != 3)
            {
                Console.WriteLine("1. LogIn\n2. Registration\n3. Exit");
                try
                {
                    control = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {

                    Console.WriteLine(e.Message);
                }
                

                if (control == 1)
                {
                    Login(people, products, buy, admin);
                }
                if (control == 2)
                {
                    Registration(people);
                }

            }

        }
        static void Registration(List<Person> people)
        {
            int control = 0;
            string Type = "";

            Console.WriteLine("choise: \n1. User\n2. Admin");
            control = int.Parse(Console.ReadLine());

            if (control == 1)
            {
                Type = "User";

                Console.Write("Enter UserName: ");
                string UserName = Console.ReadLine();
                Console.Write("Enter Password: ");
                string Password = Console.ReadLine();

                int num = people.Count;

                people.Add(new User() { Id = num++, UserName = UserName, Password = Password, UserType = Type });
            }
            if (control == 2)
            {
                Type = "Admin";

                Console.Write("Enter UserName: ");
                string UserName = Console.ReadLine();
                Console.Write("Enter Password: ");
                string Password = Console.ReadLine();

                int num = people.Count;

                people.Add(new User() { Id = num++, UserName = UserName, Password = Password, UserType = Type });
            }
        }
        static void Login(List<Person> people, List<Product> products, List<Buy<Product>> buy, Admin admin)
        {
            int control = 0;
            string Type = "";
            
            Console.WriteLine("choise: \n1. User\n2. Admin");
            control = int.Parse(Console.ReadLine());

            if (control == 1)
            {
                Type = "User";

                Console.Write("Enter UserName: ");
                string UserName = Console.ReadLine();
                Console.Write("Enter Password: ");
                string Password = Console.ReadLine();

                
                var person = people.FirstOrDefault(p => p.UserName == UserName && p.Password == Password && p.UserType == Type);
                Console.WriteLine(person);
                if (person != null)
                {
                    UserMenu(person, products, buy);
                }

            }
            if(control == 2)
            {
                Type = "Admin";

                Console.Write("Enter UserName: ");
                string UserName = Console.ReadLine();
                Console.Write("Enter Password: ");
                string Password = Console.ReadLine();

                var person = people.FirstOrDefault(p => p.UserName == UserName && p.Password == Password && p.UserType == Type);
                Console.WriteLine(person);
                if (person != null)
                {
                    AdminMenu(person, admin, products);
                }
            }
            

        }
        static void AdminMenu(Person person, Admin admin, List<Product> products) 
        {
            if (person != null)
            {
                int control = 0;
                while(control != 5)
                {
                    Console.WriteLine("1. Add\n2. Read\n3. Update\n4. Delete\n5. Exit");
                    control = int.Parse(Console.ReadLine());

                    if (control == 1)
                    {
                        admin.AddProduct(person, products);
                    }
                    if (control == 2)
                    {
                        products.ForEach(p => Console.WriteLine(p));
                    }
                    if (control == 3)
                    {
                        admin.UpdateProduct(person, products);
                    }
                    if (control == 4)
                    {
                        admin.DeleteProduct(person, products);
                    }
                }
            }
        }
        static void UserMenu( Person person, List<Product> products, List<Buy<Product>> buy)
        {
            if(person != null)
            {
                int control = 0;
                while (control != 3)
                {
                    Console.WriteLine("1. BuyProduct\n2. SeeList\n3. Back");
                    try
                    {
                        control = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException e)
                    {

                        Console.WriteLine(e.Message);
                    }
                    if (control == 1)
                    {
                        BuyProduct(person, products, buy);
                    }
                    if (control == 2)
                    {
                        SeeList(buy, person);
                    }

                }
            }
            
        }
        static void SeeList(List<Buy<Product>> buy, Person person)
        {
            if (person != null)
            {
                foreach (var buyItem in buy)
                {
                    foreach (var product in buyItem.SoldItem)
                    {
                        Console.WriteLine($"ProductId: {product.ProductId} - ProductManufacturer: {product.ProductManufacturer} - ProductName: {product.ProductName} - Price: {product.Price} - Quantity: {buyItem.Quantity}");
                    }
                    Console.WriteLine($"Time: {buyItem.SoldTime}");
                }
            }
        }
        static void BuyProduct(Person person, List<Product> products, List<Buy<Product>> buy)
        {
            if (person != null)
            {

                products.ForEach(p => Console.WriteLine(p));
                Buy<Product> buys = new Buy<Product>();
                Console.Write("choose Product By Name: ");
                string Name = Console.ReadLine();
                Console.Write("choose Quantity: ");


                var chosenProduct = products.FirstOrDefault(p => p.ProductName == Name);

                if (chosenProduct != null)
                {
                    Console.WriteLine($"Available Quantity: {chosenProduct.Quantity}");
                    Console.Write("Choose Quantity: ");
                    int quantity = int.Parse(Console.ReadLine());

                    if (quantity > 0 && quantity <= chosenProduct.Quantity)
                    {
                        
                        chosenProduct.Quantity -= quantity;

                        buy.Add(new Buy<Product>() { SoldItem = new List<Product> { chosenProduct },Quantity = quantity , SoldTime = DateTime.Now });

                        
                        foreach (var buyItem in buy)
                        {
                            foreach (var product in buyItem.SoldItem)
                            {
                                Console.WriteLine($"ProductId: {product.ProductId} - ProductManufacturer: {product.ProductManufacturer} - ProductName: {product.ProductName} - Price: {product.Price} - Quantity: {buyItem.Quantity}");
                            }
                            Console.WriteLine($"Time: {buyItem.SoldTime}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity entered. Quantity must be greater than 0 and less than or equal to the available quantity.");
                    }
                }
            }
        }
    }
}
