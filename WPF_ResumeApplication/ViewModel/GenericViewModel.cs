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
    }
}
