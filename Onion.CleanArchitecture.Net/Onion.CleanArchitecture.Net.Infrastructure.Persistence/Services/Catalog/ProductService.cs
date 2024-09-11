using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Onion.CleanArchitecture.Net.Application.Interfaces;
using Onion.CleanArchitecture.Net.Application.Interfaces.Services.Catalog;
using Onion.CleanArchitecture.Net.Domain;
using Onion.CleanArchitecture.Net.Domain.Entities.Catalog;
using Onion.CleanArchitecture.Net.Domain.Entities.Discounts;
using Onion.CleanArchitecture.Net.Domain.Entities.Orders;
using Onion.CleanArchitecture.Net.Domain.Entities.Shipping;
using Onion.CleanArchitecture.Net.Domain.Entities.Stores;
using Onion.CleanArchitecture.Net.Domain.Models;

namespace Onion.CleanArchitecture.Net.Infrastructure.Persistence.Services.Catalog;

/// <summary>
/// Product service
/// </summary>
public partial class ProductService : IProductService
{
    #region Fields
    protected readonly IRepository<Product> _productRepository;
    #endregion

    #region Ctor
    public ProductService(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }
    #endregion

    #region Utilities

    /// <summary>
    /// Applies the low stock activity to specified product by the total stock quantity
    /// </summary>
    /// <param name="product">Product</param>
    /// <param name="totalStock">Total stock</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    protected virtual async Task ApplyLowStockActivityAsync(Product product, int totalStock)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets SKU, Manufacturer part number and GTIN
    /// </summary>
    /// <param name="product">Product</param>
    /// <param name="attributesXml">Attributes in XML format</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the sKU, Manufacturer part number, GTIN
    /// </returns>
    protected virtual async Task<(string sku, string manufacturerPartNumber, string gtin)> GetSkuMpnGtinAsync(Product product, string attributesXml)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get stock message for a product with attributes
    /// </summary>
    /// <param name="product">Product</param>
    /// <param name="attributesXml">Attributes in XML format</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the message
    /// </returns>
    protected virtual async Task<string> GetStockMessageForAttributesAsync(Product product, string attributesXml)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get stock message
    /// </summary>
    /// <param name="product">Product</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the message
    /// </returns>
    protected virtual async Task<string> GetStockMessageAsync(Product product)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Reserve the given quantity in the warehouses.
    /// </summary>
    /// <param name="product">Product</param>
    /// <param name="quantity">Quantity, must be negative</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    protected virtual async Task ReserveInventoryAsync(Product product, int quantity)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Unblocks the given quantity reserved items in the warehouses
    /// </summary>
    /// <param name="product">Product</param>
    /// <param name="quantity">Quantity, must be positive</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    protected virtual async Task UnblockReservedInventoryAsync(Product product, int quantity)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets cross-sell products by product identifier
    /// </summary>
    /// <param name="productIds">The first product identifiers</param>
    /// <param name="showHidden">A value indicating whether to show hidden records</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the cross-sell products
    /// </returns>
    protected virtual async Task<IList<CrossSellProduct>> GetCrossSellProductsByProductIdsAsync(int[] productIds, bool showHidden = false)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets ratio of useful and not useful product reviews 
    /// </summary>
    /// <param name="productReview">Product review</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the result
    /// </returns>
    protected virtual async Task<(int usefulCount, int notUsefulCount)> GetHelpfulnessCountsAsync(ProductReview productReview)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Inserts a product review helpfulness record
    /// </summary>
    /// <param name="productReviewHelpfulness">Product review helpfulness record</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    protected virtual async Task InsertProductReviewHelpfulnessAsync(ProductReviewHelpfulness productReviewHelpfulness)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    #endregion


    #region Products

    /// <summary>
    /// Delete a product
    /// </summary>
    /// <param name="product">Product</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task DeleteProductAsync(Product product)
    {
        await _productRepository.DeleteAsync(product);
    }

    /// <summary>
    /// Delete products
    /// </summary>
    /// <param name="products">Products</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task DeleteProductsAsync(IList<Product> products)
    {
        await _productRepository.DeleteAsync(products);
    }

