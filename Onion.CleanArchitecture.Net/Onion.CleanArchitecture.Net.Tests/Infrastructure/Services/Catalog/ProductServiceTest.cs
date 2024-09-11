using FluentAssertions;
using Onion.CleanArchitecture.Net.Application.Interfaces.Services.Catalog;
using Onion.CleanArchitecture.Net.Domain.Entities.Catalog;

namespace Onion.CleanArchitecture.Net.Tests.Infrastructure.Services.Catalog;

[TestFixture]
public class ProductServiceTest : BaseTest
{
    private IProductService _productService;

    [OneTimeSetUp]
    public void SetUp()
    {
        _productService = GetService<IProductService>();
    }

    /// <summary>
    /// Tests the insertion of a product asynchronously.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    /// /// /// /// [Test]
    public async Task InsertProductAsync_ShouldInsertProduct()
    {
        // Arrange
        var product = new Product { Id = 1, Name = "Test Product" };
        // Act
        await _productService.InsertProductAsync(product);
        // Assert
        var insertedProduct = await _productService.GetProductByIdAsync(1);
        insertedProduct.Should().NotBeNull();
    }

    /// <summary>
    /// Tests the get product by identifier asynchronously.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    [Test]
    public async Task GetProductByIdAsync_ShouldReturnProduct()
    {
        // Arrange
        var product = new Product { Id = 1, Name = "Test Product" };
        await _productService.InsertProductAsync(product);
        // Act
        var insertedProduct = await _productService.GetProductByIdAsync(1);
        // Assert
        insertedProduct.Should().NotBeNull();
    }

    /// <summary>
    /// Tests the get products by identifiers asynchronously.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    [Test]
    public async Task GetProductsByIdsAsync_ShouldReturnProducts()
    {
        // Arrange
        var product1 = new Product { Id = 1, Name = "Test Product 1" };
        var product2 = new Product { Id = 2, Name = "Test Product 2" };
        await _productService.InsertProductAsync(product1);
        await _productService.InsertProductAsync(product2);
        var productIds = new[] { 1, 2 };

        // Act
        var products = await _productService.GetProductsByIdsAsync(productIds);

        // Assert
        products.Should().NotBeNull();
        products.Should().HaveCount(2);
        products.Should().Contain(p => p.Id == 1);
        products.Should().Contain(p => p.Id == 2);
    }

    /// <summary>
    /// Tests the update product asynchronously.
    /// </summary>
    [Test]
    public async Task UpdateProductAsync_ShouldUpdateProduct()
    {
        // Arrange
        var product = new Product { Id = 1, Name = "Test Product" };
        await _productService.InsertProductAsync(product);
        product.Name = "Updated Product";

        // Act
        await _productService.UpdateProductAsync(product);

        // Assert
        var updatedProduct = await _productService.GetProductByIdAsync(1);
        updatedProduct.Name.Should().Be("Updated Product");
    }

    /// <summary>
    /// Tests the delete product asynchronously.
    /// </summary>
    [Test]
    public async Task DeleteProductAsync_ShouldDeleteProduct()
    {
        // Arrange
        var product = new Product { Id = 1, Name = "Test Product" };
        await _productService.InsertProductAsync(product);

        // Act
        await _productService.DeleteProductAsync(product);

        // Assert
        var deletedProduct = await _productService.GetProductByIdAsync(1);
        deletedProduct.Should().BeNull();
    }

    /// <summary>
    /// Tests the delete products asynchronously.
    /// </summary>
    [Test]
    public async Task DeleteProductsAsync_ShouldDeleteProducts()
    {
        // Arrange
        var product1 = new Product { Id = 1, Name = "Test Product 1" };
        var product2 = new Product { Id = 2, Name = "Test Product 2" };
        await _productService.InsertProductAsync(product1);
        await _productService.InsertProductAsync(product2);
        var productList = new List<Product> { product1, product2 };

        // Act
        await _productService.DeleteProductsAsync(productList);

        // Assert
        var deletedProduct1 = await _productService.GetProductByIdAsync(1);
        var deletedProduct2 = await _productService.GetProductByIdAsync(2);
        deletedProduct1.Should().BeNull();
        deletedProduct2.Should().BeNull();
    }
}