using System;
using Onion.CleanArchitecture.Net.Domain.Common;

namespace Onion.CleanArchitecture.Net.Domain.Entities.Catalog;

/// <summary>
/// Represents a record to manage product inventory per warehouse
/// </summary>
public partial class ProductWarehouseInventory : AuditableBaseEntity
{
    /// <summary>
    /// Gets or sets the product identifier
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Gets or sets the warehouse identifier
    /// </summary>
    public int WarehouseId { get; set; }

    /// <summary>
    /// Gets or sets the stock quantity
    /// </summary>
    public int StockQuantity { get; set; }

    /// <summary>
    /// Gets or sets the reserved quantity (ordered but not shipped yet)
    /// </summary>
    public int ReservedQuantity { get; set; }
}
