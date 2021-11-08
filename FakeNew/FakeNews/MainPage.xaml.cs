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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FakeNews
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<NewsItem> NewsItems;

        public MainPage()
        {
            this.InitializeComponent();
            NewsItems = new ObservableCollection<NewsItem>();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Financial.IsSelected)
            {
                NewsManager.GetNews("Financial", NewsItems);
            }
            else if (Food.IsSelected)
            {
                NewsManager.GetNews("Food", NewsItems);
            }
            if (ContentFrame.Content?.GetType() != typeof(NewItemsList))
            {
                ContentFrame.Navigate(typeof(NewItemsList), NewsItems);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Financial.IsSelected = true;
        }

        private void ListBox_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = false;
        }

        private void ListBox_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = true;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.GoBack();
        }

        private void ListBox_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (ContentFrame.Content?.GetType() != typeof(NewItemsList))
            {
                ContentFrame.Navigate(typeof(NewItemsList), NewsItems);
            }
        }
    }
}
