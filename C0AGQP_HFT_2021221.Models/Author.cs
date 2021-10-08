using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C0AGQP_HFT_2021221.Models
{
	public class Author
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[NotMapped]
		public virtual ICollection<Song> Songs { get; set; }
		public virtual ICollection<Album> Albums { get; set; }
		public Author()
		{
			Songs = new HashSet<Song>();
		}
	}
}
