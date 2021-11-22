using C0AGQP_HFT_2021221.Logic;
using C0AGQP_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace C0AGQP_HFT_2021221.Endpoint.Controllers
{
	[Route("/[controller]")]
	[ApiController]
	public class SongController : ControllerBase
	{
		ISongLogic songLogic;
		public SongController(ISongLogic songLogic)
		{
			this.songLogic = songLogic;
		}
		// GET: /song
		[HttpGet]
		public IEnumerable<Song> Get()
		{
			return songLogic.ReadAll();
		}

		// GET /song/id
		[HttpGet("{id}")]
		public Song Get(int id)
		{
			return songLogic.Read(id);
		}

		// POST /song
		[HttpPost]
		public void Post([FromBody] Song value)
		{
			songLogic.Create(value);
		}

		// PUT /song
		[HttpPut]
		public void Put([FromBody] Song value)
		{
			songLogic.Update(value);
		}

		// DELETE /song/id
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			songLogic.Delete(id);
		}
	}
}
