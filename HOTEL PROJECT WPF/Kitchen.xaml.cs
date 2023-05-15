using HOTEL_PROJECT_WPF.Models;
using HOTEL_PROJECT_WPF.Rooms;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for Kitchen.xaml
    /// </summary>
    public partial class Kitchen : Window
    {
        HotelContext context = new HotelContext();
        Food_Menus food;
        public Kitchen()
        {
            context.reservations.Load();
            InitializeComponent();
            object[] roomNumberOriginal = new object[]
           {
                101,
                102,
                103,
                104,
                105,
                106,
                107,
                108,
                109,
                110,
                201,
                202,
                203,
                204,
                205,
                206,
                207,
                208,
                209,
                210,
                301,
                302,
                303,
                304,
                305,
                306,
                307,
                308,
                309,
                310,
                401,
                402,
                403,
                404,
                405,
                406,
                407,
                408,
                409,
                410,
                501,
                502,
                503,
                504,
                505,
                506,
                507,
                508,
                509,
                510,
           };
            object[] Rooms = new object[]
                 {
              "Double","Single","Twin","Duplex","Suite"
                };
            object[] Floors = new object[]
                {
              "1","2","3","4","5"
             };

            foreach (var i in Rooms)
                this.RoomTypeComboBox.Items.Add(i);
            foreach (var i in Floors)
                this.FloorComboBox.Items.Add(i);

            foreach (var i in roomNumberOriginal)
                this.RoomNumberTypeComboBox.Items.Add(i);

            if (food == null)
                food = new Food_Menus();
            List.ItemsSource = context.reservations.Where(r => r.check_in == true).ToList();
        }

        private void RoomTypeComboBox_DropDownOpened(object sender, EventArgs e)
        {

        }

        private void FloorComboBox_DropDownOpened(object sender, EventArgs e)
        {

        }

        private void RoomNumberTypeComboBox_DropDownOpened(object sender, EventArgs e)
        {

        }

        private void UpdateBtn_Click_1(object sender, RoutedEventArgs e)
        {
            if (food?.Visibility == Visibility.Hidden)
                food.Visibility = Visibility.Visible;
            

            else
                food?.ShowDialog();


          
        }

        private void UpdateBtn_Click_All(object sender, RoutedEventArgs e)
        {

            var result = MessageBox.Show("Are you Sure To Update The Data!", "Hint", MessageBoxButton.YesNo, MessageBoxImage.Information);
            switch (result)
            {
                case MessageBoxResult.Cancel:
                    break;

                case MessageBoxResult.Yes:

                    Reservation reservation = new Reservation();
                    try
                    {
                        if (fnameTextBox is TextBox Fname && Fname != null)
                        {
                            reservation.first_name = Fname.Text;
                        }
                        if (lnameTextBox is TextBox Lname && Lname != null)
                        {
                            reservation.last_name = Lname.Text;
                        }

                      

                        if (phoneTextBox is TextBox phone && phone.Text != null)
                        {
                            reservation.phone_number = phone.Text;
                        }
                        
                       
                        
                        if (RoomNumberTypeComboBox is ComboBox NumRoom && NumRoom.SelectedItem != null)
                        {
                            reservation.room_number = NumRoom.Text;
                        }
                        if (RoomTypeComboBox is ComboBox RoomType && RoomType.SelectedItem != null)
                        {
                            reservation.room_type = RoomType.Text;
                        }
                        if (FloorComboBox is ComboBox floor && floor.SelectedItem != null)
                        {
                            reservation.room_floor = floor.Text;
                        }
                        


                        reservation.food_bill = food?.foodBill ?? 0;
                        try 
                        { 
                        reservation.dinner = Convert.ToInt16(dinnnerNumberWindow.Text ?? "0");
                        reservation.lunch = Convert.ToInt16(lunchNumberWindow.Text ?? "0");
                        reservation.break_fast = Convert.ToInt16(breakfastNumberWindow.Text ?? "0");
                        }
                        catch
                        {
                            MessageBox.Show("Number of meals must be Numerical !", "Hint", MessageBoxButton.OK, MessageBoxImage.Information);
                            return;
                        }
                        reservation.towel = ((towelWindow.IsChecked) == true) ? true : false;
                        reservation.s_surprise = ((surpriseWindow.IsChecked) == true) ? true : false;
                        reservation.cleaning = ((cleanningWindow.IsChecked) == true) ? true : false;


                        var selectedObject = List.SelectedItem as Reservation;


                        var row = context.Database.ExecuteSql(
                        $"update reservation \r\nset first_name= {reservation.first_name},last_name={reservation.last_name},\r\nphone_number={reservation.phone_number},\r\nroom_floor={reservation.room_floor},room_type={reservation.room_type},room_number={reservation.room_number},break_fast={reservation.break_fast},\r\nlunch={reservation.lunch},dinner={reservation.dinner},cleaning={reservation.cleaning},towel={reservation.towel},s_surprise={reservation.s_surprise},food_bill={reservation.food_bill}\r\nwhere Id={selectedObject?.Id ?? 0}"
                        );
                        MessageBox.Show($"Updated Succeffuly\n Rows affected = {row} !", "Updated", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    catch
                    {
                        MessageBox.Show("Cannot update the database !", "Hint", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    break;
                case MessageBoxResult.No:

                    break;



            }
            if (sender is Button updateBtn)
            {
                SolidColorBrush BrushFromHex(string hexColorString)
                {
                    return (SolidColorBrush)(new BrushConverter().ConvertFrom(hexColorString));
                }
                updateBtn.Background = BrushFromHex("#006EB140");
            }













        }

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            breakfastWindow.Visibility=Visibility.Visible;
            breakfastNumberWindow.Visibility=Visibility.Visible;
            lunchWindow.Visibility=Visibility.Visible;
            lunchNumberWindow.Visibility=Visibility.Visible;
            dinnerWindow.Visibility=Visibility.Visible;
            dinnnerNumberWindow.Visibility=Visibility.Visible;
        }

        private void TabItem_GotFocus_1(object sender, RoutedEventArgs e)
        {
            breakfastWindow.Visibility = Visibility.Hidden;
            breakfastNumberWindow.Visibility = Visibility.Hidden;
            lunchWindow.Visibility = Visibility.Hidden;
            lunchNumberWindow.Visibility = Visibility.Hidden;
            dinnerWindow.Visibility = Visibility.Hidden;
            dinnnerNumberWindow.Visibility = Visibility.Hidden;


            var ocuupiedReservation = context?.reservations.Where(R => R.check_in == true).ToList();


            dataGridRooms.ItemsSource = ocuupiedReservation;
            dataGridRooms.Columns[15].DisplayIndex = 0;
            dataGridRooms.Columns[13].DisplayIndex = 1;
            dataGridRooms.Columns[3].Visibility = Visibility.Hidden;
            dataGridRooms.Columns[4].Visibility = Visibility.Hidden;
            dataGridRooms.Columns[6].Visibility = Visibility.Hidden;
            dataGridRooms.Columns[7].Visibility = Visibility.Hidden;
            dataGridRooms.Columns[8].Visibility = Visibility.Hidden;
            dataGridRooms.Columns[9].Visibility = Visibility.Hidden;
            dataGridRooms.Columns[10].Visibility = Visibility.Hidden;
            dataGridRooms.Columns[11].Visibility = Visibility.Hidden;
            dataGridRooms.Columns[12].Visibility = Visibility.Hidden;
            dataGridRooms.Columns[14].Visibility = Visibility.Hidden;
            dataGridRooms.Columns[17].Visibility = Visibility.Hidden;
            dataGridRooms.Columns[18].Visibility = Visibility.Hidden;
            dataGridRooms.Columns[19].Visibility = Visibility.Hidden;
            dataGridRooms.Columns[20].Visibility = Visibility.Hidden;
            dataGridRooms.Columns[21].Visibility = Visibility.Hidden;
            dataGridRooms.Columns[25].Visibility = Visibility.Hidden;
            dataGridRooms.Columns[26].Visibility = Visibility.Hidden;

        }



        private void List_Selected(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListBox lst)
            {
                if (lst.SelectedItem is Reservation selctedReservation)
                {
                    fnameTextBox.Text = selctedReservation.first_name;
                    lnameTextBox.Text = selctedReservation.last_name;
                    phoneTextBox.Text = selctedReservation.phone_number;
                    phoneTextBox.Text = selctedReservation.phone_number;


                    RoomTypeComboBox.Text = selctedReservation.room_type;
                    RoomTypeComboBox.Text = selctedReservation.room_type;
                    FloorComboBox.Text = selctedReservation.room_floor;
                    RoomNumberTypeComboBox.Text = selctedReservation.room_number;


                    if (food?.breakfast is CheckBox breakfast)
                    {
                        if (selctedReservation.break_fast == 0)
                        {
                            breakfast.IsChecked = false;
                            breakfastWindow.IsChecked = false;
                            food.breakfastNumber.Text = "0";
                            breakfastNumberWindow.Text = "0";
                        }
                        else
                        {
                            breakfast.IsChecked = true;
                            breakfastWindow.IsChecked = true;
                            food.breakfastNumber.Text = selctedReservation.break_fast.ToString();
                            breakfastNumberWindow.Text = selctedReservation.break_fast.ToString();
                        }
                    }



                    if (food?.lunch is CheckBox lunch)
                    {
                        if (selctedReservation.lunch == 0)
                        {
                            lunch.IsChecked = false;
                            lunchWindow.IsChecked = false;
                            food.lunchNumber.Text = "0";
                            lunchNumberWindow.Text = "0";
                        }
                        else
                        {
                            lunch.IsChecked = true;
                            lunchWindow.IsChecked = true;
                            lunchNumberWindow.Text = selctedReservation.lunch.ToString();
                        }
                    }



                    if (food?.dinner is CheckBox dinner)
                    {
                        if (selctedReservation.lunch == 0)
                        {
                            dinner.IsChecked = false;
                            dinnerWindow.IsChecked = false;
                            food.dinnnerNumber.Text = "0";
                            dinnnerNumberWindow.Text = "0";
                        }
                        else
                        {
                            dinner.IsChecked = true;
                            dinnerWindow.IsChecked = true;
                            food.dinnnerNumber.Text = selctedReservation.dinner.ToString();
                            dinnnerNumberWindow.Text = selctedReservation.dinner.ToString();
                        }

                    }

                    if (food?.cleanning is CheckBox clean)
                    {
                        if (selctedReservation.cleaning == false)
                        {
                            clean.IsChecked = false;
                            cleanningWindow.IsChecked = false;
                        }
                        else
                        {
                            clean.IsChecked = true;
                            cleanningWindow.IsChecked = true;

                        }
                    }


                    if (food?.towel is CheckBox towel)
                    {
                        if (selctedReservation.towel == false)
                        {
                            towel.IsChecked = false;
                            towelWindow.IsChecked = false;

                        }
                        else
                        {
                            towel.IsChecked = true;
                            towelWindow.IsChecked = true;

                        }
                    }


                    if (food?.surprise is CheckBox surprise)
                    {
                        if (selctedReservation.s_surprise == false)
                        {
                            surprise.IsChecked = false;
                            surpriseWindow.IsChecked = false;

                        }
                        else
                        {
                            surprise.IsChecked = true;
                            surpriseWindow.IsChecked = true;
                        }
                    }



                }
            }
        }

        private void updateBtn_MouseMove(object sender, MouseEventArgs e)
        {
            if (
                 !string.IsNullOrEmpty(RoomTypeComboBox.Text)
              && !string.IsNullOrEmpty(FloorComboBox.Text)
              && !string.IsNullOrEmpty(RoomNumberTypeComboBox.Text)
              && !string.IsNullOrEmpty(phoneTextBox.Text)
               )
            {
                if (sender is Button updateBtn)
                {
                    updateBtn.IsEnabled = true;

                    SolidColorBrush BrushFromHex(string hexColorString)
                    {
                        return (SolidColorBrush)(new BrushConverter().ConvertFrom(hexColorString));
                    }
                    updateBtn.Background = BrushFromHex("#FF6EB140");
                }



            }
            else
                MessageBox.Show("Year must Enter all values !", "Hint", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            breakfastWindow.IsChecked = food?.breakfast.IsChecked;
            breakfastNumberWindow.Text = food?.breakfastNumber.Text;

            lunchWindow.IsChecked = food?.lunch.IsChecked;
            lunchNumberWindow.Text = food?.lunchNumber.Text;

            dinnerWindow.IsChecked = food?.dinner.IsChecked;
            dinnnerNumberWindow.Text = food?.dinnnerNumber.Text;

            cleanningWindow.IsChecked = food?.cleanning.IsChecked;
            towelWindow.IsChecked = food?.towel.IsChecked;
            surpriseWindow.IsChecked = food?.surprise.IsChecked;

            
        }
    }
}
