using SongManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SongManagementApp.ViewModel
{
    public class SearchSongViewModel : INotifyPropertyChanged
    {
        public int? ID { get; set; }
        public string SongName { get; set; }
        public string SingerName { get; set; }
        public string Genre { get; set; }
        public string Country { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

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

    }
}
