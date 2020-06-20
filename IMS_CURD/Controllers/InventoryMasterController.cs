using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IMS_CURD.Data;
using IMS_CURD.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLog;

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
		public  IActionResult Get()
		{
			try
			{
				IEnumerable<Inventory> inventories = _dataRepository.GetAll();
				return Ok(inventories);
			}
			catch(Exception e)
            {
				throw e;
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
			}catch(Exception e) { throw e; }

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
			catch (Exception e) { throw e; }
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
			catch (Exception e) { throw e; }
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
			catch (Exception e) { throw e; }
		}

		}
}
