using SongManagementApp.Commands;
using SongManagementApp.Model;
using SongManagementApp.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SongManagementApp.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Song> Songs { get; set; }
        private readonly SongRepository _repo = new SongRepository();
        public ICommand AddWindowCommand { get; set; }
        public ICommand SearchWindowCommand { get; set; }
        public ICommand DeleteActionCommand { get; set; }
        public ICommand UpdateActionCommand { get; set; }


        public MainViewModel()
        {
            Songs = _repo.GetAll();

            //Command mở các cửa sổ
            AddWindowCommand = new RelayCommand(ShowAddWindow, CanShowAddWindow);
            SearchWindowCommand = new RelayCommand(ShowSearchWindow, CanShowSearchWindow);

            //Command của các nút
            DeleteActionCommand = new AsyncRelayCommand(DeleteSong, CanDeleteSong);
            UpdateActionCommand = new AsyncRelayCommand(UpdateSong, CanUpdateSong);
        }


        //Command của AddWindow 
        private bool CanShowAddWindow(object obj)
        {
            return true;
        }

        private void ShowAddWindow(object obj)
        {
            var MainWindow = (Window)obj;

            //xử lí việc truyền bộ sưu tập ObservableCollection<Song> từ MainViewModel sang AddSongViewModel
            var mainViewModel = MainWindow.DataContext as MainViewModel;
            var addVm = new AddSongViewModel(mainViewModel.Songs);
            AddSong addSong = new AddSong{ DataContext = addVm }; //khởi chạy cửa sổ add song
            addSong.Owner = MainWindow;
            addSong.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            addSong.Show();

        }

        //Command của SearchWindow 
        private bool CanShowSearchWindow(object obj)
        {
            return true;
        }

        private void ShowSearchWindow(object obj)
        {
            var searchVm = new SearchSongViewModel(_repo); // gán repo của main window cho SearchSongViewModel
            var MainWindow = (Window)obj;
            SearchSong searchSong = new SearchSong { DataContext = searchVm };
            searchSong.Owner = MainWindow;
            searchSong.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            bool? result = searchSong.ShowDialog(); // Hiển thị cửa sổ tìm kiếm

            if (searchVm.FilteredSongs.Any())
            {
                Songs = new ObservableCollection<Song>(searchVm.FilteredSongs);
                OnPropertyChanged(nameof(Songs));
            }
            else
            {
                Songs = _repo.GetAll(); // Nếu không có kết quả tìm kiếm, hiển thị lại tất cả bài hát
            }
        }

        //Command của nút Delete
        private bool CanDeleteSong(object obj)
        {
            return true;
        }

        private async Task DeleteSong(object obj)
        {
            var songsToDelete = Songs.Where(s => s.IsSelected).ToList(); // Tạo bản sao an toàn
            if (!songsToDelete.Any())
            {
                MessageBox.Show("Vui lòng chọn ít nhất một bài hát để xóa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {
                await _repo.Delete(songsToDelete); // Xóa từ repository
                foreach (var song in songsToDelete)
                {
                    Songs.Remove(song); // phải xóa cả ở song để giao diện cập nhật 
                }
                MessageBox.Show("Xóa bài hát thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        //Command của nút Update
        private bool CanUpdateSong(object obj)
        {
            return true;
        }

        private async Task UpdateSong(object arg)
        {
            var songsToUpdate = Songs.Where(s => s.IsSelected).ToList(); //songsToUpdate giữ tham chiếu đến cùng một instance của Song, không phải tạo ra bản sao.
            try
            {
                foreach (var song in songsToUpdate)
                {
                    await _repo.Update(song); // Cập nhật từng bài hát
                    song.IsSelected = false; // Bỏ chọn bài hát sau khi cập nhật
                }
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật bài hát: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        //Xử lí selected all cho DataGrid (tạm thời chưa dùng đến)
        private bool _selectAll;
        public bool SelectAll
        {
            get => _selectAll;
            set
            {
                if (_selectAll == value) return;
                _selectAll = value;
                OnPropertyChanged(nameof(SelectAll));

                // whenever SelectAll changes, update every item
                foreach (var song in Songs)
                    song.IsSelected = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

