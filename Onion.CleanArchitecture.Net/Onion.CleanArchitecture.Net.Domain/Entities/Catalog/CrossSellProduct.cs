using System;
using Onion.CleanArchitecture.Net.Domain.Common;

namespace Onion.CleanArchitecture.Net.Domain.Entities.Catalog;

/// <summary>
/// Represents a cross-sell product
/// </summary>
public partial class CrossSellProduct : AuditableBaseEntity
{
    /// <summary>
    /// Gets or sets the first product identifier
    /// </summary>
    public int ProductId1 { get; set; }

    /// <summary>
    /// Gets or sets the second product identifier
    /// </summary>
    public int ProductId2 { get; set; }
}
