using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C0AGQP_HFT_2021221.Models
{
	public class Album
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
		public int Name { get; set; }
		[ForeignKey(nameof(Author))]
		public int AuthorId { get; set; }
		public Author Author { get; set; }
		public ICollection<Song> Songs { get; set; }
		public Album()
		{
			Songs = new HashSet<Song>();
		}
	}
}
