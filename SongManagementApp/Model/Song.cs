using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongManagementApp.Model
{
    public class Song : INotifyPropertyChanged
    {
        public int ID { get; set; }                  // Mã bài hát
        public string SongName { get; set; }         // Tên bài hát
        public string SingerName { get; set; } = "Unknown";       // Tên ca sĩ
        public string Genre { get; set; } = "Unknown";             // Thể loại nhạc
        public string Country { get; set; } = "Unknown";           // Quốc gia
        public DateTime ReleaseDate { get; set; }    // Ngày phát hành

        private bool _isSelected = false;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
