using C0AGQP_HFT_2021221.Models;
using System.Collections.Generic;

namespace C0AGQP_HFT_2021221.Logic
{
	public interface IAlbumLogic
	{
		void Create(Album album);
		void Delete(int id);
		#region
		/*IEnumerable<Song> FemaleSongs();
		void GroupByAuthors();
		int HowManySongsInAlbumFutureNostalgia();
		IEnumerable<Song> ListAviciiSongs();
		IEnumerable<Song> MalePopSongs();				
		IEnumerable<Song> SeanPaulDanceHallArray();
		IEnumerable<Song> StoriesSongs();*/
		#endregion
		Album Read(int id);
		IEnumerable<Album> ReadAll();
		void Update(Album album);
		public int HowManyDuaLipaAlbums();
		public int AlbumsFrom2015();
		public int MGKAlbumsFrom2020();
	}
}