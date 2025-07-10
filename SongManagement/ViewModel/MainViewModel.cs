using SongManagement.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
namespace SongManagement.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Song> Songs { get; set; }
        public ICommand ToggleSearchCommand { get; }
        public ICommand SearchCommand { get; }

        private bool _isSearchVisible;
        public bool IsSearchVisible
        {
            get => _isSearchVisible;
            set { _isSearchVisible = value; OnPropertyChanged(nameof(IsSearchVisible)); }
        }

        // Các trường tìm kiếm
        public string SearchSongName { get; set; } = string.Empty;

        public MainViewModel()
        {
            Songs = new ObservableCollection<Song>
        {
            new Song { ID = "001", SongName = "Lạc trôi", SingerName = "Sơn Tùng", Genre = "EDM", Country = "Việt Nam", ReleaseDate = "2016/05/30" },
            new Song { ID = "002", SongName = "Nơi này có anh", SingerName = "Sơn Tùng", Genre = "Pop", Country = "Việt Nam", ReleaseDate = "2017/02/14" }
        };

            ToggleSearchCommand = new RelayCommand.RelayCommand(_ => IsSearchVisible = !IsSearchVisible);
            SearchCommand = new RelayCommand.RelayCommand(_ => ApplySearch());
        }

        //private void ApplySearch()
        //{
        //    var filtered = Songs.Where(s => s.SongName.Contains(SearchSongName, StringComparison.OrdinalIgnoreCase)).ToList();
        //    Songs.Clear();
        //    foreach (var song in filtered)
        //        Songs.Add(song);
        //}

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}
