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
using System.Data.Entity;
using System.Data;
using System.Reflection;
using Microsoft.Office.Interop;
using System.IO;
using BISCOT_F;

namespace test_matrial
{
    /// <summary>
    /// Interaction logic for User_page.xaml
    /// </summary>
    public partial class User_page : Page
    {
        public usertbl  usertb= new usertbl();
        public MainWindow mycallingpage = null;
        biscotir_dbEntities1 biscotir_DbEntities1 = new biscotir_dbEntities1();
        public User_page(usertbl usertbl, MainWindow callingPage)
        {
            InitializeComponent();
            fild(usertbl);
            mycallingpage = callingPage;
            usertb = usertbl;
        }
        public void fild(usertbl usertbl)
        {
            txtname.Text = usertbl.FirstName;
            txtlastname.Text = usertbl.LastName;
            txtcode.Text = usertbl.Code.ToString() ;
            txtphone.Text = usertbl.PhoneNumber.ToString();
            txtaddres.Text = usertbl.Address;

        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
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

        private void textBox5_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            user_main page2 = new user_main(mycallingpage);
            mycallingpage.frame.Navigate(page2);
        }

      
        private void btnsabt_Click(object sender, RoutedEventArgs e)
        {
            try {
                if (usertb.Id == 0)
                {

                    usertb.FirstName = txtname.Text;
                    usertb.LastName = txtlastname.Text;
                    usertb.Code = Convert.ToInt64(txtcode.Text);
                    usertb.PhoneNumber = Convert.ToInt64(txtphone.Text);
                    usertb.Address = txtaddres.Text;
                    usertb.Pic = BitmapSourceToByteArray((BitmapSource)Image.Source);
                    biscotir_DbEntities1.usertbls.Add(usertb);
                    biscotir_DbEntities1.SaveChanges();
                    MessageBox.Show("کاربر جدید با موفیقت ثبت شد");
                }
                else {
                    var user = biscotir_DbEntities1.usertbls.First(a => a.Id == usertb.Id);
                    user.FirstName = txtname.Text;
                    user.LastName = txtlastname.Text;
                    user.Code = Convert.ToInt64(txtcode.Text);
                    user.PhoneNumber = Convert.ToInt64(txtphone.Text);
                    user.Address = txtaddres.Text;
                    user.Pic= BitmapSourceToByteArray((BitmapSource)Image.Source);
                    biscotir_DbEntities1.SaveChanges();
                    MessageBox.Show("ویرایش کاربر با موفیقت انجام شد");
                }
            }
            catch { }
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
        private BitmapImage byteArrayToImage(byte[] byteArrayIn)
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
            if(usertb.Pic !=null)
            Image.Source = byteArrayToImage(usertb.Pic);
        }
    }
}
