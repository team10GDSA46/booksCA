using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksCA
{
    public class UserBusinessLogic
    {
        public static void UpdateBooks(int BookId,
              string Title, int CategoryID, string Author, string ISBN, int Stock, decimal Price)
        {
            using (Mybooks entities = new Mybooks())
            {
                Book book = entities.Books.Where(p => p.BookID == BookId).First<Book>();
                book.Title = Title;
                book.CategoryID = CategoryID;
                book.Author = Author;
                book.ISBN = ISBN;
                book.Stock = Stock;
                book.Price = Price;


                entities.SaveChanges();
            }
        }

        public static void DeleteBooks(int BookId)
        {
            using (Mybooks entities = new Mybooks())
            {
                Book book = entities.Books.Where(p => p.BookID == BookId).First<Book>();
                entities.Books.Remove(book);
                entities.SaveChanges();
            }
        }
        public static List<Book> Listbook()
        {
            using (Mybooks entities = new Mybooks())
            {
                return entities.Books.ToList<Book>();
            }
        }



    }
}

