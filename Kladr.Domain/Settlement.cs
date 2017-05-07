using System.Collections.Generic;

namespace Domain
{
    public class Settlement : Entity
    {
        public virtual string Name { get; set; }
        public virtual IList<Street> Streets { get; set; }
    }
}
