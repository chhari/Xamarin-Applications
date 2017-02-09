using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.XamarinForms.DataControls;
using Telerik.XamarinForms.DataControls.ListView;
using Xamarin.Forms;

namespace Portable
{
    public partial class asad : ContentPage
    {

        public class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
        }

        public class ViewModel
        {
            public ViewModel()
            {
                this.Source = new List<Book>{
            new Book{ Title = "The Fault in Our Stars ",  Author = "John Green"},
            new Book{ Title = "Divergent",  Author = "Veronica Roth"},
            new Book{ Title = "Gone Girl",  Author = "Gillian Flynn"},
            new Book{ Title = "Clockwork Angel",  Author = "Cassandra Clare"},
            new Book{ Title = "The Martian",  Author = "Andy Weir"},
            new Book{ Title = "Ready Player One",  Author = "Ernest Cline"},
            new Book{ Title = "The Lost Hero",  Author = "Rick Riordan"},
            new Book{ Title = "All the Light We Cannot See",  Author = "Anthony Doerr"},
            new Book{ Title = "Cinder",  Author = "Marissa Meyer"},
            new Book{ Title = "Me Before You",  Author = "Jojo Moyes"},
            new Book{ Title = "The Night Circus",  Author = "Erin Morgenstern"},
        };
            }

            public List<Book> Source { get; set; }
        }
        public asad()
        {
            InitializeComponent();
            var listView = new RadListView
            {
                BackgroundColor = Color.White,
                ItemsSource = new ViewModel().Source,
                ItemTemplate = new DataTemplate(() =>
                {
                    var cell = new ListViewTextCell
                    {
                        TextColor = Color.Black,
                        DetailColor = Color.Gray,
                    };

                    cell.SetBinding(ListViewTextCell.TextProperty, new Binding(nameof(Book.Title)));
                    cell.SetBinding(ListViewTextCell.DetailProperty, new Binding(nameof(Book.Author)));

                    return cell;
                }),
                LayoutDefinition = new ListViewLinearLayout { ItemLength = 70 },
            };
        }
    }
}
