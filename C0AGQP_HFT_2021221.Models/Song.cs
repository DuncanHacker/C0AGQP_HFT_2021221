using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C0AGQP_HFT_2021221.Models
{
	public class Song
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
		public string Title { get; set; }
		public string Genre { get; set; }
		[ForeignKey(nameof(Author))]
		public string AuthorId { get; set; }
		[NotMapped]
		public virtual Author Author { get; set; }
		[ForeignKey(nameof(Album))]
		public int AlbumId { get; set; }
		public Album Album { get; set; }		
	}
}
