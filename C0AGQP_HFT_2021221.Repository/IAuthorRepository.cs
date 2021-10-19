using C0AGQP_HFT_2021221.Models;
using System.Linq;

namespace C0AGQP_HFT_2021221.Repository
{
	public interface IAuthorRepository
	{
		void Create(Author author);
		void Delete(int id);
		Author Read(int id);
		IQueryable<Author> ReadAll();
		void Update(Author author);
	}
}