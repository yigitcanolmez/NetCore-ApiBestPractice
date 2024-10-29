using Repositories.Products;
using System.Net;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services.Products.Models.Request;
using Services.Products.Models.Response;

namespace Services.Products;

public class ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork) : IProductService
{
    public async Task<ServiceResult<List<ProductResponse>>> GetTopPriceProductsAsync(int count)
    {
        var products = await productRepository.GetTopPriceProductsAsync(count);

        var productsAsDto = products.Select(x => new ProductResponse(x.Id, x.Name,
            x.Price, x.Stock)).ToList();

        return ServiceResult<List<ProductResponse>>.Success(productsAsDto);
    }

    public async Task<ServiceResult<List<ProductResponse>>> GetAllAsync()
    {
        var products = await productRepository.GetAll().ToListAsync();

        var productAsDto = products.Select(x => new ProductResponse(x.Id, x.Name, x.Price, x.Stock)).ToList();

        return ServiceResult<List<ProductResponse>>.Success(productAsDto);
    }

    public async Task<ServiceResult<List<ProductResponse>>> GetPagedAllListAsync(int pageNumber, int pageSize)
    {
        var products = await productRepository.GetAll()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var productAsDto = products.Select(x => new ProductResponse(x.Id, x.Name, x.Price, x.Stock)).ToList();

        return ServiceResult<List<ProductResponse>>.Success(productAsDto);
    }

    public async Task<ServiceResult<ProductResponse?>> GetByIdAsync(int id)
    {
        var product = await productRepository.GetByIdAsync(id);

        if (product is null)
            return ServiceResult<ProductResponse?>.Fail("Product not found", HttpStatusCode.NotFound);

        var productAsDto = new ProductResponse(product.Id, product.Name, product.Price, product.Stock);

        return ServiceResult<ProductResponse?>.Success(productAsDto!);
    }

    public async Task<ServiceResult<CreateProductResponse>> CreateAsync(CreateProductRequest request)
    {
        var product = new Product
        {
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock
        };

        await productRepository.AddAsync(product);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult<CreateProductResponse>.SuccessAsCreated(new CreateProductResponse(product.Id),
            $"api/products/{product.Id}"
        );
    }

    public async Task<ServiceResult> UpdateAsync(int id, UpdateProductRequest request)
    {
        var product = await productRepository.GetByIdAsync(id);

        if (product is null)
        {
            return ServiceResult.Fail("Product Not Found", HttpStatusCode.NotFound);
        }

        product.Name = request.Name;
        product.Price = request.Price;
        product.Stock = request.Stock;

        productRepository.Update(product);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success(HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var product = await productRepository.GetByIdAsync(id);

        if (product is null)
        {
            return ServiceResult.Fail("Product Not Found", HttpStatusCode.NotFound);
        }

        productRepository.Delete(product);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success(HttpStatusCode.NoContent);
    }
}