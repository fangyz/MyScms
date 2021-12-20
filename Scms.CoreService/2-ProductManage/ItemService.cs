using Microsoft.Extensions.Logging;
using Scms.BusinessModel;
using Scms.ToolHelp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scms.CoreService
{
    public static  class ItemService
    {
        public static ILogger<object> Logger;

        public static ResultModel SearchItem(SearchItemModel model)
        {
            
            using(var dbContext=new ScmsDbContext())
            {
                var list = dbContext.Base_ItemInfo.Where(s=>s.IsDelete==false);
                if (string.IsNullOrEmpty(model?.ItemCode)==false)
                    list = list.Where(s => s.ItemCode == model.ItemCode);

                if (string.IsNullOrEmpty(model?.ItemName) == false)
                    list = list.Where(s => s.ItemName == model.ItemName);

                if (string.IsNullOrEmpty(model?.CreateUser) == false)
                    list = list.Where(s => s.CreateUser == model.CreateUser);

                var itemList = list.ToList();
                return new ResultModel() { ResultObj = itemList, IsSuccess = true };
            }
        }
    }
}
