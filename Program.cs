using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkScore2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Salesman salesman = new Salesman();
            Player player = new Player();
            Console.WriteLine("Добро пожаловать в магазин. Выйти из магазина - end ");
            string userInput = Console.ReadLine();

            while (userInput != "end")
            {
                Console.WriteLine("1 - Посмотреть товар продоваца. 2 - Купить предмет. 3 - Взглянуть что купил.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        salesman.ShowInfo();
                        break;

                    case "2":
                        player.BuyProduct();
                        break;

                    case "3":
                        player.ShowInfo();
                        break;
                }
            }
        }
    }

    class Player
    {
        private List<Product> _products = new List<Product>();
        private Salesman _salesman = new Salesman();
        private int _сoins = 100;

        public void BuyProduct()
        {
            Product product = _salesman.BuyProduct();
            if (product != null)
            {
                if (product.Price < _сoins)
                {
                    _сoins -= product.Price;
                    Console.WriteLine(_сoins);
                    Console.WriteLine("Отлично сделка удалась !");
                    _products.Add(new Product(product.Title, product.Price));
                }
                else
                {
                    Console.WriteLine("У вас не достаточно денег!");
                }
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine("Ваши приобретеные предметы!");
            foreach (Product product in _products)
            {
                Console.WriteLine(product.Title);
            }
        }
    }

    class Salesman
    {
        private List<Product> _products = new List<Product>();

        public Salesman()
        {
            CreateProducts();
        }

        public void ShowInfo()
        {
            foreach (var products in _products)
            {
                Console.WriteLine($"\n В продаже {products.Title}. Цена за штуку {products.Price} золотых монет.");
            }
        }

        public Product BuyProduct()
        {
            Console.WriteLine("Какой товар хотите купить ?");
            string userInput = Console.ReadLine();
            Product product = null;

            for (int i = 0; i < _products.Count; i++)
            {
                if (_products[i].Title.Contains(userInput))
                {
                    Console.WriteLine($"{_products[i].Title} стоит {_products[i].Price} монет");
                    Console.WriteLine("Покупаете ? да или нет?");
                    if (Console.ReadLine() == "да")
                    {
                        Console.WriteLine("Деньги вперёд!");
                        product = _products[i];
                    }
                }
            }
            return product;
        }

        private void CreateProducts()
        {
            _products.Add(new Product("Яйцо Дракона", 40));
            _products.Add(new Product("Пылесос", 20));
            _products.Add(new Product("Палка-Капалка", 40));
            _products.Add(new Product("Палка-Ковырялка", 40));
        }
    }

    class Product
    {
        public string Title { get; private set; }
        public int Price { get; private set; }

        public Product(string title, int price)
        {
            Title = title;
            Price = price;
        }
    }
}
