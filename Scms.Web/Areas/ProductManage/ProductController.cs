using CoreService.ProductManage;
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
        public ProductController(ILogger<ProductController> logger)
        {
            BomService.Logger = logger;
            ItemService.Logger = logger;
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
        /// 新增料号
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public string AddItem(Base_ItemInfo item)
        {
            return JsonHelp.ToJson(ItemService.AddItem(item));
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
