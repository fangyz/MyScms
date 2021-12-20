using CoreService.ProductManage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Scms.BusinessModel;
using Scms.CoreService;
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
        #endregion

        #region Bom维护
        public IActionResult BomIndex()
        {
            return View();
        }

        public string SearchBomByCode(string itemCode)
        {
            return JsonHelp.ToJson(BomService.SearchBomByCode(itemCode));
        }

        public string DelBomById(int bomId)
        {
            return JsonHelp.ToJson(BomService.DelBomById(bomId));
        }

        public string AddBom(string parentItem, string childItem, int childCount)
        {
            return JsonHelp.ToJson(BomService.AddBom(parentItem, childItem, childCount));
        }
        #endregion
    }
}
