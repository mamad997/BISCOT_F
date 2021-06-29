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
using BISCOT_F;
using System.Collections;
using System.Windows.Media.Animation;
using test_matrial;

namespace BISCOT_F
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
  
        public MainWindow()
        {
            InitializeComponent();
            ButtinMenuclose.Visibility = Visibility.Collapsed;
            ButtinMenopne.Visibility = Visibility.Visible;
            RequestP page1 = new RequestP();
            frame.Navigate(page1);
            //  this.Content = page1;
            //   page2.Show() ;
            // ListView_Requset.ItemsSource= start_conf();
            //  ListView_Requset.SelectedIndex = 0;
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtinMenuopne_Click(object sender, RoutedEventArgs e)
        {

            ButtinMenopne.Visibility = Visibility.Collapsed;
            ButtinMenuclose.Visibility = Visibility.Visible;
        }

        private void ButtinMenclose_Click(object sender, RoutedEventArgs e)
        {
            ButtinMenuclose.Visibility = Visibility.Collapsed;
            ButtinMenopne.Visibility = Visibility.Visible;

        }
        private void WindowMaximize_Click_1(object sender, RoutedEventArgs e)
        {

            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                this.WindowState = System.Windows.WindowState.Normal;
            }
        }
        private void Btn_Driver_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            // Driver_Page page1 = new Driver_Page();
            // Request_Page page2 = new Request_Page();
            // mian_view.Child = page2;
        }

        private void btn_request_Click(object sender, RoutedEventArgs e)
        {
            RequestP page1 = new RequestP();
            frame.Navigate(page1);
        }

        private void btn_drivers(object sender, RoutedEventArgs e)
        {

            Driver_Main page2 = new Driver_Main(this);
            frame.Navigate(page2);
        }

        private void GridMenu_MouseLeave(object sender, MouseEventArgs e)
        {
            //RoutedEventArgs e = new RoutedEventArgs();
            //   e.Source =;e.RoutedEvent
            if (ButtinMenuclose.Visibility == Visibility.Visible)
            {
                ButtinMenclose_Click(null, null);
                Storyboard s = (Storyboard)TryFindResource("Storyboard2");
                s.Begin();
            }

        }



        private void Btn_user_Click_1(object sender, RoutedEventArgs e)
        {
            user_main page3 = new user_main(this);
            frame.Navigate(page3);
        }

        private void Btn_report_Click(object sender, RoutedEventArgs e)
        {
            ReportP page4 = new ReportP();
            frame.Navigate(page4);
        }
    }
}