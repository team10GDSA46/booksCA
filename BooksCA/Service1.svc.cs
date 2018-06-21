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

        public List<int> GetBookIds()
        {
            return new Work().GetBooksIds();
        }
    }
}
