using C0AGQP_HFT_2021221.Data;
using C0AGQP_HFT_2021221.Models;
using System;
using System.Linq;

namespace C0AGQP_HFT_2021221.Client
{
	class Program
	{
		static void Main(string[] args)
		{
			SongAuthorAlbumContext database = new SongAuthorAlbumContext();

			var Authors = database.Authors.ToArray();
			var Albums = database.Albums.ToArray();
			var Songs = database.Songs.ToArray();
			
		}
	}
}
