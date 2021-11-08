using FakeNews.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FakeNews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewItemsList : Page
    {
        private ObservableCollection<NewsItem> NewsItems;
        public NewItemsList()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            NewsItems = (ObservableCollection<NewsItem>)e.Parameter;
        }
        private void NewsItemGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var grid = sender as NewsItemControl;
            var newsItem = grid.DataContext;
            this.Frame.Navigate(typeof(NewDetails), newsItem);
        }
    }
}
