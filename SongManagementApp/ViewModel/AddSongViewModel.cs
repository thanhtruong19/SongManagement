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
        public MainViewModel mvd = new MainViewModel(); // Tạo một instance của MainViewModel để có thể truy cập ObservableCollection<Song> từ đó
        public ObservableCollection<Song> Songs { get; set; }
        private readonly SongRepository _repo = new SongRepository();
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
           
            AddSongCommand = new AsyncRelayCommand(AddSong, CanAddSong);
        }

        public AddSongViewModel(ObservableCollection<Song> songs) : this() // Gọi constructor không tham số để khởi tạo AddSongViewModel, vì nếu không có dòng này thì sẽ không khởi tạo được AddSongCommand
        {
            Songs = songs; // Nhận đúng đối tượng ObservableCollection<Song> từ MainViewModel để cập nhật giao diện
        }

        private async Task AddSong(object obj)
        {
            //ObservableCollection<Song> getListSong = SongManager.GetSongs();
            
            //lấy ID lớn nhất  
            //int maxID = (getListSong != null && getListSong.Any()) ? getListSong.Max(song => song.ID) + 1 : 1; -> chỗ này không cần nữa
            Song song = new Song() 
            {
                //ID = maxID,
                SongName = this.SongName,
                SingerName = this.SingerName,
                Genre = this.Genre,
                Country = this.Country,
                ReleaseDate = this.ReleaseDate
            };
            await _repo.Add(song);
            Songs.Add(song);
            MessageBox.Show("Thêm bài hát thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            Window addSongWindow = (Window)obj;
            addSongWindow.Close();
        }
        //giải thích tại sao cập nhập :Songs là một ObservableCollection<Song>
        //ObservableCollection<T> triển khai interface INotifyCollectionChanged.
        //Mỗi khi bạn gọi Add(), nó sẽ phát ra sự kiện CollectionChanged.Tương tự với Delete
        private bool CanAddSong(object obj)
        {
            return true;
        }
    }
}
