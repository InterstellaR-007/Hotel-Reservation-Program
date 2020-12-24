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

        public enum customerType
        {
            normal,reward
        }

        public int total_Days;
        public int WeekendDays;
        public int WeekDays;

        Dictionary<customerType, List<HotelDetail>> CustomerBased_hotelList = new Dictionary<customerType, List<HotelDetail>>()
        {
            { customerType.normal, new List<HotelDetail>{new HotelDetail { Name="Lakewood",WeekdayRate=110, WeekendRate=90,Rating=3},
                new HotelDetail{ Name="Bridgewood",WeekdayRate=150,WeekendRate=50,Rating=4},
                new HotelDetail{Name="Ridgewood",WeekdayRate=220,WeekendRate=150,Rating=5} } },
            { customerType.reward, new List<HotelDetail>{new HotelDetail { Name="Lakewood",WeekdayRate=80, WeekendRate=80,Rating=3},
                new HotelDetail{ Name="Bridgewood",WeekdayRate=110,WeekendRate=50,Rating=4},
                new HotelDetail{Name="Ridgewood",WeekdayRate=100,WeekendRate=40,Rating=5}} }
        };


        public void get_Hotel_List()
        {
            foreach (var item in CustomerBased_hotelList)
            {
                Console.WriteLine("Customer type: " + item.Key);
                foreach (var hotel in item.Value)
                {
                    Console.WriteLine("Hotel Name: " + hotel.Name + " WeekdayRate : " + hotel.WeekdayRate + " WeekendRate : " + hotel.WeekendRate + " Rating : " + hotel.Rating);
                }
                Console.WriteLine("\n");

            }
        }

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
                return (hotel.WeekdayRate * WeekDays) + (hotel.WeekendRate * WeekendDays);
            else
                return -1;
        }

        public void findCheapestBestHotel(DateTime firstDate, DateTime lastDate,customerType type)
        {
                  
            
            total_Days = Convert.ToInt32(lastDate.Subtract(firstDate).TotalDays) +1;
            WeekendDays = total_WeekendDays(firstDate, lastDate);
            WeekDays = total_Days - WeekendDays;
            

            
            HotelDetail cheapestBestHotel = new HotelDetail();
            int cheapestRate = 0;


            List<HotelDetail> hotel_list = CustomerBased_hotelList[type];

            hotel_list.Sort((x, y) => ((getTotalRate(x)).CompareTo(getTotalRate(y))));
            cheapestRate = getTotalRate(hotel_list.First()); 


            cheapestBestRatedHotelsList = hotel_list.FindAll(x => getTotalRate(x).Equals(cheapestRate));


            cheapestBestRatedHotelsList.Sort((x, y) => (y.Rating).CompareTo(x.Rating));

            Console.WriteLine("Cheapest Rated Hotels are as follows: ");
            int bestCheapestRating = cheapestBestRatedHotelsList.First().Rating;

            foreach(var hotel in cheapestBestRatedHotelsList.FindAll(x=> x.Rating.Equals(bestCheapestRating)))
            {
                Console.WriteLine(hotel.Name + " Rating is :" + hotel.Rating + " Total Cost :" + " " + getTotalRate(hotel));
            }
            Console.WriteLine("\n ");
        }

        public void FindBestRatedHotel(DateTime firstDate,DateTime lastDate,customerType type)
        {
            total_Days = Convert.ToInt32(lastDate.Subtract(firstDate).TotalDays) + 1;
            WeekendDays = total_WeekendDays(firstDate, lastDate);
            WeekDays = total_Days - WeekendDays;

            List<HotelDetail> hotel_list = CustomerBased_hotelList[type];

            hotel_list.Sort((x, y) => (x.Rating).CompareTo(y.Rating));

            int BestRating = (hotel_list.Last()).Rating;


            Console.WriteLine("Best Rated Hotels are as follows ");

            foreach(var hotel in hotel_list.FindAll(x => x.Rating.Equals(BestRating)))
            {
                Console.WriteLine(hotel.Name + " Rating is :" + hotel.Rating + " Total Cost :" + " " + getTotalRate(hotel));
            }
            Console.WriteLine("\n");
        }
    }
}
