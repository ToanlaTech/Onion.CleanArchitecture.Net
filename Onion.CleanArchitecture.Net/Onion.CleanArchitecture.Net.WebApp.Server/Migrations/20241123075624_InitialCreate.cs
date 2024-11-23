using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Onion.CleanArchitecture.Net.WebApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    ParentGroupedProductId = table.Column<int>(type: "int", nullable: false),
                    VisibleIndividually = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FullDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdminComment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductTemplateId = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    ShowOnHomepage = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MetaKeywords = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MetaDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MetaTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AllowCustomerReviews = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ApprovedRatingSum = table.Column<int>(type: "int", nullable: false),
                    NotApprovedRatingSum = table.Column<int>(type: "int", nullable: false),
                    ApprovedTotalReviews = table.Column<int>(type: "int", nullable: false),
                    NotApprovedTotalReviews = table.Column<int>(type: "int", nullable: false),
                    SubjectToAcl = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LimitedToStores = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Sku = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ManufacturerPartNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gtin = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsGiftCard = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    GiftCardTypeId = table.Column<int>(type: "int", nullable: false),
                    OverriddenGiftCardAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    RequireOtherProducts = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    RequiredProductIds = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AutomaticallyAddRequiredProducts = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDownload = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DownloadId = table.Column<int>(type: "int", nullable: false),
                    UnlimitedDownloads = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MaxNumberOfDownloads = table.Column<int>(type: "int", nullable: false),
                    DownloadExpirationDays = table.Column<int>(type: "int", nullable: true),
                    DownloadActivationTypeId = table.Column<int>(type: "int", nullable: false),
                    HasSampleDownload = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SampleDownloadId = table.Column<int>(type: "int", nullable: false),
                    HasUserAgreement = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserAgreementText = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsRecurring = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    RecurringCycleLength = table.Column<int>(type: "int", nullable: false),
                    RecurringCyclePeriodId = table.Column<int>(type: "int", nullable: false),
                    RecurringTotalCycles = table.Column<int>(type: "int", nullable: false),
                    IsRental = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    RentalPriceLength = table.Column<int>(type: "int", nullable: false),
                    RentalPricePeriodId = table.Column<int>(type: "int", nullable: false),
                    IsShipEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsFreeShipping = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ShipSeparately = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AdditionalShippingCharge = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    DeliveryDateId = table.Column<int>(type: "int", nullable: false),
                    IsTaxExempt = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TaxCategoryId = table.Column<int>(type: "int", nullable: false),
                    ManageInventoryMethodId = table.Column<int>(type: "int", nullable: false),
                    ProductAvailabilityRangeId = table.Column<int>(type: "int", nullable: false),
                    UseMultipleWarehouses = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    DisplayStockAvailability = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DisplayStockQuantity = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MinStockQuantity = table.Column<int>(type: "int", nullable: false),
                    LowStockActivityId = table.Column<int>(type: "int", nullable: false),
                    NotifyAdminForQuantityBelow = table.Column<int>(type: "int", nullable: false),
                    BackorderModeId = table.Column<int>(type: "int", nullable: false),
                    AllowBackInStockSubscriptions = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    OrderMinimumQuantity = table.Column<int>(type: "int", nullable: false),
                    OrderMaximumQuantity = table.Column<int>(type: "int", nullable: false),
                    AllowedQuantities = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AllowAddingOnlyExistingAttributeCombinations = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DisplayAttributeCombinationImagesOnly = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    NotReturnable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DisableBuyButton = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DisableWishlistButton = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AvailableForPreOrder = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PreOrderAvailabilityStartDateTimeUtc = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CallForPrice = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    OldPrice = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    ProductCost = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    CustomerEntersPrice = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MinimumCustomerEnteredPrice = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    MaximumCustomerEnteredPrice = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    BasepriceEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    BasepriceAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    BasepriceUnitId = table.Column<int>(type: "int", nullable: false),
                    BasepriceBaseAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    BasepriceBaseUnitId = table.Column<int>(type: "int", nullable: false),
                    MarkAsNew = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MarkAsNewStartDateTimeUtc = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    MarkAsNewEndDateTimeUtc = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    HasTierPrices = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HasDiscountsApplied = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Length = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Width = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    AvailableStartDateTimeUtc = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AvailableEndDateTimeUtc = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Published = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ProductType = table.Column<int>(type: "int", nullable: false),
                    BackorderMode = table.Column<int>(type: "int", nullable: false),
                    DownloadActivationType = table.Column<int>(type: "int", nullable: false),
                    GiftCardType = table.Column<int>(type: "int", nullable: false),
                    LowStockActivity = table.Column<int>(type: "int", nullable: false),
                    ManageInventoryMethod = table.Column<int>(type: "int", nullable: false),
                    RecurringCyclePeriod = table.Column<int>(type: "int", nullable: false),
                    RentalPricePeriod = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastModified = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products",
                schema: "public");
        }
    }
}
