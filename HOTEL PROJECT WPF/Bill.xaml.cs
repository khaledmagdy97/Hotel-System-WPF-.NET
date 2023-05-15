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
    /// Interaction logic for Bill.xaml
    /// </summary>
    public partial class Bill : Window
    {

        
        object[] mmVisa = new object[]
         {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"
         };
        object[] yyVisa = new object[]
        {
            14,
            15,
            16,
            17,
            18,
            19,
            20,
            21,
            22,
            23,
            24
        };
        object[] payment = new object[]
        {
            "VISA" ,"Credit Card"
        };
        public Bill()
        {
            InitializeComponent();

            foreach (var i in mmVisa)
                mmVisaComboBox.Items.Add(i);
            foreach (var i in yyVisa)
                yyVisaComboBox.Items.Add(i);
            foreach (var i in payment)
                PamentTypeComboBox.Items.Add(i);
        }


        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox t && t != null)
            {
                t.Text = "";
            }
        }

        private void VisaNumberTextBox_Copy_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox t && t != null)
            {
                t.Text = "";
            }
        }

        private void VisaNumberTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox t && t != null)
            {
                t.Text = "";
            }
        }

        private void PamentTypeComboBox_DropDownOpened(object sender, EventArgs e)
        {
            A.Visibility= Visibility.Collapsed;
            if (sender is ComboBox t && string.IsNullOrEmpty( t.Text )!=true)
            {
                CardTypeLabel.Content = t.Text;
            }
        }

        private void mmVisaComboBox_DropDownOpened(object sender, EventArgs e)
        {
            MMLabel.Visibility = Visibility.Collapsed;
        }

        private void yyVisaComboBox_Copy_DropDownOpened(object sender, EventArgs e)
        {
            YYLabel.Visibility = Visibility.Collapsed;
        }

        private void NextButton_Click(object sender,RoutedEventArgs ee)
        {
          
            this.Visibility = Visibility.Hidden;

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
            this.Visibility = Visibility.Hidden;
        }
    }
}
