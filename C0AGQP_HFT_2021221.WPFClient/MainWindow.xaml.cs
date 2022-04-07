using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace C0AGQP_HFT_2021221.WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Albums_Click(object sender, RoutedEventArgs e)
        {
            AlbumWindow albumWindow = new AlbumWindow();
            albumWindow.Show();
        }

        private void Songs_Click(object sender, RoutedEventArgs e)
        {
            SongWindow songWindow = new SongWindow();
            songWindow.Show();
        }
    }
}
