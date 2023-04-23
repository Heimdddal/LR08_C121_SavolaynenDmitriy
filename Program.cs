using System.Security.Principal;
using System.Xml.Serialization;

namespace LR08_C121_SavolaynenDmitriy
{
    internal class Program
    {
        class Product
        {
            private string _name;
            private decimal _price;
            private int _quantity;
            private bool _on_stock;

            public Product()
            {
                _name = "Новый товар";
                _price = 100;
                _quantity = 1;
            }
            public Product(string name, decimal price, int quantity)
            {
                _name = name;
                _price = price;
                _quantity = quantity;
            }
            public Product(string name, decimal price)
            {
                _name = name;
                _price = price;
                _quantity = 1;
            }
            public Product(string name)
            {
                _name = name;
                _price = 100;
                _quantity = 1;
            }
            
            public Product(int quantity)
            {
                _name = "Новый продукт";
                _price = 100;
                _quantity=quantity;
            }

            public Product(decimal price)
            {
                _name = "Новый продукт";
                _price = price;
                _quantity = 1;
            }

            public string Name
            {
                get { return _name; }
                set
                {
                    if (value == "")
                    {
                        Console.WriteLine("Название товара не может быть пустым");
                    }
                    else
                    {
                        _name = value;
                    }
                }
            }

            public decimal Price
            {
                get { return _price; }
                set
                {
                    if (value <= 0)
                    {
                        Console.WriteLine("Цена должна быть положительным числом");
                    }
                    else
                    {
                        _price = value;
                    }
                }
            }

            public int Quantity
            {
                get { return _quantity; }
                set
                {
                    if (value < 0)
                    {
                        Console.WriteLine("Количество не может быть отрицательным");
                    }
                    else
                    {
                        _quantity = value;
                    }
                }
            }

            public bool OnStock
            {
                get { return _on_stock; }
                set
                {
                    if (value == true)
                    {
                        Console.WriteLine("Товар есть на складе");
                        _on_stock = true;
                    }
                    else
                    {
                        Console.WriteLine("Товара нет на складе");
                        _on_stock = false;
                    }
                }
            }

            public void quantity_change(bool increase, int value)
            {
                if (increase)
                {
                    Quantity += value;
                }
                else
                {
                    if (value > _quantity)
                    {
                        Quantity = 0;
                    }
                    else
                    {
                        Quantity -= value;
                    }
                }
            }

            public bool price_from_to(int from, int to)
            {
                if (_price <= to && _price >= from)
                {
                    Console.WriteLine("Цена товара попадает в заданный промежуток");
                    return true;
                }
                else
                {
                    Console.WriteLine("Цена товара не попадает в заданный промежуток");
                    return false;
                }
            }

            public void hatch(int value)
            {
                _quantity += value;
                _on_stock = true;
            }

            public static Product operator ++(Product product)
            {
                product.Quantity++;
                return product;
            }

            public static Product operator --(Product product)
            {
                product.Quantity--;
                return product;
            }

            public static decimal operator +(Product product, int amount)
            {
                return product.Price * amount;
            }

            public static decimal operator *(Product product1, Product product2)
            {
                return product1.Price * product1.Quantity + product2.Price * product2.Quantity;
            }

            public static bool operator >(Product a, int b)
            {
                return a.Quantity > b;
            }

            public static bool operator <(Product a, int b)
            {
                return a.Quantity < b;
            }

            public static explicit operator int(Product product)
            {
                return product.Quantity;
            }

            public static implicit operator Product(int quantity)
            {
                return new Product(quantity);
            }



            public void PrintInfo()
            {
                if (_on_stock) 
                {
                    Console.WriteLine($"Товар: {_name}\nЦена: {_price} руб.\nКоличество: {_quantity} шт.\nТовар есть в магазине.\n");
                }
                else
                {
                    Console.WriteLine($"Товар: {_name}\nЦена: {_price} руб.\nКоличество: {_quantity} шт.\nТовара нет в магазине.\n");
                }
                
            }
        }

        static void Main(string[] args)
        {
            Product product = new Product();
            Product product1 = new Product(100);
            Product product2 = new Product(100.0m);
            Product product3 = new Product("Apples");
            Product product4 = new Product("Oranges", 150m);
            Product product5 = new Product("Tomats", 200m, 20);
            product.PrintInfo();
            product1.PrintInfo();
            product2.PrintInfo();
            product3.PrintInfo();
            product4.PrintInfo();
            product5.PrintInfo();
            product.Price = 1000;
            product1.Quantity = 35;
            product2.Name = "Sunflowers";
            product.PrintInfo();
            product1.PrintInfo();
            product2.PrintInfo();
            product3.quantity_change(true, 20);
            product3.PrintInfo();
            product.price_from_to(1, 100);
            product4.hatch(40);
            product4.PrintInfo();
            product5++;
            product5.PrintInfo();
            product5--;
            product5.PrintInfo();
            Console.WriteLine(product5 + 5);
            Console.WriteLine(product5 * product);
            int a = (int)product2;
            Console.WriteLine(a);
            int b = 10;
            Product product6 = (Product)b;
            product6.PrintInfo();
        }
    }
}