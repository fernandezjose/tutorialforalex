using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace CommandPatternAlejandro
{
    public class Product: AggregateRoot
    {
        public virtual ProductName Name { get; protected set; }

        public virtual Decimal Price{ get; protected set; }

        public virtual string Description { get; protected set; }

        public virtual DateTime ExpirationDate { get; protected set; }

        public virtual bool IsRawMaterial { get; protected set; }

        public virtual void UpdateName(string name)
        {
            this.Name = new ProductName(name);
        }

        protected Product()
        {
            
        }

        protected Product(string name, decimal price)
        {
            Name = new ProductName(name);
            Description = Name.GetCrazyFormatting();
        }

        public static Product CreateProduct(string name, decimal price)
        {
            return new Product(name, price);
        }
    }

    public class ProductName
    {
        public ProductName(string name)
        {
            this.Name = name;
        }

        protected ProductName()
        {
            
        }
        public string Name { get; set; }

        public string GetCrazyFormatting()
        {
            var x = from t in Name
                select Name.IndexOf(t)/2 == 0 ? t : 'x';
            return String.Concat(x);
        }
    }
}
