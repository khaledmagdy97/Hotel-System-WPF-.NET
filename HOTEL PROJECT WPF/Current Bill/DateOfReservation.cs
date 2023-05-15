using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HOTEL_PROJECT_WPF.Buissness_Logic
{
    public class DateOfReservation
    {
        frontend window;
        public DateOfReservation(frontend window)
        {
            this.window = window;
        }
        public decimal duratiionCostCalcuation()
        {
            int duration;
            int durationCost = 0;
            if (string.IsNullOrEmpty(window.EntryDate.Text))
                MessageBox.Show("Please Enter Entry Date", "Hint", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            if (string.IsNullOrEmpty(window.DepartureDate.Text))
                MessageBox.Show("Please Enter Departure Date", "Hint", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            duration = Convert.ToDateTime(window.DepartureDate.Text).Day - Convert.ToDateTime(window.EntryDate.Text).Day;

            if (duration < 0)
            {
                MessageBox.Show("entry date must be eariler than departure date !!!", "Hint", MessageBoxButton.OK, MessageBoxImage.Error);
                duration = 0;
                return 0;
            }
            if (duration == 0)
                durationCost = 75;

            durationCost = duration * 75;

            return durationCost;
        }

    }
}
