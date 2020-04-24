using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestTask.Commands;
using TestTask.Controls.ViewControls;
using TestTask.Controls.ViewModelsControls;
using System.Windows;
using TestTask;
using System.Windows.Controls;

namespace TestTask.ViewModel
{
   public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            Control1 = new UserControlCode();
            Control2 = new UserControlCode();
            Control3 = new UserControlCode();

            Control1.OnLoad += Control1_OnLoad;
            Control2.OnLoad += Control2_OnLoad;
            Control3.OnLoad += Control3_OnLoad;

            Control3.OnReset += Control3_OnReset;
            Control2.OnReset += Control2_OnReset;
            Control1.OnReset += Control1_OnReset;
        }

        private void Control1_OnReset()
        {
            this.CurrentValue = "0";
            this.AllSize = " / 0 Кб";
        }

        private void Control2_OnReset()
        {
            this.CurrentValue = "0";
            this.AllSize = " / 0 Кб";
        }

        private void Control3_OnReset()
        {
            this.CurrentValue = "0";
            this.AllSize = " / 0 Кб";
        }

        private void Control1_OnLoad(int obj, int load)
        {
            this.CurrentProgress = obj;
            this.CurrentValue = Convert.ToString((Control1.Load + Control2.Load + Control3.Load) / 1024);
            if (!DownLoadAll)
            {
                this.AllSize = " / " + Convert.ToString((Control1.Size + Control2.Size + Control3.Size) / 1024) + " Кб";
            }
        }

        private void Control2_OnLoad(int obj,int load)
        {
            this.CurrentProgress = obj;
            this.CurrentValue = Convert.ToString((Control1.Load + Control2.Load + Control3.Load) / 1024);
            if (!DownLoadAll)
            {
                this.AllSize = " / " + Convert.ToString((Control1.Size + Control2.Size + Control3.Size) / 1024) + " Кб";
            }
        }

        private void Control3_OnLoad(int obj,int load)
         {
            this.CurrentProgress = obj;
            this.CurrentValue = Convert.ToString((Control1.Load + Control2.Load + Control3.Load)/1024);
            if (!DownLoadAll)
            {
                this.AllSize = " / " + Convert.ToString((Control1.Size + Control2.Size + Control3.Size) / 1024) + " Кб";
            }
        }

        public int CurrentProgress
        {
            get { return this.currentProgress; }
            private set
            {
                if (this.currentProgress != value)
                {
                    this.currentProgress = value;
                    INotifyPropertyChanged("CurrentProgress");
                }
            }
        }
        private int currentProgress;

        public string AllSize
        {
            get { return this.allSize; }
            private set
            {
                if (this.allSize != value)
                {
                    this.allSize = value;
                    INotifyPropertyChanged("AllSize");
                }
            }
        }
        private string allSize;

        public string CurrentValue
        {
            get { return this.currentValue; }
            private set
            {
                if (this.currentValue != value)
                {
                    this.currentValue = value;
                    INotifyPropertyChanged("CurrentValue");
                }
            }
        }
        private string currentValue;

        public static  UserControlCode Control1 { get; set; }
        public UserControlCode Control2 { get; set; }
        public UserControlCode Control3 { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void INotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private ICommand _BtnAllStart;
        public ICommand BtnAllStart
        {
            get
            {
                if (_BtnAllStart == null)
                {
                    _BtnAllStart = new RelayCommand(BtnAllStartExecute, CanBtnAllStartExecute, false);
                }
                return _BtnAllStart;
            }
        }

        private void BtnAllStartExecute(object parametr)
        {
            DownLoadAll = true;
            CalculateSize();
            Control1.BtnStartExecute(Control1);
            Control2.BtnStartExecute(Control2);
            Control3.BtnStartExecute(Control3);
            DownLoadAll = false;
        }

        private bool CanBtnAllStartExecute(object parametr)//условие нажатия на кнопку
        {
            if ((string.IsNullOrEmpty(Control1.Link)) || (string.IsNullOrEmpty(Control2.Link)) || (string.IsNullOrEmpty(Control3.Link)))
            {
                return false;
            }
            else return true;
        }

        public bool DownLoadAll = false;

        public  void CalculateSize()
        {
            Control1.BtnToKnowSizeExecute(Control1);
            Control2.BtnToKnowSizeExecute(Control2);
            Control3.BtnToKnowSizeExecute(Control3);
            AllSize =" / "+ Convert.ToString((Control1.Size + Control2.Size + Control3.Size) / 1024) + " Кб";
        }
    }
}
