using System.Text;

namespace MusicHub
{
    using System;
    using System.Linq;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            //DbInitializer.ResetDatabase(context);

            //Test your solutions here
            Console.WriteLine(ExportAlbumsInfo(context, 9));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var sb = new StringBuilder();

            var producer = context.Producers
                .Where(p => p.Id == producerId)
                .Select(p => p.Albums
                    .Select(a => new
                    {
                        a.Name,
                        a.ReleaseDate,
                        ProducerName = a.Producer.Name,
                        a.Price,
                        Songs = a.Songs.Select(s => new
                        {
                            s.Name,
                            s.Price,
                            s.Writer
                        }).ToList()
                    })
                    .OrderByDescending(a => a.Price)
                    .ToList())
                .First();

            foreach (var album in producer)
            {
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate:MM/dd/yyyy}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");

                var songs = album.Songs
                    .OrderByDescending(s => s.Name)
                    .ThenBy(s => s.Writer.Name)
                    .ToList();

                for (int i = 0; i < songs.Count; i++)
                {
                    var song = songs[i];

                    sb.AppendLine($"---#{i + 1}");
                    sb.AppendLine($"---SongName: {song.Name}");
                    sb.AppendLine($"---Price: {song.Price:f2}");
                    sb.AppendLine($"---Writer: {song.Writer.Name}");
                }

                sb.AppendLine($"-AlbumPrice: {album.Price:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            throw new NotImplementedException();
        }
    }
}
