using C0AGQP_HFT_2021221.Models;
using System.Collections.Generic;

namespace C0AGQP_HFT_2021221.Logic
{
	public interface IAlbumLogic
	{
		void Create(Album album);
		void Delete(int id);
		IEnumerable<Song> FemaleSongs();
		void GroupByAuthors();
		int HowManySongsInAlbumFutureNostalgia();
		IEnumerable<Song> ListAviciiSongs();
		IEnumerable<Song> MalePopSongs();
		Album Read(int id);
		IEnumerable<Album> ReadAll();
		IEnumerable<Song> SeanPaulDanceHallArray();
		IEnumerable<Song> StoriesSongs();
		void Update(Album album);
	}
}