using SongManagementApp.Commands;
using SongManagementApp.Model;
using SongManagementApp.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SongManagementApp.ViewModel
{
    public class MainViewModel
    {
        public ObservableCollection<Song> Songs { get; set; }
        public ICommand AddWindowCommand { get; set; }
        public ICommand SearchWindowCommand { get; set; }
        public ICommand DeleteActionCommand { get; set; }
        public MainViewModel()
        {
            Songs = SongManager.GetSongs();
            AddWindowCommand = new RelayCommand(ShowAddWindow, CanShowAddWindow);
            SearchWindowCommand = new RelayCommand(ShowSearchWindow, CanShowSearchWindow);
            DeleteActionCommand = new RelayCommand(DeleteSong, CanDeleteSong);
        }



        //Command của AddWindow 
        private bool CanShowAddWindow(object obj)
        {
            return true;
        }

        private void ShowAddWindow(object obj)
        {
            var MainWindow = (Window)obj;
            AddSong addSong = new AddSong();
            addSong.Owner = MainWindow;
            addSong.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            addSong.Show();
        }

        //Command của SearchWindow 
        private bool CanShowSearchWindow(object obj)
        {
            return true;
        }

        private void ShowSearchWindow(object obj)
        {
            var MainWindow = (Window)obj;
            SearchSong searchSong = new SearchSong();
            searchSong.Owner = MainWindow;
            searchSong.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            searchSong.Show();
        }

        //Command của Delete Window
        private bool CanDeleteSong(object obj)
        {
            return true;
        }

        private void DeleteSong(object obj)
        {
            var songsToDelete = Songs.Where(s => s.IsSelected).ToList(); // Tạo bản sao an toàn

            foreach (var song in songsToDelete)
            {
                Songs.Remove(song); // ✅ Xóa từng bài hát mà không ảnh hưởng vòng lặp
            }
        }
    }
}

