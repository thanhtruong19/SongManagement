using SongManagementApp.Commands;
using SongManagementApp.Model;
using System;
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
    public class SearchSongViewModel : INotifyPropertyChanged
    {
        // Các thuộc tính để lưu trữ thông tin tìm kiếm mà giao diện trả về
        public int? ID { get; set; }
        public string? SongName { get; set; }
        public string? SingerName { get; set; }
        public string? Genre { get; set; }
        public string? Country { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        private readonly SongRepository _repo; // Tạo một instance của SongRepository để truy cập dữ liệu
        //khai báo class để chứa kết quả tìm kiếm
        private ObservableCollection<Song> _filteredSongs;
        public ObservableCollection<Song> FilteredSongs
        {
            get => _filteredSongs;
            set
            {
                _filteredSongs = value;
                OnPropertyChanged(nameof(FilteredSongs));
            }
        }

        //  Command 
        public ICommand SearchCommand { get; set; }

        public SearchSongViewModel()
        {
            FilteredSongs = new ObservableCollection<Song>();
            SearchCommand = new AsyncRelayCommand(SearchSong, CanSearchSong);
        }
        public SearchSongViewModel(SongRepository repo) : this() // Gọi constructor không tham số để khởi tạo SearchSongViewModel
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo)); //  gán repo của main window cho SearchSongViewModel
        }



        private async Task SearchSong(object obj)
        {
            var results = await _repo.SearchAsync(ID, SongName, SingerName, Genre, Country, StartDate, EndDate);
            FilteredSongs = new ObservableCollection<Song>(results);
            OnPropertyChanged(nameof(FilteredSongs));

            Window searchWindow = obj as Window;
            searchWindow.Close(); // Đóng cửa sổ tìm kiếm sau khi tìm kiếm xong
        }

        private bool CanSearchSong(object obj)
        {
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
