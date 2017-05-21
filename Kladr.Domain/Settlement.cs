
namespace Kladr.Domain
{
    public class Settlement : Entity
    {
        public virtual string Name { get; set; }
        public virtual string RegionName { get; set; }
        public virtual string Index { get; set; }
    }
}
