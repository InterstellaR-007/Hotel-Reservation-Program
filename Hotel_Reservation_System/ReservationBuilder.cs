using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace Hotel_Reservation_System
{
    public class ReservationBuilder
    {
        List<HotelDetail> hotel_list = new List<HotelDetail> {
                new HotelDetail { hotel_Name="Lakewood",hotel_WeekdayRate=110,hotel_WeekendRate=90},
                new HotelDetail{ hotel_Name="Bridgewood",hotel_WeekdayRate=150,hotel_WeekendRate=50},
                new HotelDetail{hotel_Name="Ridgewood",hotel_WeekdayRate=220,hotel_WeekendRate=150}

            };
        public int total_WeekendDays(DateTime firstDate, DateTime lastDate)
        {
            int count = 0;
            
            for (var day = firstDate; day.Date <= lastDate; day = day.AddDays(1))
            {
                if(day.ToString("dddd")=="Saturday" || day.ToString("dddd") == "Sunday")
                {
                    count++;
                }
            }
            return count;
            
        }

        public void findCheapestHotel(DateTime firstDate, DateTime lastDate)
        {
            int total_Days = Convert.ToInt32(lastDate.Subtract(firstDate).TotalDays) +1;
            int WeekendDays = total_WeekendDays(firstDate, lastDate);
            int WeekDays = total_Days - WeekendDays;



            HotelDetail cheapest_Hotel = new HotelDetail();
            cheapest_Hotel = hotel_list.First();
            
            foreach(var hotel in hotel_list)
            {
                cheapest_Hotel = hotel.hotel_WeekdayRate * total_Days <= cheapest_Hotel.hotel_WeekdayRate * total_Days ? hotel : cheapest_Hotel;
            }

            Console.WriteLine(cheapest_Hotel.hotel_Name + "" + "Total Cost :" + cheapest_Hotel.hotel_WeekdayRate * total_Days);
        }
    }
}
