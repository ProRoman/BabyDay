using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyDay.Models.Entity
{
    public interface IEntityModel<out TKey>
    {
        TKey Id { get; }
    }
}
