using EAM.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EAM.Shared.StoredProcedures;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EAM.Controllers
{
#pragma warning disable CS0436 // Type conflicts with imported type
#pragma warning disable CS8604 // Possible null reference argument.
    [Route("api/[controller]")]
    [ApiController]
    public class EAMController : ControllerBase
    {
        private readonly EAMDbContext _context;
        public EAMController(EAMDbContext context)
        {
            this._context = context;
        }

        #region REF

        [HttpGet("xpAsset-HRC/{company_id}/{id}")]
        public async Task<ActionResult<List<xpAsset_Tree>>> xpAsset_HRC(string? company_id, string? id)
        {
            List<xpAsset_Tree> asset_Trees = new();
            try
            {
                asset_Trees = await _context.Set<xpAsset_Tree>().FromSqlRaw("EXEC dbo.xpAsset_HRC {0}, {1}", company_id, id).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
            }

            return Ok(asset_Trees);
        }

        [HttpGet("Asset-Group/{company_id}")]
        public async Task<ActionResult<List<xpAsset_Group>>> Asset_Group(string? company_id)
        {
            List<xpAsset_Group> assets = new();
            try
            {
                assets = await _context.Set<xpAsset_Group>().FromSqlRaw("EXEC dbo.xpAsset_Group {0}", company_id).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
            }

            return Ok(assets);
        }

        [HttpGet("Asset-Category/{company_id}")]
        public async Task<ActionResult<List<xpAsset_Category>>> Asset_Category(string? company_id)
        {
            List<xpAsset_Category> assets = new();
            try
            {
                assets = await _context.Set<xpAsset_Category>().FromSqlRaw("EXEC dbo.xpAsset_Category {0}", company_id).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
            }

            return Ok(assets);
        }

        [HttpGet("Asset-Classification/{company_id}/{category}")]
        public async Task<ActionResult<List<xpAsset_Classification>>> Asset_Classification(string? company_id, string? category)
        {
            List<xpAsset_Classification> assets = new();
            try
            {
                assets = await _context.Set<xpAsset_Classification>().FromSqlRaw("EXEC dbo.xpAsset_Classification {0}, {1}", company_id, category).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
            }

            return Ok(assets);
        }

        [HttpGet("Asset-Brand/{company_id}/{category}")]
        public async Task<ActionResult<List<xpAsset_Brand>>> Asset_Brand(string? company_id, string? category)
        {
            List<xpAsset_Brand> assets = new();
            try
            {
                assets = await _context.Set<xpAsset_Brand>().FromSqlRaw("EXEC dbo.xpAsset_Brand {0}, {1}", company_id, category).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
            }

            return Ok(assets);
        }

        [HttpGet("Asset-List/{company_id}/{category}")]
        public async Task<ActionResult<List<xpAsset>>> Asset_List(string? company_id, string? category)
        {
            List<xpAsset> assets = new();
            try
            {
                assets = await _context.Set<xpAsset>().FromSqlRaw("EXEC dbo.xpAsset_List {0}, {1}", company_id, category).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
            }

            return Ok(assets);
        }

        [HttpGet("Asset-Single/{id}")]
        public async Task<ActionResult<xpAsset>> Asset_Single(string? id)
        {
            var asset = new xpAsset();

            var assets = await _context.Set<xpAsset>().FromSqlRaw("EXEC dbo.xpAsset_Single {0}", id).ToListAsync();
            if (assets != null && assets.Count > 0)
                asset = assets[0];

            return Ok(asset);
        }

        [HttpPost("Asset-Add")]
        public async Task<ActionResult<xpAsset>> Asset_Add(xpAsset _asset)
        {
            var asset = new xpAsset();
            string jsAsset = JsonSerializer.Serialize<xpAsset>(_asset);

            //var assets = await _context.Set<xpAsset>().FromSqlRaw("EXEC dbo.xpAsset_Add {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}", _asset.Company_Id, _asset.Id, _asset.Category, _asset.Prefix, _asset.Class, _asset.Serial_Number, _asset.Name, _asset.Type, _asset.Model, _asset.Brand, _asset.Specifications, _asset.Fuel, _asset.Emission, _asset.Production_Year, _asset.Item_Condition, _asset.Purchase_Date, _asset.Price, _asset.Supplier_Id, _asset.Warranty, _asset.Warranty_Exp_Date, _asset.Insurance, _asset.Insurance_Exp_Date, _asset.Resale_Date, _asset.Resale_Price, _asset.Hours_Meter, _asset.Status).ToListAsync();
            var assets = await _context.Set<xpAsset>().FromSqlRaw("EXEC dbo.xpAsset_Add {0}", jsAsset).ToListAsync();
            if (assets != null && assets.Count > 0)
                asset = assets[0];

            return Ok(asset);
        }

        [HttpPost("Asset-Update")]
        public async Task<ActionResult<xpAsset>> Asset_Update(xpAsset _asset)
        {
            var asset = new xpAsset();
            string jsAsset = JsonSerializer.Serialize<xpAsset>(_asset);

            //var assets = await _context.Set<xpAsset>().FromSqlRaw("EXEC dbo.xpAsset_Update {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}", s.Company_Id, s.Id, s.Category, s.Prefix, s.Class, s.Serial_Number, s.Name, s.Type, s.Model, s.Brand, s.Specifications, s.Fuel, s.Emission, s.Production_Year, s.Item_Condition, s.Purchase_Date, s.Price, s.Supplier_Id, s.Warranty, s.Warranty_Exp_Date, s.Insurance, s.Insurance_Exp_Date, s.Resale_Date, s.Resale_Price, s.Hours_Meter, s.Status).ToListAsync();
            var assets = await _context.Set<xpAsset>().FromSqlRaw("EXEC dbo.xpAsset_Update", jsAsset).ToListAsync();
            if (assets != null && assets.Count > 0)
                asset = assets[0];

            return Ok(asset);
        }

        [HttpDelete("Asset-Delete/{id}")]
        public async Task<ActionResult<xpAsset>> Asset_Delete(string id)
        {
            var asset = new xpAsset();

            var assets = await _context.Set<xpAsset>().FromSqlRaw("EXEC dbo.xpAsset_Delete {0}", id).ToListAsync();
            if (assets != null && assets.Count > 0)
                asset = assets[0];

            return Ok(asset);
        }

        #endregion
    }
#pragma warning restore CS0436 // Type conflicts with imported type
#pragma warning restore CS8604 // Possible null reference argument.
}
