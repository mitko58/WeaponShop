using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeaponShop.Models
{
    public class WeaponCategory
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }
       [StringLength(200,ErrorMessage ="Description must be below 200 characters")]
        public string Description { get; set; }
        
        [Display(Name ="Position")]
        public int SortableId { get; set; }
        public string CreatedBy { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }
        
        public virtual ICollection<WeaponCategory> Weapons { get; set; }
    }
}