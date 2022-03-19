using C0AGQP_HFT_2021221.Data;
using C0AGQP_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C0AGQP_HFT_2021221.Repository
{
	public class AlbumRepository : IAlbumRepository
	{
		SongAuthorAlbumContext database;
		public AlbumRepository(SongAuthorAlbumContext database)
		{
			this.database = database;
		}

		public void Create(Album album)
		{
			database.Albums.Add(album);
			database.SaveChanges();
		}

		public Album Read(int id)
		{
			return database.Albums.FirstOrDefault(t => t.Id == id);
		}

		public IQueryable<Album> ReadAll()
		{
			return database.Albums;
		}

		public void Delete(int id)
		{
			database.Albums.Remove(Read(id));
			database.SaveChanges();
		}

		public void Update(Album album)
		{
			var oldalbum = Read(album.Id);
			oldalbum.Name = album.Name;
			oldalbum.AuthorId = album.AuthorId;
			database.SaveChanges();
		}
	}
}
