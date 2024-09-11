using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Onion.CleanArchitecture.Net.WebApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameColumn(
                name: "Rate",
                schema: "public",
                table: "Products",
                newName: "Width");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "public",
                table: "Products",
                newName: "UserAgreementText");

            migrationBuilder.RenameColumn(
                name: "Barcode",
                schema: "public",
                table: "Products",
                newName: "Sku");

            migrationBuilder.AddColumn<decimal>(
                name: "AdditionalShippingCharge",
                schema: "public",
                table: "Products",
                type: "numeric(18,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "AdminComment",
                schema: "public",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AllowAddingOnlyExistingAttributeCombinations",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllowBackInStockSubscriptions",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AllowCustomerReviews",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AllowedQuantities",
                schema: "public",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApprovedRatingSum",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApprovedTotalReviews",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "AutomaticallyAddRequiredProducts",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "AvailableEndDateTimeUtc",
                schema: "public",
                table: "Products",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AvailableForPreOrder",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "AvailableStartDateTimeUtc",
                schema: "public",
                table: "Products",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BackorderMode",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BackorderModeId",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "BasepriceAmount",
                schema: "public",
                table: "Products",
                type: "numeric(18,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BasepriceBaseAmount",
                schema: "public",
                table: "Products",
                type: "numeric(18,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "BasepriceBaseUnitId",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "BasepriceEnabled",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "BasepriceUnitId",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "CallForPrice",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                schema: "public",
                table: "Products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "CustomerEntersPrice",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryDateId",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "DisableBuyButton",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DisableWishlistButton",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DisplayAttributeCombinationImagesOnly",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "DisplayStockAvailability",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DisplayStockQuantity",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "DownloadActivationType",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DownloadActivationTypeId",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DownloadExpirationDays",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DownloadId",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FullDescription",
                schema: "public",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GiftCardType",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GiftCardTypeId",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Gtin",
                schema: "public",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasDiscountsApplied",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasSampleDownload",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasTierPrices",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasUserAgreement",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Height",
                schema: "public",
                table: "Products",
                type: "numeric(18,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsDownload",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFreeShipping",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsGiftCard",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRecurring",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRental",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsShipEnabled",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTaxExempt",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Length",
                schema: "public",
                table: "Products",
                type: "numeric(18,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "LimitedToStores",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LowStockActivity",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LowStockActivityId",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ManageInventoryMethod",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ManageInventoryMethodId",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ManufacturerPartNumber",
                schema: "public",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MarkAsNew",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "MarkAsNewEndDateTimeUtc",
                schema: "public",
                table: "Products",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MarkAsNewStartDateTimeUtc",
                schema: "public",
                table: "Products",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxNumberOfDownloads",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "MaximumCustomerEnteredPrice",
                schema: "public",
                table: "Products",
                type: "numeric(18,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                schema: "public",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaKeywords",
                schema: "public",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaTitle",
                schema: "public",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinStockQuantity",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "MinimumCustomerEnteredPrice",
                schema: "public",
                table: "Products",
                type: "numeric(18,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "NotApprovedRatingSum",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NotApprovedTotalReviews",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "NotReturnable",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NotifyAdminForQuantityBelow",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "OldPrice",
                schema: "public",
                table: "Products",
                type: "numeric(18,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "OrderMaximumQuantity",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderMinimumQuantity",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "OverriddenGiftCardAmount",
                schema: "public",
                table: "Products",
                type: "numeric(18,6)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentGroupedProductId",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PreOrderAvailabilityStartDateTimeUtc",
                schema: "public",
                table: "Products",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "public",
                table: "Products",
                type: "numeric(18,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ProductAvailabilityRangeId",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ProductCost",
                schema: "public",
                table: "Products",
                type: "numeric(18,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ProductTemplateId",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductType",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductTypeId",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Published",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RecurringCycleLength",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecurringCyclePeriod",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecurringCyclePeriodId",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecurringTotalCycles",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RentalPriceLength",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RentalPricePeriod",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RentalPricePeriodId",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "RequireOtherProducts",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RequiredProductIds",
                schema: "public",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SampleDownloadId",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ShipSeparately",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                schema: "public",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShowOnHomepage",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "StockQuantity",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "SubjectToAcl",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TaxCategoryId",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "UnlimitedDownloads",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOnUtc",
                schema: "public",
                table: "Products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "UseMultipleWarehouses",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "VendorId",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "VisibleIndividually",
                schema: "public",
                table: "Products",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                schema: "public",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                schema: "public",
                table: "Products",
                type: "numeric(18,6)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalShippingCharge",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AdminComment",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AllowAddingOnlyExistingAttributeCombinations",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AllowBackInStockSubscriptions",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AllowCustomerReviews",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AllowedQuantities",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ApprovedRatingSum",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ApprovedTotalReviews",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AutomaticallyAddRequiredProducts",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AvailableEndDateTimeUtc",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AvailableForPreOrder",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AvailableStartDateTimeUtc",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BackorderMode",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BackorderModeId",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BasepriceAmount",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BasepriceBaseAmount",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BasepriceBaseUnitId",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BasepriceEnabled",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BasepriceUnitId",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CallForPrice",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CustomerEntersPrice",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeliveryDateId",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DisableBuyButton",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DisableWishlistButton",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DisplayAttributeCombinationImagesOnly",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DisplayStockAvailability",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DisplayStockQuantity",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DownloadActivationType",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DownloadActivationTypeId",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DownloadExpirationDays",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DownloadId",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FullDescription",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GiftCardType",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GiftCardTypeId",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Gtin",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "HasDiscountsApplied",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "HasSampleDownload",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "HasTierPrices",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "HasUserAgreement",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Height",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsDownload",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsFreeShipping",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsGiftCard",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsRecurring",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsRental",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsShipEnabled",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsTaxExempt",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Length",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LimitedToStores",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LowStockActivity",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LowStockActivityId",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ManageInventoryMethod",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ManageInventoryMethodId",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ManufacturerPartNumber",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MarkAsNew",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MarkAsNewEndDateTimeUtc",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MarkAsNewStartDateTimeUtc",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MaxNumberOfDownloads",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MaximumCustomerEnteredPrice",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MetaDescription",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MetaKeywords",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MetaTitle",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MinStockQuantity",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MinimumCustomerEnteredPrice",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NotApprovedRatingSum",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NotApprovedTotalReviews",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NotReturnable",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "NotifyAdminForQuantityBelow",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OldPrice",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderMaximumQuantity",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OrderMinimumQuantity",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "OverriddenGiftCardAmount",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ParentGroupedProductId",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PreOrderAvailabilityStartDateTimeUtc",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductAvailabilityRangeId",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductCost",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductTemplateId",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductType",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductTypeId",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Published",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RecurringCycleLength",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RecurringCyclePeriod",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RecurringCyclePeriodId",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RecurringTotalCycles",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RentalPriceLength",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RentalPricePeriod",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RentalPricePeriodId",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RequireOtherProducts",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "RequiredProductIds",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SampleDownloadId",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShipSeparately",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShowOnHomepage",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StockQuantity",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SubjectToAcl",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TaxCategoryId",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UnlimitedDownloads",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdatedOnUtc",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UseMultipleWarehouses",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VendorId",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "VisibleIndividually",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                schema: "public",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Weight",
                schema: "public",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "public",
                newName: "Products");

            migrationBuilder.RenameColumn(
                name: "Width",
                table: "Products",
                newName: "Rate");

            migrationBuilder.RenameColumn(
                name: "UserAgreementText",
                table: "Products",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Sku",
                table: "Products",
                newName: "Barcode");
        }
    }
}
