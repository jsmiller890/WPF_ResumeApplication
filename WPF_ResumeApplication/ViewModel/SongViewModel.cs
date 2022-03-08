using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using WPF_ResumeApplication.Model;
using WPF_ResumeApplication.View;

namespace WPF_ResumeApplication.ViewModel
{
    class SongViewModel
    {
        SongView sv;

        private IList<Song> _SongsList;

        public SongViewModel(SongView w)
        {
            sv = w;

            _SongsList = new List<Song>
            {

            };
            LoadData();
        }

        public IList<Song> Songs
        {
            get { return _SongsList; }
            set { _SongsList = value; }
        }

        //**** Commands for managing the data ******//

        // Save Command
        private ICommand mSaver;
        public ICommand SaveCommand
        {
            get
            {
                if (mSaver == null)
                    mSaver = new Saver(this);
                return mSaver;
            }

            set
            {
                mSaver = value;
            }
        }
        private class Saver : ICommand
        {
            private SongViewModel songViewModel;
            public Saver(SongViewModel vm)
            {
                songViewModel = vm;
            }
            #region
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                songViewModel.SaveData();
            }

            #endregion
        }

        //Load command
        private ICommand mLoader;
        public ICommand LoadCommand
        {
            get
            {
                if (mLoader == null)
                    mLoader = new Loader(this);
                return mLoader;
            }

            set
            {
                mLoader = value;
            }

        }

        private class Loader : ICommand
        {
            private SongViewModel songViewModel;
            public Loader(SongViewModel vm)
            {
                songViewModel = vm;
            }
            #region
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                songViewModel.LoadData();

            }

            #endregion
        }

        //Update Command
        private ICommand mUpdater;
        public ICommand UpdateCommand
        {

            get
            {
                if (mUpdater == null)
                    mUpdater = new Updater(this);
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }

        private class Updater : ICommand
        {
            private SongViewModel songViewModel;
            public Updater(SongViewModel vm)
            {
                songViewModel = vm;
            }

            #region ICommand Members

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                songViewModel.UpdateData();
            }

            #endregion
        }

        //Add Command
        private ICommand mAdder;
        public ICommand AddCommand
        {
            get
            {
                if (mAdder == null)
                    mAdder = new Adder(this);
                return mAdder;
            }

            set
            {
                mAdder = value;
            }

        }
        private class Adder : ICommand
        {
            private SongViewModel songViewModel;
            public Adder(SongViewModel vm)
            {
                songViewModel = vm;
            }
            #region
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                songViewModel.AddEntry();

            }

            #endregion
        }

        //Delete Command
        private ICommand mDeleter;
        public ICommand DeleteCommand
        {
            get
            {
                if (mDeleter == null)
                    mDeleter = new Deleter(this);
                return mDeleter;
            }

            set
            {
                mDeleter = value;
            }

        }
        private class Deleter : ICommand
        {
            private SongViewModel songViewModel;
            public Deleter(SongViewModel vm)
            {
                songViewModel = vm;
            }
            #region
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                songViewModel.DeleteEntry();

            }

            #endregion
        }



        //Saves the data in listview to a txt file
        public void SaveData()
        {
            string splitter = "|";
            string filename = "SongList.txt";
            if (!File.Exists("SongList.txt"))
                File.Create(filename);

            File.WriteAllText(filename, "");

            foreach (Song song in Songs)
            {
                string songToSave = song.Title + splitter + song.Album + splitter + song.Artist + splitter + song.Genre + splitter + song.Time + splitter;
                using (StreamWriter sw = File.AppendText(filename))
                {
                    sw.WriteLine(songToSave);
                }
            }

            Songs.Clear();

        }

        //Loads the data from a file into the listview
        public void LoadData()
        {
            char splitter = '|';
            string filename = "SongList.txt";
            string fileContents = "";

            if (!File.Exists(filename))
                MessageBox.Show("The file " + filename + "does not exist.");

            using (StreamReader sr = File.OpenText(filename))
            {
                fileContents = sr.ReadLine();
                Songs.Clear();

                while (fileContents != null)
                {
                    string[] dividedContents = fileContents.Split(splitter);
                    Songs.Add(new Song { Title = dividedContents[0], Album = dividedContents[1], Artist = dividedContents[2], Genre = dividedContents[3], Time = dividedContents[4] });


                    fileContents = sr.ReadLine();
                }

            }
            UpdateData();


        }

        //Update what appears in the list view
        public void UpdateData()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(Songs);

            view.Refresh();
        }

        //Adds an entry into the Songs list and displays it in the listview
        public void AddEntry()
        {
            Songs.Add(new Song { Title = sv.titleTxtBox.Text, Album = sv.albumTxtBox.Text, Artist = sv.artistTxtBox.Text, Genre = sv.genreTxtBox.Text, Time = sv.timeTxtBox.Text });
            UpdateData();
        }


        //Deletes the selected entry in the listview         
        public void DeleteEntry()
        {

            ICollectionView view = CollectionViewSource.GetDefaultView(Songs);
            var toBeDeleted = sv.songGrid.SelectedItem;
            foreach (Song song in Songs)
            {
                if (toBeDeleted == song)
                {
                    toBeDeleted = song;
                }
            }
            Songs.Remove((Song)toBeDeleted);
            view.Refresh();
        }
    }
}
