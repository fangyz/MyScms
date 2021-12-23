using Microsoft.AspNetCore.Mvc;
using Scms.BusinessModel;
using Scms.CoreService;
using Scms.ToolHelp;

namespace Scms.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public string SearchItem(string itemCode, string itemName, string createUser)
        {
            SearchItemModel model = new SearchItemModel { ItemCode = itemCode };
            return JsonHelp.ToJson(ItemService.SearchItem(model));
        }
    }


}
