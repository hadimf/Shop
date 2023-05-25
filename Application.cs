using System;
using System.Collections.Generic;
using Shop.enums;
using Shop.Models;
using Shop.Services;

namespace Shop
{
    public class Application
    {
        static CategoryService categoryService = new CategoryService();
        static ItemService itemService = new ItemService();
        public void Start()
        {
            Request request;
            do
            {
                // Show List of Categories
                List<CategoryModel> categories = categoryService.GetCategories();
                ConsoleHelper.ShowCategories(categories);
                // Ask Request From User
                request = ConsoleHelper.AskService();
                CheckRequest(request);

            } while (request != Request.ShowItems);
        }
        private static void CheckRequest(Request request)
        {
            switch (request)
            {
                case Request.CreateCategory:

                    CategoryModel categoryModel = new CategoryModel();
                    categoryModel.Properties =new List<string>();
                    // Ask Name of Category
                    string nameCategory = ConsoleHelper.AskNameCategory();
                    categoryModel.Name = nameCategory;
                    // Add Properties to Category
                    AddPropertiesToCategory(categoryModel);
                    // Add Category to List
                    categoryService.AddToCategoryList(categoryModel);


                    break;
                case Request.AddItem:
                    ItemModel itemModel = new ItemModel();
                    itemModel.Properties = new Dictionary<string, string>();
                    // Ask Name of Category and Item
                    string nameCategoryItem = ConsoleHelper.AskNameCategoryOfItem();
                    string nameItem = ConsoleHelper.AskNameItem();
                    itemModel.Name = nameItem;
                    itemModel.Category = nameCategoryItem;
                    // Get Properties From Category
                    List<CategoryModel> categories = categoryService.GetCategories();
                    List<string> properties = GetPropertyOfCategory(categories, nameCategoryItem);
                    // Ask Properties of Item From User
                    ConsoleHelper.FillPropertiesMessage();
                    ConsoleHelper.AskPropertyItems(properties, itemModel.Properties);

                    // ??? Ticked!
                    AddItemsToDictionary(itemModel, nameCategoryItem);
                    break;
                case Request.ShowItems:
                    string categoryName = ConsoleHelper.AskNameCategory();
                    List<ItemModel> items = itemService.GetItems(categoryName);
                    ConsoleHelper.ShowItems(items);
                    break;
            }
        }

        private static void AddPropertiesToCategory(CategoryModel categoryModel)
        {
            bool addMore;
            List<string> propertiestlist = new List<string>();
            do
            {   string property = ConsoleHelper.AskPropertyCategory();
                propertiestlist.Add(property);

                Answer answer = ConsoleHelper.AddMore();
                addMore = answer == Answer.Yes ? true : false;

            } while (addMore);
            categoryModel.Properties = propertiestlist;
        }
        private static List<string> GetPropertyOfCategory(List<CategoryModel> categories, string nameCategory)
        {
            List<string> properties = new List<string>();
            foreach (var category in categories)
            {
                if (category.Name == nameCategory)
                {
                    properties = category.Properties;
                }
            }
            return properties;
        }
        private static void AddItemsToDictionary(ItemModel itemModel, string nameCategory)
        {

            if (!itemService.ListOfItems.ContainsKey(nameCategory))
            {
                itemService.ListOfItems[nameCategory] = new List<ItemModel>();
            }
            itemService.ListOfItems[nameCategory].Add(itemModel);

        }
    }
}
