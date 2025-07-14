using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongManagementApp.Model
{
    public class SongRepository
    {
        private readonly SongDbContext _ctx;

        public SongRepository()
        {
            _ctx = new SongDbContext();
        }

        public ObservableCollection<Song> GetAll()
        {
            // Load toàn bộ từ DB
            var list = _ctx.Songs
                           .AsNoTracking()       // nếu bạn không track thay đổi tự động
                           .ToList();
            return new ObservableCollection<Song>(list);
        }

        public async Task Add(Song song)
        {
            _ctx.Songs.Add(song); //hàm add này là add trực tiếp vào DbSet<Song> chứ không phải add vào ObservableCollection
            await _ctx.SaveChangesAsync(); //bắt buộc await
        }

        public async Task Delete(IEnumerable<Song> songs)
        {
            _ctx.Songs.RemoveRange(songs);
            await _ctx.SaveChangesAsync();
        }

        public async Task Update(Song song)
        {
            _ctx.Songs.Update(song);
            await _ctx.SaveChangesAsync();
        }
    }
}
