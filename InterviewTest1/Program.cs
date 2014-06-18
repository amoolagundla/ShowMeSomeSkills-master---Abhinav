using System;
using System.Linq;

namespace InterviewTest1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var data = new Repo().All();


            data.ToList().ForEach(x =>
                x.LineItems.ToList().ForEach(y =>
                {
                    y.SubTotal = (y.UnitPrice * y.Quantity);
                    y.Total = Repo.calctotal(y, x.TaxRate);
                  
                })
            );



            data.SelectMany(invoice => invoice.LineItems)
            .ToList()
           .ForEach(Console.WriteLine);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("********* END OF EXERCISE 1***********");
            Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
           // invoice number, Company Name, SubTotal, Total, and the invoice line items with it's SubTotal and Total.


            data.ToList().ForEach(x =>
                {
                    Console.WriteLine("Invoice number = " + x.InvoiceNo + " ");
                    Console.WriteLine("Company Name = " + x.CompanyName + " ");
                    x.SubTotal = x.LineItems.ToList().Sum(y => y.Total);
                    Console.WriteLine("SubTotal = " + x.SubTotal + " ");

                    Console.WriteLine("Total =" + (x.SubTotal + x.Shipping) + " ");
                    Console.WriteLine();
                     Console.WriteLine();
                     x.LineItems.ToList().ForEach(y =>
                     {
                         Console.WriteLine("************Line Items ***********");
                         Console.WriteLine("LineText ="+ y.LineText + " ");
                         Console.WriteLine("quantity ="+ y.Quantity + " ");
                         Console.WriteLine("Unit Price ="+ y.UnitPrice + " ");
                         Console.WriteLine("Discount = "+ y.Discount + " ");
                         y.SubTotal = (y.UnitPrice * y.Quantity);
                         Console.WriteLine("Subtotal = "+y.SubTotal + " ");
                         y.Total = Repo.calctotal(y, x.TaxRate);
                         Console.WriteLine("Total = "+y.Total + " ");
                         //Console.WriteLine("************End of invoice ****************");
                         Console.WriteLine();
                         Console.WriteLine();
                     });
                     
                });

            Console.WriteLine("********* END OF EXERCISE 2 ***********");
            Console.ReadLine();



            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            // invoice number, Company Name, SubTotal, Total, and the invoice line items with it's SubTotal and Total.


            data.ToList().ForEach(x =>
            {
                Console.WriteLine("Invoice number = " + x.InvoiceNo + " ");
                Console.WriteLine("Company Name = " + x.CompanyName + " ");
                x.SubTotal = x.LineItems.ToList().Sum(y => y.Total);
                Console.WriteLine("SubTotal = " + x.SubTotal + " ");

                Console.WriteLine("Total =" + (x.SubTotal + x.Shipping) + " ");
               
                Console.WriteLine();
                Console.WriteLine();
                x.LineItems.ToList().ForEach(y =>
                {
                    Console.WriteLine("************Line Items ***********");
                    Console.WriteLine("LineText =" + y.LineText + " ");
                    Console.WriteLine("quantity =" + y.Quantity + " ");
                    Console.WriteLine("Unit Price =" + y.UnitPrice + " ");
                    Console.WriteLine("Discount = " + y.Discount + " ");
                    y.SubTotal = (y.UnitPrice * y.Quantity);
                    Console.WriteLine("Subtotal = " + y.SubTotal + " ");
                    y.Total = Repo.calctotal(y, x.TaxRate);
                    Console.WriteLine("Total = " + y.Total + " ");  

                    //Rouding to half dollar. 
                    y.lineItemCommission=  Math.Round (
                                                     (  ( Repo.caluclateDiscount(y.SubTotal, y.Discount) * (decimal)(x.commissionRate/100) ) / (decimal) .5) ,0) *(decimal) .5;
                    Console.WriteLine("LineItem Store Commision amount = " + y.lineItemCommission + " ");
                    //Console.WriteLine("************End of invoice ****************");
                    Console.WriteLine();
                    Console.WriteLine();
                });
                Console.WriteLine("Store Commission  = " + x.LineItems.ToList().Sum(y => y.lineItemCommission) + " ");
               

            });

            Console.WriteLine("********* END OF EXERCISE 3 ***********");
            Console.ReadLine();



        }
    }
}