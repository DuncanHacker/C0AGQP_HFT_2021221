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
	[Route("[controller]")]
	[ApiController]
	public class AuthorController : ControllerBase
	{
		IAuthorLogic authorLogic;
		IHubContext<SignalRHub> hub;
		public AuthorController(IAuthorLogic authorLogic, IHubContext<SignalRHub> hub)
		{
			this.authorLogic = authorLogic;
			this.hub = hub;
		}
		// GET: /author
		[HttpGet]
		public IEnumerable<Author> Get()
		{
			return authorLogic.ReadAll();
		}

		// GET /author/id
		[HttpGet("{id}")]
		public Author Get(int id)
		{
			return authorLogic.Read(id);
		}

		// POST /author
		[HttpPost]
		public void Post([FromBody] Author value)
		{
			authorLogic.Create(value);
			hub.Clients.All.SendAsync("AuthorCreated", value);
		}

		// PUT /author
		[HttpPut]
		public void Put([FromBody] Author value)
		{
			authorLogic.Update(value);
			hub.Clients.All.SendAsync("AuthorUpdated", value);
		}

		// DELETE /author/id
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			var authorToDelete = authorLogic.Read(id);
			authorLogic.Delete(id);
			hub.Clients.All.SendAsync("AuthorDeleted", authorToDelete);
		}
	}
}
