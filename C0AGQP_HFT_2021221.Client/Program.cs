using C0AGQP_HFT_2021221.Data;
using C0AGQP_HFT_2021221.Logic;
using C0AGQP_HFT_2021221.Models;
using C0AGQP_HFT_2021221.Repository;
using System;
using System.Linq;

namespace C0AGQP_HFT_2021221.Client
{
	class Program
	{
		static void Main(string[] args)
		{
			SongAuthorAlbumContext database = new SongAuthorAlbumContext();
			ISongRepository songrepo = new SongRepository(database);
			IAlbumRepository albumrepo = new AlbumRepository(database);
			IAuthorRepository authorrepo = new AuthorRepository(database);
			SongLogic songlogic = new SongLogic(songrepo);
			AlbumLogic albumlogic = new AlbumLogic(albumrepo);
			AuthorLogic authorlogic = new AuthorLogic(authorrepo);
			var Authors = database.Authors.ToArray();
			var Albums = database.Albums.ToArray();
			var JustinSongs = songlogic.HowManyJustinSongs();
			var DuaLipaSongs = songlogic.HowManyDuaLipaSongs();
			var FutureNostalgiaSongs = albumlogic.HowManySongsInAlbumFutureNostalgia();
			;
		}
	}
}
