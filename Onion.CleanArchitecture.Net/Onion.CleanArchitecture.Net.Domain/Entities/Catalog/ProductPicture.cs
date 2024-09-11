using System;
using Onion.CleanArchitecture.Net.Domain.Common;

namespace Onion.CleanArchitecture.Net.Domain.Entities.Catalog;

/// <summary>
/// Represents a product picture mapping
/// </summary>
public partial class ProductPicture : AuditableBaseEntity
{
    /// <summary>
    /// Gets or sets the product identifier
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Gets or sets the picture identifier
    /// </summary>
    public int PictureId { get; set; }

    /// <summary>
    /// Gets or sets the display order
    /// </summary>
    public int DisplayOrder { get; set; }
}
