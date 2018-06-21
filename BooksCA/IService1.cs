using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BooksCA
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet(UriTemplate = "/Books", ResponseFormat = WebMessageFormat.Json)]
        List<int> GetBookIds();

        [OperationContract]
        [WebGet(UriTemplate = "/Book/{id}", ResponseFormat = WebMessageFormat.Json)]
        WCF_Product GetBook(string id);
    }

    [DataContract]
    public class WCF_Product
    {
        [DataMember]
        public int BookID;
        [DataMember]
        public int Stock;
        [DataMember]
        public int CatID;
        [DataMember]
        public string Title;
        [DataMember]
        public string Author;
        [DataMember]
        public string ISBN;
        [DataMember]
        public decimal Price;


        public WCF_Product(int BookID, int Stock, decimal Price, int CatID, string Title, string Author, string ISBN)
        {
            this.BookID = BookID;
            this.Stock = Stock;
            this.CatID = CatID;
            this.Title = Title;
            this.Author = Author;
            this.ISBN = ISBN;
            this.Price = Price;
        }
    }
    
}
