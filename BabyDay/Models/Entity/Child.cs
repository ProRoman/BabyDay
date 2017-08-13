using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BabyDay.Models.Entity
{
    public class Child
    {
        public int ChildId { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime BirthDate { get; set; }

        public int ParentId { get; set; }

        public virtual Parent Parent { get; set; }
    }
}