using System.ComponentModel;

namespace WPF_ResumeApplication.Model
{
    class Song : INotifyPropertyChanged
    {
        private string _title;
        private string _artist;
        private string _album;
        private string _time;
        private string _genre;

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Artist
        {
            get
            {
                return _artist;
            }
            set
            {
                _artist = value;
                OnPropertyChanged("Artist");
            }
        }

        public string Album
        {
            get
            {
                return _album;
            }
            set
            {
                _album = value;
                OnPropertyChanged("Album");
            }
        }

        public string Time
        {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
                OnPropertyChanged("Time");
            }
        }

        public string Genre
        {
            get
            {
                return _genre;
            }
            set
            {
                _genre = value;
                OnPropertyChanged("Genre");
            }
        }

        #region INotifyPropertyChanged Members  

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }


}
