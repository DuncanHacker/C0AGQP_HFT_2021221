using C0AGQP_HFT_2021221.Models;
using System.Collections.Generic;

namespace C0AGQP_HFT_2021221.Logic
{
	public interface IAuthorLogic
	{
		void Create(Author author);
		void Delete(int id);
		Author Read(int id);
		IEnumerable<Author> ReadAll();
		void Update(Author author);
	}
}