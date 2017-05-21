
namespace Kladr.Domain
{
    public class Street : Entity
    {
        public virtual string Name { get; set; }
        public virtual string SettlementName { get; set; }
        public virtual string RegionName { get; set; }
        public virtual string Index { get; set; }
    }
}
