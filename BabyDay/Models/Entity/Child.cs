using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BabyDay.Models.Entity
{
    public class Child : IEntityModel<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime BirthDate { get; set; }

        public int ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual Parent Parent { get; set; }
    }
}