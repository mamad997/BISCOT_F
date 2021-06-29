using biscotDATAaccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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
using System.Web;
using System.IO;
using System.Runtime.InteropServices;
using BISCOT_F;

namespace test_matrial
{
    /// <summary>
    /// Interaction logic for ReportP.xaml
    /// </summary>
    public partial class ReportP : Page
    {
       
        public biscotir_dbEntities1 biscotir_DbEntities1 = new biscotir_dbEntities1();
        public List<Triptbl> Triptbls = new List<Triptbl>();
        public Triptbl Triptbl = new Triptbl();
        public View_report view_Report = new View_report();
        public List<View_report> view_Reports = new List<View_report>();
        public SetDataTabel SDT = new SetDataTabel();
        public ExportExcel ExportExcel = new ExportExcel();
        public ReportP()
        {
            InitializeComponent();
            //makedriverslist();
            Triptbls  = biscotir_DbEntities1.Triptbls.ToList();
            id.ItemsSource = Triptbls;
         //   Triptbl.Tozihat
        }
       

        private void Expander_Drop(object sender, DragEventArgs e)
        {
            var t = id;


        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            
        }

        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtdatestart.Text == "از تاریخ")
            {
                txtdatestart.Text = "--/--/---1";
                
            }
        }

        private void Txtdatestart_MouseEnter(object sender, MouseEventArgs e)
        {
            if (txtdatestart.Text == "از تاریخ")
            {
                txtdatestart.Text = "--/--/---1";
                txtdatestart.SelectionStart = 3;
            }
            
        }

        private void Txtdatestart_MouseLeave(object sender, MouseEventArgs e)
        {
            if(txtdatestart.Text == "--/--/---1")
            {
                txtdatestart.Text = "از تاریخ";
            }
        }

      


       
           
        
            private void btnrefresh_Click(object sender, RoutedEventArgs e)
        {
            biscotir_DbEntities1 = new biscotir_dbEntities1();
            Triptbls = biscotir_DbEntities1.Triptbls.ToList();
            id.ItemsSource = Triptbls;
           
        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            view_Reports = biscotir_DbEntities1.View_report.ToList();
            //   DataTable dt = ToDataTable(view_Reports);
            DataTable dt = SDT.ToDataTable(view_Reports);

            ExportExcel.Export(dt);
           
        }

      

    }

}


