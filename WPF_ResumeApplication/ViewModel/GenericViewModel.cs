using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_ResumeApplication.View;

namespace WPF_ResumeApplication.ViewModel
{
    class GenericViewModel
    {
        GenericView gv;
        public GenericViewModel(GenericView w)
        {
            gv = w;
        }

        private ICommand mCalculator;
        public ICommand CalculateCommand
        {
            get
            {
                if (mCalculator == null)
                    mCalculator = new Calculator(this);
                return mCalculator;
            }

            set
            {
                mCalculator = value;
            }

        }
        private class Calculator : ICommand
        {
            private GenericViewModel genericViewModel;
            public Calculator(GenericViewModel vm)
            {
                genericViewModel = vm;
            }
            #region
            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                genericViewModel.Submit();

            }

            #endregion
        }

        public void Submit()
        {
            if (gv.addRB.IsChecked.Value)
            {
                gv.outputLbl.Content = gv.value1txtBox.Text + gv.value2txtBox.Text;
            }
        }
        
    }
}
