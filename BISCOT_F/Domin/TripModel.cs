using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.Data;
using System.Windows.Input;
using System.Data.SqlClient;
using biscotDATAaccess;

namespace BISCOT_F
{
    class TripModel : INotifyPropertyChanged
    {
        private ObservableCollection<Triptbl> trips = null;
        public ObservableCollection<Triptbl> Trips
        {
            get
            {
                trips = trips ?? new ObservableCollection<Triptbl>();
                return trips;
            }
        }
        private ObservableCollection<usertbl> users = null;
        public ObservableCollection<usertbl> Users
        {
            get
            {
                users = users ?? new ObservableCollection<usertbl>();
                return users;
            }
        }

        private ICommand insertMessage;

        public ICommand InsertMessage
        {
            get
            {
                this.insertMessage = this.insertMessage ?? new DelegateCommand(this.ExecuteInsert, () => !string.IsNullOrEmpty(this.Title) && !string.IsNullOrEmpty(this.Description));
                return this.insertMessage;
            }
        }

        public Dispatcher UIDispatcher { get; set; }

        public SQLNotifier Notifier { get; set; }
        public TripModel(Dispatcher uidispatcher)
        {
            this.UIDispatcher = uidispatcher;
            this.Notifier = new SQLNotifier();

            this.Notifier.NewMessage += new EventHandler<SqlNotificationEventArgs>(Notifier_NewMessage);
            DataTable dt = this.Notifier.RegisterDependency();


            this.LoadMessage(dt);
        }

        private string title;
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
                this.OnPropertyChanged("Title");
            }
        }
        private string description;
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
                this.OnPropertyChanged("Description");
            }
        }
        public void ExecuteInsert()
        {
            this.Notifier.Insert(this.Title, this.Description);
            this.Title = string.Empty;
            this.Description = string.Empty;
        }
        private void LoadMessage(DataTable dt)
        {

            this.UIDispatcher.BeginInvoke((Action)delegate ()
            {
                if (dt != null)
                {
                    this.Trips.Clear();

                    foreach (DataRow drow in dt.Rows)
                    {
                        usertbl user = new usertbl
                        {

                            FirstName = drow["FirstName"] as string,
                            LastName = drow["LastName"] as string

                        };
                        this.Users.Add(user);
                        Triptbl trip = new Triptbl();
                        try
                        {
                            Triptbl trips = new Triptbl
                            {

                                Id = Convert.ToInt32(Convert.ToString(drow["Id"])),
                                DriverId = Convert.ToInt32(Convert.ToString(drow["DriverId"])),
                                usertbl = user,
                                UserId = Convert.ToInt32(Convert.ToString(drow["UserId"])),
                                Status = Convert.ToInt32(Convert.ToString(drow["Status"])),
                                StartLoc = drow["StartLoc"] as string,
                                EndLoc = drow["EndLoc"] as string,
                                EndLocName = drow["EndLocName"] as string,
                                StartLocName = drow["StartLocName"] as string,
                                Tozihat = drow["Tozihat"] as string,
                                Date = Convert.ToDateTime(drow["Date"] as string),


                            };
                            trip = trips;
                        }
                        catch {
                            Triptbl trips = new Triptbl
                            {

                                Id = Convert.ToInt32(Convert.ToString(drow["Id"])),
                              //  DriverId = Convert.ToInt32(Convert.ToString(drow["DriverId"])),
                                usertbl = user,
                                UserId = Convert.ToInt32(Convert.ToString(drow["UserId"])),
                                Status = Convert.ToInt32(Convert.ToString(drow["Status"])),
                                StartLoc = drow["StartLoc"] as string,
                                EndLoc = drow["EndLoc"] as string,
                                EndLocName = drow["EndLocName"] as string,
                                StartLocName = drow["StartLocName"] as string,
                                Tozihat = drow["Tozihat"] as string,
                                Date = Convert.ToDateTime(drow["Date"] as string),


                            };
                            trip = trips;
                        }
                        
                        this.Trips.Add(trip);

                    }
                    
                }
            });
        }
        void Notifier_NewMessage(object sender, SqlNotificationEventArgs e)
        {
            this.LoadMessage(this.Notifier.RegisterDependency());
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}