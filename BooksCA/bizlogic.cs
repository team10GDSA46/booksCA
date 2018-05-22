using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksCA
{
    public class bizlogic
    {
        public static List<Category> ListCategory()
        {
            Mybooks entities = new Mybooks();
            return entities.Categories.ToList<Category>();

        }

        public static void AddBook(string Title, string ISBN, string Author, int Cat, int Stock, decimal Price)
            
        {
            Mybooks entities = new Mybooks();
            Book bk = new Book();
            bk.Title = Title;
            bk.Author = Author;
            bk.ISBN = ISBN;
            bk.Price = Price;
            bk.Stock = Stock;
            bk.CategoryID = Cat;

            entities.Books.Add(bk);
            entities.SaveChanges();
        }
    }
}