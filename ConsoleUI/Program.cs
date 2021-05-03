using Business.Concrete;
using System;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.İnMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            BookTest();
            //CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManeger = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManeger.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void BookTest()
        {
            BookManager bookManeger = new BookManager(new EfBookDal());

            var result = bookManeger.GetBookDetails();
            if (result.Success)
            {
                foreach (var book in bookManeger.GetBookDetails().Data)
                {
                    Console.WriteLine(book.BookName+" / "+book.CategoryId);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            
        }
    }
}
