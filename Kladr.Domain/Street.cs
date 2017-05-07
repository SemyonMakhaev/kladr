using System.Collections.Generic;

namespace Domain
{
    public class Street : Entity
    {
        public virtual string Name { get; set; }
        public virtual IList<House> Houses { get; set; }
    }
}
