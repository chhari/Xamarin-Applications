using System;
using System.Collections.Generic;
using Telerik.XamarinForms.Primitives;
using Xamarin.Forms;

namespace Portable
{
    public partial class Drawer : ContentPage
    {

        public Drawer()
        {
            InitializeComponent();
            var drawerContent = new StackLayout();
            drawerContent.Children.Add(new Button { Text = "About" });
            drawerContent.Children.Add(new Button { Text = "Location Selection" });
            drawerContent.Children.Add(new Button { Text = "People" });

            var sideDrawer = new RadSideDrawer
            {
                MainContent = new Label { Text = "Main content" },
                DrawerContent = drawerContent,
                DrawerLength = 200
            };
        }
         void OnToolbarButtonClick(object sender,EventArgs e)
        {
            this.drawer.IsOpen = !this.drawer.IsOpen;
            
        }
        public void OnAboutButton(object sender, EventArgs e)
        {

            Navigation.PushAsync(new about());
        }
        public void OnLocationButton(object sender, EventArgs e)
        {

            Navigation.PushAsync(new location());
        }
        public void OnSelectionButton(object sender, EventArgs e)
        {

            Navigation.PushAsync(new MainPage());
        }
    }
}
