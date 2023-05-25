using System;
using System.Collections.Generic;
using Shop.Models;

namespace Shop.Services
{
    public class CategoryService
    {
        private List<CategoryModel> Categories = new List<CategoryModel>();
        public List<CategoryModel> GetCategories()
        {
            return Categories;
        }
        public void AddToCategoryList(CategoryModel categoryModel)
        {
            Categories.Add(categoryModel);
        }
    }
}
