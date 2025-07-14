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

        public async Task<IEnumerable<Song>> SearchAsync(int? id, string? SongName, string? SingerName, string? genre, string? country, DateTime? start, DateTime? end)
        {
            return await _ctx.Songs
                .Where(s =>
                    // ID filter
                    (!id.HasValue || s.ID == id.Value) //kiểm tra nếu id có giá trị thì so sánh với ID của bài hát
                   // Text filters (treat null or empty as “no filter”)
                    && (string.IsNullOrWhiteSpace(SongName) //kiểm tra songName có giá trị hay không, nếu có thì so sánh với tên bài hát, không quan trọng chữ hoa chữ thường
                        || s.SongName.Contains(SongName))
                    && (string.IsNullOrWhiteSpace(SingerName) //kiểm tra songName có giá trị hay không, nếu có thì so sánh với tên bài hát, không quan trọng chữ hoa chữ thường
                        || s.SingerName.Contains(SingerName))
                    && (string.IsNullOrWhiteSpace(genre)
                        || s.Genre.Contains(genre))
                    && (string.IsNullOrWhiteSpace(country)
                        || s.Country.Contains(country))
                    // Date range
                    && (!start.HasValue || s.ReleaseDate >= start.Value)// Nếu không nhập StartDate thì !start.HasValue = true → bỏ qua điều kiện, Nếu nhập StartDate rồi thì chỉ lấy những bản ghi có ReleaseDate ≥ start.
                    && (!end.HasValue || s.ReleaseDate <= end.Value) // tương tự
                )
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
