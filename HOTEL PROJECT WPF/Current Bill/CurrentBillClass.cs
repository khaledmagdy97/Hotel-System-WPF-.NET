using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTEL_PROJECT_WPF.Buissness_Logic
{
    public class CurrentBillClass
    {
        frontend window;
        public CurrentBillClass(frontend window)
        {
            this.window = window;
        }
        public decimal CurrentBill()
        {
            RoomType room = new RoomType(window);
            Guest guest = new Guest(window);
            DateOfReservation date = new DateOfReservation(window);

            decimal GuestCost = guest.GuestCostCalcuation();
            decimal RoomTypeCost = room.RoomTypeCostCalcuation();
            decimal duratiionCost = date.duratiionCostCalcuation();

            decimal cost = GuestCost + RoomTypeCost + duratiionCost;
            return cost;
        }
    }
}
