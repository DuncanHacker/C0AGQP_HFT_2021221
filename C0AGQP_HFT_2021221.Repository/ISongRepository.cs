using C0AGQP_HFT_2021221.Models;
using System.Linq;

namespace C0AGQP_HFT_2021221.Repository
{
	public interface ISongRepository
	{
		void Create(Song song);
		void Delete(int id);
		Song Read(int id);
		IQueryable<Song> ReadAll();
		void Update(Song song);
	}
}