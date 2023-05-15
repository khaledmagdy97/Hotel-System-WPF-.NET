using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HOTEL_PROJECT_WPF
{
    public  class Guest
    {
        frontend window;
        public Guest( frontend w)
        {
            window = w;  
        }

        public decimal GuestCostCalcuation()
        {
            decimal cost = 0;
            if (string.IsNullOrEmpty(window.GuestsComboBox.Text))
            {
                MessageBox.Show("Please Enter Number of guests", "Hint", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return 0m;
            }


            switch (Convert.ToInt16(window.GuestsComboBox.Text))
            {
                case 1:
                    cost = 15;
                    break;
                case 2:
                    cost = 20;
                    break;
                case 3:
                    cost = 25;
                    break;
                case 4:
                    cost = 30;
                    break;
                case 5:
                    cost = 35;
                    break;
                case 6:
                    cost = 40;
                    break;
            }

            return cost;
        }

    }
}
