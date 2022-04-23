using C0AGQP_HFT_2021221.Endpoint.Services;
using C0AGQP_HFT_2021221.Logic;
using C0AGQP_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
		IHubContext<SignalRHub> hub;
		public SongController(ISongLogic songLogic, IHubContext<SignalRHub> hub)
		{
			this.songLogic = songLogic;
			this.hub = hub;
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
			hub.Clients.All.SendAsync("SongCreated", value);
		}

		// PUT /song
		[HttpPut]
		public void Put([FromBody] Song value)
		{
			songLogic.Update(value);
			hub.Clients.All.SendAsync("SongUpdated", value);
		}

		// DELETE /song/id
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			var songToDelete = songLogic.Read(id);
			songLogic.Delete(id);
			hub.Clients.All.SendAsync("SongDeleted", songToDelete);
		}
	}
}
