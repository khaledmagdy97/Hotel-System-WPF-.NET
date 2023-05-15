using HOTEL_PROJECT_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HOTEL_PROJECT_WPF
{
    /// <summary>
    /// Interaction logic for Food_Menus.xaml
    /// </summary>
    public partial class Food_Menus : Window
    {
        
        public int lunchMoney = 0; public int breakfastMoney = 0; public int dinnerMoney = 0;
        public int cleaningMoney=0; public int towelMoney=0; public int surpriseMoney = 0;
        public int foodBill = 0;


        public Food_Menus()
        {
            InitializeComponent();
            
        }

         void FoodFunction()
        {
            try
            {

            if (breakfast is CheckBox morning)
            {
                if (morning.IsChecked == true)
                    {
                        try
                        { 
                        breakfastMoney= Convert.ToInt16(breakfastNumber.Text)*7;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Value must be Numerical not letters !\n{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                else
                        breakfastMoney = 0;
            }
                if (lunch is CheckBox evening)
                {
                    if (evening.IsChecked == true)
                    {
                        try
                        {
                            lunchMoney = Convert.ToInt16(lunchNumber.Text) * 27;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Value must be Numerical not letters !\n{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                        lunchMoney = 0;
                }
                if (dinner is CheckBox night)
                {
                    if (night.IsChecked == true)
                    {
                        try
                        {
                            dinnerMoney = Convert.ToInt16(dinnnerNumber.Text) * 17;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Value must be Numerical not letters !\n{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                        dinnerMoney = 0;
                }
                if (cleanning is CheckBox clean)
                {
                    if (clean.IsChecked == true)
                       cleaningMoney =5;
                    else
                        cleaningMoney = 0;
                }
                if (towel is CheckBox twl)
                {
                    if (twl.IsChecked == true)
                        towelMoney = 5;
                    else
                        towelMoney = 0;
                }
                if (surprise is CheckBox srp)
                {
                    if (srp.IsChecked == true)
                        surpriseMoney = 50;
                    else
                        surpriseMoney = 0;
                }
                foodBill= lunchMoney+ breakfastMoney + dinnerMoney+cleaningMoney+towelMoney+surpriseMoney;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox t && t != null)
            {
                t.Text = "";
            }
        }

        private void TextBox_GotFocus_1(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox t && t != null)
            {
                t.Text = "";
            }
        }

        private void Button_Click(object sender,RoutedEventArgs ee)
        {
            FoodFunction();
            this.Visibility = Visibility.Hidden;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            FoodFunction();
            this.Visibility = Visibility.Hidden;
        }
    }
}
