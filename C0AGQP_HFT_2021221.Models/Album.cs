using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace C0AGQP_HFT_2021221.Models
{
	public class Album
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[ForeignKey(nameof(Author))]
		public int AuthorId { get; set; }
		[NotMapped]
		[JsonIgnore]
		public virtual Author Author { get; set; }
		[NotMapped]
		[JsonIgnore]
		public virtual ICollection<Song> Songs { get; set; }
		public Album()
		{
			Songs = new HashSet<Song>();
		}
	}
}
