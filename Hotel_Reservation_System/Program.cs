using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Hotel_Reservation_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hotel reservation Program");

            Console.WriteLine("Enter first date :<d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MM/yyyy", "yyyy-MM-dd", "yyyy-M-d", "yyyy-M-dd>");
            DateTime firstDate = Convert.ToDateTime(Console.ReadLine());

            var formats = new[] { "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MM/yyyy","yyyy-MM-dd","yyyy-M-d","yyyy-M-dd" };
            DateTime dt;
            
            
            while(!DateTime.TryParseExact(firstDate.ToShortDateString(), formats, null, DateTimeStyles.None, out dt))
            {
                Console.WriteLine("Invalid Entered Date");
                firstDate = Convert.ToDateTime(Console.ReadLine());
            }

            Console.WriteLine("Enter last date :<d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MM/yyyy", "yyyy-MM-dd", "yyyy-M-d", "yyyy-M-dd>");
            DateTime lastDate = Convert.ToDateTime(Console.ReadLine());

            while (!DateTime.TryParseExact(lastDate.ToShortDateString(), formats, null, DateTimeStyles.None, out dt))
            {
                Console.WriteLine("Invalid Entered Date");
                firstDate = Convert.ToDateTime(Console.ReadLine());
            }

            Console.WriteLine("Enter Customer type");
            string customerInputFormat = "^reward|^normal";
            Regex regex = new Regex(customerInputFormat, RegexOptions.IgnoreCase);

            ReservationBuilder.customerType customertype;
            string customer = Console.ReadLine().ToLower();
            Match match = regex.Match(customer);
            while (!match.Success)
            {
                Console.WriteLine("Invalid customer type");
            }

            if (customer == "normal")
                customertype = ReservationBuilder.customerType.normal;
            else
                customertype = ReservationBuilder.customerType.reward;

            ReservationBuilder reservation = new ReservationBuilder();
            reservation.FindBestRatedHotel(firstDate,lastDate,customertype);


            
            


        }
    }
}
