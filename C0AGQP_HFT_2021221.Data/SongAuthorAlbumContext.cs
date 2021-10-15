using C0AGQP_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C0AGQP_HFT_2021221.Data
{
	public class SongAuthorAlbumContext : DbContext
	{
		public virtual DbSet<Song> Songs { get; set; }
		public virtual DbSet<Author> Authors { get; set; }
		public virtual DbSet<Album> Albums { get; set; }
		public SongAuthorAlbumContext()
		{
			this.Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.
				UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SongAuthorAlbum.mdf;Integrated Security=True");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Song>(entity =>
			{
				entity
				.HasOne(song => song.Author)
				.WithMany(author => author.Songs)
				.HasForeignKey(song => song.AuthorId)
				.OnDelete(DeleteBehavior.Restrict);
			});

			modelBuilder.Entity<Author>(entity =>
			{
				entity
				.HasMany(author => author.Songs)
				.WithOne(song => song.Author)				
				.OnDelete(DeleteBehavior.Restrict);
			});

			modelBuilder.Entity<Album>(entity =>
			{
				entity
				.HasOne(album => album.Author)
				.WithMany(author => author.Albums)
				.HasForeignKey(album => album.AuthorId)
				.OnDelete(DeleteBehavior.Restrict);
			});
		}
	}
}
