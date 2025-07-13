using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongManagementApp.Model
{
    class SongManager
    {
        public static ObservableCollection<Song> _SongData = new ObservableCollection<Song>()
        {
            new Song { ID = 1, SongName = "Evermore", SingerName = "Taylor Swift", Genre = "Indie Folk", Country = "USA", ReleaseDate = new DateTime(2020, 12, 11) },
            new Song { ID = 2, SongName = "Blue Bird", SingerName = "Ikimono Gakari", Genre = "J-Pop", Country = "Japan", ReleaseDate = new DateTime(2008, 4, 23)}
        };

        public static ObservableCollection<Song> GetSongs()
        {
            return _SongData;
        }
        public static void AddSongs(Song song)
        {
            _SongData.Add(song);
        }
    }
}
