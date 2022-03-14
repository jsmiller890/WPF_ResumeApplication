using System;
using System.Windows.Input;
using WPF_ResumeApplication.View;

namespace WPF_ResumeApplication.ViewModel
{
    class MainViewModel
    {
        public MainViewModel()
        {

        }
        private ICommand mOpenNewView;
        public ICommand OpenNewViewCommand
        {
            get
            {
                if (mOpenNewView == null)
                    mOpenNewView = new Opener(this);
                return mOpenNewView;
            }
            set
            {
                mOpenNewView = value;
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
                if ((string)parameter == "SongList")
                {
                    mainViewModel.OpenSongView();
                }
                else if ((string)parameter == "Generic")
                {
                    mainViewModel.OpenGenericView();
                }
                else if ((string)parameter == "Calculator")
                    mainViewModel.OpenCalculatorView();

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
            GenericView genericView = new GenericView();
            GenericViewModel gvm = new GenericViewModel(genericView);
            genericView.DataContext = gvm;
            genericView.ShowDialog();
        }

        public void OpenCalculatorView()
        {
            Calculator calculatorView = new Calculator();
            calculatorView.ShowDialog();
        }
    }
}
