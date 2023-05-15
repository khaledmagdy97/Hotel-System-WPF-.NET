using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
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
using System.Xml.Linq;
using HOTEL_PROJECT_WPF.Buissness_Logic;
using HOTEL_PROJECT_WPF.Models;
using HOTEL_PROJECT_WPF.Rooms;
using Microsoft.EntityFrameworkCore;

namespace HOTEL_PROJECT_WPF
{
    /// <summary>
    /// Interaction logic for frontend.xaml
    /// </summary>
    public partial class frontend : Window
    {

        //---------------------------------------- variables ------------------------------------------//
        Food_Menus? food;
        Bill? billMenu;
        HotelContext context =new HotelContext();

        public frontend()
        {

            context.reservations.Load();
            object[] arr = new object[] 
            {
            "January ",
            "February ",
            "March ",
            "April ",
            "May ",
            "June ",
            "July ",
            "August ",
            "September ",
            "October ",
            "November ",
            "December"
            };

           object[] gender = new object[]
          {
              "Male","Female","Other"
          };
            object[] guests = new object[]
        {
              "1","2","3","4","5","6"
        };
            object[] Floors = new object[]
         {
              "1","2","3","4","5"
        };
            object[] state = new object[]
        {
                "Alabama",
                "Alaska",
                "Arizona",
                "Arkansas",
                "California",
                "Colorado",
                "Connecticut",
                "Delaware",
                "Florida",
                "Georgia",
                "Hawaii",
                "Idaho",
                "Illinois Indiana",
                "Iowa",
                "Kansas",
                "Kentucky",
                "Louisiana",
                "Maine",
                "Maryland",
                "Massachusetts",
                "Michigan",
                "Minnesota",
                "Mississippi",
                "Missouri",
                "Montana Nebraska",
                "Nevada",
                "New Hampshire",
                "New Jersey",
                "New Mexico",
                "New York",
                "North Carolina",
                "North Dakota",
                "Ohio",
                "Oklahoma",
                "Oregon",
                "Pennsylvania Rhode Island",
                "South Carolina",
                "South Dakota",
                "Tennessee",
                "Texas",
                "Utah",
                "Vermont",
                "Virginia",
                "Washington",
                "West Virginia",
                "Wisconsin",
                "Wyoming"
        };
            object[] Rooms = new object[]
        {
              "Double","Single","Twin","Duplex","Suite"
         };
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

            object[] arr1 = new object[31];
            int[] tempArr1 = Enumerable.Range(1, 31).ToArray();
            for (int i = 0; i < tempArr1.Length; i++)
                arr1[i] = tempArr1[i];

            InitializeComponent();            

            foreach (var i in arr)
            this.monthComboBox.Items.Add(i);
            monthComboBox.SelectedItem = arr[0];
            foreach (var i in arr1)
                this.DayComboBox.Items.Add(i);
            DayComboBox.SelectedItem = arr1[0];

            foreach (var i in gender)
                this.GenderComboBox.Items.Add(i);
            GenderComboBox.SelectedItem = gender[0];

            foreach (var i in state)
                this.StateComboBox.Items.Add(i);
            foreach (var i in guests)
                this.GuestsComboBox.Items.Add(i);
            foreach (var i in Rooms)
                this.RoomTypeComboBox.Items.Add(i);
            foreach (var i in Floors)
                this.FloorComboBox.Items.Add(i);
            
            foreach (var i in roomNumberOriginal)
                this.RoomNumberTypeComboBox.Items.Add(i);

            Reservation_data_grid_view.ItemsSource=context.reservations.Local.ToBindingList();
            SearchDataGrid.Visibility=Visibility.Hidden;
            SearchIconNew.Visibility = Visibility.Hidden;
            SearchLabel.Visibility = Visibility.Hidden;
            SearchLabel2.Visibility = Visibility.Hidden;
            SearchLabel3.Visibility = Visibility.Hidden;
            if (food == null)
            {
                food = new();
            }

        }

       

       
      

        private void BillButton_Click(object sender, RoutedEventArgs e)
        {
            if(billMenu==null)
             billMenu = new Bill();

            CurrentBillClass HotellBill = new CurrentBillClass(this);
            decimal hotelBill = HotellBill.CurrentBill();
            decimal food_lBill = food?.foodBill ?? 0;
            decimal tax = 15;

            billMenu.CurrentBillLabel.Content= $"{hotelBill} $";
            billMenu.FoodBillLabel.Content = $"{food_lBill} $";
            billMenu.TaxLabel.Content = $"{tax} $";
            billMenu.TotalLabel.Content = $"{food_lBill+hotelBill+tax} $";
            billMenu.ShowDialog();
        }
       

        private void NewReservationButton_Click(object sender, RoutedEventArgs e)
        {
            SubmitBtn.IsEnabled= true;
            SubmitBtn.Visibility= Visibility.Visible;
            DeleteButton.Visibility = Visibility.Hidden;
            UpdateBtn.Visibility = Visibility.Hidden;
            ReservationComboBox.Visibility = Visibility.Hidden;
            Reservationlabel.Visibility = Visibility.Hidden;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            food?.Close();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            ReservationComboBox.Visibility = Visibility.Visible;
            DeleteButton.Visibility = Visibility.Visible;
            UpdateBtn.Visibility = Visibility.Visible;
            Reservationlabel.Visibility = Visibility.Visible;
            SubmitBtn.Visibility = Visibility.Hidden;
            ReservationComboBox.ItemsSource = context.reservations.Local.ToBindingList();
            
        }
        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            Reservation reservation = new Reservation();


