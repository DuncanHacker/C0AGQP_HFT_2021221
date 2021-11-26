using C0AGQP_HFT_2021221.Models;
using C0AGQP_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C0AGQP_HFT_2021221.Logic
{
	public class SongLogic : ISongLogic
	{
		ISongRepository songRepo;
		public SongLogic(ISongRepository songRepo)
		{
			this.songRepo = songRepo;
		}

		public void Create(Song song)
		{
			songRepo.Create(song);
		}

		public Song Read(int id)
		{
			return songRepo.Read(id);
		}

		public IEnumerable<Song> ReadAll()
		{
			return songRepo.ReadAll();
		}

		public void Delete(int id)
		{
			songRepo.Delete(id);
		}

		public void Update(Song song)
		{
			songRepo.Update(song);
		}

		public int HowManyJustinSongs()
		{
			var result = songRepo.ReadAll().Where(x => x.Author.Name == "Justin Bieber").Count();
			return result;
		}

		public int HowManyDuaLipaSongs()
		{
			var result = songRepo.ReadAll().Where(x => x.Author.Name == "Dua Lipa").Count();
			return result;
		}

		public int HowManySongInStories()
		{
			var result = songRepo.ReadAll().Where(x => x.Album.Name == "Stories").Count();
			return result;
		}

		public IEnumerable<Song> ListAviciiSongs()
		{
			var result = songRepo.ReadAll().Where(x => x.Author.Name == "Avicii").ToList();
			return result;
		}

		public IEnumerable<Song> FemaleSongs()
		{
			var result = songRepo.ReadAll().Where(x => x.Author.Name == "Dua Lipa" || x.Author.Name == "Rita Ora").ToList();
			return result;
		}

		public IEnumerable<Song> SeanPaulDanceHallArray()
		{
			var result = songRepo.ReadAll().Where(x => x.Genre == "Dancehall" && x.Author.Name == "Sean Paul").ToArray();
			return result;
		}

		public IEnumerable<Song> MalePopSongs()
		{
			var result = songRepo.ReadAll().Where(x => (x.Author.Name == "Avicii" || x.Author.Name == "Justin Bieber" ||
				x.Author.Name == "Sean Paul" || x.Author.Name == "Machine Gun Kelly") && x.Genre == "Pop").ToList();
			return result;
		}

		public IEnumerable<Song> MGKAlbumsSongs()
		{
			var result = songRepo.ReadAll().Where(x => x.Album.Author.Name == "Machine Gun Kelly").ToList();
			return result;
		}

		public IEnumerable<Song> StoriesSongs()
		{
			var result = songRepo.ReadAll().Where(x => x.Album.Name == "Stories").ToArray();
			return result;
		}

	}
}
