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
using SongManagement.ViewModel;
using SongManagement.Views;
namespace SongManagement.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; set; } = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var searchWindow = new Search();
            searchWindow.ShowDialog(); // hoặc .Show() nếu bạn không muốn chặn luồng
        }

        private void OpenAddWindow()
        {
            var addWindow = new Add(); // ⬅️ mở cửa sổ thêm bài hát
            if (addWindow.ShowDialog() == true)
            {
                var newSong = addWindow.ViewModel.NewSong;
                var vm = new MainViewModel();
                // Gán ID bài hát mới dựa vào danh sách hiện tại
                newSong.ID = vm.Songs.Any() ? vm.Songs.Max(s => s.ID) + 1 : 1;

                // Thêm bài hát vào danh sách trong MainViewModel
                vm.Songs.Add(newSong);
                Console.WriteLine($"Đã thêm bài hát: {newSong.SongName} - {newSong.SingerName}");
            }
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            OpenAddWindow();
        }
    }
}