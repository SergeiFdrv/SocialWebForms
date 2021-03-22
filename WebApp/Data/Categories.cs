using System.Collections.Generic;
using System.Linq;
using WebApp.Models;

namespace WebApp.Data
{
    public static class Categories
    {
        public static List<Category> All { get; } = new List<Category>
        {
            new Category
            {
                CategoryID = 0,
                CategoryName = Resources.Category.Notes,
                CategorySlug = "notes",
                CategoryDescription = Resources.Category.NotesDescription
            },
            new Category
            {
                CategoryID = 1,
                CategoryName = Resources.Category.Longreads,
                CategorySlug = "longreads",
                CategoryDescription = Resources.Category.LongreadsDescription
            },
            new Category
            {
                CategoryID = 2,
                CategoryName = Resources.Category.Lists,
                CategorySlug = "lists",
                CategoryDescription = Resources.Category.ListsDescription
            },
            new Category
            {
                CategoryID = 3,
                CategoryName = Resources.Category.FAQ,
                CategorySlug = "faq",
                CategoryDescription = Resources.Category.FAQDescription
            }
        };

        public static Category GetCategory(int i) =>
            All.FirstOrDefault(c => c.CategoryID == i);
        public static Category GetCategory(string s) =>
            All.FirstOrDefault(c => c.CategorySlug == s || c.CategoryName == s);
    }
}