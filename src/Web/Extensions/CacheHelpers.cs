namespace Microsoft.BookStore.Web.Extensions;

public static class CacheHelpers
{
    public static readonly TimeSpan DefaultCacheDuration = TimeSpan.FromSeconds(30);
    private static readonly string _itemsKeyTemplate2 = "items-{0}-{1}-{2}-{3}";
    private static readonly string _itemsKeyTemplate = "items-{0}-{1}-{2}";

    public static string GenerateCatalogItemCacheKey(int pageIndex, int itemsPage, int? brandId, int? typeId)
    {
        return string.Format(_itemsKeyTemplate2, pageIndex, itemsPage, brandId, typeId);
    }

    public static string GenerateBookItemCacheKey(int pageIndex, int itemsPage, long? categoryId)
    {
        return string.Format(_itemsKeyTemplate, pageIndex, itemsPage, categoryId);
    }

    public static string GenerateBrandsCacheKey()
    {
        return "brands";
    }

    public static string GenerateTypesCacheKey()
    {
        return "types";
    }
}
