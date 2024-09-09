using Onion.CleanArchitecture.Net.Application.Features.Products.Commands.CreateProduct;

namespace Onion.CleanArchitecture.Net.Application
{
    public class CreateRangeProductResponse : CreateProductCommand
    {
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
