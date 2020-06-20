using System;
using System.Collections.Generic;
using IMS_CURD.Data;
using IMS_CURD.Repository;
using Microsoft.AspNetCore.Mvc;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using Microsoft.Extensions.Logging;

namespace IMS_CURD.Controllers
{
	[Route("api/InventoryMaster")]
	[ApiController]
	public class InventoryMasterController : ControllerBase
	{
		private readonly IDataRepository<Inventory> _dataRepository;

		public InventoryMasterController(IDataRepository<Inventory> dataRepository)
		{
			_dataRepository = dataRepository;

		}

		[HttpGet]
		public IActionResult Get()
		{
			IEnumerable<Inventory> inventories = _dataRepository.GetAll();
			return Ok(inventories);
		}

		// GET: api/Inventory/1
		[HttpGet("{id}", Name = "Get")]
		public IActionResult Get(long id)
		{
			Inventory inventory = _dataRepository.Get(id);

			if (inventory == null)
			{
				return NotFound("The inventory record couldn't be found.");
			}

			return Ok(inventory);

		}

		// POST: api/inventory
		[HttpPost]
		public IActionResult Post([FromBody] Inventory inventory)
		{

			if (inventory == null)
			{
				return BadRequest("Inventory is null.");
			}

			_dataRepository.Add(inventory);
			return CreatedAtRoute(
				  "Get",
				  new { Id = inventory.InventoryID },
				  inventory);
		}
		// PUT: api/Inventory/5
		[HttpPut("{id}")]
		public IActionResult Put(long id, [FromBody] Inventory inventory)
		{
			if (inventory == null)
			{
				return BadRequest("inventory is null.");
			}

			Inventory inventoryToUpdate = _dataRepository.Get(id);
			if (inventoryToUpdate == null)
			{
				return NotFound("The inventory record couldn't be found.");
			}

			_dataRepository.Update(inventoryToUpdate, inventory);
			return NoContent();
		}

		// DELETE: api/inventory/2
		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			Inventory inventory = _dataRepository.Get(id);
			if (inventory == null)
			{
				return NotFound("The inventory record couldn't be found.");
			}

			_dataRepository.Delete(inventory);
			return NoContent();

		}
	}
}
