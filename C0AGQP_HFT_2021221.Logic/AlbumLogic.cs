using C0AGQP_HFT_2021221.Models;
using C0AGQP_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C0AGQP_HFT_2021221.Logic
{
	public class AlbumLogic
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
	}
}
