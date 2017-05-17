using System;

namespace CommandPatternAlejandro
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _repository;

        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public void Handle(UpdateProductCommand command)
        {
            var product = _repository.GetById(command.ProductId);
            product.UpdateName(command.Name);
            _repository.Update(product);
            _repository.Delete(product.Id);
        }
    }
}