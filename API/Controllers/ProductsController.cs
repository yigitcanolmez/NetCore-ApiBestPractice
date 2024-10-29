using Microsoft.AspNetCore.Mvc;
using Services.Products;
using Services.Products.Models.Request;

namespace API.Controllers;

[Route("[controller]")]
[ApiController]
public class ProductsController(IProductService productService) : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        CreateActionResult(await productService.GetAllAsync());

    [HttpGet("{pageNumber:int}/{pageSize:int}")]
    public async Task<IActionResult> GetPagedAllList(int pageNumber, int pageSize) =>
        CreateActionResult(await productService.GetPagedAllListAsync(pageNumber, pageSize));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id) =>
        CreateActionResult(await productService.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductRequest request) =>
        CreateActionResult(await productService.CreateAsync(request));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateProductRequest request) =>
        CreateActionResult(await productService.UpdateAsync(id, request));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) =>
        CreateActionResult(await productService.DeleteAsync(id));
}