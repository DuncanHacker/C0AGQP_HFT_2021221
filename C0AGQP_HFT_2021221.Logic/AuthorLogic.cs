using C0AGQP_HFT_2021221.Models;
using C0AGQP_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C0AGQP_HFT_2021221.Logic
{
	public class AuthorLogic
	{
		IAuthorRepository authorRepo;
		public AuthorLogic(IAuthorRepository authorRepo)
		{
			this.authorRepo = authorRepo;
		}

		public void Create(Author author)
		{
			authorRepo.Create(author);
		}

		public Author Read(int id)
		{
			return authorRepo.Read(id);
		}

		public IEnumerable<Author> ReadAll()
		{
			return authorRepo.ReadAll();
		}

		public void Delete(int id)
		{
			authorRepo.Delete(id);
		}

		public void Update(Author author)
		{
			authorRepo.Update(author);
		}
	}
}
