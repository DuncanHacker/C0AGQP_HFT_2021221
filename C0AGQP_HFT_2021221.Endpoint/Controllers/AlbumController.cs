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
	[Route("[controller]")]
	[ApiController]
	public class AlbumController : ControllerBase
	{
		IAlbumLogic albumLogic;
		public AlbumController(IAlbumLogic albumLogic)
		{
			this.albumLogic = albumLogic;
		}
		// GET: /album
		[HttpGet]
		public IEnumerable<Album> Get()
		{
			return albumLogic.ReadAll();
		}

		// GET /album/id
		[HttpGet("{id}")]
		public Album Get(int id)
		{
			return albumLogic.Read(id);
		}

		// POST /album
		[HttpPost]
		public void Post([FromBody] Album value)
		{
			albumLogic.Create(value);
		}

		// PUT /album
		[HttpPut]
		public void Put([FromBody] Album value)
		{
			albumLogic.Update(value);
		}

		// DELETE /album/id
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			albumLogic.Delete(id);
		}
	}
}
