using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BooksCA
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<WCF_Product> BookDetail()
        {
            List<WCF_Product> books = new List<WCF_Product>();

            List<int> BooksID = this.GetBooks();
            foreach(int i in BooksID)
            {
                books.Add(this.GetBook(i.ToString()));
            }

            return books;
        }

        public WCF_Product GetBook(string id)
        {
            int n = Int32.Parse(id);
            Book b = new Work().GetBook(n);
            if (b.Stock > 0)
            {
                return new WCF_Product(b.BookID, b.Stock, b.Price, b.CategoryID, b.Title, b.Author, b.ISBN);
            }
            return null;            
        }

        public List<int> GetBooks()
        {
            return new Work().GetBooksIds();
        }

        public List<string> GetISBN()
        {
            return new Work().GetISBN();
        }

        public List<WCF_Product> SearchBooks(string search)
        {
            List<WCF_Product> books = new List<WCF_Product>();
            string decodedUrl = Uri.UnescapeDataString(search);
            //string decodedUrl = search.Replace("%20", " ").Replace("%3A", ":").Replace("%23", "+");
            List<int> SearchedBooks = new Work().SearchBook(decodedUrl);
            
            //List<int> SearchedBooks = new Work().SearchBook(search.Replace("%20", " ").Replace("%21",":").Replace("%23", "+"));

            foreach (int i in SearchedBooks)
            {
                books.Add(this.GetBook(i.ToString()));
            }

            return books;
        }
    }
}
