using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMS_CURD.Data
{
   
    public class Inventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InventoryID { get; set; }

        [Required]
        [Display(Name = "ItemName")]
        public string ItemName { get; set; }

        [Required]
        [Display(Name = "StockQty")]
        public int StockQty { get; set; }

        [Required]
        [Display(Name = "ReorderQty")]
        public int ReorderQty { get; set; }

        public int PriorityStatus { get; set; }
    }
}
