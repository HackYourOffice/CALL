using System;
using System.Collections.Generic;
using System.Text;

namespace call_app.ViewModels
{
    class CountdownViewModel : BaseViewModel
    {
        private int counter;
        public int Counter
        {
            get { return counter; }
            set { SetProperty(ref counter, value); }
        }
    }
}
