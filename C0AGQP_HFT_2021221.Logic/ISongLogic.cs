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
	}
}