using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMS_CURD.Data;
using IMS_CURD.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IMS_CURD.Controllers
{
    [Route("api/InventoryMaster")]
    [ApiController]
	public class InventoryMasterController : ControllerBase
	{
		private readonly IDataRepository<Inventory> _dataRepository;
		//private readonly InventoryContext _context;
		private readonly ILogger<InventoryMasterController> _logger;

		public InventoryMasterController(IDataRepository<Inventory> dataRepository)
		{
			_dataRepository = dataRepository;
		}

		//public InventoryMasterController(ILogger<InventoryMasterController> logger)
		//{
		//	_logger = logger;
		//}
		//public InventoryMasterController(InventoryContext context)
		//{
		//	_context = context;
		//}

		// GET: api/Inventory
		[HttpGet]
		public  IActionResult Get()
		{
			IEnumerable<Inventory> inventories = _dataRepository.GetAll();
			return  Ok(inventories);
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











		//// GET: api/InventoryMasterAPI

		//[HttpGet]
		//[Route("Inventory")]
		//public IEnumerable<Inventory> GetInventoryMaster()
		//{
		//	return _context.InventoryMaster;

		//}


		//// POST: api/InventoryMasterAPI
		//[HttpPost]
		//public async Task<IActionResult> PostInventoryMaster([FromBody] Inventory InventoryMaster)
		//{
		//	if (!ModelState.IsValid)
		//	{
		//		return BadRequest(ModelState);
		//	}

		//	_context.InventoryMaster.Add(InventoryMaster);
		//	try
		//	{
		//		await _context.SaveChangesAsync();
		//	}
		//	catch (DbUpdateException)
		//	{
		//		if (InventoryMasterExists(InventoryMaster.InventoryID))
		//		{
		//			return new StatusCodeResult(StatusCodes.Status409Conflict);
		//		}
		//		else
		//		{
		//			throw;
		//		}
		//	}

		//	return CreatedAtAction("GetInventoryMaster", new { id = InventoryMaster.InventoryID }, InventoryMaster);
		//}
		//private bool InventoryMasterExists(int id)
		//{
		//	return _context.InventoryMaster.Any(e => e.InventoryID == id);
		//}



		//// PUT: api/InventoryMasterAPI/2
		//[HttpPut("{id}")]
		//public async Task<IActionResult> PutInventoryMaster([FromRoute] int id, [FromBody] Inventory InventoryMaster)
		//{
		//	if (!ModelState.IsValid)
		//	{
		//		return BadRequest(ModelState);
		//	}

		//	if (id != InventoryMaster.InventoryID)
		//	{
		//		return BadRequest();
		//	}

		//	_context.Entry(InventoryMaster).State = EntityState.Modified;

		//	try
		//	{
		//		await _context.SaveChangesAsync();
		//	}
		//	catch (DbUpdateConcurrencyException)
		//	{
		//		if (!InventoryMasterExists(id))
		//		{
		//			return NotFound();
		//		}
		//		else
		//		{
		//			throw;
		//		}
		//	}

		//	return NoContent();
		//}


		//// DELETE: api/InventoryMasterAPI/2
		//[HttpDelete("{id}")]
		//public async Task<IActionResult> DeleteInventoryMaster([FromRoute] int id)
		//{
		//	if (!ModelState.IsValid)
		//	{
		//		return BadRequest(ModelState);
		//	}

		//	Inventory InventoryMaster = await _context.InventoryMaster.SingleOrDefaultAsync(m => m.InventoryID == id);
		//	if (InventoryMaster == null)
		//	{
		//		return NotFound();
		//	}

		//	_context.InventoryMaster.Remove(InventoryMaster);
		//	await _context.SaveChangesAsync();

		//	return Ok(InventoryMaster);
		//}
	}
}
