using AutoMapper;
using Repositories.Products;
using Services.Products.Models.Response;

namespace Services.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Product, ProductResponse>().ReverseMap();
    }
    
}