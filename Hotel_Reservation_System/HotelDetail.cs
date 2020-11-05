using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel_Reservation_System
{
    public class HotelDetail
    {
        public enum customerType
        {
            normal,reward
        }
        public string Name { get; set; }
        public int WeekdayRate { get; set; }
        public int WeekendRate { get; set; }

        public int Rating { get; set; }


    }
}
