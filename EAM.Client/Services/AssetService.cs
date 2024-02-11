using EAM.Shared.Interfaces;
using EAM.Shared.StoredProcedures;
using System.Net.Http.Json;

//(tsas.V2)
namespace EAM.Client.Services
{
#pragma warning disable CS8603 // Possible null reference return.

    public class AssetService : IAssetRepository
    {
        private readonly HttpClient httpClient;
        public AssetService(HttpClient httpClient) 
        { 
            this.httpClient = httpClient;
        }

        public async Task<List<xpAsset_Group>> AssetGroupAsync(string company_Id)
        {
            List<xpAsset_Group>? assets = await httpClient.GetFromJsonAsync<List<xpAsset_Group>>($"api/EAM/Asset-Group/{company_Id}");
            return assets;
        }

        public async Task<List<xpAsset_Category>> AssetCategoryAsync(string company_Id)
        {
            List<xpAsset_Category>? assets = await httpClient.GetFromJsonAsync<List<xpAsset_Category>>($"api/EAM/Asset-Category/{company_Id}");
            return assets;
        }

        public async Task<List<xpAsset_Classification>> AssetClassificationAsync(string company_Id, string category)
        {
            List<xpAsset_Classification>? assets = await httpClient.GetFromJsonAsync<List<xpAsset_Classification>>($"api/EAM/Asset-Classification/{company_Id}/{category}");
            return assets;
        }

        public async Task<List<xpAsset_Brand>> AssetBrandAsync(string company_Id, string category)
        {
            List<xpAsset_Brand>? assets = await httpClient.GetFromJsonAsync<List<xpAsset_Brand>>($"api/EAM/Asset-Brand/{company_Id}/{category}");
            return assets;
        }

        public async Task<List<xpAsset>> AssetListAsync(string company_Id, string category)
        {
            List<xpAsset>? assets = await httpClient.GetFromJsonAsync<List<xpAsset>>($"api/EAM/Asset-List/{company_Id}/{category}");
            return assets;
        }

        public async Task<xpAsset> AssetSingleAsync(string assetId)
        {
            HttpResponseMessage? singleassets = await httpClient.GetAsync("api/EAM/Asset-Single");
            xpAsset? response = await singleassets.Content.ReadFromJsonAsync<xpAsset>();
            return response;
        }

        public async Task<xpAsset> AssetAddAsync(xpAsset asset)
        {
            HttpResponseMessage? newasset = await httpClient.PostAsJsonAsync("api/EAM/Asset-Add", asset);
            xpAsset? response = await newasset.Content.ReadFromJsonAsync<xpAsset>();
            return response;
        }

        public async Task<xpAsset> AssetUpdateAsync(xpAsset asset)
        {
            HttpResponseMessage? newasset = await httpClient.PostAsJsonAsync("api/EAM/Asset-Update", asset);
            xpAsset? response = await newasset.Content.ReadFromJsonAsync<xpAsset>();
            return response;
        }

        public async Task<xpAsset> AssetDeleteAsync(string id)
        {
            HttpResponseMessage? newasset = await httpClient.DeleteAsync($"api/EAM/Asset-Delete/{id}");
            xpAsset? response = await newasset.Content.ReadFromJsonAsync<xpAsset>();
            return response;
        }
    }
#pragma warning restore CS8603 // Possible null reference return.
}
