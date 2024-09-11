using Onion.CleanArchitecture.Net.Domain.Common;

namespace Onion.CleanArchitecture.Net.Domain.Entities.Catalog
{
    public class Product : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
    }
}
