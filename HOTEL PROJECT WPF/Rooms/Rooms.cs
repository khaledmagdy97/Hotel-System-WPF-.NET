using HOTEL_PROJECT_WPF.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Text;
using System.Windows.Documents;

namespace HOTEL_PROJECT_WPF.Rooms
{
    public class OcuupiedRooms
    {
        HotelContext? context;
        frontend? window;
        public  OcuupiedRooms(frontend w,HotelContext c)
        {
            context= c;
            window= w;
        }


        public IList GetOcuupiedRooms()
        {
            var ocuupiedReservation = context?.reservations.Where(R => R.check_in == true).ToList();
            return ocuupiedReservation??new();
        }

    }


    public class ReservedRooms
    {
        HotelContext? context;
        frontend? window;
        public ReservedRooms(frontend w, HotelContext c)
        {
            context = c;
            window = w;
        }


        public IList GetReservedRooms()
        {
            var ocuupiedReservation = context?.reservations.Where(R => R.check_in == false).ToList();
            return ocuupiedReservation ?? new();
        }

    }
}
