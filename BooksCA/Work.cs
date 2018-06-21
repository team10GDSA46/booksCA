using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

namespace BooksCA
{
    public class Work
    {
        Mybooks mb = new Mybooks();

        public List<Book> GetBooks()
        {
            return mb.Books.ToList<Book>() ;
        }

        public List<int> GetBooksIds()
        {
            List<int> list = new List<int>();
            foreach (Book b in GetBooks())
            {
                list.Add(b.BookID);
            }
            return list;
        }

        public static void LogOutAdmin()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
        public static void LogOutUser()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Response.Redirect("~/UserLogin.aspx");
        }
        public Book GetBook(int id)
        {
            return mb.Books.Where
                    (b => b.BookID == id).First();
        }
        public int CheckStock(int bookID)
        {
            return mb.Books
                .Where(x => x.BookID == bookID)
                .Select(x => x.Stock).First();
        }
     
        public void Transaction(int userid, List<Book> cartitems)
        {
            Random r = new Random();
            int rand = r.Next(1000000, 9999999);
            Tran t = new Tran();
            t.transID = rand.ToString();
            t.UserID = userid;
            t.transDate = DateTime.Today;
            mb.Trans.Add(t);
            foreach (Book b in cartitems)
            {
                TransDetail td = new TransDetail();
                td.transID = rand.ToString();
                td.BookID = b.BookID;
                td.Discount = (decimal)GetDiscountRate(DateTime.Today.Date);
                td.Amount = b.Price - (b.Price * td.Discount);
                mb.TransDetails.Add(td);
                UpdateStock(b.BookID);
            }
            mb.SaveChanges();
        }
        public void RemoveItems(int userid)
        {
            List<CartBook> cart = mb.CartBooks
                .Where(x => x.UserID == userid).ToList();
            foreach(CartBook cb in cart)
            {
                mb.CartBooks.Remove(cb);
            }
            mb.SaveChanges();
        }
        public double GetDiscountRate(DateTime date)
        {
            if (mb.Discounts.Where(x => x.FromDate <= date)
                .Where(x => x.ToDate >= date).Count() > 0)
            {
                decimal discount = (from x in mb.Discounts
                                    where x.FromDate <= date &&
                                    x.ToDate >= date
                                    select x.DiscountPercent).First();
                return (double)discount / 100;
            }
            else
            {
                return 0;
            }
        }
        public double CalculateTotal(List<Book> cart)
        {
            double total = 0;
            foreach(Book b in cart)
            {
                double price = (double)b.Price;
                double discount = GetDiscountRate(DateTime.Today.Date);
                double amount = price - (price * discount);
                total += amount;
            }
            return total;
        }
        public void UpdateStock(int bookid)
        {
            Book b = mb.Books.Where(x => x.BookID == bookid).First();
            b.Stock -= 1;
            mb.SaveChanges();
        }
    }
}