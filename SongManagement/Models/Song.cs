using System;
using System.ComponentModel;

namespace SongManagement.Models
{
    public class Song : INotifyPropertyChanged
    {
        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set { _isSelected = value; OnPropertyChanged(nameof(IsSelected)); }
        }

        private int _id;
        public int ID
        {
            get => _id;
            set { _id = value; OnPropertyChanged(nameof(ID)); }
        }

        private string _songName = string.Empty;
        public string SongName
        {
            get => _songName;
            set { _songName = value; OnPropertyChanged(nameof(SongName)); }
        }

        private string _singerName = string.Empty;
        public string SingerName
        {
            get => _singerName;
            set { _singerName = value; OnPropertyChanged(nameof(SingerName)); }
        }

        private string _genre = string.Empty;
        public string Genre
        {
            get => _genre;
            set { _genre = value; OnPropertyChanged(nameof(Genre)); }
        }

        private string _country = string.Empty;
        public string Country
        {
            get => _country;
            set { _country = value; OnPropertyChanged(nameof(Country)); }
        }

        private DateTime? _releaseDate;
        public DateTime? ReleaseDate
        {
            get => _releaseDate;
            set { _releaseDate = value; OnPropertyChanged(nameof(ReleaseDate)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
