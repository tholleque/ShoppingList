using System.Threading.Channels;

namespace ShoppingList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to The Farmers Market!");
            Console.WriteLine();
            Dictionary<string, double> menu = new Dictionary<string, double>();

            menu.Add("eggs", 100000);
            menu.Add("milk", 2.59);
            menu.Add("butter", 1.78);
            menu.Add("cheese", 3.49);
            menu.Add("chicken", 8.78);
            menu.Add("onion", 0.75);
            menu.Add("potato", 0.38);
            menu.Add("pepper", 1.06);

            List<string> cart = new List<string>();
            List<double> prices = new List<double>();

            bool goON = true;
            do
            {
                
                Console.WriteLine("Item\t\tPrice");
                Console.WriteLine("=========================");
                foreach (KeyValuePair<string, double> kvp in menu)
                {
                    Console.WriteLine(kvp.Key + "\t\t" + "$" + kvp.Value);

                }
                Console.WriteLine();
                Console.WriteLine("Choose an item to purchase:");
                string purchasedItem = Console.ReadLine();
                if (menu.ContainsKey(purchasedItem))
                {
                    cart.Add(purchasedItem);
                    prices.Add(menu[purchasedItem]);
                }
                else
                {
                    Console.WriteLine("Item not found.");
                    Console.WriteLine();
                }

                goON = Continue();
            } while (goON == true);
            Console.WriteLine("Thank you for your order!");

                Console.WriteLine("Receipt:");
                Console.WriteLine();
            double total = 0;
            foreach(string item in cart)
            {
                Console.WriteLine($"{item}\t{menu[item]}");
                total += menu[item];

            }
            
            Console.WriteLine();
            Console.WriteLine("Your total is: $" + total);
            //double maxPrice = prices.Max();
            //Console.WriteLine(maxPrice);





        }
        public static bool Continue()
        {
            Console.WriteLine("Would you like to keep shopping? y/n");
            string input = Console.ReadLine();
            if(input == "y")
            {
                return true;
            }
            else if (input == "n")
            {
                Console.WriteLine("Goodbye!");
                Console.WriteLine();
                return false;
            }
            else
            {
                Console.WriteLine("Hey I didn't understand that lets try again!");
                return Continue();
            }
        }

    }
}