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

			Author bieber = new Author() { Id = 1, Name = "Justin Bieber" };
			Author mgk = new Author() { Id = 2, Name = "Machine Gun Kelly" };
			Author dualipa = new Author() { Id = 3, Name = "Dua Lipa" };
			 
			Album purpose = new Album() { Id = 1, Name = "Purpose", AuthorId = bieber.Id };
			Album ticketstomydownfall = new Album() { Id = 2, Name = "Tickets to my Downfall", AuthorId = mgk.Id };
			Album futurenostalgia = new Album() { Id = 3, Name = "Future Nostalgia (The Moonlight Edition)", AuthorId = dualipa.Id };

			Song loveyourself = new Song() { Id = 1, Title = "Love Yourself", AuthorId = bieber.Id, Genre = "Pop", AlbumId = purpose.Id };
			Song bloodyvalentine = new Song() { Id = 2, Title = "Bloody Valentine", AuthorId = mgk.Id, Genre = "Punk Rock", AlbumId = ticketstomydownfall.Id };
			Song levitating = new Song() { Id = 3, Title = "Levitating", AuthorId = dualipa.Id, Genre = "Pop", AlbumId = futurenostalgia.Id };
			Song loveagain = new Song() { Id = 4, Title = "Love Again", AuthorId = dualipa.Id, Genre = "Pop", AlbumId = futurenostalgia.Id };

			modelBuilder.Entity<Author>().HasData(bieber, mgk, dualipa);
			modelBuilder.Entity<Album>().HasData(purpose, ticketstomydownfall, futurenostalgia);
			modelBuilder.Entity<Song>().HasData(loveyourself, bloodyvalentine, levitating, loveagain);
		} 

	}
}
