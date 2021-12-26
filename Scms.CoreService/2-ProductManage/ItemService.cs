using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Scms.BusinessModel;
using Scms.DbModel;
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
        //public static ScmsDbContext dbContext;

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

                var itemList = list.AsNoTracking().ToList();
                return new ResultModel() { ResultObj = itemList, IsSuccess = true };
            }
        }

        public static ResultModel AddItem(Base_ItemInfo ItemInfo)
        {
            //新增物料
            return new ResultModel { IsSuccess = true };
        }


        //编辑物料
        public static ResultModel EditItem(Base_ItemInfo editItem)
        {
            if (string.IsNullOrEmpty(editItem?.ItemCode))
                return new ResultModel { IsSuccess = false, Message ="没有要编辑的物料"};

            try
            {
                using (var dbContext = new ScmsDbContext())
                {
                    var toEditItem = dbContext.Base_ItemInfo.Where(s => s.ItemCode == editItem.ItemCode && s.IsDelete == false).FirstOrDefault();
                    if (toEditItem == null)
                        return new ResultModel { IsSuccess = false, Message = "要编辑的物料不存在" };

                    toEditItem.ItemName = editItem.ItemName;
                    toEditItem.Specifications = editItem.Specifications;
                    toEditItem.Brand = editItem.Brand;
                    toEditItem.ItemType = editItem.ItemType;
                    toEditItem.PictureNo = editItem.PictureNo;
                    toEditItem.UpdateTime = DateTime.Now;
                    toEditItem.UpdateUser = "管理员";
                    toEditItem.RowVersion = toEditItem.RowVersion + 1;
                    dbContext.Entry(toEditItem).Property("RowVersion").OriginalValue = editItem.RowVersion;

                    try
                    {
                        dbContext.SaveChanges();
                    }
                    catch(DbUpdateConcurrencyException dex)
                    {
                        return new ResultModel { IsSuccess = false, Message =string.Format("已有其它用户【{0}】修改了此物料的数据，请您刷新后再编辑",((Base_ItemInfo)dex?.Entries?[0].Entity).UpdateUser)};
                    }
                }
            }
            catch(Exception ex)
            {
                return new ResultModel { IsSuccess = false, Message = ex.Message };
            }

            return new ResultModel { IsSuccess = true };
        }
    }
}
