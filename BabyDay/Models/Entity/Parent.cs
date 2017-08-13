using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BabyDay.Models.Entity
{
    public class Parent
    {
        public Parent()
        {
            Children = new List<Child>();
        }

        public int ParentId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime BirthDate { get; set; }

        public string UserProfileId { get; set; }

        [ForeignKey("UserProfileId")]
        public virtual ApplicationUser UserProfile { get; set; }

        //virtual - lazy loading
        public virtual ICollection<Child> Children { get; set; }
    }
}