using C0AGQP_HFT_2021221.Logic;
using C0AGQP_HFT_2021221.Models;
using C0AGQP_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C0AGQP_HFT_2021221.Test
{
	[TestFixture]
	public class Tester
	{
		AlbumLogic albumLogic;
		public Tester()
		{
			var MockAlbumRepo = new Mock<IAlbumRepository>();
			albumLogic = new AlbumLogic(MockAlbumRepo.Object);

			Author avicii = new Author()
			{
				Name = "Avicii"
			};
			Author dualipa = new Author()
			{
				Name = "Dua Lipa"
			};
			Author seanpaul = new Author()
			{
				Name = "Sean Paul"
			};
			Author bieber = new Author()
			{
				Name = "Justin Bieber"
			};
			var songs = new List<Song>()
			{
				new Song()
				{
					Title = "Wake Me Up",
					Author = avicii,
					Genre = "EDM"
				},
				new Song()
				{
					Title = "IDGAF",
					Author = dualipa,
					Genre = "Pop"
				},
				new Song()
				{
					Title = "Temperature",
					Author = seanpaul,
					Genre = "Dancehall"
				},
				new Song()
				{
					Title = "What Do You Mean",
					Author = bieber,
					Genre = "Pop"
				},
				new Song()
				{
					Title = "Sunset Jesus",
					Author = avicii,
					Genre = "EDM"
				}
			};
			var albums = new List<Album>()
			{
				new Album()
				{
					Name = "True",
					Author = avicii,
					Songs = songs
				},
				new Album()
				{
					Name = "Dua Lipa",
					Author = dualipa,
					Songs = songs
				},
				new Album()
				{
					Name = "The Trinity",
					Author = seanpaul,
					Songs = songs
				},
				new Album()
				{
					Name = "Stories",
					Author = avicii,
					Songs = songs
				}
			}.AsQueryable();		

			MockAlbumRepo.Setup((t) => t.ReadAll()).Returns(albums);
		}

		[Test]
		public void AviciiSongTest()
		{			
			var result = albumLogic.ListAviciiSongs().ToArray();
			Assert.That(result[0].Title, Is.EqualTo("Wake Me Up"));
		}
		[Test]
		public void FemaleSongsTest()
		{
			var result = albumLogic.FemaleSongs().ToArray();
			Assert.That(result[0].Title, Is.EqualTo("IDGAF"));
		}
		[Test]
		public void SeanPaulDanceHallTest()
		{
			var result = albumLogic.SeanPaulDanceHallArray().ToArray();
			Assert.That(result[0].Title, Is.EqualTo("Temperature"));
		}
		[Test]
		public void MalePopSongTest()
		{
			var result = albumLogic.MalePopSongs().ToArray();
			Assert.That(result[0].Title, Is.EqualTo("What Do You Mean"));
		}
		[Test]
		public void StoriesSongsTest()
		{
			var result = albumLogic.StoriesSongs().ToArray();
			Assert.That(result[0].Title, Is.EqualTo("Sunset Jesus"));
		}

	}
	
}
