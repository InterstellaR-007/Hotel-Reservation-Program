using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Hotel_Reservation_System
{
    /// <summary>
    /// Hotel Reservation Program UI - Main
    /// </summary>
    class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {

            bool exit_Program = false;

            Console.WriteLine("Welcome to Hotel reservation Program");

            //get first date
            Console.WriteLine("Enter first date :");
            DateTime firstDate = Convert.ToDateTime(Console.ReadLine());

            // Input Date Format String for Validation
            var formats = new[] { "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MM/yyyy","yyyy-MM-dd","yyyy-M-d","yyyy-M-dd" };
            DateTime dt;
            
            //Check firstDate input valid
            while(!DateTime.TryParseExact(firstDate.ToShortDateString(), formats, null, DateTimeStyles.None, out dt))
            {
                Console.WriteLine("Invalid Entered Date");
                firstDate = Convert.ToDateTime(Console.ReadLine());
            }

            //get last date
            Console.WriteLine("Enter last date :");
            DateTime lastDate = Convert.ToDateTime(Console.ReadLine());

            //Check lastDate input valid
            while (!DateTime.TryParseExact(lastDate.ToShortDateString(), formats, null, DateTimeStyles.None, out dt))
            {
                Console.WriteLine("Invalid Entered Date");
                firstDate = Convert.ToDateTime(Console.ReadLine());
            }

            //Enter customer type
            Console.WriteLine("Enter Customer type :<reward/normal>");
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

            while (exit_Program != true)
            {


                Console.WriteLine("Select the option from below :");
                Console.WriteLine("1: Find the Best Rated Hotel in given date range");
                Console.WriteLine("2: Find the Cheapest Best Hotel in given date range");
                Console.WriteLine("3. View Hotels available ");
                Console.WriteLine("4. exit program ");
                int input_Choice = int.Parse(Console.ReadLine());

                ReservationBuilder reservation = new ReservationBuilder();

                switch (input_Choice)
                {
                    case 1:
                        reservation.FindBestRatedHotel(firstDate, lastDate, customertype);
                        break;
                    case 2:
                        reservation.findCheapestBestHotel(firstDate, lastDate, customertype);
                        break;
                    case 3:
                        reservation.get_Hotel_List();
                        break;
                    case 4:
                        exit_Program = true;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;

                }
            }
            
            


            
            


        }
    }
}
