using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace Hotel_Reservation_System
{
    public class ReservationBuilder
    {
        List<HotelDetail> cheapestHotelsList = new List<HotelDetail>();
        List<HotelDetail> cheapestBestRatedHotelsList = new List<HotelDetail>();

        List<HotelDetail> hotel_list = new List<HotelDetail> {
                new HotelDetail { hotel_Name="Lakewood",hotel_WeekdayRate=110,hotel_WeekendRate=90,hotel_Rating=3},
                new HotelDetail{ hotel_Name="Bridgewood",hotel_WeekdayRate=150,hotel_WeekendRate=50,hotel_Rating=4},
                new HotelDetail{hotel_Name="Ridgewood",hotel_WeekdayRate=220,hotel_WeekendRate=150,hotel_Rating=5}

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
        public int getTotalRate(HotelDetail hotel,int weekDays,int weekendDays)
        {
            if (hotel != null)
                return (hotel.hotel_WeekdayRate * weekDays) + (hotel.hotel_WeekendRate * weekendDays);
            else
                return -1;
        }

        public void findCheapestHotel(DateTime firstDate, DateTime lastDate)
        {
            int BestHotelRating = 0;
            int total_Days = Convert.ToInt32(lastDate.Subtract(firstDate).TotalDays) +1;
            int WeekendDays = total_WeekendDays(firstDate, lastDate);
            int WeekDays = total_Days - WeekendDays;
            

            
            HotelDetail cheapest_Hotel = new HotelDetail();
            cheapest_Hotel = hotel_list.First();
            
            foreach(var hotel in hotel_list)
            {
                cheapest_Hotel = getTotalRate(hotel,WeekDays,WeekendDays)<getTotalRate(cheapest_Hotel, WeekDays, WeekendDays) ? hotel : cheapest_Hotel;
            }

            foreach(var hotel in hotel_list)
            {
                if (getTotalRate(hotel, WeekDays, WeekendDays) == getTotalRate(cheapest_Hotel, WeekDays, WeekendDays))
                    cheapestHotelsList.Add(hotel);
            }

            BestHotelRating = (cheapestHotelsList.First()).hotel_Rating;

            foreach(var hotel in cheapestHotelsList)
            {
                BestHotelRating = hotel.hotel_Rating > BestHotelRating ? hotel.hotel_Rating : BestHotelRating;
            }
            
            foreach(var hotel in cheapestHotelsList)
            {
                if (hotel.hotel_Rating == BestHotelRating)
                    cheapestBestRatedHotelsList.Add(hotel);
            }

            foreach(var hotel in cheapestBestRatedHotelsList)
                Console.WriteLine(hotel.hotel_Name + " Rating is :" + hotel.hotel_Rating + " Total Cost :" +" "+ getTotalRate(hotel,WeekDays,WeekendDays));
        }
    }
}
