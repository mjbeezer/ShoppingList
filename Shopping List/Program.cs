using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepGoing = true;
            bool program = true;
            string choice;

            //Menu and Prices done through dictionary
            Dictionary<string, double> shop = new Dictionary<string, double>();
            shop.Add("Soda Pop", 1.99);
            shop.Add("Tall Boy", 2.99);
            shop.Add("Candy Bar", .99);
            shop.Add("Bag of Chips", 1.99);
            shop.Add("Cigarettes", 5.99);
            shop.Add("Bubble Gum", .99);
            shop.Add("Lotto Ticket", 4.99);
            shop.Add("Red Bull", 1.99);

            //"cart" lists
            List<string> items = new List<string>();
            List<double> prices = new List<double>();

            Console.WriteLine("Hello! Welcome to the Matt's Mart!");
            while (keepGoing)
            {
                while (true)
                {
                    //display menu and pricing
                    foreach (KeyValuePair<string, double> kvp in shop)
                    {
                        Console.WriteLine($"{kvp.Key}\t\t{kvp.Value}");
                    }
                    //ask for user input
                    Console.WriteLine("Please select an item from our menu.");
                    choice = Console.ReadLine();

                    //check to see if item is valid. If yes, add to item and price to correct lists. If not ask for user input 
                    double checkItems;
                    
                        if (shop.TryGetValue(choice, out checkItems))
                        {
                            Console.WriteLine($"You have selected {choice} for {checkItems}");
                            items.Add(choice);
                            prices.Add(shop[choice]);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("We're sorry. We do not have the item you selected. Please choose an item from the menu.");
                            break;
                        }
                }

                while (true)
                {
                    //ask if they wish to add another item
                    Console.WriteLine("Would you like to add another item from the menu to your cart? y/n");
                    string moreItems = Console.ReadLine().ToLower();
                    if (moreItems == "n")
                    {
                        keepGoing = false;
                        break;
                    }
                    else if (moreItems == "y")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("We're sorry. We don't understand.");
                    } 
                }
            }
            //Checkout time!
            Console.WriteLine("Thanks for choosing Matt's Mart! Here is what we have in your cart.");
            for(int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{items[i]}\t{prices[i]}");
            }
            double average = prices.Average();
            Console.WriteLine($"The average price of your items is {average}.");
        }
    }
}
