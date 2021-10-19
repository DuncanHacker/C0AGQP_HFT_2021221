using C0AGQP_HFT_2021221.Data;
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
			var Authors = database.Authors.ToArray();
			var Albums = database.Albums.ToArray();
			var Songs = songrepo.ReadAll();
			
		}
	}
}
