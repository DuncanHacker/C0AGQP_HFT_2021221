using C0AGQP_HFT_2021221.Data;
using C0AGQP_HFT_2021221.Logic;
using C0AGQP_HFT_2021221.Models;
using C0AGQP_HFT_2021221.Repository;
using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace C0AGQP_HFT_2021221.Client
{
	class Program
	{
		static void Main(string[] args)
		{
			#region
			/*SongAuthorAlbumContext database = new SongAuthorAlbumContext();
			ISongRepository songrepo = new SongRepository(database);
			IAlbumRepository albumrepo = new AlbumRepository(database);
			IAuthorRepository authorrepo = new AuthorRepository(database);
			SongLogic songlogic = new SongLogic(songrepo);
			AlbumLogic albumlogic = new AlbumLogic(albumrepo);
			AuthorLogic authorlogic = new AuthorLogic(authorrepo);

			//var Authors = database.Authors.ToArray();
			//var Albums = database.Albums.ToArray();
			//var JustinSongs = songlogic.HowManyJustinSongs();
			//var DuaLipaSongs = songlogic.HowManyDuaLipaSongs();
			//var FutureNostalgiaSongs = albumlogic.HowManySongsInAlbumFutureNostalgia();
			//var AviciiSongList = albumlogic.ListAviciiSongs();
			var FemaleSongList = albumlogic.FemaleSongs();
			//var SeanPaulDancehallArray = albumlogic.SeanPaulDanceHallArray();
			//var MalePopSongList = albumlogic.MalePopSongs();
			//var StoriesSongList = albumlogic.StoriesSongs();
			;*/
			#endregion
			Thread.Sleep(12000);
			MainMenu();	
		}

		static void MainMenu()
		{
			Console.WriteLine("1. Albums List, 2. Authors List, 3. Songs List, 4. - 13. Queries");
			RestService restService = new RestService("http://localhost:29693");
			var albums = restService.Get<Album>("Album");
			var authors = restService.Get<Author>("Author");
			var songs = restService.Get<Song>("Song");
			var q1 = restService.Get<int>("QueryOne");
			var q4 = restService.Get<IEnumerable<Song>>("QueryFour");
			int choice = int.Parse(Console.ReadLine());
			switch (choice)
			{
				case 1:
					foreach (var album in albums)
					{
						Console.WriteLine("Album ID: " + album.Id);
						Console.WriteLine("Album Name: " + album.Name);
						Console.WriteLine("Release Year: " + album.ReleaseYear);
					}
					break;
				case 2:
					foreach (var author in authors)
					{
						Console.WriteLine("Author ID: " + author.Id);
						Console.WriteLine("Author Name: " + author.Name);
					}
					break;
				case 3:
					foreach (var song in songs)
					{
						Console.WriteLine("Song ID: " + song.Id);
						Console.WriteLine("Song Title: " + song.Title);
						Console.WriteLine("Song Genre: " + song.Genre);
					}
					break;
				case 4:
						Console.WriteLine("How many Dua Lipa Songs are there: " + q1);
					break;
				default:
					break;
			}
		}
	}
}
