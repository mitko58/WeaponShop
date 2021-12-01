using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeaponShop.Models
{
    public class Weapons
    {
        public int Id { get; set; }
        public int WeaponCategoryId { get; set; }
        public virtual WeaponCategory WeaponCategory { get; set; }

        [Required]
        [StringLength(100,MinimumLength = 5)]
        public string Name { get; set; }
       
        public string Description { get; set; }
       
        public int Calibre { get; set; }
        [Required]
        public double Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishedOnSite { get; set; }
        public bool isEnabled { get; set; }
    }
}