using System;
using System.Collections.Generic;
using Shop.Models;

namespace Shop.Services
{
    public class ItemService
    {
        private List<ItemModel> Items = new List<ItemModel>();
        public Dictionary<string, List<ItemModel>> ListOfItems = new Dictionary<string, List<ItemModel>>();
        public void AddToItemsList(ItemModel itemModel)
        {
            Items.Add(itemModel);
        }
        public List<ItemModel> GetItems(string categoryName)
        {
            return ListOfItems[categoryName];
            
        }
    }
}
