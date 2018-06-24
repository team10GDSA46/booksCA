using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp3
{
    using ServiceReference1;

    class Program
    {
        static void Main(string[] args)
        {
            //Service1Client c = new Service1Client();
            //int []ids = c.GetBookIds();
            //foreach(int i in ids)
            //{
            //    Console.WriteLine(i);
            //    WCF_Product p = c.GetBook(i.ToString());
            //    Console.WriteLine(p.Title);
            //    Console.WriteLine(p.Stock);
            //    Console.WriteLine(p.Price + "\n");
              

            //}

            String abd = "The%20Trials%20of%20Apollo,%20Book%201%21%20The%20Hidden%20Oracle";
            Console.WriteLine(abd.ToUpper().Replace("%21",":").Replace("%23", "+").Replace("%20", " "));

        }
    }
}
