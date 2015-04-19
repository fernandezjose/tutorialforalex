namespace CommandPatternAlejandro
{
    public class CreateProductCommand
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
   
    }

    public class UpdateProductCommand
    {
        public string Name { get; set; }
        public int ProductId { get; set; }
    }
}