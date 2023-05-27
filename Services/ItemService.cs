using System;
using System.Collections.Generic;
using Shop.Models;

namespace Shop.Services
{
    public class ItemService
    {
        public Dictionary<string, List<ItemModel>> ListOfItems = new Dictionary<string, List<ItemModel>>();

        public List<ItemModel> GetItems(string categoryName)
        {
            if (!ListOfItems.ContainsKey(categoryName))
            {
                ListOfItems[categoryName] = new List<ItemModel>();
                Console.WriteLine("There is nothing");
                return ListOfItems[categoryName];

            }
            return ListOfItems[categoryName];

        }
    }
}
