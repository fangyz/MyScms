using CommonHelp;
using CoreService.ProductManage;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scms.Web.Areas.ProductManage
{
    [Area("ProductManage")]
    public class ProductController : Controller
    {
        #region 料号管理
        public IActionResult ItemIndex()
        {
            return View();
        }
        #endregion

        #region Bom维护
        public IActionResult BomIndex()
        {
            return View();
        }

        public string SearchBomByCode(string itemCode)
        {
            return JsonHelper.ToJson(BomService.SearchBomByCode(itemCode));
        }

        public string DelBomById(int bomId)
        {
            return JsonHelper.ToJson(BomService.DelBomById(bomId));
        }

        public string AddBom(string parentItem, string childItem, int childCount)
        {
            return JsonHelper.ToJson(BomService.AddBom(parentItem, childItem, childCount));
        }
        #endregion
    }
}
