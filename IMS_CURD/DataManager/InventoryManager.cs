using IMS_CURD.Data;
using IMS_CURD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMS_CURD.DataManager
{
    public class InventoryManager : IDataRepository<Inventory>
    {
        readonly InventoryContext _inventoryContext;


        public InventoryManager(InventoryContext context)
        {
            _inventoryContext = context;
        }

        public IEnumerable<Inventory> GetAll()
        {
            return _inventoryContext.InventoryMaster.ToList();
        }

        public Inventory Get(long id)
        {
            try
            {
                return _inventoryContext.InventoryMaster
                      .FirstOrDefault(i => i.InventoryID == id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void Add(Inventory entity)
        {
            try
            {
                _inventoryContext.InventoryMaster.Add(entity);
                _inventoryContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void Update(Inventory inventory, Inventory entity)
        {
            try
            {
                inventory.InventoryID = entity.InventoryID;
                inventory.ItemName = entity.ItemName;
                inventory.StockQty = entity.StockQty;
                inventory.ReorderQty = entity.ReorderQty;
                inventory.PriorityStatus = entity.PriorityStatus;
                _inventoryContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void Delete(Inventory inventory)
        {
            try
            {
                _inventoryContext.InventoryMaster.Remove(inventory);
                _inventoryContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
    
