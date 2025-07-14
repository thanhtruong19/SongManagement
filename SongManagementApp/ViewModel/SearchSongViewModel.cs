using SongManagementApp.Commands;
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
    //public class SearchSongViewModel : INotifyPropertyChanged
    //{
    //    public int? ID { get; set; }
    //    public string SongName { get; set; }
    //    public string SingerName { get; set; }
    //    public string Genre { get; set; }
    //    public string Country { get; set; }
    //    public DateTime? StartDate { get; set; }
    //    public DateTime? EndDate { get; set; }

    //    private ObservableCollection<Song> _filteredSongs;
    //    public ObservableCollection<Song> FilteredSongs
    //    {
    //        get => _filteredSongs;
    //        set 
    //        { 
    //            _filteredSongs = value; 
    //            OnPropertyChanged(nameof(FilteredSongs)); 
    //        }
    //    }

    //    //  Command 
    //    public ICommand SearchCommand { get; set; }
    //    public SearchSongViewModel()
    //    {
    //        FilteredSongs = new ObservableCollection<Song>();
    //        SearchCommand = new RelayCommand(_ => Search());
    //    }

    //    private void Search()
    //    {
    //        var all = SongManager.GetSongs();

    //        var query = all.Where(s =>
    //            // ID filter
    //            (!ID.HasValue || s.ID == ID.Value)
    //            // Text filters (ignore case, contains)
    //            && (string.IsNullOrWhiteSpace(SongName) || s.SongName.IndexOf(SongName, StringComparison.OrdinalIgnoreCase) >= 0)
    //            && (string.IsNullOrWhiteSpace(SingerName) || s.SingerName.IndexOf(SingerName, StringComparison.OrdinalIgnoreCase) >= 0)
    //            && (string.IsNullOrWhiteSpace(Genre) || s.Genre.IndexOf(Genre, StringComparison.OrdinalIgnoreCase) >= 0)
    //            && (string.IsNullOrWhiteSpace(Country) || s.Country.IndexOf(Country, StringComparison.OrdinalIgnoreCase) >= 0)
    //            // Date range
    //            && (!StartDate.HasValue || s.ReleaseDate >= StartDate.Value)
    //            && (!EndDate.HasValue || s.ReleaseDate <= EndDate.Value)
    //        );

    //        // Cập nhật kết quả
    //        FilteredSongs.Clear();
    //        foreach (var song in query)
    //            FilteredSongs.Add(song);
    //    }

}
