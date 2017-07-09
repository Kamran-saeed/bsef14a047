using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    [MetadataType(typeof(ItemMetaData))]
    public partial class Item
    {
        
    }
    public class ItemMetaData
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Brand Name")]
        public string brandName { get; set; }
        [Required]
        [Display(Name = "Item Name")]
        public string itemName { get; set; }
        [Required]
        [Display(Name = "Color")]
        public string color { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        public int quantity { get; set; }
        [Required]
        [Display(Name = "Price")]
        public int price { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string description { get; set; }
        [Required]
        public int categoryId { get; set; }
    }
}
