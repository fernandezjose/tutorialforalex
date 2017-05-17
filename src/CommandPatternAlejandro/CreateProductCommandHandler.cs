using System;

namespace CommandPatternAlejandro
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        private readonly IProductRepository _repository;

        public CreateProductCommandHandler(IProductRepository repository )
        {
            _repository = repository;
        }
        public void Handle(CreateProductCommand command)
        {
            var product = Product.CreateProduct(command.Name, command.Price);

            _repository.Create(product);
        }
    }
}