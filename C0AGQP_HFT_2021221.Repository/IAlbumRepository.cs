using C0AGQP_HFT_2021221.Models;
using System.Linq;

namespace C0AGQP_HFT_2021221.Repository
{
	public interface IAlbumRepository
	{
		void Create(Album album);
		void Delete(int id);
		Album Read(int id);
		IQueryable<Album> ReadAll();
		void Update(Album album);
	}
}