            if (!string.IsNullOrEmpty(billMenu?.TotalLabel.Content?.ToString()?.Split(' ')[0])
               && !string.IsNullOrEmpty(FnameTextBox.Text)
               && !string.IsNullOrEmpty(LnameTextBox.Text)
               && !string.IsNullOrEmpty(EntryDate.Text)
               && !string.IsNullOrEmpty(DepartureDate.Text)
               && !string.IsNullOrEmpty(DepartureDate.Text)
               && (monthComboBox is ComboBox mth && mth.SelectedItem != null)
               && (DayComboBox is ComboBox day && day.SelectedItem != null)
               && !string.IsNullOrEmpty(YearTextBox.Text)
               && !string.IsNullOrEmpty(StateComboBox.Text)
               && !string.IsNullOrEmpty(cityTextBox.Text)
               && !string.IsNullOrEmpty(cityTextBox.Text)
               && !string.IsNullOrEmpty(GenderComboBox.Text)
               && !string.IsNullOrEmpty(RoomTypeComboBox.Text)
               && !string.IsNullOrEmpty(FloorComboBox.Text)
               && !string.IsNullOrEmpty(RoomNumberTypeComboBox.Text)
               && !string.IsNullOrEmpty(PhoneTextBox.Text)
               && !string.IsNullOrEmpty(suiteTextBox.Text)
               && !string.IsNullOrEmpty(emailTextBox.Text)
               && !string.IsNullOrEmpty(billMenu.PamentTypeComboBox.Text)
               && !string.IsNullOrEmpty(billMenu.CVCVisaNumberTextBox.Text)
               && !string.IsNullOrEmpty(billMenu.mmVisaComboBox.Text)
               && !string.IsNullOrEmpty(billMenu.yyVisaComboBox.Text)
               && !string.IsNullOrEmpty(billMenu.VisaNumberTextBox.Text)
                )
            {
              

            }
            else 
            { 
                MessageBox.Show("Year must Enter all values !", "Hint", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }



            try
            {
                if (FnameTextBox is TextBox Fname && Fname != null)
                {
                    reservation.first_name = Fname.Text;
                }
                if (LnameTextBox is TextBox Lname && Lname != null)
                {
                    reservation.last_name = Lname.Text;
                }

                if ((monthComboBox is ComboBox mthh && mthh.SelectedItem != null) &&
                      (DayComboBox is ComboBox dayy && dayy.SelectedItem != null) &&
                     (YearTextBox is TextBox year && year.Text != null))
                {
                    try
                    { 
                    reservation.birth_day = $"{mthh.Text}-{dayy.Text}-{Convert.ToInt16(year.Text)}";
                    }
                    catch 
                    {
                        MessageBox.Show("Please Enter Year of Birthday ", "Hint", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                }
                if (GenderComboBox is ComboBox gndr && gndr.SelectedItem != null)
                {
                    reservation.gender = gndr.Text;
                }
                if (PhoneTextBox is TextBox phone && phone.Text != null)
                {
                    reservation.phone_number = phone.Text;
                }
                if (emailTextBox is TextBox email && email.Text != null)
                {
                    reservation.email_address = email.Text;
                }
                if (StreetTextBox is TextBox street && street.Text != null)
                {
                    reservation.street_address = street.Text;
                }
                if (suiteTextBox is TextBox suite && suite.Text != null)
                {
                    reservation.apt_suite = suite.Text;
                }
                if (cityTextBox is TextBox city && city.Text != null)
                {
                    reservation.city = city.Text;
                }
                if (StateComboBox is ComboBox state && state.SelectedItem != null)
                {
                    reservation.state = state.Text;
                }
                if (zipTextBox is TextBox zip && zip.Text != null)
                {
                    reservation.zip_code = zip.Text;
                }
                if (GuestsComboBox is ComboBox Guests && Guests.SelectedItem != null)
                {
                    reservation.number_guest = Convert.ToInt16(Guests.Text);
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
                if (EntryDate is DatePicker Edate && Edate.Text != null)
                {
                    reservation.arrival_time = Convert.ToDateTime(Edate.Text);
                }
                if (DepartureDate is DatePicker Ddate && Ddate.Text != null)
                {
                    reservation.arrival_time = Convert.ToDateTime(Ddate.Text);
                }
                if (CheckIn is CheckBox chk)
                {
                    if (chk.IsChecked == true)
                        reservation.check_in = true;
                    else
                        reservation.check_in = false;
                }
                if (FoodSupply is CheckBox Supply)
                {
                    if (Supply.IsChecked == true)
                        reservation.supply_status = true;
                    else
                        reservation.supply_status = false;
                }

                var duration = Convert.ToDateTime(this.DepartureDate.Text).Day - Convert.ToDateTime(this.EntryDate.Text).Day;

                if (duration < 0)
                {
                    MessageBox.Show("entry date must be eariler than departure date !!!", "Hint", MessageBoxButton.OK, MessageBoxImage.Error);
                    duration = 0;
                    return;
                }
                reservation.food_bill = food?.foodBill ?? 0;
                reservation.dinner = Convert.ToInt16(food?.dinnnerNumber.Text ?? "0");
                reservation.lunch = Convert.ToInt16(food?.lunchNumber.Text ?? "0");
                reservation.break_fast = Convert.ToInt16(food?.breakfastNumber.Text ?? "0");
                reservation.towel = ((food?.towel.IsChecked) == true) ? true : false;
                reservation.s_surprise = ((food?.surprise.IsChecked) == true) ? true : false;
                reservation.cleaning = ((food?.cleanning.IsChecked) == true) ? true : false;
             

                reservation.card_exp = billMenu?.mmVisaComboBox.Text + "/" + billMenu?.yyVisaComboBox.Text;
                reservation.total_bill=Convert.ToDouble((billMenu?.TotalLabel?.Content?.ToString()??"").Trim('$').Trim());
                reservation.payment_type = billMenu?.PamentTypeComboBox.Text; 
                reservation.card_number = billMenu?.VisaNumberTextBox.Text; 
                reservation.card_cvc = billMenu?.CVCVisaNumberTextBox.Text; 
                reservation.card_type = billMenu?.CardTypeLabel.Content.ToString();
                context.reservations.Add(reservation);


                if(context.reservations.Where(r=>r.room_number==reservation.room_number && r.leaving_time>DateTime.Now).FirstOrDefault()!=null)
                {
                    MessageBox.Show("Cannot Make Reservation, Rooms already Reserved", "Not Added", MessageBoxButton.OK, MessageBoxImage.Hand);
                    
                }
                else
                {
                    if (context.SaveChanges() > 0)
                        MessageBox.Show("Reservation Added successfully", "Added", MessageBoxButton.OK, MessageBoxImage.Information);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private void TextBox_GotFocus_1(object sender, KeyEventArgs e)
        {
            if (sender is TextBox t && t != null)
            {
                
                Thickness myMargin = new();
                myMargin.Left = 11;
                myMargin.Top = 100;
                myMargin.Right = 0;
                myMargin.Bottom = 0;
                t.Margin = myMargin;


                SearchIconNew_Copy.Visibility = Visibility.Hidden;
                SearchDataGrid.Visibility = Visibility.Visible;
                SearchIconNew.Visibility = Visibility.Visible;
                SearchLabel.Visibility = Visibility.Visible;
                SearchLabel2.Visibility = Visibility.Visible;
                SearchLabel3.Visibility = Visibility.Visible;

                SearchDataGrid.ItemsSource = context.reservations.Local.ToBindingList();


            }
            if (e.Key==Key.Enter && sender is TextBox search && search != null)
            {
                try
                { 
                 char[] spearator = { ',', ' ','/','-' };
                 var lst= context.reservations.Where(R => R.Id ==int.Parse( search.Text.ToLower().Split(spearator)[0] )|| R.first_name.ToLower() == search.Text.ToLower().Split(spearator)[1] || R.last_name.ToLower() == search.Text.ToLower().Split(spearator)[2]).Take(10).ToList();
                 SearchDataGrid.ItemsSource= lst;
                    
                    if (lst.Count==0)
                        MessageBox.Show("No Results For Your Search :(", "Hint", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                catch 
                {
                    MessageBox.Show("Invalid Formula !\nPlease Search using Seperator id-First name-last name ", "Hint", MessageBoxButton.OK, MessageBoxImage.Information);

                }

            }
        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox t && t != null)
            {
                t.Text = "";
            }
        }

        private void SearchIconNew_Click(object sender, RoutedEventArgs e)
        {

            TextBox search = SearchTextBox;
                try
                {
                    char[] spearator = { ',', ' ', '/', '-' };
                    var lst = context.reservations.Where(R => R.Id == int.Parse(search.Text.ToLower().Split(spearator)[0]) || R.first_name.ToLower() == search.Text.ToLower().Split(spearator)[1] || R.last_name.ToLower() == search.Text.ToLower().Split(spearator)[2]).Take(10).ToList();
                    SearchDataGrid.ItemsSource = lst;

                if (lst.Count == 0)
                    MessageBox.Show("No Results For Your Search :(", "Hint", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch
                {
                    MessageBox.Show("Invalid Formula !\nPlease Search using Seperator id-First name-last name ", "Hint", MessageBoxButton.OK, MessageBoxImage.Information);

                }

            }

        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            //OCCUPIED Rooms
            //var availableRoomsList = context.reservations.Where(R => temp.Any(room => room!= Convert.ToInt16( R.room_number)|| (R.leaving_time)<(DateTime.Now) )).ToList();
            OcuupiedRooms occupied = new OcuupiedRooms(this, context);

            OccupiedRoomListBox.ItemsSource = occupied.GetOcuupiedRooms();
            OccupiedRoomListBox.Columns[15].DisplayIndex = 0;
            OccupiedRoomListBox.Columns[13].DisplayIndex = 1;
            OccupiedRoomListBox.Columns[3].Visibility = Visibility.Hidden;
            OccupiedRoomListBox.Columns[4].Visibility = Visibility.Hidden;
            OccupiedRoomListBox.Columns[6].Visibility = Visibility.Hidden;
            OccupiedRoomListBox.Columns[7].Visibility = Visibility.Hidden;
            OccupiedRoomListBox.Columns[8].Visibility = Visibility.Hidden;
            OccupiedRoomListBox.Columns[9].Visibility = Visibility.Hidden;
            OccupiedRoomListBox.Columns[10].Visibility = Visibility.Hidden;
            OccupiedRoomListBox.Columns[11].Visibility = Visibility.Hidden;
            OccupiedRoomListBox.Columns[12].Visibility = Visibility.Hidden;
            OccupiedRoomListBox.Columns[14].Visibility = Visibility.Hidden;
            OccupiedRoomListBox.Columns[17].Visibility = Visibility.Hidden;
            OccupiedRoomListBox.Columns[18].Visibility = Visibility.Hidden;
            OccupiedRoomListBox.Columns[19].Visibility = Visibility.Hidden;
            OccupiedRoomListBox.Columns[20].Visibility = Visibility.Hidden;
            OccupiedRoomListBox.Columns[21].Visibility = Visibility.Hidden;
            OccupiedRoomListBox.Columns[25].Visibility = Visibility.Hidden;
            OccupiedRoomListBox.Columns[26].Visibility = Visibility.Hidden;
            OccupiedRoomListBox.Columns[27].Visibility = Visibility.Hidden;
            OccupiedRoomListBox.Columns[28].Visibility = Visibility.Hidden;
            OccupiedRoomListBox.Columns[29].Visibility = Visibility.Hidden;
            OccupiedRoomListBox.Columns[30].Visibility = Visibility.Hidden;
            OccupiedRoomListBox.Columns[31].Visibility = Visibility.Hidden;
            OccupiedRoomListBox.Columns[32].Visibility = Visibility.Hidden;


            //Reserved Rooms
            //var availableRoomsList = context.reservations.Where(R => temp.Any(room => room!= Convert.ToInt16( R.room_number)|| (R.leaving_time)<(DateTime.Now) )).ToList();
            ReservedRooms Reserved = new ReservedRooms(this, context);

            availableRoomListBox.ItemsSource = Reserved.GetReservedRooms();
            availableRoomListBox.Columns[15].DisplayIndex = 0;
            availableRoomListBox.Columns[13].DisplayIndex = 1;
            availableRoomListBox.Columns[3].Visibility = Visibility.Hidden;
            availableRoomListBox.Columns[4].Visibility = Visibility.Hidden;
            availableRoomListBox.Columns[6].Visibility = Visibility.Hidden;
            availableRoomListBox.Columns[7].Visibility = Visibility.Hidden;
            availableRoomListBox.Columns[8].Visibility = Visibility.Hidden;
            availableRoomListBox.Columns[9].Visibility = Visibility.Hidden;
            availableRoomListBox.Columns[10].Visibility = Visibility.Hidden;
            availableRoomListBox.Columns[11].Visibility = Visibility.Hidden;
            availableRoomListBox.Columns[12].Visibility = Visibility.Hidden;
            availableRoomListBox.Columns[14].Visibility = Visibility.Hidden;
            availableRoomListBox.Columns[17].Visibility = Visibility.Hidden;
            availableRoomListBox.Columns[18].Visibility = Visibility.Hidden;
            availableRoomListBox.Columns[19].Visibility = Visibility.Hidden;
            availableRoomListBox.Columns[20].Visibility = Visibility.Hidden;
            availableRoomListBox.Columns[21].Visibility = Visibility.Hidden;
            availableRoomListBox.Columns[25].Visibility = Visibility.Hidden;
            availableRoomListBox.Columns[26].Visibility = Visibility.Hidden;
            availableRoomListBox.Columns[27].Visibility = Visibility.Hidden;
            availableRoomListBox.Columns[28].Visibility = Visibility.Hidden;
            availableRoomListBox.Columns[29].Visibility = Visibility.Hidden;
            availableRoomListBox.Columns[30].Visibility = Visibility.Hidden;
            availableRoomListBox.Columns[31].Visibility = Visibility.Hidden;
            availableRoomListBox.Columns[32].Visibility = Visibility.Hidden;
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {

        }

       

    

      
        private void ReservationComboBox_DropDownClosed_1(object sender, EventArgs e)
        {
            char[] spearator = { ',', ' ', '/', '-' };
            this.Statelabel.Content = "";
            this.No_of_Guests_label.Content = "";
            this.Room_Type_label.Content = "";
            this.Floor_Label.Content = "";
            this.Room_Number_label.Content = "";
            this.Statelabel.Content = "";


            if (sender is ComboBox combo && combo != null)
            {
                if (combo.SelectedItem is Reservation selctedReservation && selctedReservation != null)
                {
                    if (food == null)
                        food = new();

                    FnameTextBox.Text = selctedReservation.first_name;
                    LnameTextBox.Text = selctedReservation.last_name;

                    var date = selctedReservation.birth_day.Split('-');
                    monthComboBox.Text = date[0];
                    DayComboBox.Text = date[1];
                    YearTextBox.Text = date[2];

                    GenderComboBox.Text = selctedReservation.gender;
                    PhoneTextBox.Text = selctedReservation.phone_number;
                    emailTextBox.Text = selctedReservation.email_address;
                    StreetTextBox.Text = selctedReservation.street_address;
                    StreetTextBox.Text = selctedReservation.street_address;
                    suiteTextBox.Text = selctedReservation.apt_suite;
                    cityTextBox.Text = selctedReservation.city;
                    cityTextBox.Text = selctedReservation.city;
                    StateComboBox.Text = selctedReservation.state;
                    zipTextBox.Text = selctedReservation.zip_code;
                    GuestsComboBox.Text = selctedReservation.number_guest.ToString();
                    RoomTypeComboBox.Text = selctedReservation.room_type;
                    RoomTypeComboBox.Text = selctedReservation.room_type;
                    FloorComboBox.Text = selctedReservation.room_floor;
                    RoomNumberTypeComboBox.Text = selctedReservation.room_number;
                    EntryDate.Text = selctedReservation.arrival_time.ToString();
                    DepartureDate.Text = selctedReservation.leaving_time.ToString();

                    if (  food?.breakfast is CheckBox breakfast)
                    {
                        if (selctedReservation.break_fast == 0)
                        {
                            breakfast.IsChecked = false;
                            food.breakfastNumber.Text = "0";
                        }
                        else
                        {
                            breakfast.IsChecked = true;
                            food.breakfastNumber.Text = selctedReservation.break_fast.ToString();
                        }
                    }
                    
                    

                    if ( food?.lunch is CheckBox lunch) 
                    {
                        if (selctedReservation.lunch == 0)
                        {
                            lunch.IsChecked = false;
                            food.lunchNumber.Text = "0";
                        }
                        else
                        {
                             lunch.IsChecked = true;
                             food.lunchNumber.Text = selctedReservation.lunch.ToString();
                        }
                    }
                    


                    if (  food?.dinner is CheckBox dinner)
                    {
                        if (selctedReservation.lunch == 0)
                        {
                        dinner.IsChecked = false;
                        food.dinnnerNumber.Text = "0";
                        }
                        else
                        {
                            dinner.IsChecked = true;
                            food.dinnnerNumber.Text = selctedReservation.dinner.ToString();
                        }

                    }
          
                    if ( food?.cleanning is CheckBox clean)
                    {
                        if (selctedReservation.cleaning == false)
                        {
                            clean.IsChecked = false;
                        }
                        else
                        {
                        clean.IsChecked = true;

                        }
                    }


                    if ( food?.towel is CheckBox towel)
                    {
                        if (selctedReservation.towel == false)
                        towel.IsChecked = false;
                        else
                        towel.IsChecked = true;
                    }


                    if ( food?.surprise is CheckBox surprise)
                    {
                        if (selctedReservation.s_surprise == false)
                            surprise.IsChecked = false;
                        else surprise.IsChecked = true;
                    }

                    if (this?.CheckIn is CheckBox CheckIn)
                    {
                        if (selctedReservation.check_in == false)
                            CheckIn.IsChecked = false;
                        else
                        CheckIn.IsChecked = true;
                    }

                    if ( this?.FoodSupply is CheckBox FoodSupply)
                    {
                        if (selctedReservation.supply_status == false)
                            FoodSupply.IsChecked = false;
                        else
                            FoodSupply.IsChecked = true;
                    }


                    var expire = selctedReservation.card_exp.Split('/');
                    if (billMenu == null)
                        billMenu = new();
                    billMenu.YYLabel.Content = ' ';
                    billMenu.MMLabel.Content = ' ';
                    billMenu.A.Content = ' ';
                    billMenu.PamentTypeComboBox.Text = selctedReservation.payment_type;
                    billMenu.VisaNumberTextBox.Text = selctedReservation.card_number;
                    billMenu.CVCVisaNumberTextBox.Text = selctedReservation.card_cvc;
                    billMenu.mmVisaComboBox.Text = expire[0];
                    billMenu.yyVisaComboBox.Text = expire[1];
                    billMenu.CardTypeLabel.Content = billMenu.PamentTypeComboBox.Text;

                    if (sender is Button updateBtn)
                    {
                        SolidColorBrush BrushFromHex(string hexColorString)
                        {
                            return (SolidColorBrush)(new BrushConverter().ConvertFrom(hexColorString));
                        }
                        updateBtn.Background = BrushFromHex("#006EB140");
                    }

                }
            }
        }
        private void Fname_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox t && t != null)
            {
                t.Text = "";
            }
        }

        private void Lname_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox t && t != null)
            {
                t.Text = "";
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox t && t != null)
            {
                t.Text = "";
            }
        }

        private void StateComboBox_DropDownClosed(object sender, EventArgs e)
        {
            Statelabel.Visibility = Visibility.Collapsed;
        }

        private void RoomTypeComboBox_DropDownOpened(object sender, EventArgs e)
        {
            Room_Type_label.Visibility = Visibility.Collapsed;

        }

        private void ReservationComboBox_DropDownOpened(object sender, EventArgs e)
        {
            Reservationlabel.Visibility = Visibility.Collapsed;

        }

        private void Button_GotFocus(object sender, RoutedEventArgs e)
        {
            this.Background = Brushes.Transparent;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (food?.Visibility == Visibility.Hidden)
                food.Visibility = Visibility.Visible;
          

            else
                food?.ShowDialog();
        }
        private void GuestsComboBox_DropDownOpened(object sender, EventArgs e)
        {
            No_of_Guests_label.Visibility = Visibility.Hidden;
        }

        private void FloorComboBox_DropDownOpened(object sender, EventArgs e)
        {
            Floor_Label.Visibility = Visibility.Hidden;
        }

        private void RoomNumberTypeComboBox_DropDownOpened(object sender, EventArgs e)
        {
            Room_Number_label.Visibility = Visibility.Hidden;
        }

        private void UpdateBtn_MouseMove(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(billMenu?.TotalLabel.Content?.ToString()?.Split(' ')[0])
               && !string.IsNullOrEmpty(FnameTextBox.Text)
               && !string.IsNullOrEmpty(LnameTextBox.Text)
               && !string.IsNullOrEmpty(EntryDate.Text)
               && !string.IsNullOrEmpty(DepartureDate.Text)
               && !string.IsNullOrEmpty(DepartureDate.Text)
               &&(monthComboBox is ComboBox mth && mth.SelectedItem != null)
               &&(DayComboBox is ComboBox day && day.SelectedItem != null)
               && !string.IsNullOrEmpty(YearTextBox.Text )
               && !string.IsNullOrEmpty(StateComboBox.Text)
               && !string.IsNullOrEmpty(cityTextBox.Text)
               && !string.IsNullOrEmpty(cityTextBox.Text)
               && !string.IsNullOrEmpty(GenderComboBox.Text)
               && !string.IsNullOrEmpty(RoomTypeComboBox.Text)
               && !string.IsNullOrEmpty(FloorComboBox.Text)
               && !string.IsNullOrEmpty(RoomNumberTypeComboBox.Text)
               && !string.IsNullOrEmpty(PhoneTextBox.Text)
               && !string.IsNullOrEmpty(suiteTextBox.Text)
               && !string.IsNullOrEmpty(emailTextBox.Text)
               && !string.IsNullOrEmpty(billMenu.PamentTypeComboBox.Text)
               && !string.IsNullOrEmpty(billMenu.CVCVisaNumberTextBox.Text)
               && !string.IsNullOrEmpty(billMenu.mmVisaComboBox.Text)
               && !string.IsNullOrEmpty(billMenu.yyVisaComboBox.Text)
               && !string.IsNullOrEmpty(billMenu.VisaNumberTextBox.Text)
                )
            {
                if (sender is Button updateBtn)
                {
                    updateBtn.IsEnabled=true;

                     SolidColorBrush BrushFromHex(string hexColorString)
                        {
                        return (SolidColorBrush)(new BrushConverter().ConvertFrom(hexColorString));
                        }
                        updateBtn.Background = BrushFromHex("#FF6EB140") ;
                }

                

            }
            else
                MessageBox.Show("Year must Enter all values !", "Hint", MessageBoxButton.OK, MessageBoxImage.Information);

        }

        private void UpdateBtn_Click_1(object sender, RoutedEventArgs e)
        {

            try
            {
                int.Parse(YearTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Year must be in numerical values !", "Hint", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try
            {
                int.Parse(zipTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Zip Code must be in numerical values !", "Hint", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try
            {
                int.Parse(PhoneTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Phone Number must be in numerical values !", "Hint", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            var duration = Convert.ToDateTime(this.DepartureDate.Text).Day - Convert.ToDateTime(this.EntryDate.Text).Day;

            if (duration < 0)
            {
                MessageBox.Show("entry date must be eariler than departure date !!!", "Hint", MessageBoxButton.OK, MessageBoxImage.Error);
                duration = 0;
                return;
            }
            var result = MessageBox.Show("Are you Sure To Update The Data!", "Hint", MessageBoxButton.YesNo, MessageBoxImage.Information);
            switch (result)
            {
                case MessageBoxResult.Cancel:
                    break;

                case MessageBoxResult.Yes:

                    Reservation reservation = new Reservation();
                    try
                    {
                        if (FnameTextBox is TextBox Fname && Fname != null)
                        {
                            reservation.first_name = Fname.Text;
                        }
                        if (LnameTextBox is TextBox Lname && Lname != null)
                        {
                            reservation.last_name = Lname.Text;
                        }

                        if ((monthComboBox is ComboBox mth && mth.SelectedItem != null) &&
                              (DayComboBox is ComboBox day && day.SelectedItem != null) &&
                             (YearTextBox is TextBox year && year.Text != null))
                        {
                            try
                            {
                                reservation.birth_day = $"{mth.Text}-{day.Text}-{Convert.ToInt16(year.Text)}";
                            }
                            catch
                            {
                                MessageBox.Show("Please Enter Year of Birthday ", "Hint", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                        if (GenderComboBox is ComboBox gndr && gndr.SelectedItem != null)
                        {
                            reservation.gender = gndr.Text;
                        }
                        if (PhoneTextBox is TextBox phone && phone.Text != null)
                        {
                            reservation.phone_number = phone.Text;
                        }
                        if (emailTextBox is TextBox email && email.Text != null)
                        {
                            reservation.email_address = email.Text;
                        }
                        if (StreetTextBox is TextBox street && street.Text != null)
                        {
                            reservation.street_address = street.Text;
                        }
                        if (suiteTextBox is TextBox suite && suite.Text != null)
                        {
                            reservation.apt_suite = suite.Text;
                        }
                        if (cityTextBox is TextBox city && city.Text != null)
                        {
                            reservation.city = city.Text;
                        }
                        if (StateComboBox is ComboBox state && state.SelectedItem != null)
                        {
                            reservation.state = state.Text;
                        }
                        if (zipTextBox is TextBox zip && zip.Text != null)
                        {
                            reservation.zip_code = zip.Text;
                        }
                        if (GuestsComboBox is ComboBox Guests && Guests.SelectedItem != null)
                        {
                            reservation.number_guest = Convert.ToInt16(Guests.Text);
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
                        if (EntryDate is DatePicker Edate && Edate.Text != null)
                        {
                            reservation.arrival_time = Convert.ToDateTime(Edate.Text);
                        }
                        if (DepartureDate is DatePicker Ddate && Ddate.Text != null)
                        {
                            reservation.arrival_time = Convert.ToDateTime(Ddate.Text);
                        }
                        if (CheckIn is CheckBox chk)
                        {
                            if (chk.IsChecked == true)
                                reservation.check_in = true;
                            else
                                reservation.check_in = false;
                        }
                        if (FoodSupply is CheckBox Supply)
                        {
                            if (Supply.IsChecked == true)
                                reservation.supply_status = true;
                            else
                                reservation.supply_status = false;
                        }


                        reservation.food_bill = food?.foodBill ?? 0;
                        reservation.dinner = Convert.ToInt16(food?.dinnnerNumber.Text ?? "0");
                        reservation.lunch = Convert.ToInt16(food?.lunchNumber.Text ?? "0");
                        reservation.break_fast = Convert.ToInt16(food?.breakfastNumber.Text ?? "0");
                        reservation.towel = ((food?.towel.IsChecked) == true) ? true : false;
                        reservation.s_surprise = ((food?.surprise.IsChecked) == true) ? true : false;
                        reservation.cleaning = ((food?.cleanning.IsChecked) == true) ? true : false;


                        reservation.card_exp = billMenu?.mmVisaComboBox.Text + "/" + billMenu?.yyVisaComboBox.Text;
                        reservation.total_bill = Convert.ToDouble((billMenu?.TotalLabel?.Content?.ToString() ?? "").Trim('$').Trim());
                        reservation.payment_type = billMenu?.PamentTypeComboBox.Text;
                        reservation.card_number = billMenu?.VisaNumberTextBox.Text;
                        reservation.card_cvc = billMenu?.CVCVisaNumberTextBox.Text;
                        reservation.card_type = billMenu?.CardTypeLabel.Content.ToString();


                        var selectedObject=ReservationComboBox.SelectedItem as Reservation;


                        var row = context.Database.ExecuteSql(
                        $"update reservation \r\nset first_name= {reservation.first_name},last_name={reservation.last_name},birth_day={reservation.birth_day},gender={reservation.birth_day},\r\nphone_number={reservation.phone_number},email_address={reservation.email_address},number_guest={reservation.number_guest},\r\nstreet_address={reservation.email_address},apt_suite={reservation.apt_suite},city={reservation.city},state={reservation.state},zip_code={reservation.zip_code},\r\nroom_floor={reservation.room_floor},room_type={reservation.room_type},room_number={reservation.room_number},total_bill={reservation.total_bill},\r\npayment_type={reservation.payment_type},card_type={reservation.card_type},card_cvc={reservation.card_cvc},card_exp={reservation.card_exp},card_number={reservation.card_number},\r\narrival_time={reservation.arrival_time},leaving_time={reservation.leaving_time},check_in={reservation.check_in},break_fast={reservation.break_fast},\r\nlunch={reservation.lunch},dinner={reservation.dinner},cleaning={reservation.cleaning},towel={reservation.towel},supply_status={reservation.supply_status},s_surprise={reservation.s_surprise},food_bill={reservation.food_bill}\r\nwhere Id={selectedObject?.Id??0}"
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

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int.Parse(YearTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Year must be in numerical values !", "Hint", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try
            {
                int.Parse(zipTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Zip Code must be in numerical values !", "Hint", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try
            {
                int.Parse(PhoneTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Phone Number must be in numerical values !", "Hint", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (!string.IsNullOrEmpty(billMenu?.TotalLabel.Content?.ToString()?.Split(' ')[0])
               && !string.IsNullOrEmpty(FnameTextBox.Text)
               && !string.IsNullOrEmpty(LnameTextBox.Text)
               && !string.IsNullOrEmpty(EntryDate.Text)
               && !string.IsNullOrEmpty(DepartureDate.Text)
               && !string.IsNullOrEmpty(DepartureDate.Text)
               && (monthComboBox is ComboBox mth && mth.SelectedItem != null)
               && (DayComboBox is ComboBox day && day.SelectedItem != null)
               && !string.IsNullOrEmpty(YearTextBox.Text)
               && !string.IsNullOrEmpty(StateComboBox.Text)
               && !string.IsNullOrEmpty(cityTextBox.Text)
               && !string.IsNullOrEmpty(cityTextBox.Text)
               && !string.IsNullOrEmpty(GenderComboBox.Text)
               && !string.IsNullOrEmpty(RoomTypeComboBox.Text)
               && !string.IsNullOrEmpty(FloorComboBox.Text)
               && !string.IsNullOrEmpty(RoomNumberTypeComboBox.Text)
               && !string.IsNullOrEmpty(PhoneTextBox.Text)
               && !string.IsNullOrEmpty(suiteTextBox.Text)
               && !string.IsNullOrEmpty(emailTextBox.Text)
               && !string.IsNullOrEmpty(billMenu.PamentTypeComboBox.Text)
               && !string.IsNullOrEmpty(billMenu.CVCVisaNumberTextBox.Text)
               && !string.IsNullOrEmpty(billMenu.mmVisaComboBox.Text)
               && !string.IsNullOrEmpty(billMenu.yyVisaComboBox.Text)
               && !string.IsNullOrEmpty(billMenu.VisaNumberTextBox.Text)
                )
            {

               var duration = Convert.ToDateTime(this.DepartureDate.Text).Day - Convert.ToDateTime(this.EntryDate.Text).Day;

                if (duration < 0)
                {
                    MessageBox.Show("entry date must be eariler than departure date !!!", "Hint", MessageBoxButton.OK, MessageBoxImage.Error);
                    duration = 0;
                    return ;
                }
                var result = MessageBox.Show("Are you Sure To Delete The Data!", "Hint", MessageBoxButton.YesNo, MessageBoxImage.Information);
                switch (result)
                {
                    case MessageBoxResult.Cancel:
                        break;

                    case MessageBoxResult.Yes:

                        Reservation reservation = new Reservation();
                        try
                        {
                            if (FnameTextBox is TextBox Fname && Fname != null)
                            {
                                reservation.first_name = Fname.Text;
                            }
                            if (LnameTextBox is TextBox Lname && Lname != null)
                            {
                                reservation.last_name = Lname.Text;
                            }

                            if ((monthComboBox is ComboBox mthh && mthh.SelectedItem != null) &&
                                  (DayComboBox is ComboBox dayy && dayy.SelectedItem != null) &&
                                 (YearTextBox is TextBox year && year.Text != null))
                            {
                                try
                                {
                                    reservation.birth_day = $"{mthh.Text}-{dayy.Text}-{Convert.ToInt16(year.Text)}";
                                }
                                catch
                                {
                                    MessageBox.Show("Please Enter Year of Birthday ", "Hint", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                            }
                            if (GenderComboBox is ComboBox gndr && gndr.SelectedItem != null)
                            {
                                reservation.gender = gndr.Text;
                            }
                            if (PhoneTextBox is TextBox phone && phone.Text != null)
                            {
                                reservation.phone_number = phone.Text;
                            }
                            if (emailTextBox is TextBox email && email.Text != null)
                            {
                                reservation.email_address = email.Text;
                            }
                            if (StreetTextBox is TextBox street && street.Text != null)
                            {
                                reservation.street_address = street.Text;
                            }
                            if (suiteTextBox is TextBox suite && suite.Text != null)
                            {
                                reservation.apt_suite = suite.Text;
                            }
                            if (cityTextBox is TextBox city && city.Text != null)
                            {
                                reservation.city = city.Text;
                            }
                            if (StateComboBox is ComboBox state && state.SelectedItem != null)
                            {
                                reservation.state = state.Text;
                            }
                            if (zipTextBox is TextBox zip && zip.Text != null)
                            {
                                reservation.zip_code = zip.Text;
                            }
                            if (GuestsComboBox is ComboBox Guests && Guests.SelectedItem != null)
                            {
                                reservation.number_guest = Convert.ToInt16(Guests.Text);
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
                            if (EntryDate is DatePicker Edate && Edate.Text != null)
                            {
                                reservation.arrival_time = Convert.ToDateTime(Edate.Text);
                            }
                            if (DepartureDate is DatePicker Ddate && Ddate.Text != null)
                            {
                                reservation.arrival_time = Convert.ToDateTime(Ddate.Text);
                            }
                            if (CheckIn is CheckBox chk)
                            {
                                if (chk.IsChecked == true)
                                    reservation.check_in = true;
                                else
                                    reservation.check_in = false;
                            }
                            if (FoodSupply is CheckBox Supply)
                            {
                                if (Supply.IsChecked == true)
                                    reservation.supply_status = true;
                                else
                                    reservation.supply_status = false;
                            }


                            reservation.food_bill = food?.foodBill ?? 0;
                            reservation.dinner = Convert.ToInt16(food?.dinnnerNumber.Text ?? "0");
                            reservation.lunch = Convert.ToInt16(food?.lunchNumber.Text ?? "0");
                            reservation.break_fast = Convert.ToInt16(food?.breakfastNumber.Text ?? "0");
                            reservation.towel = ((food?.towel.IsChecked) == true) ? true : false;
                            reservation.s_surprise = ((food?.surprise.IsChecked) == true) ? true : false;
                            reservation.cleaning = ((food?.cleanning.IsChecked) == true) ? true : false;


                            reservation.card_exp = billMenu?.mmVisaComboBox.Text + "/" + billMenu?.yyVisaComboBox.Text;
                            reservation.total_bill = Convert.ToDouble((billMenu?.TotalLabel?.Content?.ToString() ?? "").Trim('$').Trim());
                            reservation.payment_type = billMenu?.PamentTypeComboBox.Text;
                            reservation.card_number = billMenu?.VisaNumberTextBox.Text;
                            reservation.card_cvc = billMenu?.CVCVisaNumberTextBox.Text;
                            reservation.card_type = billMenu?.CardTypeLabel.Content.ToString();


                            var selectedObject = ReservationComboBox.SelectedItem as Reservation;


                            var row = context.Database.ExecuteSql(
                            $"delete from reservation where Id={selectedObject?.Id ?? 0}"
                            );
                            MessageBox.Show($"Deleted Succeffuly\n Rows affected = {row} !", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);

                        }
                        catch
                        {
                            MessageBox.Show("Cannot delete from the database !", "Hint", MessageBoxButton.OK, MessageBoxImage.Information);
                        }

                        break;
                    case MessageBoxResult.No:

                        break;



                }
            }
        }

        private void TabItem_GotFocus_1(object sender, RoutedEventArgs e)
        {
            Kitchen kitchen = new();
            kitchen.ShowDialog();
        }
    }
    }
    
