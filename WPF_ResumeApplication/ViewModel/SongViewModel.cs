﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using WPF_ResumeApplication.Model;
using System.IO;
using System.Windows;
using System.Windows.Data;

namespace WPF_ResumeApplication.ViewModel
{
    class SongViewModel
    {
        private IList<Song> _SongsList;

        public SongViewModel()
        {
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

        public void SaveData()
        {
            string splitter = "|";
            string filename = "SongList.txt";
            if (!File.Exists("SongList.txt"))
                File.Create(filename);

            File.WriteAllText(filename, "");

            foreach (Song song in _SongsList)
            {
                string songToSave = song.Title + splitter + song.Album + splitter + song.Artist + splitter + song.Genre + splitter + song.Time + splitter;
                using (StreamWriter sw = File.AppendText(filename))
                {
                    sw.WriteLine(songToSave);
                }
            }

            _SongsList.Clear();

        }

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
                _SongsList.Clear();

                while (fileContents != null)
                {
                    string[] dividedContents = fileContents.Split(splitter);
                    _SongsList.Add(new Song { Title = dividedContents[0], Album = dividedContents[1], Artist = dividedContents[2], Genre = dividedContents[3], Time = dividedContents[4] });
                    

                    fileContents = sr.ReadLine();
                }
                
            }
            UpdateData();


        }

        public void UpdateData()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(_SongsList);

            view.Refresh();
        }

        public void AddEntry()
        {
            _SongsList.Add(new Song { Title = , Album = dividedContents[1], Artist = dividedContents[2], Genre = dividedContents[3], Time = dividedContents[4]});
        }

        public void DeleteEntry()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(_SongsList);
            var toBeDeleted = view.CurrentItem;
            foreach (Song song in _SongsList)
            {
                if (toBeDeleted == song)
                    toBeDeleted = song;
            }
            _SongsList.Remove((Song)toBeDeleted);
            view.Refresh();
        }
    }
}