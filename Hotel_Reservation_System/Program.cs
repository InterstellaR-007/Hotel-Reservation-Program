using System;
using System.Collections.Generic;

namespace Hotel_Reservation_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hotel reservation Program");

            List<HotelDetail> hotel_list = new List<HotelDetail> {
                new HotelDetail { hotel_Name="Lakewood",hotel_WeekdayRate=110,hotel_WeekendRate=80},
                new HotelDetail{ hotel_Name="Bridgewood",hotel_WeekdayRate=160,hotel_WeekendRate=110},
                new HotelDetail{hotel_Name="Ridgewood",hotel_WeekdayRate=220,hotel_WeekendRate=100}

            };

            foreach(var hotel in hotel_list)
            {
                Console.WriteLine(hotel.hotel_Name);
            }
        }
    }
}
