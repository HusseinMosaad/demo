using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Core.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public bool IsNew
        {
            get { return Id == 0; }
        }
    }
}
