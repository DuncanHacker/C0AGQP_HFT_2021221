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
			Author ritaora = new Author() { Id = 4, Name = "Rita Ora" };
			Author seanpaul = new Author() { Id = 5, Name = "Sean Paul" };
			Author avicii = new Author() { Id = 6, Name = "Avicii" };
			
			Album purpose = new Album() { Id = 1, Name = "Purpose", AuthorId = bieber.Id };
			Album ticketstomydownfall = new Album() { Id = 2, Name = "Tickets to my Downfall", AuthorId = mgk.Id };
			Album futurenostalgia = new Album() { Id = 3, Name = "Future Nostalgia (The Moonlight Edition)", AuthorId = dualipa.Id };
			Album phoenix = new Album() { Id = 4, Name = "Phoenix", AuthorId = ritaora.Id };
			Album thetrinity = new Album() { Id = 5, Name = "The Trinity", AuthorId = seanpaul.Id };
			Album stories = new Album() { Id = 6, Name = "Stories", AuthorId = avicii.Id };

			Song loveyourself = new Song() { Id = 1, Title = "Love Yourself", AuthorId = bieber.Id, Genre = "Pop", AlbumId = purpose.Id };
			Song bloodyvalentine = new Song() { Id = 2, Title = "Bloody Valentine", AuthorId = mgk.Id, Genre = "Punk Rock", AlbumId = ticketstomydownfall.Id };
			Song levitating = new Song() { Id = 3, Title = "Levitating", AuthorId = dualipa.Id, Genre = "Pop", AlbumId = futurenostalgia.Id };
			Song loveagain = new Song() { Id = 4, Title = "Love Again", AuthorId = dualipa.Id, Genre = "Pop", AlbumId = futurenostalgia.Id };
			Song imperialblaze = new Song() { Id = 5, Title = "Imperial Blaze", AuthorId = seanpaul.Id, Genre = "Dancehall", AlbumId = thetrinity.Id };
			Song wellbeburnin = new Song() { Id = 6, Title = "We'll Be Burnin", AuthorId = seanpaul.Id, Genre = "Dancehall", AlbumId = thetrinity.Id };
			Song everblazin = new Song() { Id = 7, Title = "Ever Blazin", AuthorId = seanpaul.Id, Genre = "Dancehall", AlbumId = thetrinity.Id };
			Song yoursong = new Song() { Id = 8, Title = "Your Song", AuthorId = ritaora.Id, Genre = "Pop", AlbumId = phoenix.Id };
			Song lonelytogether = new Song() { Id = 9, Title = "Lonely Together", AuthorId = ritaora.Id, Genre = "Pop", AlbumId = phoenix.Id };
			Song sunsetjesus = new Song() { Id = 10, Title = "Sunset Jesus", AuthorId = avicii.Id, Genre = "EDM", AlbumId = stories.Id };
			Song somewhereinstockholm = new Song() { Id = 11, Title = "Somewhere In Stockholm", AuthorId = avicii.Id, Genre = "EDM", AlbumId = stories.Id };
			Song waitingforlove = new Song() { Id = 12, Title = "Waiting For Love", AuthorId = avicii.Id, Genre = "EDM", AlbumId = stories.Id };
			Song citylights = new Song() { Id = 13, Title = "City Lights", AuthorId = avicii.Id, Genre = "EDM", AlbumId = stories.Id };

			modelBuilder.Entity<Author>().HasData(bieber, mgk, dualipa, ritaora, seanpaul, avicii);
			modelBuilder.Entity<Album>().HasData(purpose, ticketstomydownfall, futurenostalgia, phoenix, thetrinity, stories);
			modelBuilder.Entity<Song>().HasData(loveyourself, bloodyvalentine, levitating, loveagain, imperialblaze,
				wellbeburnin, everblazin, yoursong, lonelytogether, sunsetjesus, somewhereinstockholm, waitingforlove, citylights);
		} 

	}
}
