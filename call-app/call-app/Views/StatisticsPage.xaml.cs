using System;
using System.Collections.Generic;
using call_app.Models;
using call_app.ViewModels;
using Xamarin.Forms;

namespace call_app.Views
{
    public partial class StatisticsPage : ContentPage
    {
		private StatisticsViewModel viewModel;

        public StatisticsPage(Event myEvent)
        {
            InitializeComponent();
            
            BindingContext = viewModel = new StatisticsViewModel(myEvent);
        }
    }
}
