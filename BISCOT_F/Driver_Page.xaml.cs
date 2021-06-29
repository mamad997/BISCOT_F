using Microsoft.Win32;
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
using System.IO;
using System.Data.Entity.Validation;
using BISCOT_F;

namespace test_matrial
{
    /// <summary>
    /// Interaction logic for Driver_Page.xaml
    /// </summary>
    public partial class Driver_Page : Page
    {

        public Drivertbl Driver = new Drivertbl();
        public MainWindow mycallingpage =null;
        public biscotir_dbEntities1 biscotir_DbEntities1 = new biscotir_dbEntities1();
        public Cartbl Cartbl = new Cartbl();
        public Triptbl Triptbl = new Triptbl();
        public Driver_Page(Drivertbl d, MainWindow callingPage)
        {
            InitializeComponent();
            //makedriverslist();
            mycallingpage = callingPage;
            DataContext = d;
            if (d.Cartbl != null)
                Fild(d);
            Driver = d;
        }


        public void Fild(Drivertbl driver) {
            
            DateTime oDate = Convert.ToDateTime(driver.BirthdayDate);          
            txttavalod.SelectedDate = oDate;
           
            foreach (ComboBoxItem item in comboBoxcar.Items)
            {
                if (driver.Cartbl.ModelKhodro == item.Content.ToString()) {

                    var nt = comboBoxcar.Items.IndexOf(item); ;
                    comboBoxcar.SelectedIndex = nt;
                }

            }
            txtfirsname.Text = driver.FirstName;
            txtlastname.Text = driver.LastName;
            txtfahtername.Text = driver.FatherName;
            txtncode.Text = driver.N_Code.ToString();
            txtscode.Text = driver.N_Id.ToString();
            txtphone.Text = driver.PhoneNumber.ToString();
            txtaddress.Text = driver.Address;
            txtrang.Text = driver.Cartbl.Rang;
            txtvin.Text = driver.Cartbl.VIN.ToString();
            txtpelak.Text = driver.Cartbl.Pelak;
            txtsalesakht.Text = driver.Cartbl.SaleSakht.ToString();

        
        }
       
       

      

        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == true)
            {
                string selectedFileName = dlg.FileName;
                
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
                Image.Source = bitmap;
            }
        }

        

      

       

        private void Button_Copy_Click_1(object sender, RoutedEventArgs e)
        {
            Driver_Main page2 = new Driver_Main(mycallingpage);
            mycallingpage.frame.Navigate(page2);
        }

      
      
        private byte[] BitmapSourceToByteArray(BitmapSource image)
        {
            using (var stream = new MemoryStream())
            {
                var encoder = new PngBitmapEncoder(); // or some other encoder
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(stream);
                return stream.ToArray();
            }
        }
        private BitmapImage ByteArrayToImage(byte[] byteArrayIn)
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                stream.Write(byteArrayIn, 0, byteArrayIn.Length);
                stream.Position = 0;
                System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
                BitmapImage returnImage = new BitmapImage();
                returnImage.BeginInit();
                MemoryStream ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                ms.Seek(0, SeekOrigin.Begin);
                returnImage.StreamSource = ms;
                returnImage.EndInit();

                return returnImage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            if (Driver.Pic != null)
                Image.Source = ByteArrayToImage(Driver.Pic);
        }

        private void Btnsabt_Click(object sender, RoutedEventArgs e)
        {
            if (Driver.Id == 0)
            {
                try
                {
                    Driver = new Drivertbl();
                    // DateTime oDate = Convert.ToDateTime(driver.BirthdayDate);


                    Cartbl.ModelKhodro = comboBoxcar.Text;
                    Cartbl.Rang = txtrang.Text;
                    Cartbl.VIN = Convert.ToInt64(txtvin.Text);
                    Cartbl.Pelak = txtpelak.Text;
                    Cartbl.SaleSakht = Convert.ToInt32(txtsalesakht.Text);
                    biscotir_DbEntities1.Cartbls.Add(Cartbl);
                    biscotir_DbEntities1.SaveChanges();
                    Driver.CarId = biscotir_DbEntities1.Cartbls
                        .Where(c => c.VIN == Cartbl.VIN)
                        .Select(c => c.Id).First();


                    //   Driver.Cartbl = Cartbl;
                    Driver.BirthdayDate = txttavalod.SelectedDate.Value.Date.ToShortDateString();
                    Driver.FirstName = txtfirsname.Text;
                    Driver.Pic = BitmapSourceToByteArray((BitmapSource)Image.Source);
                    Driver.LastName = txtlastname.Text;
                    Driver.FatherName = txtfahtername.Text;
                    Driver.N_Code = Convert.ToInt64(txtncode.Text);
                    Driver.N_Id = Convert.ToInt64(txtscode.Text);
                    Driver.PhoneNumber = Convert.ToInt64(txtphone.Text);
                    Driver.Address = txtaddress.Text;
                    //   Driver.Cartbl = Triptbl.Id;

                    biscotir_DbEntities1.Drivertbls.Add(Driver);
                    biscotir_DbEntities1.SaveChanges();
                    MessageBox.Show("راننده جدید با موفقیت ثبت شد");
                }
                catch (DbEntityValidationException et)
                {

                    foreach (var eve in et.EntityValidationErrors)
                    {

                        foreach (var ve in eve.ValidationErrors)
                        {
                            MessageBox.Show(ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
            else
            {
                try
                {
                    //    Driver = new Drivertbl();
                    // DateTime oDate = Convert.ToDateTime(driver.BirthdayDate);

                    var car = biscotir_DbEntities1.Cartbls.First(a => a.Id ==Driver.CarId);
                    car.ModelKhodro = comboBoxcar.Text;
                    car.Rang = txtrang.Text;
                    car.VIN = Convert.ToInt64(txtvin.Text);
                    car.Pelak = txtpelak.Text;
                    car.SaleSakht = Convert.ToInt32(txtsalesakht.Text);
                  //  biscotir_DbEntities1.Cartbls.Add(car);
                    biscotir_DbEntities1.SaveChanges();


                    var dr = biscotir_DbEntities1.Drivertbls.First(a => a.Id == Driver.Id);
                    //   Driver.Cartbl = Cartbl;
                    dr.BirthdayDate = txttavalod.SelectedDate.Value.Date.ToShortDateString();
                    dr.FirstName = txtfirsname.Text;
                    dr.Pic = BitmapSourceToByteArray((BitmapSource)Image.Source);
                    dr.LastName = txtlastname.Text;
                    dr.FatherName = txtfahtername.Text;
                    dr.N_Code = Convert.ToInt64(txtncode.Text);
                    dr.N_Id = Convert.ToInt64(txtscode.Text);
                    dr.PhoneNumber = Convert.ToInt64(txtphone.Text);
                    dr.Address = txtaddress.Text;
                    //   Driver.Cartbl = Triptbl.Id;

                   // biscotir_DbEntities1.Drivertbls.Add(dr);
                    biscotir_DbEntities1.SaveChanges();
                    MessageBox.Show("راننده با موفقیت ویرایش شد");
                }
                catch (DbEntityValidationException et)
                {
                    foreach (var eve in et.EntityValidationErrors)
                    {
                       
                        foreach (var ve in eve.ValidationErrors)
                        {
                            MessageBox.Show( ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
        }
    }
}
