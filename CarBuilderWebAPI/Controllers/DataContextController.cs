using CarBuilderWebAPI.Data;
using CarBuilderWebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarBuilderWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DataContextController : ControllerBase
	{
		private DataContext _dataContext;

		public DataContextController(DataContext dataContext)
		{
			_dataContext = dataContext;
		}

		/* PURELY FOR TESTING PURPOSES */
		[HttpDelete("DELETE_ALL_DATABASE_DATA")]
		[ProducesResponseType(typeof(bool), 200)]
		[ProducesResponseType(500)]
		public IActionResult DeleteAllDatabaseData()
		{
			if (_dataContext.Database.EnsureDeleted()) return Ok(true);
			return Problem(statusCode: 500, detail: "Database could not be deleted.");
		}
	}
}