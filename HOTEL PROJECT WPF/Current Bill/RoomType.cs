using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HOTEL_PROJECT_WPF
{
    public class RoomType
    {   
        frontend window;
        public RoomType(frontend window)
        {
            this.window = window;
        }
        public  decimal RoomTypeCostCalcuation()
        {
            if (string.IsNullOrEmpty(window.RoomTypeComboBox.Text))
                MessageBox.Show("Please Enter Room Type", "Hint", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            decimal cost = 0;
            if (window.RoomTypeComboBox.Text.ToLower() == "double".ToLower())
                cost = 50;
            if (window.RoomTypeComboBox.Text.ToLower() == "single".ToLower())
                cost = 35;
            if (window.RoomTypeComboBox.Text.ToLower() == "twin".ToLower())
                cost = 75;
            if (window.RoomTypeComboBox.Text.ToLower() == "doublex".ToLower())
                cost = 100;
            if (window.RoomTypeComboBox.Text.ToLower() == "Suite".ToLower())
                cost = 150;
            return cost;
        }

    }
}
