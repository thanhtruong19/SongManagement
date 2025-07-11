using SongManagement.Models;
using System.ComponentModel;

namespace SongManagement.ViewModel
{
    public class AddSongViewModel : INotifyPropertyChanged
    {
        public Song NewSong { get; set; } = new Song(); // Binding trực tiếp vào Song

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
