using SongManagementApp.ViewModel;
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
using System.Windows.Shapes;

namespace SongManagementApp.Views
{
    /// <summary>
    /// Interaction logic for SearchSong.xaml
    /// </summary>
    public partial class SearchSong : Window
    {
        public SearchSong()
        {
            InitializeComponent();
            SearchSongViewModel searchSongViewModel = new SearchSongViewModel();
            this.DataContext = searchSongViewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Đóng cửa sổ tìm kiếm khi nút được nhấn
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        }
    }
}
