using System.Collections.Generic;

namespace Domain
{
    public class Region : Entity
    {
        public virtual string Name { get; set; }
        public virtual IList<Settlement> Settlements { get; set; }
    }
}
