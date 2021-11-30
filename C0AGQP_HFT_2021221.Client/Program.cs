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
			MainMenu();a
		}

		static void MainMenu()
		{
			Console.WriteLine("1. Albums List, 2. Authors List, 3. Songs List, 4. Queries, 5. Post, 6. Put, 7. Delete");
			RestService restService = new RestService("http://localhost:29693");
			#region RestServiceData
			var albums = restService.Get<Album>("Album");
			var authors = restService.Get<Author>("Author");
			var songs = restService.Get<Song>("Song");
			int choice = int.Parse(Console.ReadLine());
			var q1 = restService.GetSingle<int>("query/QueryOne");
			var q2 = restService.GetSingle<int>("query/QueryTwo");
			var q3 = restService.GetSingle<int>("query/QueryThree");
			var q4 = restService.Get<Song>("query/QueryFour");			
			var q5 = restService.Get<Song>("query/QueryFive");
			var q6 = restService.Get<Song>("query/QuerySix");
			var q7 = restService.Get<Song>("query/QuerySeven");
			var q8 = restService.Get<Song>("query/QueryEight");
			var q9 = restService.Get<Song>("query/QueryNine");
			var q10 = restService.Get<Song>("query/QueryTen");
			var q11 = restService.Get<Song>("query/QueryEleven");
			#endregion
			switch (choice)
			{
				#region TablesPrinting
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
				#endregion
				#region QueryPrinting
				case 4:					
					Console.WriteLine("How many Dua Lipa Albums: " + q1);
					Console.WriteLine("Albums from 2015: " + q2);
					Console.WriteLine("MGK Albums from 2020: " + q3);
					Console.WriteLine();
					Console.WriteLine("Female Song Titles: ");
					foreach (var song in q4)
					{
						Console.WriteLine(song.Title); 
					}
					Console.WriteLine();
					Console.WriteLine("Avicii Songs: ");
					foreach (var song in q5)
					{
						Console.WriteLine(song.Title);
					}
					Console.WriteLine();
					Console.WriteLine("Sean Paul Dancehall Songs: ");
					foreach (var song in q6)
					{
						Console.WriteLine(song.Title);
					}
					Console.WriteLine();
					Console.WriteLine("Male Pop Songs: ");
					foreach (var song in q7)
					{
						Console.WriteLine(song.Title);
					}
					Console.WriteLine();
					Console.WriteLine("Machine Gun Kelly's Album's Songs: ");
					foreach (var song in q8)
					{
						Console.WriteLine(song.Title);
					}
					Console.WriteLine();
					Console.WriteLine("Stories Songs: ");
					foreach (var song in q9)
					{
						Console.WriteLine(song.Title);
					}
					Console.WriteLine();
					Console.WriteLine("Punk Rock Songs: ");
					foreach (var song in q10)
					{
						Console.WriteLine(song.Title);
					}
					Console.WriteLine();
					Console.WriteLine("Rita Ora Pop Songs: ");
					foreach (var song in q11)
					{
						Console.WriteLine(song.Title);
					}
					break;
				#endregion
				case 5:
					Console.WriteLine("Posting Author -> Miki Matsubara");
					restService.Post(new Author()
					{
						Name = "Miki Matsubara"
					}, "Author");
					break;
				case 6:
					Console.WriteLine("Updating Author -> Miki Matsubara");
					restService.Put(new Author()
					{
						Id = 6,
						Name = "Miki Matsubara",
					}, "Author");
					break;
				case 7:
					Console.WriteLine("Deleting MGK");
					restService.Delete(2,"Author");
					break;
				default:
					break;
			}
		}
	}
}
