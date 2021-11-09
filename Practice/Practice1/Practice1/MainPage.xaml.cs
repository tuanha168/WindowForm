using System;
using System.Collections.Generic;
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
using Practice1.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Practice1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private DBConnection conn = new DBConnection();
        private List<Employee> Employees = null;
        public MainPage()
        {
            this.InitializeComponent();
            conn.SelectEmployee(ref Employees);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var username = userName.Text;
            var pass = password.Text;
            if (this.nullString(username) || this.nullString(pass))
            {
                MessageBlock.Text = "Please enter User Name and Password";
                return;
            }
            MessageBlock.Text = conn.Login(username, pass);
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var username = userName.Text;
            var pass = password.Text;
            if (this.nullString(username) || this.nullString(pass))
            {
                MessageBlock.Text = "Please enter User Name and Password";
                return;
            }
            MessageBlock.Text = conn.Register(username, pass);
        }

        private bool nullString(string text)
        {
            return text == null || text == string.Empty;
        }
    }
}
