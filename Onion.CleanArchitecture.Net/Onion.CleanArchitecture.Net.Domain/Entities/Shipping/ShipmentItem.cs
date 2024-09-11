using System;
using Onion.CleanArchitecture.Net.Domain.Common;

namespace Onion.CleanArchitecture.Net.Domain.Entities.Shipping;

/// <summary>
/// Represents a shipment item
/// </summary>
public partial class ShipmentItem : AuditableBaseEntity
{
    /// <summary>
    /// Gets or sets the shipment identifier
    /// </summary>
    public int ShipmentId { get; set; }

    /// <summary>
    /// Gets or sets the order item identifier
    /// </summary>
    public int OrderItemId { get; set; }

    /// <summary>
    /// Gets or sets the quantity
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the warehouse identifier
    /// </summary>
    public int WarehouseId { get; set; }
}
