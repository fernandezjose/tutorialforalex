using FluentNHibernate.Mapping;

namespace CommandPatternAlejandro
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id);
            Component(x => x.Name);
            //Map(x => x.Name);
            Map(x => x.Description);
            Map(x => x.ExpirationDate);
            Map(x => x.IsRawMaterial);
            Map(x => x.Price);
        }
    }

    public class ProductNameMap : ComponentMap<ProductName>
    {
        public ProductNameMap()
        {
            Map(x => x.Name);
        }
    }
}