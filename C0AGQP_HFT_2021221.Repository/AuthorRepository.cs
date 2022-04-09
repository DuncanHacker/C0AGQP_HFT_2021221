using C0AGQP_HFT_2021221.Data;
using C0AGQP_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C0AGQP_HFT_2021221.Repository
{
	public class AuthorRepository : IAuthorRepository
	{
		SongAuthorAlbumContext database;
		public AuthorRepository(SongAuthorAlbumContext database)
		{
			this.database = database;
		}

		public void Create(Author author)
		{
			database.Authors.Add(author);
			database.SaveChanges();
		}

		public Author Read(int id)
		{
			return database.Authors.FirstOrDefault(t => t.Id == id);
		}

		public IQueryable<Author> ReadAll()
		{
			return database.Authors;
		}

		public void Delete(int id)
		{
			database.Remove(Read(id));
			database.SaveChanges();
		}

		public void Update(Author author)
		{
			var oldauthor = Read(author.Id);
			oldauthor.Id = author.Id;
			oldauthor.Name = author.Name;
			database.SaveChanges();
		}
	}
}
