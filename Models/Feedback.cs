using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeaponShop.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public int WeaponsId { get; set; }
        public virtual Weapons Weapons { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishedOnSite { get; set; }
        public bool isEnabled { get; set; }
        public long Reads { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}