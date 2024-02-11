using EAM.Shared.StoredProcedures;

namespace EAM.Shared.Interfaces
{
    public interface IAssetRepository
    {
        Task<List<xpAsset_Group>> AssetGroupAsync(string company_Id);
        Task<List<xpAsset_Category>> AssetCategoryAsync(string company_Id);
        Task<List<xpAsset_Classification>> AssetClassificationAsync(string company_Id, string category);
        Task<List<xpAsset_Brand>> AssetBrandAsync(string company_Id, string category);
        Task<List<xpAsset>> AssetListAsync(string company_Id, string category);
        Task<xpAsset> AssetSingleAsync(string Id);
        Task<xpAsset> AssetAddAsync(xpAsset asset);
        Task<xpAsset> AssetUpdateAsync(xpAsset asset);
        Task<xpAsset> AssetDeleteAsync(string Id);
    }
}