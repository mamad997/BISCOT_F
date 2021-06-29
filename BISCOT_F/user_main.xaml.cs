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
using biscotDATAaccess;
using System.Data.Entity;
using System.Data;
using System.Reflection;
using Microsoft.Office.Interop;
using System.Windows.Forms;
using BISCOT_F;

namespace test_matrial
{
    /// <summary>
    /// Interaction logic for user_main.xaml
    /// </summary>
    public partial class user_main : Page
    {
        public MainWindow mycallingpage = null;
        public List<usertbl> usertbls = new List<usertbl>();
        public biscotir_dbEntities1 biscotir_DbEntities1 = new biscotir_dbEntities1();
        public  usertbl usertbl = new usertbl();
        public SetDataTabel SDT = new SetDataTabel();
        public ExportExcel ExportExcel = new ExportExcel();
        


        public user_main(MainWindow callingPage)
        {
            InitializeComponent();
            mycallingpage = callingPage;
            usertbls = biscotir_DbEntities1.usertbls.ToList();
            id.ItemsSource = usertbls;
            // usertbl.Address
        }
        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            
                biscotDATAaccess.usertbl temp = new biscotDATAaccess.usertbl();
                User_page page = new User_page(temp, mycallingpage);
                mycallingpage.frame.Navigate(page);
            

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (id.SelectedItem != null)
                {

                    usertbl tempD = (usertbl)id.SelectedItem;
                    var tempid = tempD.Id;
                    biscotir_DbEntities1.usertbls.Remove(tempD);

                    biscotir_DbEntities1.SaveChanges();
                    Btnrefresh_Click(null, null);
                }
                else { System.Windows.MessageBox.Show("first select Driver"); }
            }
            catch
            {

            }


        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void datagrid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void id_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void btnexcel(object sender, RoutedEventArgs e)
        {
            usertbls = biscotir_DbEntities1.usertbls.ToList();
            //   DataTable dt = ToDataTable(view_Reports);
            DataTable dt = SDT.ToDataTable(usertbls);

            ExportExcel.Export(dt);
        }

        private void btnedithe_Click(object sender, RoutedEventArgs e)
        {

            if (id.SelectedItem != null)
            {
                biscotDATAaccess.usertbl temp = (biscotDATAaccess.usertbl)id.SelectedItems[0];
                User_page page = new User_page(temp, mycallingpage);
                mycallingpage.frame.Navigate(page);
            }
        }

        private void Btnrefresh_Click(object sender, RoutedEventArgs e)
        {
            biscotir_DbEntities1 = new biscotir_dbEntities1();
            usertbls = biscotir_DbEntities1.usertbls.ToList();
            id.ItemsSource = usertbls;
        }
    }
}
