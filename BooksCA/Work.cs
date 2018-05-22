using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace BooksCA
{
    public class Work
    {
        Mybooks mb = new Mybooks();
        public Book GetBook(int id)
        {
            return mb.Books.Where
                    (b => b.BookID == id).First();
        }
        public void AddToCart()
        {
            // codes
        }
        public int CheckStock(int bookID)
        {
            return mb.Books
                .Where(x => x.BookID == bookID)
                .Select(x => x.Stock).First();
        }
        public void CheckOut()
        {

        }
    }
}