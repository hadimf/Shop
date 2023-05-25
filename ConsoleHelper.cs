using System;
using System.Collections.Generic;
using Shop.enums;
using Shop.Models;
using Shop.Services;

namespace Shop
{
    public class ConsoleHelper
    {
        public static void ShowCategories(List<CategoryModel> categoryModels)
        {
            Console.WriteLine("These are List of Categories : ");
            foreach (var categoryModel in categoryModels)
            {
                Console.WriteLine(categoryModel.Name);
            }
            Console.WriteLine();
        }

        public static Request AskService()
        {
            Console.WriteLine("Which one do you want ?");
            Console.WriteLine("1.Create Category");
            Console.WriteLine("2.Add Item");
            Console.WriteLine("3.Show Items");
            string request = Console.ReadLine();
            return (Request)Enum.Parse(typeof(Request), request);
        }

        public static string AskNameCategory()
        {
            Console.WriteLine("What is Name of Category ? ");
            string nameCategory = Console.ReadLine();
            return nameCategory;
        }

        public static string AskPropertyCategory()
        {
            Console.WriteLine("What is Property of Category ?");
            string property = Console.ReadLine();
            return property;
        }

        public static Answer AddMore()
        {
            Console.WriteLine("Do you want add more properties");
            Console.WriteLine("1.Yes");
            Console.WriteLine("2.No");
            Answer answer = (Answer)Enum.Parse(typeof(Answer), Console.ReadLine());
            return answer;
        }

        public static string AskNameCategoryOfItem()
        {
            Console.WriteLine("What is Name of Category to add it ? ");
            string nameCategory = Console.ReadLine();
            return nameCategory;
        }

        public static string AskNameItem()
        {
            Console.WriteLine("What is name of item ? ");
            return Console.ReadLine();
        }

        public static void FillPropertiesMessage() => Console.WriteLine("Fill the Properties : ");
        public static void AskPropertyItems(List<string> properties, Dictionary<string, string> propertiesOfItem)
        {



            foreach (var property in properties)
            {
                Console.WriteLine(property + " : ");
                string input = Console.ReadLine();


                propertiesOfItem[property] = input;

            }


        }
        public static void ShowItems(List<ItemModel> items)
        {

            foreach (var item in items)
            {
                Console.WriteLine("Name : " + item.Name);
                Console.WriteLine("Category : " + item.Category);
                if (item.Properties != null)
                {
                    foreach (KeyValuePair<string, string> property in item.Properties)
                    {
                        Console.WriteLine(property.Key + " : " + property.Value);
                    }

                }
                Console.WriteLine("*************************");
            }
        }
    }
}
