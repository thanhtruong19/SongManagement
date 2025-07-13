using SongManagementApp.Commands;
using SongManagementApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SongManagementApp.ViewModel
{

    class AddSongViewModel
    {
        public ICommand AddSongCommand { get; set; }

        //cái đống dưới này để hứng data được binding từ giao diện trả về
        public int? ID { get; set; }               // Mã bài hát, lưu ý là nếu không gán gì cho ID thì nó sẽ mặc định là 0 , có ? thì biến thành null
        public string SongName { get; set; }         // Tên bài hát
        public string SingerName { get; set; }       // Tên ca sĩ
        public string Genre { get; set; }            // Thể loại nhạc
        public string Country { get; set; }          // Quốc gia
        public DateTime ReleaseDate { get; set; } = new DateTime(2000, 1, 1);    // Ngày phát hành



        public AddSongViewModel()
        {
            
            AddSongCommand = new RelayCommand(AddSong, CanAddSong);
        }

        private void AddSong(object obj)
        {
            ObservableCollection<Song> getListSong = SongManager.GetSongs();
            
            //lấy ID lớn nhất  
            int maxID = (getListSong != null && getListSong.Any()) ? getListSong.Max(song => song.ID) + 1 : 1;
            Song song = new Song() 
            {
                ID = maxID,
                SongName = this.SongName,
                SingerName = this.SingerName,
                Genre = this.Genre,
                Country = this.Country,
                ReleaseDate = this.ReleaseDate
            };
            SongManager.AddSongs(song);

            Window addSongWindow = (Window)obj;
            addSongWindow.Close();

        }

        private bool CanAddSong(object obj)
        {
            return true;
        }
    }
}
