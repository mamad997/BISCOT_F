using GMap.NET;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;
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
using System.Collections.ObjectModel;
using System.Windows.Threading;
using Demo.WindowsPresentation.CustomMarkers;
using Demo.WindowsForms;
using GMap.NET.MapProviders;
using System.Globalization;
using BISCOT_F.CustomMarkers;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;

namespace BISCOT_F
{
    /// <summary>
    /// Interaction logic for RequestP.xaml
    /// </summary>
    public partial class RequestP : Page
    {
        PointLatLng start;
        PointLatLng end;

        // marker
        GMapMarker currentMarker;

        // zones list
        List<GMapMarker> Circles = new List<GMapMarker>();
        DispatcherTimer timer = new DispatcherTimer();
        public List<usertbl> usertbls = new List<usertbl>();
        public List<Drivertbl> drivertbls = new List<Drivertbl>();
        public List<Cartbl> cartbls = new List<Cartbl>();
        public List<Triptbl> triptbls = new List<Triptbl>();
        public biscotir_dbEntities1 biscotir_DbEntities1 = new biscotir_dbEntities1();
        public Drivertbl drivertbl = new Drivertbl();
        public Triptbl Triptbl = new Triptbl();
        public usertbl usertbl = new usertbl();
        public Cartbl cartbl = new Cartbl();
        public System.Windows.Forms.Timer timer12;
        public ObservableCollection<object> itemsCollection = new ObservableCollection<object>();
        public int shomare = 0;
        public int index = 0;
        Triptbl temp = new Triptbl();
        public RequestP()
        {
            InitializeComponent();
            if (!Stuff.PingNetwork("pingtest.com"))
            {
                MainMap.Manager.Mode = AccessMode.CacheOnly;
                System.Windows.MessageBox.Show("No internet connection available, going to CacheOnly mode.", "GMap.NET - Demo.WindowsPresentation", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            // config map
            MainMap.MapProvider = GMapProviders.GoogleHybridMap;
            MainMap.Position = new PointLatLng(30.493291, 56.821461);
            MainMap.Zoom = 15;
            MainMap.ScaleMode = ScaleModes.Dynamic;


            // map events
            MainMap.OnPositionChanged += new PositionChanged(MainMap_OnCurrentPositionChanged);
            MainMap.OnTileLoadComplete += new TileLoadComplete(MainMap_OnTileLoadComplete);
            MainMap.OnTileLoadStart += new TileLoadStart(MainMap_OnTileLoadStart);
            MainMap.OnMapTypeChanged += new MapTypeChanged(MainMap_OnMapTypeChanged);
            MainMap.MouseMove += new System.Windows.Input.MouseEventHandler(MainMap_MouseMove);
            MainMap.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(MainMap_MouseLeftButtonDown);
            MainMap.MouseEnter += new System.Windows.Input.MouseEventHandler(MainMap_MouseEnter);

            // get map types
            //.ItemsSource = GMapProviders.List;
            // comboBoxMapType.DisplayMemberPath = "Name";
            comboBoxMapType.SelectedItem = MainMap.MapProvider;

            // acccess mode
            comboBoxMode.ItemsSource = Enum.GetValues(typeof(AccessMode));
            comboBoxMode.SelectedItem = MainMap.Manager.Mode;

            // get cache modes
            /*.IsChecked = MainMap.Manager.UseRouteCache;
            checkBoxGeoCache.IsChecked = MainMap.Manager.UseGeocoderCache;*/

            // setup zoom min/max
            sliderZoom.Maximum = MainMap.MaxZoom;
            sliderZoom.Minimum = MainMap.MinZoom;

            // get position
            textBoxLat.Text = MainMap.Position.Lat.ToString(CultureInfo.InvariantCulture);
            textBoxLng.Text = MainMap.Position.Lng.ToString(CultureInfo.InvariantCulture);

            // get marker state
            /* checkBoxCurrentMarker.IsChecked = true;*/

            // can drag map
            // checkBoxDragMap.IsChecked = MainMap.CanDragMap;

#if DEBUG
            /*  checkBoxDebug.IsChecked = true;*/

#endif

            //validator.Window = this;

            // set current marker
            currentMarker = new GMapMarker(MainMap.Position);
            {
                currentMarker.Shape = new CustomMarkerRed(this, currentMarker, "custom position marker");
                currentMarker.Offset = new System.Windows.Point(-15, -15);
                currentMarker.ZIndex = int.MaxValue;
                MainMap.Markers.Add(currentMarker);
            }

            //if(false)
            {
                // add my city location for demo
                GeoCoderStatusCode status = GeoCoderStatusCode.Unknow;

                PointLatLng? city = GMapProviders.GoogleMap.GetPoint("Lithuania, Vilnius", out status);
                if (city != null && status == GeoCoderStatusCode.G_GEO_SUCCESS)
                {
                    GMapMarker it = new GMapMarker(city.Value);
                    {
                        it.ZIndex = 55;
                        it.Shape = new CustomMarkerDemo(this, it, "Welcome to Lithuania! ;}");
                    }
                    MainMap.Markers.Add(it);

                    #region -- add some markers and zone around them --
                    //if(false)
                    {
                        List<PointAndInfo> objects = new List<PointAndInfo>();
                        {
                            string area = "Antakalnis";
                            PointLatLng? pos = GMapProviders.GoogleMap.GetPoint("Lithuania, Vilnius, " + area, out status);
                            if (pos != null && status == GeoCoderStatusCode.G_GEO_SUCCESS)
                            {
                                objects.Add(new PointAndInfo(pos.Value, area));
                            }
                        }
                        {
                            string area = "Senamiestis";
                            PointLatLng? pos = GMapProviders.GoogleMap.GetPoint("Lithuania, Vilnius, " + area, out status);
                            if (pos != null && status == GeoCoderStatusCode.G_GEO_SUCCESS)
                            {
                                objects.Add(new PointAndInfo(pos.Value, area));
                            }
                        }
                        {
                            string area = "Pilaite";
                            PointLatLng? pos = GMapProviders.GoogleMap.GetPoint("Lithuania, Vilnius, " + area, out status);
                            if (pos != null && status == GeoCoderStatusCode.G_GEO_SUCCESS)
                            {
                                objects.Add(new PointAndInfo(pos.Value, area));
                            }
                        }
                        AddDemoZone(8.8, city.Value, objects);
                    }
                    #endregion
                }

                if (MainMap.Markers.Count > 1)
                {
                    MainMap.ZoomAndCenterMarkers(null);
                }
            }

            // perfromance test
            timer.Interval = TimeSpan.FromMilliseconds(44);
            timer.Tick += new EventHandler(timer_Tick);

            // transport demo
            transport.DoWork += new DoWorkEventHandler(transport_DoWork);
            transport.ProgressChanged += new ProgressChangedEventHandler(transport_ProgressChanged);
            transport.WorkerSupportsCancellation = true;
            transport.WorkerReportsProgress = true;
        }
        public void test_trips(Triptbl temp2)
        {
            MainMap.Markers.Clear();
            string p = temp2.StartLoc;
            string[] pp = p.Split(new Char[] {  ',' });
            var pos = new PointLatLng(Convert.ToDouble(pp[0]), Convert.ToDouble(pp[1]));
            GMapMarker m = new GMapMarker(pos);
            {

                // Placemark? p = null;
                // if(checkBoxPlace.IsChecked.Value)
                // if (true)
                // {
                //  GeoCoderStatusCode status;
                // var plret = GMapProviders.GoogleMap.GetPlacemark(currentMarker.Position, out status);
                // if (status == GeoCoderStatusCode.G_GEO_SUCCESS && plret != null)
                // {
                //    p = plret;
                // }
                // }

                string ToolTipText;
                // if (p != null)
                //{
                // ToolTipText = p.Value.Address;
                // }
                //  else
                //  {
                ToolTipText = p;
                //  }


                m.Shape = new CustomMarkerDemo(this, m, temp2.StartLocName);
                m.ZIndex = 55;
            }
            
            MainMap.Markers.Add(m);
            test_tripe(temp2);
        }
        public void test_tripe(Triptbl temp2)
        {
            string p = temp2.EndLoc;
            string[] pp = p.Split(new Char[] {  ',' });
            var pos = new PointLatLng(Convert.ToDouble(pp[0]), Convert.ToDouble(pp[1]));
            GMapMarker m = new GMapMarker(pos);
            {

                // Placemark? p = null;
                // if(checkBoxPlace.IsChecked.Value)
                // if (true)
                // {
                //  GeoCoderStatusCode status;
                // var plret = GMapProviders.GoogleMap.GetPlacemark(currentMarker.Position, out status);
                // if (status == GeoCoderStatusCode.G_GEO_SUCCESS && plret != null)
                // {
                //    p = plret;
                // }
                // }

                string ToolTipText;
                // if (p != null)
                //{
                // ToolTipText = p.Value.Address;
                // }
                //  else
                //  {
                ToolTipText = p;
                //  }


                m.Shape = new CustomMarkerDemo(this, m, temp2.EndLocName);
                m.ZIndex = 55;
            }
            MainMap.Markers.Add(m);
        }
        void MainMap_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            MainMap.Focus();
        }

        #region -- performance test--
        public RenderTargetBitmap ToImageSource(FrameworkElement obj)
        {
            // Save current canvas transform
            Transform transform = obj.LayoutTransform;
            obj.LayoutTransform = null;

            // fix margin offset as well
            Thickness margin = obj.Margin;
            obj.Margin = new Thickness(0, 0, margin.Right - margin.Left, margin.Bottom - margin.Top);

            // Get the size of canvas
            System.Windows.Size size = new System.Windows.Size(obj.Width, obj.Height);

            // force control to Update
            obj.Measure(size);
            obj.Arrange(new Rect(size));

            RenderTargetBitmap bmp = new RenderTargetBitmap((int)size.Width, (int)size.Height, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(obj);

            if (bmp.CanFreeze)
            {
                bmp.Freeze();
            }

            // return values as they were before
            obj.LayoutTransform = transform;
            obj.Margin = margin;

            return bmp;
        }

        double NextDouble(Random rng, double min, double max)
        {
            return min + (rng.NextDouble() * (max - min));
        }

        Random r = new Random();

        int tt = 0;
        void timer_Tick(object sender, EventArgs e)
        {
            var pos = new PointLatLng(NextDouble(r, MainMap.ViewArea.Top, MainMap.ViewArea.Bottom), NextDouble(r, MainMap.ViewArea.Left, MainMap.ViewArea.Right));
            GMapMarker m = new GMapMarker(pos);
            {
                var s = new Test((tt++).ToString());

                var image = new System.Windows.Controls.Image();
                {
                    RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.LowQuality);
                    image.Stretch = Stretch.None;
                    image.Opacity = s.Opacity;

                    image.MouseEnter += new System.Windows.Input.MouseEventHandler(image_MouseEnter);
                    image.MouseLeave += new System.Windows.Input.MouseEventHandler(image_MouseLeave);

                    image.Source = ToImageSource(s);
                }

                m.Shape = image;

                m.Offset = new System.Windows.Point(-s.Width, -s.Height);
            }
            MainMap.Markers.Add(m);

            if (tt >= 333)
            {
                timer.Stop();
                tt = 0;
            }
        }

        void image_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            System.Windows.Controls.Image img = sender as System.Windows.Controls.Image;
            img.RenderTransform = null;
        }

