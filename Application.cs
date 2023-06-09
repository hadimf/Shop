using System;
using System.Collections.Generic;
using Shop.enums;
using Shop.Models;
using Shop.Services;
using System.Text.Json;

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

        // Check Request of User
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

                    // Add Items to Dictionary
                    AddItemsToDictionary(itemModel, nameCategoryItem);
                    break;
                case Request.ShowItems:
                    // Ask Name of Category
                    string categoryName = ConsoleHelper.AskNameCategory();
                    // Show Items
                    List<ItemModel> items = itemService.GetItems(categoryName);
                    ConsoleHelper.ShowItems(items);
                    break;
            }
        }

        // Ask From User Add more Properties or No
        private static void AddPropertiesToCategory(CategoryModel categoryModel)
        {
            bool addMore;
            List<string> propertiesList = new List<string>();
            do
            {   string property = ConsoleHelper.AskPropertyCategory();
                propertiesList.Add(property);

                Answer answer = ConsoleHelper.AddMore();
                addMore = answer == Answer.Yes ? true : false;

            } while (addMore);
            categoryModel.Properties = propertiesList;
        }

        // Get Properties Of Category
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

        // Add Items to Dictionary
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
