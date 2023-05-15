using HOTEL_PROJECT_WPF.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HOTEL_PROJECT_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       


        HotelContext context = new HotelContext();
        public MainWindow()
        {
            InitializeComponent();
            context.Logins.Load();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                frontend window = new frontend();
                var user =  context.Logins.Where(l => l.user_name == usernameTextBox.Text && l.pass_word == passwordTextBox.Password.ToString()).FirstOrDefault();

                if (user != null)
                {
                    this.Close();
                    window.ReservationComboBox.Visibility = Visibility.Hidden;
                    window.DeleteButton.Visibility = Visibility.Hidden;
                    window.UpdateBtn.Visibility = Visibility.Hidden;
                    window.Reservationlabel.Visibility= Visibility.Hidden;
                    window.SubmitBtn.Visibility= Visibility.Hidden;
                    window.ShowDialog();
                }
                else
                    MessageBox.Show("Wrong password or username", "Invalid Login", MessageBoxButton.OK, MessageBoxImage.Error);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string message = "All copy rights reserved for Dev:khaled magdy\n notice to indicate that we will retain all rights provided by copyright law.";
            MessageBox.Show(message, "Licence", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
