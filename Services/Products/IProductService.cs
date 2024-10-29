using Services.Products.Models.Request;
using Services.Products.Models.Response;

namespace Services.Products;

public interface IProductService
{
    Task<ServiceResult<List<ProductResponse>>> GetTopPriceProductsAsync(int count);
    Task<ServiceResult<List<ProductResponse>>> GetAllAsync();
    Task<ServiceResult<List<ProductResponse>>> GetPagedAllListAsync(int pageNumber, int pageSize);
    Task<ServiceResult<ProductResponse?>> GetByIdAsync(int id);
    Task<ServiceResult<CreateProductResponse>> CreateAsync(CreateProductRequest request);
    Task<ServiceResult> UpdateAsync(int id, UpdateProductRequest request);
    Task<ServiceResult> DeleteAsync(int id);
}