    /// <summary>
    /// Gets all products displayed on the home page
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the products
    /// </returns>
    public virtual async Task<IList<Product>> GetAllProductsDisplayedOnHomepageAsync()
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets product
    /// </summary>
    /// <param name="productId">Product identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the product
    /// </returns>
    public virtual async Task<Product> GetProductByIdAsync(int productId)
    {
        return await _productRepository.GetByIdAsync(productId, cache => default);
    }

    /// <summary>
    /// Get products by identifiers
    /// </summary>
    /// <param name="productIds">Product identifiers</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the products
    /// </returns>
    public virtual async Task<IList<Product>> GetProductsByIdsAsync(int[] productIds)
    {
        return await _productRepository.GetByIdsAsync(productIds, cache => default, false);
    }

    /// <summary>
    /// Inserts a product
    /// </summary>
    /// <param name="product">Product</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task InsertProductAsync(Product product)
    {
        await _productRepository.InsertAsync(product);
    }

    /// <summary>
    /// Updates the product
    /// </summary>
    /// <param name="product">Product</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task UpdateProductAsync(Product product)
    {
        await _productRepository.UpdateAsync(product);
    }

    /// <summary>
    /// Gets featured products by a category identifier
    /// </summary>
    /// <param name="categoryId">Category identifier</param>
    /// <param name="storeId">Store identifier; 0 if you want to get all records</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the list of featured products
    /// </returns>
    public virtual async Task<IList<Product>> GetCategoryFeaturedProductsAsync(int categoryId, int storeId = 0)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets featured products by manufacturer identifier
    /// </summary>
    /// <param name="manufacturerId">Manufacturer identifier</param>
    /// <param name="storeId">Store identifier; 0 if you want to get all records</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the list of featured products
    /// </returns>
    public virtual async Task<IList<Product>> GetManufacturerFeaturedProductsAsync(int manufacturerId, int storeId = 0)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets products which marked as new
    /// </summary>
    /// <param name="storeId">Store identifier; 0 if you want to get all records</param>
    /// <param name="pageIndex">Page index</param>
    /// <param name="pageSize">Page size</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the list of new products
    /// </returns>
    public virtual async Task<IPagedList<Product>> GetProductsMarkedAsNewAsync(int storeId = 0, int pageIndex = 0, int pageSize = int.MaxValue)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get number of product (published and visible) in certain category
    /// </summary>
    /// <param name="categoryIds">Category identifiers</param>
    /// <param name="storeId">Store identifier; 0 to load all records</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the number of products
    /// </returns>
    public virtual async Task<int> GetNumberOfProductsInCategoryAsync(IList<int> categoryIds = null, int storeId = 0)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Search products
    /// </summary>
    /// <param name="pageIndex">Page index</param>
    /// <param name="pageSize">Page size</param>
    /// <param name="categoryIds">Category identifiers</param>
    /// <param name="manufacturerIds">Manufacturer identifiers</param>
    /// <param name="storeId">Store identifier; 0 to load all records</param>
    /// <param name="vendorId">Vendor identifier; 0 to load all records</param>
    /// <param name="warehouseId">Warehouse identifier; 0 to load all records</param>
    /// <param name="productType">Product type; 0 to load all records</param>
    /// <param name="visibleIndividuallyOnly">A values indicating whether to load only products marked as "visible individually"; "false" to load all records; "true" to load "visible individually" only</param>
    /// <param name="excludeFeaturedProducts">A value indicating whether loaded products are marked as featured (relates only to categories and manufacturers); "false" (by default) to load all records; "true" to exclude featured products from results</param>
    /// <param name="priceMin">Minimum price; null to load all records</param>
    /// <param name="priceMax">Maximum price; null to load all records</param>
    /// <param name="productTagId">Product tag identifier; 0 to load all records</param>
    /// <param name="keywords">Keywords</param>
    /// <param name="searchDescriptions">A value indicating whether to search by a specified "keyword" in product descriptions</param>
    /// <param name="searchManufacturerPartNumber">A value indicating whether to search by a specified "keyword" in manufacturer part number</param>
    /// <param name="searchSku">A value indicating whether to search by a specified "keyword" in product SKU</param>
    /// <param name="searchProductTags">A value indicating whether to search by a specified "keyword" in product tags</param>
    /// <param name="languageId">Language identifier (search for text searching)</param>
    /// <param name="filteredSpecOptions">Specification options list to filter products; null to load all records</param>
    /// <param name="orderBy">Order by</param>
    /// <param name="showHidden">A value indicating whether to show hidden records</param>
    /// <param name="overridePublished">
    /// null - process "Published" property according to "showHidden" parameter
    /// true - load only "Published" products
    /// false - load only "Unpublished" products
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the products
    /// </returns>
    public virtual async Task<IPagedList<Product>> SearchProductsAsync(
        int pageIndex = 0,
        int pageSize = int.MaxValue,
        IList<int> categoryIds = null,
        IList<int> manufacturerIds = null,
        int storeId = 0,
        int vendorId = 0,
        int warehouseId = 0,
        ProductType? productType = null,
        bool visibleIndividuallyOnly = false,
        bool excludeFeaturedProducts = false,
        decimal? priceMin = null,
        decimal? priceMax = null,
        int productTagId = 0,
        string keywords = null,
        bool searchDescriptions = false,
        bool searchManufacturerPartNumber = true,
        bool searchSku = true,
        bool searchProductTags = false,
        int languageId = 0,
        IList<SpecificationAttributeOption> filteredSpecOptions = null,
        ProductSortingEnum orderBy = ProductSortingEnum.Position,
        bool showHidden = false,
        bool? overridePublished = null)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets products by product attribute
    /// </summary>
    /// <param name="productAttributeId">Product attribute identifier</param>
    /// <param name="pageIndex">Page index</param>
    /// <param name="pageSize">Page size</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the products
    /// </returns>
    public virtual async Task<IPagedList<Product>> GetProductsByProductAttributeIdAsync(int productAttributeId,
        int pageIndex = 0, int pageSize = int.MaxValue)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets associated products
    /// </summary>
    /// <param name="parentGroupedProductId">Parent product identifier (used with grouped products)</param>
    /// <param name="storeId">Store identifier; 0 to load all records</param>
    /// <param name="vendorId">Vendor identifier; 0 to load all records</param>
    /// <param name="showHidden">A value indicating whether to show hidden records</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the products
    /// </returns>
    public virtual async Task<IList<Product>> GetAssociatedProductsAsync(int parentGroupedProductId,
        int storeId = 0, int vendorId = 0, bool showHidden = false)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Update product review totals
    /// </summary>
    /// <param name="product">Product</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task UpdateProductReviewTotalsAsync(Product product)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get low stock products
    /// </summary>
    /// <param name="vendorId">Vendor identifier; pass null to load all records</param>
    /// <param name="loadPublishedOnly">Whether to load published products only; pass null to load all products, pass true to load only published products, pass false to load only unpublished products</param>
    /// <param name="pageIndex">Page index</param>
    /// <param name="pageSize">Page size</param>
    /// <param name="getOnlyTotalCount">A value in indicating whether you want to load only total number of records. Set to "true" if you don't want to load data from database</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the products
    /// </returns>
    public virtual async Task<IPagedList<Product>> GetLowStockProductsAsync(int? vendorId = null, bool? loadPublishedOnly = true,
        int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get low stock product combinations
    /// </summary>
    /// <param name="vendorId">Vendor identifier; pass null to load all records</param>
    /// <param name="loadPublishedOnly">Whether to load combinations of published products only; pass null to load all products, pass true to load only published products, pass false to load only unpublished products</param>
    /// <param name="pageIndex">Page index</param>
    /// <param name="pageSize">Page size</param>
    /// <param name="getOnlyTotalCount">A value in indicating whether you want to load only total number of records. Set to "true" if you don't want to load data from database</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the product combinations
    /// </returns>
    public virtual async Task<IPagedList<ProductAttributeCombination>> GetLowStockProductCombinationsAsync(int? vendorId = null, bool? loadPublishedOnly = true,
        int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a product by SKU
    /// </summary>
    /// <param name="sku">SKU</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the product
    /// </returns>
    public virtual async Task<Product> GetProductBySkuAsync(string sku)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a products by SKU array
    /// </summary>
    /// <param name="skuArray">SKU array</param>
    /// <param name="vendorId">Vendor ID; 0 to load all records</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the products
    /// </returns>
    public async Task<IList<Product>> GetProductsBySkuAsync(string[] skuArray, int vendorId = 0)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Update HasTierPrices property (used for performance optimization)
    /// </summary>
    /// <param name="product">Product</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task UpdateHasTierPricesPropertyAsync(Product product)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Update HasDiscountsApplied property (used for performance optimization)
    /// </summary>
    /// <param name="product">Product</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task UpdateHasDiscountsAppliedAsync(Product product)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets number of products by vendor identifier
    /// </summary>
    /// <param name="vendorId">Vendor identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the number of products
    /// </returns>
    public async Task<int> GetNumberOfProductsByVendorIdAsync(int vendorId)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Parse "required product Ids" property
    /// </summary>
    /// <param name="product">Product</param>
    /// <returns>A list of required product IDs</returns>
    public virtual int[] ParseRequiredProductIds(Product product)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get a value indicating whether a product is available now (availability dates)
    /// </summary>
    /// <param name="product">Product</param>
    /// <param name="dateTime">Datetime to check; pass null to use current date</param>
    /// <returns>Result</returns>
    public virtual bool ProductIsAvailable(Product product, DateTime? dateTime = null)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get a list of allowed quantities (parse 'AllowedQuantities' property)
    /// </summary>
    /// <param name="product">Product</param>
    /// <returns>Result</returns>
    public virtual int[] ParseAllowedQuantities(Product product)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get total quantity
    /// </summary>
    /// <param name="product">Product</param>
    /// <param name="useReservedQuantity">
    /// A value indicating whether we should consider "Reserved Quantity" property 
    /// when "multiple warehouses" are used
    /// </param>
    /// <param name="warehouseId">
    /// Warehouse identifier. Used to limit result to certain warehouse.
    /// Used only with "multiple warehouses" enabled.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the result
    /// </returns>
    public virtual async Task<int> GetTotalStockQuantityAsync(Product product, bool useReservedQuantity = true, int warehouseId = 0)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get number of rental periods (price ratio)
    /// </summary>
    /// <param name="product">Product</param>
    /// <param name="startDate">Start date</param>
    /// <param name="endDate">End date</param>
    /// <returns>Number of rental periods</returns>
    public virtual int GetRentalPeriods(Product product, DateTime startDate, DateTime endDate)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Formats the stock availability/quantity message
    /// </summary>
    /// <param name="product">Product</param>
    /// <param name="attributesXml">Selected product attributes in XML format (if specified)</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the stock message
    /// </returns>
    public virtual async Task<string> FormatStockMessageAsync(Product product, string attributesXml)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Formats SKU
    /// </summary>
    /// <param name="product">Product</param>
    /// <param name="attributesXml">Attributes in XML format</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the sKU
    /// </returns>
    public virtual async Task<string> FormatSkuAsync(Product product, string attributesXml = null)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Formats manufacturer part number
    /// </summary>
    /// <param name="product">Product</param>
    /// <param name="attributesXml">Attributes in XML format</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the manufacturer part number
    /// </returns>
    public virtual async Task<string> FormatMpnAsync(Product product, string attributesXml = null)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Formats GTIN
    /// </summary>
    /// <param name="product">Product</param>
    /// <param name="attributesXml">Attributes in XML format</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the gTIN
    /// </returns>
    public virtual async Task<string> FormatGtinAsync(Product product, string attributesXml = null)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Formats start/end date for rental product
    /// </summary>
    /// <param name="product">Product</param>
    /// <param name="date">Date</param>
    /// <returns>Formatted date</returns>
    public virtual string FormatRentalDate(Product product, DateTime date)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Update product store mappings
    /// </summary>
    /// <param name="product">Product</param>
    /// <param name="limitedToStoresIds">A list of store ids for mapping</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task UpdateProductStoreMappingsAsync(Product product, IList<int> limitedToStoresIds)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the value whether the sequence contains downloadable products
    /// </summary>
    /// <param name="productIds">Product identifiers</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the result
    /// </returns>
    public virtual async Task<bool> HasAnyDownloadableProductAsync(int[] productIds)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the value whether the sequence contains gift card products
    /// </summary>
    /// <param name="productIds">Product identifiers</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the result
    /// </returns>
    public virtual async Task<bool> HasAnyGiftCardProductAsync(int[] productIds)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the value whether the sequence contains recurring products
    /// </summary>
    /// <param name="productIds">Product identifiers</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the result
    /// </returns>
    public virtual async Task<bool> HasAnyRecurringProductAsync(int[] productIds)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns a list of sku of not existing products
    /// </summary>
    /// <param name="productSku">The sku of the products to check</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the list of sku not existing products
    /// </returns>
    public virtual async Task<string[]> GetNotExistingProductsAsync(string[] productSku)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    #endregion

    #region Inventory management methods

    /// <summary>
    /// Adjust inventory
    /// </summary>
    /// <param name="product">Product</param>
    /// <param name="quantityToChange">Quantity to increase or decrease</param>
    /// <param name="attributesXml">Attributes in XML format</param>
    /// <param name="message">Message for the stock quantity history</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task AdjustInventoryAsync(Product product, int quantityToChange, string attributesXml = "", string message = "")
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Book the reserved quantity
    /// </summary>
    /// <param name="product">Product</param>
    /// <param name="warehouseId">Warehouse identifier</param>
    /// <param name="quantity">Quantity, must be negative</param>
    /// <param name="message">Message for the stock quantity history</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task BookReservedInventoryAsync(Product product, int warehouseId, int quantity, string message = "")
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Reverse booked inventory (if acceptable)
    /// </summary>
    /// <param name="product">product</param>
    /// <param name="shipmentItem">Shipment item</param>
    /// <param name="message">Message for the stock quantity history</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the quantity reversed
    /// </returns>
    public virtual async Task<int> ReverseBookedInventoryAsync(Product product, ShipmentItem shipmentItem, string message = "")
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    #endregion

    #region Related products

    /// <summary>
    /// Deletes a related product
    /// </summary>
    /// <param name="relatedProduct">Related product</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task DeleteRelatedProductAsync(RelatedProduct relatedProduct)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets related products by product identifier
    /// </summary>
    /// <param name="productId">The first product identifier</param>
    /// <param name="showHidden">A value indicating whether to show hidden records</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the related products
    /// </returns>
    public virtual async Task<IList<RelatedProduct>> GetRelatedProductsByProductId1Async(int productId, bool showHidden = false)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a related product
    /// </summary>
    /// <param name="relatedProductId">Related product identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the related product
    /// </returns>
    public virtual async Task<RelatedProduct> GetRelatedProductByIdAsync(int relatedProductId)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Inserts a related product
    /// </summary>
    /// <param name="relatedProduct">Related product</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task InsertRelatedProductAsync(RelatedProduct relatedProduct)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Updates a related product
    /// </summary>
    /// <param name="relatedProduct">Related product</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task UpdateRelatedProductAsync(RelatedProduct relatedProduct)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Finds a related product item by specified identifiers
    /// </summary>
    /// <param name="source">Source</param>
    /// <param name="productId1">The first product identifier</param>
    /// <param name="productId2">The second product identifier</param>
    /// <returns>Related product</returns>
    public virtual RelatedProduct FindRelatedProduct(IList<RelatedProduct> source, int productId1, int productId2)
    {
        return source.FirstOrDefault(rp => rp.ProductId1 == productId1 && rp.ProductId2 == productId2);
    }

    #endregion

    #region Cross-sell products

    /// <summary>
    /// Deletes a cross-sell product
    /// </summary>
    /// <param name="crossSellProduct">Cross-sell identifier</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task DeleteCrossSellProductAsync(CrossSellProduct crossSellProduct)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets cross-sell products by product identifier
    /// </summary>
    /// <param name="productId1">The first product identifier</param>
    /// <param name="showHidden">A value indicating whether to show hidden records</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the cross-sell products
    /// </returns>
    public virtual async Task<IList<CrossSellProduct>> GetCrossSellProductsByProductId1Async(int productId1, bool showHidden = false)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a cross-sell product
    /// </summary>
    /// <param name="crossSellProductId">Cross-sell product identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the cross-sell product
    /// </returns>
    public virtual async Task<CrossSellProduct> GetCrossSellProductByIdAsync(int crossSellProductId)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Inserts a cross-sell product
    /// </summary>
    /// <param name="crossSellProduct">Cross-sell product</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task InsertCrossSellProductAsync(CrossSellProduct crossSellProduct)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a cross-sells
    /// </summary>
    /// <param name="cart">Shopping cart</param>
    /// <param name="numberOfProducts">Number of products to return</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the cross-sells
    /// </returns>
    public virtual async Task<IList<Product>> GetCrossSellProductsByShoppingCartAsync(IList<ShoppingCartItem> cart, int numberOfProducts)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Finds a cross-sell product item by specified identifiers
    /// </summary>
    /// <param name="source">Source</param>
    /// <param name="productId1">The first product identifier</param>
    /// <param name="productId2">The second product identifier</param>
    /// <returns>Cross-sell product</returns>
    public virtual CrossSellProduct FindCrossSellProduct(IList<CrossSellProduct> source, int productId1, int productId2)
    {
        return source.FirstOrDefault(csp => csp.ProductId1 == productId1 && csp.ProductId2 == productId2);
    }

    #endregion

    #region Tier prices

    /// <summary>
    /// Gets a product tier prices for customer
    /// </summary>
    /// <param name="product">Product</param>
    /// <param name="customer">Customer</param>
    /// <param name="store">Store</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task<IList<TierPrice>> GetTierPricesAsync(Product product, Customer customer, Store store)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a tier prices by product identifier
    /// </summary>
    /// <param name="productId">Product identifier</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task<IList<TierPrice>> GetTierPricesByProductAsync(int productId)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes a tier price
    /// </summary>
    /// <param name="tierPrice">Tier price</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task DeleteTierPriceAsync(TierPrice tierPrice)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a tier price
    /// </summary>
    /// <param name="tierPriceId">Tier price identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the ier price
    /// </returns>
    public virtual async Task<TierPrice> GetTierPriceByIdAsync(int tierPriceId)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Inserts a tier price
    /// </summary>
    /// <param name="tierPrice">Tier price</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task InsertTierPriceAsync(TierPrice tierPrice)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Updates the tier price
    /// </summary>
    /// <param name="tierPrice">Tier price</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task UpdateTierPriceAsync(TierPrice tierPrice)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a preferred tier price
    /// </summary>
    /// <param name="product">Product</param>
    /// <param name="customer">Customer</param>
    /// <param name="store">Store</param>
    /// <param name="quantity">Quantity</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the tier price
    /// </returns>
    public virtual async Task<TierPrice> GetPreferredTierPriceAsync(Product product, Customer customer, Store store, int quantity)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    #endregion

    #region Product pictures

    /// <summary>
    /// Deletes a product picture
    /// </summary>
    /// <param name="productPicture">Product picture</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task DeleteProductPictureAsync(ProductPicture productPicture)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a product pictures by product identifier
    /// </summary>
    /// <param name="productId">The product identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the product pictures
    /// </returns>
    public virtual async Task<IList<ProductPicture>> GetProductPicturesByProductIdAsync(int productId)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a product picture
    /// </summary>
    /// <param name="productPictureId">Product picture identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the product picture
    /// </returns>
    public virtual async Task<ProductPicture> GetProductPictureByIdAsync(int productPictureId)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Inserts a product picture
    /// </summary>
    /// <param name="productPicture">Product picture</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task InsertProductPictureAsync(ProductPicture productPicture)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Updates a product picture
    /// </summary>
    /// <param name="productPicture">Product picture</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task UpdateProductPictureAsync(ProductPicture productPicture)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get the IDs of all product images 
    /// </summary>
    /// <param name="productsIds">Products IDs</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the all picture identifiers grouped by product ID
    /// </returns>
    public async Task<IDictionary<int, int[]>> GetProductsImagesIdsAsync(int[] productsIds)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get products for which a discount is applied
    /// </summary>
    /// <param name="discountId">Discount identifier; pass null to load all records</param>
    /// <param name="showHidden">A value indicating whether to load deleted products</param>
    /// <param name="pageIndex">Page index</param>
    /// <param name="pageSize">Page size</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the list of products
    /// </returns>
    public virtual async Task<IPagedList<Product>> GetProductsWithAppliedDiscountAsync(int? discountId = null,
        bool showHidden = false, int pageIndex = 0, int pageSize = int.MaxValue)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    #endregion

    #region Product videos

    /// <summary>
    /// Deletes a product video
    /// </summary>
    /// <param name="productVideo">Product video</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task DeleteProductVideoAsync(ProductVideo productVideo)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a product videos by product identifier
    /// </summary>
    /// <param name="productId">The product identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the product videos
    /// </returns>
    public virtual async Task<IList<ProductVideo>> GetProductVideosByProductIdAsync(int productId)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets a product video
    /// </summary>
    /// <param name="productPictureId">Product video identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the product video
    /// </returns>
    public virtual async Task<ProductVideo> GetProductVideoByIdAsync(int productVideoId)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Inserts a product video
    /// </summary>
    /// <param name="productVideo">Product picture</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task InsertProductVideoAsync(ProductVideo productVideo)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Updates a product video
    /// </summary>
    /// <param name="productVideo">Product video</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task UpdateProductVideoAsync(ProductVideo productVideo)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    #endregion

    #region Product reviews

    /// <summary>
    /// Gets all product reviews
    /// </summary>
    /// <param name="customerId">Customer identifier (who wrote a review); 0 to load all records</param>
    /// <param name="approved">A value indicating whether to content is approved; null to load all records</param> 
    /// <param name="fromUtc">Item creation from; null to load all records</param>
    /// <param name="toUtc">Item item creation to; null to load all records</param>
    /// <param name="message">Search title or review text; null to load all records</param>
    /// <param name="storeId">The store identifier, where a review has been created; pass 0 to load all records</param>
    /// <param name="productId">The product identifier; pass 0 to load all records</param>
    /// <param name="vendorId">The vendor identifier (limit to products of this vendor); pass 0 to load all records</param>
    /// <param name="showHidden">A value indicating whether to show hidden records</param>
    /// <param name="pageIndex">Page index</param>
    /// <param name="pageSize">Page size</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the reviews
    /// </returns>
    public virtual async Task<IPagedList<ProductReview>> GetAllProductReviewsAsync(int customerId = 0, bool? approved = null,
        DateTime? fromUtc = null, DateTime? toUtc = null,
        string message = null, int storeId = 0, int productId = 0, int vendorId = 0, bool showHidden = false,
        int pageIndex = 0, int pageSize = int.MaxValue)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets product review
    /// </summary>
    /// <param name="productReviewId">Product review identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the product review
    /// </returns>
    public virtual async Task<ProductReview> GetProductReviewByIdAsync(int productReviewId)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get product reviews by identifiers
    /// </summary>
    /// <param name="productReviewIds">Product review identifiers</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the product reviews
    /// </returns>
    public virtual async Task<IList<ProductReview>> GetProductReviewsByIdsAsync(int[] productReviewIds)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Inserts a product review
    /// </summary>
    /// <param name="productReview">Product review</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task InsertProductReviewAsync(ProductReview productReview)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes a product review
    /// </summary>
    /// <param name="productReview">Product review</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task DeleteProductReviewAsync(ProductReview productReview)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes product reviews
    /// </summary>
    /// <param name="productReviews">Product reviews</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task DeleteProductReviewsAsync(IList<ProductReview> productReviews)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Sets or create a product review helpfulness record
    /// </summary>
    /// <param name="productReview">Product review</param>
    /// <param name="helpfulness">Value indicating whether a review a helpful</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task SetProductReviewHelpfulnessAsync(ProductReview productReview, bool helpfulness)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Updates a product review
    /// </summary>
    /// <param name="productReview">Product review</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task UpdateProductReviewAsync(ProductReview productReview)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Updates a totals helpfulness count for product review
    /// </summary>
    /// <param name="productReview">Product review</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the result
    /// </returns>
    public virtual async Task UpdateProductReviewHelpfulnessTotalsAsync(ProductReview productReview)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Check possibility added review for current customer
    /// </summary>
    /// <param name="productId">Current product</param>
    /// <param name="storeId">The store identifier; pass 0 to load all records</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the 
    /// </returns>
    public virtual async Task<bool> CanAddReviewAsync(int productId, int storeId = 0)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    #endregion

    #region Product warehouses

    /// <summary>
    /// Get a product warehouse-inventory records by product identifier
    /// </summary>
    /// <param name="productId">Product identifier</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task<IList<ProductWarehouseInventory>> GetAllProductWarehouseInventoryRecordsAsync(int productId)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes a record to manage product inventory per warehouse
    /// </summary>
    /// <param name="pwi">Record to manage product inventory per warehouse</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task DeleteProductWarehouseInventoryAsync(ProductWarehouseInventory pwi)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Inserts a record to manage product inventory per warehouse
    /// </summary>
    /// <param name="pwi">Record to manage product inventory per warehouse</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task InsertProductWarehouseInventoryAsync(ProductWarehouseInventory pwi)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Updates a record to manage product inventory per warehouse
    /// </summary>
    /// <param name="pwi">Record to manage product inventory per warehouse</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task UpdateProductWarehouseInventoryAsync(ProductWarehouseInventory pwi)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Updates a records to manage product inventory per warehouse
    /// </summary>
    /// <param name="pwis">Records to manage product inventory per warehouse</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task UpdateProductWarehouseInventoryAsync(IList<ProductWarehouseInventory> pwis)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    #endregion

    #region Stock quantity history

    /// <summary>
    /// Add stock quantity change entry
    /// </summary>
    /// <param name="product">Product</param>
    /// <param name="quantityAdjustment">Quantity adjustment</param>
    /// <param name="stockQuantity">Current stock quantity</param>
    /// <param name="warehouseId">Warehouse identifier</param>
    /// <param name="message">Message</param>
    /// <param name="combinationId">Product attribute combination identifier</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task AddStockQuantityHistoryEntryAsync(Product product, int quantityAdjustment, int stockQuantity,
        int warehouseId = 0, string message = "", int? combinationId = null)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get the history of the product stock quantity changes
    /// </summary>
    /// <param name="product">Product</param>
    /// <param name="warehouseId">Warehouse identifier; pass 0 to load all entries</param>
    /// <param name="combinationId">Product attribute combination identifier; pass 0 to load all entries</param>
    /// <param name="pageIndex">Page index</param>
    /// <param name="pageSize">Page size</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the list of stock quantity change entries
    /// </returns>
    public virtual async Task<IPagedList<StockQuantityHistory>> GetStockQuantityHistoryAsync(Product product, int warehouseId = 0, int combinationId = 0,
        int pageIndex = 0, int pageSize = int.MaxValue)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    #endregion

    #region Product discounts

    /// <summary>
    /// Clean up product references for a specified discount
    /// </summary>
    /// <param name="discount">Discount</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task ClearDiscountProductMappingAsync(Discount discount)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get a discount-product mapping records by product identifier
    /// </summary>
    /// <param name="productId">Product identifier</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task<IList<DiscountProductMapping>> GetAllDiscountsAppliedToProductAsync(int productId)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get a discount-product mapping record
    /// </summary>
    /// <param name="productId">Product identifier</param>
    /// <param name="discountId">Discount identifier</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the result
    /// </returns>
    public virtual async Task<DiscountProductMapping> GetDiscountAppliedToProductAsync(int productId, int discountId)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Inserts a discount-product mapping record
    /// </summary>
    /// <param name="discountProductMapping">Discount-product mapping</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task InsertDiscountProductMappingAsync(DiscountProductMapping discountProductMapping)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes a discount-product mapping record
    /// </summary>
    /// <param name="discountProductMapping">Discount-product mapping</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public virtual async Task DeleteDiscountProductMappingAsync(DiscountProductMapping discountProductMapping)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    #endregion
}
