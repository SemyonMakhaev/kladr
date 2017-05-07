using System.Collections.Generic;

namespace Domain
{
    public class House : Entity
    {
        public virtual string Number { get; set; }
        public virtual IList<Flat> Flats { get; set; }
    }
}
