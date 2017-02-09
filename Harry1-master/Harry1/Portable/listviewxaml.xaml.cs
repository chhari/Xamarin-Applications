using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.XamarinForms.Primitives;
using Telerik.XamarinForms.DataControls;
using Telerik.XamarinForms.DataControls.ListView;
using Xamarin.Forms;

namespace Portable
{
    public partial class listviewxaml : ContentPage
    {
        public listviewxaml()
        {
            myclass forpics = new myclass();
            forpics.createContainer();

            InitializeComponent();
            //var colors = new List<object>();
            //for (int i = 0; i < 16; i++)
            //{
            //    var c = 200 - 10 * i;
            //    colors.Add(new { Color = Color.FromRgb(c, c, c) });
            //};

            var pics = new List<object>();
            for (int i = 0; i < 2; i++)
            {
                var webImage = new Image { Aspect = Aspect.AspectFit };
                webImage.Source = ImageSource.FromUri(new Uri(forpics.urls[i]));
                pics.Add(webImage);
            }

            //listView.ItemsSource = colors;
            listView.ItemsSource = pics;
            

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
        void OnToolbarButtonClick(object sender, EventArgs e)
        {
            this.drawer.IsOpen = !this.drawer.IsOpen;
            Navigation.PushAsync(new Drawer());

        }
        public void OnAboutButton(object sender, EventArgs e)
        {

            Navigation.PushAsync(new about());
        }
    }
}
