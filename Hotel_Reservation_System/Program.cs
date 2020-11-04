using System;
using System.Collections.Generic;

namespace Hotel_Reservation_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hotel reservation Program");

            Console.WriteLine("Enter first date :");
            DateTime firstDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Enter last date :");
            DateTime lastDate = Convert.ToDateTime(Console.ReadLine());

            ReservationBuilder reservation = new ReservationBuilder();
            reservation.findCheapestHotel(firstDate,lastDate);

            
            


        }
    }
}
