using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_ResumeApplication.View;

namespace WPF_ResumeApplication.ViewModel
{
    class MainViewModel
    {
        public MainViewModel()
        {

        }
        private ICommand mOpenSongView;
        public ICommand OpenSongViewCommand
        {
            get
            {
                if (mOpenSongView == null)
                    mOpenSongView = new Opener(this);
                return mOpenSongView;
            }
            set
            {
                mOpenSongView = value;
            }
        }

        private class Opener : ICommand
        {
            private MainViewModel mainViewModel;
            public Opener(MainViewModel mvm)
            {
                mainViewModel = mvm;
            }
            #region
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                mainViewModel.OpenSongView();
                
            }

            #endregion
        }

        private ICommand mOpenGenericView;
        public ICommand OpenGenericViewCommand
        {
            get
            {
                if (mOpenSongView == null)
                    mOpenSongView = new Opener(this);
                return mOpenSongView;
            }
            set
            {
                mOpenSongView = value;
            }
        }

        private class GenericOpener : ICommand
        {
            private MainViewModel mainViewModel;
            public GenericOpener(MainViewModel mvm)
            {
                mainViewModel = mvm;
            }
            #region
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                mainViewModel.OpenSongView();

            }

            #endregion
        }

        public void OpenSongView()
        {
            SongView songView = new SongView();
            SongViewModel svm = new SongViewModel(songView);
            songView.DataContext = svm;
            songView.ShowDialog();
        }

        public void OpenGenericView()
        {
            
        }
    }
}
