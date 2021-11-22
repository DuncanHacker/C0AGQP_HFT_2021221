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
		public QueryController(IAlbumLogic albumLogic)
		{
			this.albumLogic = albumLogic;
		}

		// GET: /query/ListAviciiSongs
		[HttpGet]
		public IEnumerable<Song> QueryOne()
		{
			return albumLogic.FemaleSongs();
		}
	}
}
