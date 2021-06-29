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
using BISCOT_F;

namespace test_matrial
{
    /// <summary>
    /// Interaction logic for Driver_Main.xaml
    /// </summary>
    public partial class Driver_Main : Page


    {
        public List<Drivertbl> drivertbls = new List<Drivertbl>();
        public biscotir_dbEntities1 biscotir_DbEntities1 = new biscotir_dbEntities1();
        public Drivertbl drivertbl = new Drivertbl();
        public MainWindow mycallingpage = null;
        public SetDataTabel SDT = new SetDataTabel();
        public ExportExcel ExportExcel = new ExportExcel();
        public View_car view_Car = new View_car();
        public List<View_car> view_Cars = new List<View_car>();
        public Driver_Main(MainWindow callingPage)
        {
            InitializeComponent();
            mycallingpage = callingPage;
            drivertbls = biscotir_DbEntities1.Drivertbls.ToList();
            //var s = drivertbl.Cartbl.Rang;
            DataGridD.ItemsSource = drivertbls;
            // makedriverslist();
            //.ItemsSource = DRIVERS;
        }
      
        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
           
                Drivertbl tempD = new Drivertbl();
                Driver_Page page2 = new Driver_Page(tempD, mycallingpage);
                mycallingpage.frame.Navigate(page2);
            
          

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (DataGridD.SelectedItem != null)
                {

                    Drivertbl tempD = (Drivertbl)DataGridD.SelectedItem;
                    var tempid = tempD.CarId;
                    biscotir_DbEntities1.Drivertbls.Remove(tempD);
                    var c = (from s1 in biscotir_DbEntities1.Cartbls
                             where s1.Id == tempid
                             select s1).SingleOrDefault();
                    biscotir_DbEntities1.Cartbls.Remove(c);

                    biscotir_DbEntities1.SaveChanges();
                    Btnrefresh_Click(null, null);
                }
                else { MessageBox.Show("first select Driver"); }
            }
            catch
            { 
            
            }

         

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       

      

      

       
     

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }
        public static void GenerateExcel(DataTable dataTable, string path)
        {

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dataTable);

            // create a excel app along side with workbook and worksheet and give a name to it  
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook excelWorkBook = excelApp.Workbooks.Add();
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = excelWorkBook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;
            foreach (DataTable table in dataSet.Tables)
            {
                //Add a new worksheet to workbook with the Datatable name  
                Microsoft.Office.Interop.Excel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add();
                excelWorkSheet.Name = table.TableName;

                // add all the columns  
                for (int i = 1; i < table.Columns.Count + 1; i++)
                {
                    excelWorkSheet.Cells[1, i] = table.Columns[i - 1].ColumnName;
                }

                // add all the rows  
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    for (int k = 0; k < table.Columns.Count; k++)
                    {
                        excelWorkSheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
                    }
                }
            }
            excelWorkBook.SaveAs(path); // -> this will do the custom  
            excelWorkBook.Close();
            excelApp.Quit();
        }

        private void Btnexcel_Click(object sender, RoutedEventArgs e)
        {
            view_Cars = biscotir_DbEntities1.View_car.ToList();
            //   DataTable dt = ToDataTable(view_Reports);
            DataTable dt = SDT.ToDataTable(view_Cars);

            ExportExcel.Export(dt);
        }

        private void Btnedite_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridD.SelectedItem != null)
            {
                Drivertbl tempD = (Drivertbl)DataGridD.SelectedItem;
                Driver_Page page2 = new Driver_Page(tempD, mycallingpage);
                mycallingpage.frame.Navigate(page2);
            }
            else { MessageBox.Show("first select Driver"); }

        }

        private void Btnrefresh_Click(object sender, RoutedEventArgs e)
        {
            biscotir_DbEntities1 = new biscotir_dbEntities1();
            drivertbls = biscotir_DbEntities1.Drivertbls.ToList();
            //var s = drivertbl.Cartbl.Rang;
            DataGridD.ItemsSource = drivertbls;
        }
    }
    
}
