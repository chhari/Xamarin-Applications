﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Portable
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
            
        }
        private void OnToolbarButtonClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Drawer());
        }
    }

}