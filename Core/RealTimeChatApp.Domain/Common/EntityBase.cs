using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeChatApp.Domain.Common
{
    public class EntityBase : IEntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            IsDeleted = false;
        }


        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
