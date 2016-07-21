using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2Lib;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager manager = new ProductManager();
            Boolean loop = true;

            string code;
            string name;
            double price;
            double quantity;
            string manufacturer;

            bool exist;

            Product p;

            while (loop)
            {
                try
                {
                    Console.WriteLine("1. Add new Product");
                    Console.WriteLine("2. Update product");
                    Console.WriteLine("3. Delete product");
                    Console.WriteLine("4. Search product by name");
                    Console.WriteLine("5. Search product by price range");
                    Console.WriteLine("6: Find products belong to a manufacturer");
                    Console.WriteLine("7: Display all products");
                    Console.WriteLine("8: Exit");
                    Console.Write("Enter a number: ");
                    int menu = int.Parse(Console.ReadLine());
                    switch (menu)
                    {
                        case 1:
                            #region Add
                            Console.Write("Enter code: ");
                            code = Console.ReadLine();
                            exist = manager.findByCode(code);
                            if (exist)
                            {
                                Console.WriteLine("Product exist! Try agian please");
                            }
                            else
                            {
                                Console.Write("Enter name: ");
                                name = Console.ReadLine();
                                Console.Write("Enter price: ");
                                price = double.Parse(Console.ReadLine());
                                Console.Write("Enter quantity: ");
                                quantity = double.Parse(Console.ReadLine());
                                Console.Write("Enter manufacturer: ");
                                manufacturer = Console.ReadLine();

                                p = new Product(code, name, price, quantity, manufacturer);
                                manager.addProduct(p);
                            }
                            break;
                            #endregion
                        case 2:
                            #region Update
                            Console.Write("Enter code: ");
                            code = Console.ReadLine();
                            exist = manager.findByCode(code);
                            if (!exist)
                            {
                                Console.WriteLine("Product not found!");
                            }
                            else
                            {
                                Console.Write("Enter name: ");
                                name = Console.ReadLine();
                                Console.Write("Enter price: ");
                                price = double.Parse(Console.ReadLine());
                                Console.Write("Enter quantity: ");
                                quantity = double.Parse(Console.ReadLine());
                                Console.Write("Enter manufacturer: ");
                                manufacturer = Console.ReadLine();

                                p = new Product(code, name, price, quantity, manufacturer);
                                manager.updateProduct(p);
                            }
                            #endregion
                            break;
                        case 3:
                            #region Delete
                            Console.Write("Enter code: ");
                            code = Console.ReadLine();
                            exist = manager.findByCode(code);
                            if (!exist)
                            {
                                Console.WriteLine("Product not found!");
                            }
                            else
                            {
                                p = new Product();
                                p.code = code;
                                manager.deleteProduct(p);
                                Console.WriteLine("Product deleted");
                            }
                            #endregion
                            break;
                        case 4:
                            #region search name
                            Console.Write("Enter name: ");
                            name = Console.ReadLine();
                            p = manager.findByName(name);
                            if (p != null)
                            {
                                Console.WriteLine(p.ToString());
                            }
                            else
                            {
                                Console.WriteLine("Product not found!");
                            }
                            #endregion
                            break;
                        case 5:
                            #region search price
                            Console.Write("Enter lowest price: ");
                            double r1 = double.Parse(Console.ReadLine());
                            Console.Write("Enter highest price: ");
                            double r2 = double.Parse(Console.ReadLine());
                            p = manager.findByPriceRange(r1, r2);
                            if (p != null)
                            {
                                Console.WriteLine(p.ToString());
                            }
                            else
                            {
                                Console.WriteLine("Product not found!");
                            }
                            #endregion
                            break;
                        case 6:
                            #region Search manufacturer
                            Console.Write("Enter manufacturer: ");
                            manufacturer = Console.ReadLine();
                            manager.displayByManufacturer(manufacturer);
                            break;
                            #endregion
                        case 7:
                            #region display all
                            manager.viewProducts();
                            break;
                            #endregion
                        default:
                            loop = false;
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
