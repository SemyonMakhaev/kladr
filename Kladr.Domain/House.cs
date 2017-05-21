
namespace Kladr.Domain
{
    public class House : Entity
    {
        public virtual string Number { get; set; }
        public virtual string StreetName { get; set; }
        public virtual string SettlementName { get; set; }
        public virtual string RegionName { get; set; }
        public virtual string Index { get; set; }
    }
}
