using C0AGQP_HFT_2021221.Models;
using System.Collections.Generic;

namespace C0AGQP_HFT_2021221.Logic
{
	public interface ISongLogic
	{
		void Create(Song song);
		void Delete(int id);
		int HowManyDuaLipaSongs();
		int HowManyJustinSongs();
		Song Read(int id);
		IEnumerable<Song> ReadAll();
		void Update(Song song);
		public IEnumerable<Song> ListAviciiSongs();
		public IEnumerable<Song> FemaleSongs();
		public IEnumerable<Song> SeanPaulDanceHallArray();
		public IEnumerable<Song> MalePopSongs();
		public IEnumerable<Song> MGKAlbumsSongs();
		public IEnumerable<Song> StoriesSongs();
	}
}