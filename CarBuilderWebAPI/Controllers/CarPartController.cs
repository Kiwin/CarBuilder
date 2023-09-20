using CarBuilderWebAPI.Interfaces;
using CarBuilderWebAPI.Models;
using CarBuilderWebAPI.Providers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarBuilderWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarPartController : ControllerBase
	{
		private ICarPartRepository _carPartRepository;

		public CarPartController(ICarPartRepository carPartRepository)
		{
			_carPartRepository = carPartRepository;
		}

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(CarPart))]
		[ProducesResponseType(400)]
		public IActionResult GetCarParts()
		{
			var carParts = _carPartRepository.GetAll();
			if (carParts == null) return NotFound();
			return new JsonResult(carParts);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(200, Type = typeof(CarPart))]
		[ProducesResponseType(400)]
		public IActionResult GetCarPart(int id)
		{
			var carPart = _carPartRepository.Get(id);
			if (carPart == null) return NotFound();
			return new JsonResult(carPart);
		}

		[HttpPost()]
		[ProducesResponseType(200, Type = typeof(bool))]
		[ProducesResponseType(400)]
		public IActionResult AddCarPart(CarPart carPart)
		{
			if (carPart == null) return BadRequest();
			return new JsonResult(_carPartRepository.Add(carPart));
		}
		[HttpPost("AddCollection")]
		[ProducesResponseType(200, Type = typeof(bool))]
		[ProducesResponseType(400)]
		public IActionResult AddCarParts(ICollection<CarPart> carParts)
		{
			if (carParts == null) return BadRequest();
			return new JsonResult(_carPartRepository.AddRange(carParts));
		}

		[HttpPut()]
		[ProducesResponseType(200, Type = typeof(bool))]
		[ProducesResponseType(400)]
		public IActionResult UpdateCarPart(CarPart carPart)
		{
			if (carPart == null) return BadRequest();
			return new JsonResult(_carPartRepository.Update(carPart));
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(200, Type = typeof(bool))]
		[ProducesResponseType(400)]
		public IActionResult DeleteCarPart(int id)
		{
			return new JsonResult(_carPartRepository.Delete(id));
		}

		[HttpGet("Generate")]
		[ProducesResponseType(200, Type = typeof(ICollection<CarPart>))]
		[ProducesResponseType(400)]
		public IActionResult GenerateCarParts(IEnumerable<CarPartCategory> partCategories)
		{
			return new JsonResult(new CarPartProvider(partCategories).CarParts);
		}
	}
}
