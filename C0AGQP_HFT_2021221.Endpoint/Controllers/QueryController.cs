using C0AGQP_HFT_2021221.Logic;
using C0AGQP_HFT_2021221.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C0AGQP_HFT_2021221.Endpoint.Controllers
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class QueryController : ControllerBase
	{
		IAlbumLogic albumLogic;
		ISongLogic songLogic;
		public QueryController(IAlbumLogic albumLogic, ISongLogic songLogic)
		{
			this.albumLogic = albumLogic;
			this.songLogic = songLogic;
		}

		// GET: /query/ListAviciiSongs

		[HttpGet]
		public int QueryOne()
		{
			return albumLogic.HowManyDuaLipaAlbums();
		}

		[HttpGet]
		public int QueryTwo()
		{
			return albumLogic.AlbumsFrom2015();
		}

		[HttpGet]
		public int QueryThree()
		{
			return albumLogic.MGKAlbumsFrom2020();
		}

		[HttpGet]
		public IEnumerable<Song> QueryFour()
		{
			return songLogic.FemaleSongs();
		}

		[HttpGet]
		public IEnumerable<Song> QueryFive()
		{
			return songLogic.ListAviciiSongs();
		}

		[HttpGet]
		public IEnumerable<Song> QuerySix()
		{
			return songLogic.SeanPaulDanceHallArray();
		}

		[HttpGet]
		public IEnumerable<Song> QuerySeven()
		{
			return songLogic.MalePopSongs();
		}

		[HttpGet]
		public IEnumerable<Song> QueryEight()
		{
			return songLogic.MGKAlbumsSongs();
		}

		[HttpGet]
		public IEnumerable<Song> QueryNine()
		{
			return songLogic.StoriesSongs();
		}

		[HttpGet]
		public IEnumerable<Song> QueryTen()
		{
			return songLogic.PunkRockSongs();
		}

		[HttpGet]
		public IEnumerable<Song> QueryEleven()
		{
			return songLogic.RitaOraPopSongs();
		}
	}
}
