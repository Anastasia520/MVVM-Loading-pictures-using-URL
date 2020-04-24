using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestTask.Commands;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using System.Net;
using System.IO;
using System.Windows;

namespace TestTask.Controls.ViewModelsControls
{
    public class UserControlCode : INotifyPropertyChanged
    {

        private string _Link;
        public string Link
        {
            get { return _Link; }
            set {
                _Link = value;
                INotifyPropertyChanged(Link);
            }
        }

        private int _Size;
        public int Size
        {
            get { return _Size; }
            set
            {
                _Size = value;
                INotifyPropertyChanged("Size");
            }
        }
         
        private int  _Load;
        public int Load
        {
            get { return _Load; }
            set
            {
                _Load = value;
                INotifyPropertyChanged("Load");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void INotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private ICommand _BtnStart;
        public ICommand BtnStart
        {
            get
            {
                if (_BtnStart == null)
                {
                    _BtnStart = new RelayCommand(BtnStartExecute, CanBtnStartExecute, false);
                }
                return _BtnStart;
            }
        }

        public bool Loaded=false;
        public bool Start = false;
        public bool StartLoad = false;

        private ICommand _BtnStop;
        public ICommand BtnStop
        {
            get
            {
                if (_BtnStop == null)
                {
                    _BtnStop = new RelayCommand(BtnStopExecute, CanBtnStopExecute, false);
                }
                return _BtnStop;
            }
        }

        private  void BtnStopExecute(object parametr)
        {
            if (Loaded || !Start)
            {
                Link = "";
                Loaded = false;
                Source = new BitmapImage();
                OnLoad?.Invoke(0,0);
                OnReset?.Invoke();
                Start = false;
                Size = 0;
                Load = 0;
            }
            else if (StartLoad)
            {
                stop = true;
                webClient.CancelAsync();
            }
        }

        private bool CanBtnStopExecute(object parametr)//условие нажатия на кнопку
        {
            if (string.IsNullOrEmpty(Link))
            {
                return false;
            }
            else return true;
        }

        private ICommand _BtnToKnowSize;
        public ICommand BtnToKnowSize
        {
            get
            {
                if (_BtnToKnowSize == null)
                {
                    _BtnToKnowSize = new RelayCommand(BtnStopExecute, CanBtnToKnowSizeExecute, false);
                }
                return _BtnToKnowSize;
            }
        }

        public  void BtnToKnowSizeExecute(object parametr)
        {
            SizeToKnow();
           
        }

       public void SizeToKnow()
       {
             try
             {
                HttpWebRequest r0 = (HttpWebRequest)HttpWebRequest.Create(Link);
                r0.Method = "GET";
                HttpWebResponse res = (HttpWebResponse)r0.GetResponse();
                Size =(int) res.ContentLength;
                res.Close();
             }
            catch (Exception ex)
             {
                MessageBox.Show(@"Неверный формат ссылки или поле ввода пустое,
        попробуйте еще раз", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
             }
       }

        private bool CanBtnToKnowSizeExecute(object parametr)//условие нажатия на кнопку
        {
            if (string.IsNullOrEmpty(Link))
            {
                return false;
            }
            else return true;
        }

        private BitmapSource _source;
        public BitmapSource Source
        {
            get { return  _source; }
            set
            {
                _source = value;
                INotifyPropertyChanged("Source"); 
            }

        }

        public byte[] bytes;
        public event Action OnReset;
        public event Action<int,int> OnLoad;
        public bool stop;
        public WebClient webClient = new WebClient();
        public int size;
        public bool okDownload;//переменая, определяющая прохождение загрузки картинки без/с ошибками
        public int v = 0;
       
        public  void BtnStartExecute(object parametr)
        {
            byte[] bArr=new byte [0];
            Start = true;
            StartLoad = true;
            //загрузка картинки
            Size = 0;
            var bitmap = new BitmapImage();
            var ms = new MemoryStream();
            string Filename = "";
            try//проверка на загрузку картинки
            {
                SizeToKnow();
                webClient.DownloadProgressChanged += (s, e) =>
                {
                    Load = (int)e.BytesReceived;
                     v = e.ProgressPercentage;
                    OnLoad?.Invoke(v,Load);
                };
                webClient.DownloadFileCompleted += (s, e) =>
                {
                    
                    if (stop)
                    {
                        Start = false;
                        StartLoad = false;
                        Source = new BitmapImage();
                        stop = false;
                        File.Delete(Filename);
                        MessageBox.Show(@"Загрузка отменена", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        Load = Size;
                        OnLoad?.Invoke(100, Load);
                        var uri = new Uri(Filename);
                        bitmap = new BitmapImage(uri);
                        Source = bitmap;
                        StartLoad = false;
                        Loaded = true;
                    }
                };
               Filename = AppDomain.CurrentDomain.BaseDirectory + Link.Substring(Link.LastIndexOf('/'));
                 if (File.Exists(Filename))
                 {
                        var uri = new Uri(Filename);
                        bitmap = new BitmapImage(uri);
                        Load = Size;
                        Source = bitmap;
                        StartLoad = false;
                        Loaded = true;
                        OnLoad?.Invoke(100, Size);
                 }
                 else
                 {

                       webClient.DownloadFileAsync(new Uri(Link), AppDomain.CurrentDomain.BaseDirectory + Link.Substring(Link.LastIndexOf('/')));

                 }
            }
            
            catch (Exception ex)//ловим ошибки
            {
                    Start = false;
                    StartLoad = false;
                    MessageBox.Show(@"Неверный формат ссылки или поле ввода пустое,
        попробуйте еще раз", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
              
                }
            
        }

        private bool CanBtnStartExecute (object parametr)//условие нажатия на кнопку
        {
            if (string.IsNullOrEmpty(Link))
            {
                return false;
            }
            else return true;
        }
    }
}
