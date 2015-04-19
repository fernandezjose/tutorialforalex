namespace CommandPatternAlejandro
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(IUnitOfWork unitOfWork): base(unitOfWork)
        {
            
        }
    }
}