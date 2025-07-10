using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string ID { get; set; } = string.Empty;
        public string SongName { get; set; } = string.Empty;
        public string SingerName { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string ReleaseDate { get; set; } = string.Empty;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
