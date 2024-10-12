using Microsoft.EntityFrameworkCore;
using InventoryHub.Data;
using InventoryHub.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
namespace InventoryHub;

public static class ProductItemEndpoints
{
    public static void MapProductItemEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/ProductItem").WithTags(nameof(ProductItem));

        group.MapGet("/", async (InventoryHubContext db) =>
        {
            return await db.ProductItem.ToListAsync();
        })
        .WithName("GetAllProductItems")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<ProductItem>, NotFound>> (Guid id, InventoryHubContext db) =>
        {
            return await db.ProductItem.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is ProductItem model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetProductItemById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (Guid id, ProductItem productItem, InventoryHubContext db) =>
        {
            var affected = await db.ProductItem
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, productItem.Id)
                    .SetProperty(m => m.Name, productItem.Name)
                    .SetProperty(m => m.Description, productItem.Description)
                    .SetProperty(m => m.Price, productItem.Price)
                    .SetProperty(m => m.QuantityInStock, productItem.QuantityInStock)
                    .SetProperty(m => m.SKU, productItem.SKU)
                    .SetProperty(m => m.Category, productItem.Category)
                    .SetProperty(m => m.CreatedAt, productItem.CreatedAt)
                    .SetProperty(m => m.IsActive, productItem.IsActive)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateProductItem")
        .WithOpenApi();

        group.MapPost("/", async (ProductItem productItem, InventoryHubContext db) =>
        {
            db.ProductItem.Add(productItem);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/ProductItem/{productItem.Id}",productItem);
        })
        .WithName("CreateProductItem")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (Guid id, InventoryHubContext db) =>
        {
            var affected = await db.ProductItem
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteProductItem")
        .WithOpenApi();
    }
}
