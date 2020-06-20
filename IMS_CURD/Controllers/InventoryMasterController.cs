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
		private readonly ILogger<InventoryMasterController> _logger;
		public InventoryMasterController(IDataRepository<Inventory> dataRepository, ILogger<InventoryMasterController> logger)
		{
			_dataRepository = dataRepository;
			_logger = logger;
		}
		
		[HttpGet]
		public  IActionResult Get()
		{
			try
			{
				IEnumerable<Inventory> inventories = _dataRepository.GetAll();
				return Ok(inventories);
			}
			catch(Exception ex)
            {
				_logger.LogError($"Something went wrong: {ex}");				
				return StatusCode(500, "Internal server error");
			}
		}

		// GET: api/Inventory/1
		[HttpGet("{id}", Name = "Get")]
		public IActionResult Get(long id)
		{
			try
			{
				Inventory inventory = _dataRepository.Get(id);

				if (inventory == null)
				{
					return NotFound("The inventory record couldn't be found.");
				}

				return Ok(inventory);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong: {ex}");
				return StatusCode(500, "Internal server error");
			}

		}

		// POST: api/inventory
		[HttpPost]
		public IActionResult Post([FromBody] Inventory inventory)
		{
			try
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
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong: {ex}");
				return StatusCode(500, "Internal server error");
			}
		}
		// PUT: api/Inventory/5
		[HttpPut("{id}")]
		public IActionResult Put(long id, [FromBody] Inventory inventory)
		{
			try
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
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong: {ex}");
				return StatusCode(500, "Internal server error");
			}
		}
		// DELETE: api/inventory/2
		[HttpDelete("{id}")]
		public IActionResult Delete(long id)
		{
			try
			{
				Inventory inventory = _dataRepository.Get(id);
				if (inventory == null)
				{
					return NotFound("The inventory record couldn't be found.");
				}

				_dataRepository.Delete(inventory);
				return NoContent();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong: {ex}");
				return StatusCode(500, "Internal server error");
			}
		}

		}
}
