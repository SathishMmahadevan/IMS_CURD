using IMS_CURD.Data;
using IMS_CURD.Repository;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace IMS_CURD.DataManager
{
    public class InventoryManager : IDataRepository<Inventory>
    {
        readonly InventoryContext _inventoryContext;
        private readonly IDistributedCache redisCache;

        public InventoryManager(InventoryContext context, IDistributedCache cache)
        {
            _inventoryContext = context;
            this.redisCache = cache;
        }


        public IEnumerable<Inventory> GetAll()
        {
            try
            {
                List<Inventory> inventories;
                string jsonInventories = redisCache.GetString("reddisCacheInventories");
                if (string.IsNullOrEmpty(jsonInventories))
                {
                    inventories = _inventoryContext.InventoryMaster.ToList();
                    jsonInventories = JsonSerializer.Serialize<List<Inventory>>(inventories);
                    var options = new DistributedCacheEntryOptions();
                    options.SetAbsoluteExpiration(DateTimeOffset.Now.AddMinutes(1));
                    redisCache.SetString("reddisCacheInventories", jsonInventories, options);
                }

                JsonSerializerOptions opt = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                };
                List<Inventory> data = JsonSerializer.Deserialize<List<Inventory>>(jsonInventories, opt);
                return data;
            }
            catch (StackExchange.Redis.RedisConnectionException)
            {
                return Enumerable.Empty<Inventory>();
            }
        }

        
        


        public Inventory Get(long id)
        {
            
                return _inventoryContext.InventoryMaster
                      .FirstOrDefault(i => i.InventoryID == id);
            
            
        }

        public void Add(Inventory entity)
        {
           
                _inventoryContext.InventoryMaster.Add(entity);
                _inventoryContext.SaveChanges();
            
            
        }

        public void Update(Inventory inventory, Inventory entity)
        {
           
                inventory.InventoryID = entity.InventoryID;
                inventory.ItemName = entity.ItemName;
                inventory.StockQty = entity.StockQty;
                inventory.ReorderQty = entity.ReorderQty;
                inventory.PriorityStatus = entity.PriorityStatus;
                _inventoryContext.SaveChanges();
            }
           
        

        public void Delete(Inventory inventory)
        {
                _inventoryContext.InventoryMaster.Remove(inventory);
                _inventoryContext.SaveChanges();           
            
        }
    }
}
    
