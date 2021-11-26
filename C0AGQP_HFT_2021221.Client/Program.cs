using C0AGQP_HFT_2021221.Data;
using C0AGQP_HFT_2021221.Logic;
using C0AGQP_HFT_2021221.Models;
using C0AGQP_HFT_2021221.Repository;
using ConsoleTools;
using System;
using System.Linq;
using System.Threading;

namespace C0AGQP_HFT_2021221.Client
{
	class Program
	{
		static void Main(string[] args)
		{
			//#region
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
			;
			#endregion
			/*Thread.Sleep(12000);
			RestService restService = new RestService("http://localhost:29693");
			var albums = restService.Get<Album>("Album");
			var menu = new ConsoleMenu(args, level: 0)
				.Add("One", () => Console.WriteLine(albums))
				.Add("Change me", (thisMenu) => thisMenu.CurrentItem.Name = "I am changed!")
				.Add("Close", ConsoleMenu.Close)
				.Add("Exit", () => Environment.Exit(0))
				.Configure(config =>
					{
						config.Selector = "--> ";
						config.EnableFilter = false;
						config.Title = "Main menu";
						config.EnableWriteTitle = true;
						config.EnableBreadcrumb = true;
					});

			menu.Show();*/
			;
		}
	}
}