        void image_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            System.Windows.Controls.Image img = sender as System.Windows.Controls.Image;
            img.RenderTransform = new ScaleTransform(1.2, 1.2, 12.5, 12.5);
        }

       // DispatcherTimer timer = new DispatcherTimer();
        #endregion

        #region -- transport demo --
        BackgroundWorker transport = new BackgroundWorker();

        readonly List<VehicleData> trolleybus = new List<VehicleData>();
        readonly Dictionary<int, GMapMarker> trolleybusMarkers = new Dictionary<int, GMapMarker>();

        readonly List<VehicleData> bus = new List<VehicleData>();
        readonly Dictionary<int, GMapMarker> busMarkers = new Dictionary<int, GMapMarker>();

        bool firstLoadTrasport = true;

        void transport_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            using (Dispatcher.DisableProcessing())
            {
                lock (trolleybus)
                {
                    foreach (VehicleData d in trolleybus)
                    {
                        GMapMarker marker;

                        if (!trolleybusMarkers.TryGetValue(d.Id, out marker))
                        {
                            marker = new GMapMarker(new PointLatLng(d.Lat, d.Lng));
                            marker.Tag = d.Id;
                            marker.Shape = new CircleVisual(marker, System.Windows.Media.Brushes.Red);

                            trolleybusMarkers[d.Id] = marker;
                            MainMap.Markers.Add(marker);
                        }
                        else
                        {
                            marker.Position = new PointLatLng(d.Lat, d.Lng);
                            var shape = (marker.Shape as CircleVisual);
                            {
                                shape.Text = d.Line;
                                shape.Angle = d.Bearing;
                                shape.Tooltip.SetValues("TrolleyBus", d);

                                if (shape.IsChanged)
                                {
                                    shape.UpdateVisual(false);
                                }
                            }
                        }
                    }
                }

                lock (bus)
                {
                    foreach (VehicleData d in bus)
                    {
                        GMapMarker marker;

                        if (!busMarkers.TryGetValue(d.Id, out marker))
                        {
                            marker = new GMapMarker(new PointLatLng(d.Lat, d.Lng));
                            marker.Tag = d.Id;

                            var v = new CircleVisual(marker, System.Windows.Media.Brushes.Blue);
                            {
                                v.Stroke = new System.Windows.Media.Pen(System.Windows.Media.Brushes.Gray, 2.0);
                            }
                            marker.Shape = v;

                            busMarkers[d.Id] = marker;
                            MainMap.Markers.Add(marker);
                        }
                        else
                        {
                            marker.Position = new PointLatLng(d.Lat, d.Lng);
                            var shape = (marker.Shape as CircleVisual);
                            {
                                shape.Text = d.Line;
                                shape.Angle = d.Bearing;
                                shape.Tooltip.SetValues("Bus", d);

                                if (shape.IsChanged)
                                {
                                    shape.UpdateVisual(false);
                                }
                            }
                        }
                    }
                }

                if (firstLoadTrasport)
                {
                    firstLoadTrasport = false;
                }
            }
        }

        void transport_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!transport.CancellationPending)
            {
                try
                {
                    lock (trolleybus)
                    {
                        Stuff.GetVilniusTransportData(Demo.WindowsForms.TransportType.TrolleyBus, string.Empty, trolleybus);
                    }

                    lock (bus)
                    {
                        Stuff.GetVilniusTransportData(Demo.WindowsForms.TransportType.Bus, string.Empty, bus);
                    }

                    transport.ReportProgress(100);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("transport_DoWork: " + ex.ToString());
                }
                Thread.Sleep(3333);
            }
            trolleybusMarkers.Clear();
            busMarkers.Clear();
        }

        #endregion

        // add objects and zone around them
        void AddDemoZone(double areaRadius, PointLatLng center, List<PointAndInfo> objects)
        {
            var objectsInArea = from p in objects
                                where MainMap.MapProvider.Projection.GetDistance(center, p.Point) <= areaRadius
                                select new
                                {
                                    Obj = p,
                                    Dist = MainMap.MapProvider.Projection.GetDistance(center, p.Point)
                                };
            if (objectsInArea.Any())
            {
                var maxDistObject = (from p in objectsInArea
                                     orderby p.Dist descending
                                     select p).First();

                // add objects to zone
                foreach (var o in objectsInArea)
                {
                    GMapMarker it = new GMapMarker(o.Obj.Point);
                    {
                        it.ZIndex = 55;
                        var s = new CustomMarkerDemo(this, it, o.Obj.Info + ", distance from center: " + o.Dist + "km.");
                        it.Shape = s;
                    }

                    MainMap.Markers.Add(it);
                }

                // add zone circle
                //if(false)
                {
                    GMapMarker it = new GMapMarker(center);
                    it.ZIndex = -1;

                    Circle c = new Circle();
                    c.Center = center;
                    c.Bound = maxDistObject.Obj.Point;
                    c.Tag = it;
                    c.IsHitTestVisible = false;

                    UpdateCircle(c);
                    Circles.Add(it);

                    it.Shape = c;
                    MainMap.Markers.Add(it);
                }
            }
        }

        // calculates circle radius
        void UpdateCircle(Circle c)
        {
            var pxCenter = MainMap.FromLatLngToLocal(c.Center);
            var pxBounds = MainMap.FromLatLngToLocal(c.Bound);

            double a = (double)(pxBounds.X - pxCenter.X);
            double b = (double)(pxBounds.Y - pxCenter.Y);
            var pxCircleRadius = Math.Sqrt(a * a + b * b);

            c.Width = 55 + pxCircleRadius * 2;
            c.Height = 55 + pxCircleRadius * 2;
            (c.Tag as GMapMarker).Offset = new System.Windows.Point(-c.Width / 2, -c.Height / 2);
        }

        void MainMap_OnMapTypeChanged(GMapProvider type)
        {
            sliderZoom.Minimum = MainMap.MinZoom;
            sliderZoom.Maximum = MainMap.MaxZoom;
        }

        void MainMap_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            System.Windows.Point p = e.GetPosition(MainMap);
            currentMarker.Position = MainMap.FromLocalToLatLng((int)p.X, (int)p.Y);
        }

        // move current marker with left holding
        void MainMap_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                System.Windows.Point p = e.GetPosition(MainMap);
                currentMarker.Position = MainMap.FromLocalToLatLng((int)p.X, (int)p.Y);
            }
        }

        // zoo max & center markers
        private void button13_Click(object sender, RoutedEventArgs e)
        {
            /* MainMap.ZoomAndCenterMarkers(null);*/

            /*
            PointAnimation panMap = new PointAnimation();
            panMap.Duration = TimeSpan.FromSeconds(1);
            panMap.From = new Point(MainMap.Position.Lat, MainMap.Position.Lng);
            panMap.To = new Point(0, 0);
            Storyboard.SetTarget(panMap, MainMap);
            Storyboard.SetTargetProperty(panMap, new PropertyPath(GMapControl.MapPointProperty));

            Storyboard panMapStoryBoard = new Storyboard();
            panMapStoryBoard.Children.Add(panMap);
            panMapStoryBoard.Begin(this);
             */
        }

        // tile louading starts
        void MainMap_OnTileLoadStart()
        {
            System.Windows.Forms.MethodInvoker m = delegate ()
            {
                progressBar1.Visibility = Visibility.Visible;
            };

            try
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Loaded, m);
            }
            catch
            {
            }
        }

        // tile loading stops
        void MainMap_OnTileLoadComplete(long ElapsedMilliseconds)
        {
            MainMap.ElapsedMilliseconds = ElapsedMilliseconds;

            System.Windows.Forms.MethodInvoker m = delegate ()
            {
                progressBar1.Visibility = Visibility.Hidden;
                groupBox3.Header = "loading, last in " + MainMap.ElapsedMilliseconds + "ms";
            };

            try
            {
                this.Dispatcher.BeginInvoke(DispatcherPriority.Loaded, m);
            }
            catch
            {
            }
        }

        // current location changed
        void MainMap_OnCurrentPositionChanged(PointLatLng point)
        {
            mapgroup.Header = "gmap: " + point;
        }

        // reload
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MainMap.ReloadMap();
        }

        // enable current marker
        private void checkBoxCurrentMarker_Checked(object sender, RoutedEventArgs e)
        {
            if (currentMarker != null)
            {
                MainMap.Markers.Add(currentMarker);
            }
        }

        // disable current marker
        private void checkBoxCurrentMarker_Unchecked(object sender, RoutedEventArgs e)
        {
            if (currentMarker != null)
            {
                MainMap.Markers.Remove(currentMarker);
            }
        }

        // enable map dragging
        /*private void checkBoxDragMap_Checked(object sender, RoutedEventArgs e)
        {
           MainMap.CanDragMap = true;
        }

         disable map dragging
        private void checkBoxDragMap_Unchecked(object sender, RoutedEventArgs e)
        {
           MainMap.CanDragMap = false;
        }*/

        // goto!
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double lat = double.Parse(textBoxLat.Text, CultureInfo.InvariantCulture);
                double lng = double.Parse(textBoxLng.Text, CultureInfo.InvariantCulture);

                MainMap.Position = new PointLatLng(lat, lng);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("incorrect coordinate format: " + ex.Message);
            }
        }

        // goto by geocoder
        /* private void textBoxGeo_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
         {
            if(e.Key == System.Windows.Input.Key.Enter)
            {
               GeoCoderStatusCode status = MainMap.SetPositionByKeywords(textBoxGeo.Text);
               if(status != GeoCoderStatusCode.G_GEO_SUCCESS)
               {
                  MessageBox.Show("Geocoder can't find: '" + textBoxGeo.Text + "', reason: " + status.ToString(), "GMap.NET", MessageBoxButton.OK, MessageBoxImage.Exclamation);
               }
               else
               {
                  currentMarker.Position = MainMap.Position;
               }
            }
         }*/

        // zoom changed
        private void sliderZoom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // updates circles on map
            foreach (var c in Circles)
            {
                UpdateCircle(c.Shape as Circle);
            }
        }

        // zoom up
        private void czuZoomUp_Click(object sender, RoutedEventArgs e)
        {
            MainMap.Zoom = ((int)MainMap.Zoom) + 1;
        }

        // zoom down
        private void czuZoomDown_Click(object sender, RoutedEventArgs e)
        {
            MainMap.Zoom = ((int)(MainMap.Zoom + 0.99)) - 1;
        }

        // prefetch
        /*private void button3_Click(object sender, RoutedEventArgs e)
        {
           RectLatLng area = MainMap.SelectedArea;
           if(!area.IsEmpty)
           {
              for(int i = (int)MainMap.Zoom; i <= MainMap.MaxZoom; i++)
              {
                 MessageBoxResult res = MessageBox.Show("Ready ripp at Zoom = " + i + " ?", "GMap.NET", MessageBoxButton.YesNoCancel);

                 if(res == MessageBoxResult.Yes)
                 {
                    TilePrefetcher obj = new TilePrefetcher();
                    obj.Owner = this;
                    obj.ShowCompleteMessage = true;
                    obj.Start(area, i, MainMap.MapProvider, 100);
                 }
                 else if(res == MessageBoxResult.No)
                 {
                    continue;
                 }
                 else if(res == MessageBoxResult.Cancel)
                 {
                    break;
                 }
              }
           }
           else
           {
              MessageBox.Show("Select map area holding ALT", "GMap.NET", MessageBoxButton.OK, MessageBoxImage.Exclamation);
           }
        }*/

        // access mode
        private void comboBoxMode_DropDownClosed(object sender, EventArgs e)
        {
            MainMap.Manager.Mode = (AccessMode)comboBoxMode.SelectedItem;
            MainMap.ReloadMap();
        }

        // clear cache
        /*private void button4_Click(object sender, RoutedEventArgs e)
        {
           if(MessageBox.Show("Are You sure?", "Clear GMap.NET cache?", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
           {
              try
              {
                 MainMap.Manager.PrimaryCache.DeleteOlderThan(DateTime.Now, null);
                 MessageBox.Show("Done. Cache is clear.");
              }
              catch(Exception ex)
              {
                 MessageBox.Show(ex.Message);
              }
           }
        }*/

        // export
        /* private void button6_Click(object sender, RoutedEventArgs e)
         {
            MainMap.ShowExportDialog();
         }*/

        // import
        /* private void button5_Click(object sender, RoutedEventArgs e)
         {
            MainMap.ShowImportDialog();
         }*/

        // use route cache
        /* private void checkBoxCacheRoute_Checked(object sender, RoutedEventArgs e)
         {
            MainMap.Manager.UseRouteCache = checkBoxCacheRoute.IsChecked.Value;
         }*/

        // use geocoding cahce
        /* void checkBoxGeoCache_Checked(object sender, RoutedEventArgs e)
        {
           MainMap.Manager.UseGeocoderCache = checkBoxGeoCache.IsChecked.Value;
           MainMap.Manager.UsePlacemarkCache = MainMap.Manager.UseGeocoderCache;
        }*/

        // save currnt view
        private void button7_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ImageSource img = MainMap.ToImageSource();
                PngBitmapEncoder en = new PngBitmapEncoder();
                en.Frames.Add(BitmapFrame.Create(img as BitmapSource));

                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "GMap.NET Image"; // Default file name
                dlg.DefaultExt = ".png"; // Default file extension
                dlg.Filter = "Image (.png)|*.png"; // Filter files by extension
                dlg.AddExtension = true;
                dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                // Show save file dialog box
                bool? result = dlg.ShowDialog();

                // Process save file dialog box results
                if (result == true)
                {
                    // Save document
                    string filename = dlg.FileName;

                    using (System.IO.Stream st = System.IO.File.OpenWrite(filename))
                    {
                        en.Save(st);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        // clear all markers
        private void button10_Click(object sender, RoutedEventArgs e)
        {
            var clear = MainMap.Markers.Where(p => p != null && p != currentMarker);
            if (clear != null)
            {
                for (int i = 0; i < clear.Count(); i++)
                {
                    MainMap.Markers.Remove(clear.ElementAt(i));
                    i--;
                }
            }

            /* if(radioButtonPerformance.IsChecked == true)
             {
                tt = 0;
                if(!timer.IsEnabled)
                {
                   timer.Start();
                }
             */
        }

        // add marker
        private void button8_Click(object sender, RoutedEventArgs e)
        {
            GMapMarker m = new GMapMarker(currentMarker.Position);
            {
                Placemark? p = null;
                // if(checkBoxPlace.IsChecked.Value)
                if (true)
                {
                    GeoCoderStatusCode status;
                    var plret = GMapProviders.GoogleMap.GetPlacemark(currentMarker.Position, out status);
                    if (status == GeoCoderStatusCode.G_GEO_SUCCESS && plret != null)
                    {
                        p = plret;
                    }
                }

                string ToolTipText;
                if (p != null)
                {
                    ToolTipText = p.Value.Address;
                }
                else
                {
                    ToolTipText = currentMarker.Position.ToString();
                }

                m.Shape = new CustomMarkerDemo(this, m, ToolTipText);
                m.ZIndex = 55;
            }
            MainMap.Markers.Add(m);
        }

        // sets route start
        /* private void button11_Click(object sender, RoutedEventArgs e)
         {
            start = currentMarker.Position;
         }*/

        // sets route end
        /* private void button9_Click(object sender, RoutedEventArgs e)
         {
            end = currentMarker.Position;
         }*/

        // adds route
        /*private void button12_Click(object sender, RoutedEventArgs e)
        {
           RoutingProvider rp = MainMap.MapProvider as RoutingProvider;
           if(rp == null)
           {
              rp = GMapProviders.OpenStreetMap; // use OpenStreetMap if provider does not implement routing
           }

           MapRoute route = rp.GetRoute(start, end, false, false, (int)MainMap.Zoom);
           if(route != null)
           {
              GMapMarker m1 = new GMapMarker(start);
              m1.Shape = new CustomMarkerDemo(this, m1, "Start: " + route.Name);

              GMapMarker m2 = new GMapMarker(end);
              m2.Shape = new CustomMarkerDemo(this, m2, "End: " + start.ToString());

              GMapRoute mRoute = new GMapRoute(route.Points);
              {
                 mRoute.ZIndex = -1;
              }

              MainMap.Markers.Add(m1);
              MainMap.Markers.Add(m2);
              MainMap.Markers.Add(mRoute);

              MainMap.ZoomAndCenterMarkers(null);
           }
        }*/

        // enables tile grid view
        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            MainMap.ShowTileGridLines = true;
        }

        // disables tile grid view
        private void checkBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            MainMap.ShowTileGridLines = false;
        }

        private void Window_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            int offset = 22;

            if (MainMap.IsFocused)
            {
                if (e.Key == Key.Left)
                {
                    MainMap.Offset(-offset, 0);
                }
                else if (e.Key == Key.Right)
                {
                    MainMap.Offset(offset, 0);
                }
                else if (e.Key == Key.Up)
                {
                    MainMap.Offset(0, -offset);
                }
                else if (e.Key == Key.Down)
                {
                    MainMap.Offset(0, offset);
                }
                else if (e.Key == Key.Add)
                {
                    czuZoomUp_Click(null, null);
                }
                else if (e.Key == Key.Subtract)
                {
                    czuZoomDown_Click(null, null);
                }
            }
        }

        // set real time demo
        private void realTimeChanged(object sender, RoutedEventArgs e)
        {
            MainMap.Markers.Clear();

            // start performance test
            /* if(radioButtonPerformance.IsChecked == true)
             {
                timer.Start();
             }
             else
             {
                // stop performance test
                timer.Stop();
             }

             // start realtime transport tracking demo
             if(radioButtonTransport.IsChecked == true)
             {
                if(!transport.IsBusy)
                {
                   firstLoadTrasport = true;
                   transport.RunWorkerAsync();
                }
             }
             else
             {
                if(transport.IsBusy)
                {
                   transport.CancelAsync();
                }
             }*/
        }

       
        public void InitTimer()
        {
            timer12 = new System.Windows.Forms.Timer();
            timer12.Tick += new EventHandler(timer12_Tick);
            timer12.Interval = 15000; // in miliseconds
            timer12.Start();
        }

        private void timer12_Tick(object sender, EventArgs e)
        {
            star();
        }
        public void star()
        {
            //biscotir_DbEntities1 = new biscotir_dbEntities1();
            triptbls = biscotir_DbEntities1.Triptbls.ToList();
            drivertbls = biscotir_DbEntities1.Drivertbls.ToList();
            usertbls = biscotir_DbEntities1.usertbls.ToList();
            cartbls = biscotir_DbEntities1.Cartbls.ToList();
            ListView_Requset.ItemsSource = null;
            ListView_Requset.ItemsSource = triptbls;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListView_Requset.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("Id", ListSortDirection.Descending));
        
        ListView1_SelectionChanged(null, null);
        }



        //descriptor.AddValueChanged(ListView_Requset, new EventHandler(OnHeightOfUiElementChanged));
        public void CreatePermission()
        {
            // Make sure client has permissions 
            try
            {
                SqlClientPermission perm = new SqlClientPermission(System.Security.Permissions.PermissionState.Unrestricted);
                perm.Demand();
            }
            catch
            {
                throw new ApplicationException("No permission");
            }
        }

        

        private void test_fild(biscotDATAaccess.Triptbl temp2)
        {
            shomare = temp2.Id;
            foreach (usertbl usertbl in usertbls)
            {
                if (temp2.UserId == usertbl.Id)
                {
                    txt_name.Text = temp2.usertbl.FullName;
                    txt_phonenum.Text = usertbl.PhoneNumber.ToString();
                    txt_start.Text = temp2.StartLocName;
                    txt_end.Text = temp2.EndLocName;
                    txttozihat.Text = temp2.Tozihat;
                    txt_date.Text = temp2.Date.ToString();
                    if (usertbl.Pic != null)
                        image1.Source = byteArrayToImage(usertbl.Pic);

                }

            }

            if (temp2.Status == 0)
            {
                comboBoxd.IsEnabled = false;
                Btnsabtesafar.IsEnabled = false;
                success.Visibility = Visibility.Visible;
                doing.Visibility = Visibility.Collapsed;
                Fail.Visibility = Visibility.Collapsed;
                success1.Visibility = Visibility.Visible;
                doing1.Visibility = Visibility.Collapsed;
                Fail1.Visibility = Visibility.Collapsed;

                BrushConverter bc = new BrushConverter();
                System.Windows.Media.Brush brush = (System.Windows.Media.Brush)bc.ConvertFrom("#FF99D834");
                brush.Freeze();
                groupBox4.Background = brush;

            }
            else if (temp2.Status == 1)
            {
                comboBoxd.IsEnabled = true;
                Btnsabtesafar.IsEnabled = true;

                doing.Visibility = Visibility.Visible;
                success.Visibility = Visibility.Collapsed;
                Fail.Visibility = Visibility.Collapsed;
                doing1.Visibility = Visibility.Visible;
                success1.Visibility = Visibility.Collapsed;
                Fail1.Visibility = Visibility.Collapsed;

                BrushConverter bc = new BrushConverter();
                System.Windows.Media.Brush brush = (System.Windows.Media.Brush)bc.ConvertFrom("#FFFFB74D");
                brush.Freeze();
                groupBox4.Background = brush;
            }
            else if (temp2.Status == 3)
            {
                comboBoxd.IsEnabled = false;
                Btnsabtesafar.IsEnabled = false;
                doing.Visibility = Visibility.Visible;
                success.Visibility = Visibility.Collapsed;
                Fail.Visibility = Visibility.Collapsed;
                doing1.Visibility = Visibility.Visible;
                success1.Visibility = Visibility.Collapsed;
                Fail1.Visibility = Visibility.Collapsed;

                BrushConverter bc = new BrushConverter();
                System.Windows.Media.Brush brush = (System.Windows.Media.Brush)bc.ConvertFrom("#FF00C3FF");
                brush.Freeze();
                groupBox4.Background = brush;
            }
            else
            {
                comboBoxd.IsEnabled = false;
                Btnsabtesafar.IsEnabled = false;
                doing.Visibility = Visibility.Collapsed;
                success.Visibility = Visibility.Collapsed;
                Fail.Visibility = Visibility.Visible;
                doing1.Visibility = Visibility.Collapsed;
                success1.Visibility = Visibility.Collapsed;
                Fail1.Visibility = Visibility.Visible;

                BrushConverter bc = new BrushConverter();
                System.Windows.Media.Brush brush = (System.Windows.Media.Brush)bc.ConvertFrom("#FFFF0000");
                brush.Freeze();
                groupBox4.Background = brush;
            }


        }
        private void test_fildDriver(Drivertbl dri)
        {

            //comboBoxd.ItemsSource = dri.FirstName;
            txt_drivername.Text = dri.FirstName + " " + dri.LastName;
            txt_driverphone.Text = dri.PhoneNumber.ToString();
            foreach (Cartbl cartbl in cartbls)
            {
                if (cartbl.Id == dri.CarId)
                {
                    txt_car.Text = cartbl.ModelKhodro;
                    txt_pelak.Text = cartbl.Pelak.ToString();
                    break;
                }
                else
                {
                    txt_car.Text = "";
                    txt_pelak.Text = "";
                }

            }


        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ListView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //ListView_Requset.SelectedIndex =1;

            // comboBoxd.SelectedIndex = -1;
            //   index = ListView_Requset.SelectedIndex;
            Drivertbl dri = new Drivertbl();
            Cartbl car = new Cartbl();
            try
            {
                temp = (biscotDATAaccess.Triptbl)ListView_Requset.SelectedItems[0];
                // MainMap.Markers.Clear();
                // test_trips(temp);
                //  test_tripe(temp);
                test_fild(temp);
                test_trips(temp);
                foreach (Drivertbl d in drivertbls)
                    if (d.Id == temp.DriverId)
                    {
                        test_fildDriver(d);
                        break;
                    }
                    else
                    {
                        Drivertbl dt = new Drivertbl();
                        test_fildDriver(dt);

                    }


            }
            catch
            {
            }
        }





        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string ss = "";
            if (comboBoxd.SelectedItem != null)
                ss = comboBoxd.SelectedItem.ToString();
            foreach (Drivertbl dri in drivertbls)
            {
                if (dri.FullName == ss)
                    test_fildDriver(dri);
            }
            //  test_fildDriver(d);

        }

       

        //private void ListView_Requset_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        //{

        //    try
        //    {
        //        biscotDATAaccess.Triptbl temp = (biscotDATAaccess.Triptbl)ListView_Requset.SelectedItems[0];
        //        // MainMap.Markers.Clear();
        //        // test_trips(temp);
        //        //  test_tripe(temp);
        //        test_fild(temp);
        //    }
        //    catch
        //    {
        //    }

        //}

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            star();
            InitTimer();
            //var dpd = DependencyPropertyDescriptor.FromProperty(ItemsControl.ItemsSourceProperty, typeof(ListView));

            //if (dpd != null)
            //{
            //    dpd.AddValueChanged(ListView_Requset, ThisIsCalledWhenPropertyIsChanged);

            //}
        }
        private void ThisIsCalledWhenPropertyIsChanged(object sender, EventArgs e)
        {

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
        private void ComboBoxd_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> ts = new List<string>();
            foreach (Drivertbl dri in drivertbls)
                ts.Add(dri.FullName);
            comboBoxd.ItemsSource = ts;
            comboBoxd.SelectedItem = 0;
        }

        private void Btnsabtesafar_Click(object sender, RoutedEventArgs e)
        {
            int driverid = 0;
            if (comboBoxd.Text != "")
            {
                foreach (Drivertbl df in drivertbls)
                    if (df.FullName == comboBoxd.Text)
                    {
                        driverid = df.Id;
                    }

                ListView_Requset.SelectedIndex = index;
                //   biscotDATAaccess.Triptbl temp = (biscotDATAaccess.Triptbl)ListView_Requset.SelectedItems[0];
                var tr = biscotir_DbEntities1.Triptbls.First(a => a.Id == temp.Id);
                tr.Status = 3;
                tr.DriverId = driverid;
                biscotir_DbEntities1.SaveChanges();
                star();
                test_fild(tr);
                test_trips(tr);
                comboBox_SelectionChanged(null, null);
                comboBoxd.SelectedIndex = -1;
            }
        }

      

        private void comboBoxMapType_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            MainMap.MapProvider = GMapProviders.GoogleHybridMap;
            if (comboBoxMapType.SelectedIndex == 1)
            {
                MainMap.MapProvider = GMapProviders.GoogleMap;
            }
        }
    }

}
public struct PointAndInfo
{
    public PointLatLng Point;
    public string Info;

    public PointAndInfo(PointLatLng point, string info)
    {
        Point = point;
        Info = info;
    }
}



