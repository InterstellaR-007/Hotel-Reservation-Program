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

        public int total_Days;
        public int WeekendDays;
        public int WeekDays;

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
        public int getTotalRate(HotelDetail hotel)
        {
            if (hotel != null)
                return (hotel.hotel_WeekdayRate * WeekDays) + (hotel.hotel_WeekendRate * WeekendDays);
            else
                return -1;
        }

        public void findCheapestBestHotel(DateTime firstDate, DateTime lastDate)
        {
            
            total_Days = Convert.ToInt32(lastDate.Subtract(firstDate).TotalDays) +1;
            WeekendDays = total_WeekendDays(firstDate, lastDate);
            WeekDays = total_Days - WeekendDays;
            

            
            HotelDetail cheapestBestHotel = new HotelDetail();
            int cheapestRate = 0;
            
           

            hotel_list.Sort((x, y) => ((getTotalRate(x)).CompareTo(getTotalRate(y))));
            cheapestRate = getTotalRate(hotel_list.First()); 


            cheapestBestRatedHotelsList = hotel_list.FindAll(x => getTotalRate(x).Equals(cheapestRate));


            cheapestBestRatedHotelsList.Sort((x, y) => (y.hotel_Rating).CompareTo(x.hotel_Rating));
            int bestCheapestRating = cheapestBestRatedHotelsList.First().hotel_Rating;

            foreach(var hotel in cheapestBestRatedHotelsList.FindAll(x=> x.hotel_Rating.Equals(bestCheapestRating)))
            {
                Console.WriteLine(hotel.hotel_Name + " Rating is :" + hotel.hotel_Rating + " Total Cost :" + " " + getTotalRate(hotel));
            }
        }

        public void FindBestRatedHotel(DateTime firstDate,DateTime lastDate)
        {
            total_Days = Convert.ToInt32(lastDate.Subtract(firstDate).TotalDays) + 1;
            WeekendDays = total_WeekendDays(firstDate, lastDate);
            WeekDays = total_Days - WeekendDays;

            hotel_list.Sort((x, y) => (x.hotel_Rating).CompareTo(y.hotel_Rating));

            int BestRating = (hotel_list.Last()).hotel_Rating;


            Console.WriteLine("Best Rated Hotels are as follows ");

            foreach(var hotel in hotel_list.FindAll(x => x.hotel_Rating.Equals(BestRating)))
            {
                Console.WriteLine(hotel.hotel_Name + " Rating is :" + hotel.hotel_Rating + " Total Cost :" + " " + getTotalRate(hotel));
            }
        }
    }
}
