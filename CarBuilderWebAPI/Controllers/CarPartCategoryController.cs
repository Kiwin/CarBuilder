using CarBuilderWebAPI.Interfaces;
using CarBuilderWebAPI.Models;
using CarBuilderWebAPI.Providers;
using CarBuilderWebAPI.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarBuilderWebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarPartCategoryController : ControllerBase
	{
		private ICarPartCategoryRepository _categoryRepository;

		public CarPartCategoryController(ICarPartCategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(CarPart))]
		[ProducesResponseType(400)]
		public IActionResult GetCarParts()
		{
			var carParts = _categoryRepository.GetAll();
			if (carParts == null) return NotFound();
			return new JsonResult(carParts);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(200, Type = typeof(CarPart))]
		[ProducesResponseType(400)]
		public IActionResult GetCarPart(int id)
		{
			var carPart = _categoryRepository.Get(id);
			if (carPart == null) return NotFound();
			return new JsonResult(carPart);
		}

		[HttpPost()]
		[ProducesResponseType(200, Type = typeof(bool))]
		[ProducesResponseType(400)]
		public IActionResult AddCarPart(CarPartCategory category)
		{
			if (category == null) return BadRequest();
			return new JsonResult(_categoryRepository.Add(category));
		}
		[HttpPost("AddCollection")]
		[ProducesResponseType(200, Type = typeof(bool))]
		[ProducesResponseType(400)]
		public IActionResult AddCarParts(ICollection<CarPartCategory> categories)
		{
			if (categories == null) return BadRequest();
			return new JsonResult(_categoryRepository.AddRange(categories));
		}

		[HttpPut()]
		[ProducesResponseType(200, Type = typeof(bool))]
		[ProducesResponseType(400)]
		public IActionResult UpdateCarPart(CarPartCategory category)
		{
			if (category == null) return BadRequest();
			return new JsonResult(_categoryRepository.Update(category));
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(200, Type = typeof(bool))]
		[ProducesResponseType(400)]
		public IActionResult DeleteCarPart(int id)
		{
			return new JsonResult(_categoryRepository.Delete(id));
		}

		[HttpGet("Generate")]
		[ProducesResponseType(200, Type = typeof(IEnumerable<CarPartCategory>))]
		[ProducesResponseType(400)]
		public IActionResult GenerateCarParts()
		{
			return new JsonResult(new CarPartCategoryProvider().CarPartCategories);
		}
	}
}
