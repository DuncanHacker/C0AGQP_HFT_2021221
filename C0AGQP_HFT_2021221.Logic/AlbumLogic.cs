using C0AGQP_HFT_2021221.Models;
using C0AGQP_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C0AGQP_HFT_2021221.Logic
{
	public class AlbumLogic : IAlbumLogic
	{
		IAlbumRepository albumRepo;
		public AlbumLogic(IAlbumRepository albumRepo)
		{
			this.albumRepo = albumRepo;
		}

		public void Create(Album album)
		{
			albumRepo.Create(album);
		}

		public Album Read(int id)
		{
			return albumRepo.Read(id);
		}

		public IEnumerable<Album> ReadAll()
		{
			return albumRepo.ReadAll();
		}

		public void Delete(int id)
		{
			albumRepo.Delete(id);
		}

		public void Update(Album album)
		{
			albumRepo.Update(album);
		}

		public void GroupByAuthors()
		{
			var result = albumRepo.ReadAll()
				.GroupBy(x => x.Author.Name);
		}

		public int HowManySongsInAlbumFutureNostalgia()
		{
			var result = albumRepo.ReadAll().AsEnumerable()
				.SelectMany(y => y.Songs.Where(x => x.Album.Name == "Future Nostalgia (The MoonLight Edition)")).ToList().Count;
			return result;
		}

		public IEnumerable<Song> ListAviciiSongs()
		{
			var result = albumRepo.ReadAll()
				.SelectMany(y => y.Songs.Where(x => x.Author.Name == "Avicii")).ToList();
			return result;
		}

		public IEnumerable<Song> FemaleSongs()
		{
			var result = albumRepo.ReadAll().AsEnumerable()
				.SelectMany(y => y.Songs.Where(x => x.Author.Name == "Dua Lipa" || x.Author.Name == "Rita Ora")).ToList();
			return result;
		}

		public IEnumerable<Song> SeanPaulDanceHallArray()
		{
			var result = albumRepo.ReadAll()
				.SelectMany(y => y.Songs.Where(x => x.Genre == "Dancehall" && x.Author.Name == "Sean Paul")).ToArray();
			return result;
		}

		public IEnumerable<Song> MalePopSongs()
		{
			var result = albumRepo.ReadAll()
				.SelectMany(y => y.Songs.Where(x => (x.Author.Name == "Avicii" || x.Author.Name == "Justin Bieber" ||
				x.Author.Name == "Sean Paul" || x.Author.Name == "Machine Gun Kelly") && x.Genre == "Pop")).ToList();
			return result;
		}

		public IEnumerable<Song> StoriesSongs()
		{
			var result = albumRepo.ReadAll().SelectMany(y => y.Songs.Where(x => x.Album.Name == "Stories")).OrderBy(z => z.Author.Name).ToList();
			return result;
		}
	}
}
