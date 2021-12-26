using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Scms.BusinessModel;
using Scms.CoreService;
using Scms.DbModel;
using Scms.ToolHelp;

namespace Scms.Web.Areas.ProductManage
{
    [Area("ProductManage")]
    public class ProductController : Controller
    {
        public ProductController(ILogger<ProductController> logger,ScmsDbContext scmsDbContext)
        {
            ItemService.dbContext = scmsDbContext;
            ItemService.log = logger;

            BomService.dbContext = scmsDbContext;
            BomService.log = logger;

        }


        #region 料号管理
        public IActionResult ItemIndex()
        {
            return View();
        }

        [HttpGet]
        public string SearchItem(string itemCode,string itemName,string createUser)
        {
            SearchItemModel model = new SearchItemModel { ItemCode = itemCode, ItemName = itemName, CreateUser = createUser };
            return JsonHelp.ToJson(ItemService.SearchItem(model));
        }

        /// <summary>
        /// 新增物料
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public string AddItem(Base_ItemInfo item)
        {
            return JsonHelp.ToJson(ItemService.AddItem(item));
        }
        /// <summary>
        /// 编辑物料
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string EditItem(Base_ItemInfo item)
        {
            return JsonHelp.ToJson(ItemService.EditItem(item));
        }

        #endregion

        #region Bom维护
        public IActionResult BomIndex()
        {
            return View();
        }



        [HttpPost]
        public string SearchBomByCode(string itemCode)
        {
            return JsonHelp.ToJson(BomService.SearchBomByCode(itemCode));
        }

        [HttpPost]
        public string DelBomById(int bomId)
        {
            return JsonHelp.ToJson(BomService.DelBomById(bomId));
        }

        [HttpPost]
        public string AddBom(string parentItem, string childItem, int childCount)
        {
            return JsonHelp.ToJson(BomService.AddBom(parentItem, childItem, childCount));
        }
        #endregion
    }
}
