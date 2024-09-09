using AutoMapper;
using Onion.CleanArchitecture.Net.Application.DTOs.Email;
using Onion.CleanArchitecture.Net.Application.Features.Emails.Commands.SendMail;
using Onion.CleanArchitecture.Net.Application.Features.Products.Commands.CreateProduct;
using Onion.CleanArchitecture.Net.Application.Features.Products.Queries.GetAllProducts;
using Onion.CleanArchitecture.Net.Domain.Entities;

namespace Onion.CleanArchitecture.Net.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
            CreateMap<SendMailToOneEndPointCommand, SendEmailRequest>();
        }
    }
}
