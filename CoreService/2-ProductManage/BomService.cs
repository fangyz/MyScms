using BusinessModel.BaseSupport;
using CommonHelp;
using DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreService.ProductManage
{
    public static  class BomService
    {
        /// <summary>
        /// 通过物料编码查询bom
        /// </summary>
        /// <param name="itemCode"></param>
        /// <returns></returns>
        public static ResultModel SearchBomByCode(string itemCode)
        {
            if (string.IsNullOrEmpty(itemCode))
                return new ResultModel { Message= ErrMsgModel.CriteriaEmpty};

            ResultModel resultModel = new ResultModel();
            using (var dbContext = new ScmsDbContext())
            {
                List<Base_Bom> base_Boms = dbContext.Base_Bom.Where(s => s.ParentItemCode == itemCode && s.IsDelete == false).ToList();
                if (base_Boms.Count > 0)
                {
                    resultModel.ResultString = JsonHelper.ToJson(base_Boms);
                    resultModel.IsSuccess = true;
                }
                else
                {
                    resultModel.IsSuccess = false;
                    resultModel.Message = "此料号下面没有子料号";
                }

            }
            return resultModel;
        }

        /// <summary>
        /// 根据BomId删除bom关系数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static ResultModel DelBomById(int bomId)
        {
            ResultModel resultModel = new ResultModel();
            using (var dbContext = new ScmsDbContext())
            {
                var bom= dbContext.Base_Bom.Where(s => s.Id == bomId && s.IsDelete == false).FirstOrDefault();
                if (bom == null)
                {
                    resultModel.Message = "不存在要删除的数据";
                    return resultModel;
                }
                bom.IsDelete = true;
                bom.DeleteTime = DateTime.Now;
                bom.DeleteUser = "admin";
                dbContext.SaveChanges();
                resultModel.IsSuccess = true;
                return resultModel;
            }
        }

        /// <summary>
        /// 新增bom
        /// </summary>
        /// <param name="parentItem"></param>
        /// <param name="childItem"></param>
        /// <returns></returns>
        public static ResultModel AddBom(string parentItemCode, string childItemCode,int childCount)
        {
            //MK0123458
            if (string.IsNullOrEmpty(parentItemCode?.Trim()))
                return new ResultModel {Message = "请输入父料号" };
            if (string.IsNullOrEmpty(childItemCode?.Trim()))
                return new ResultModel {Message = "请输入子料号" };
            if (childCount == 0)
                return new ResultModel { Message = "子料号数量不能为0" };

            using(var dbContext=new ScmsDbContext())
            {
                //基本料号检查
                var parentItem= dbContext.Base_ItemInfo.Where(s => s.IsDelete == false && s.ItemCode == parentItemCode).FirstOrDefault();
                if (parentItem == null)
                    return new ResultModel { Message = "您输入的父料号不存在" };
                var childItem = dbContext.Base_ItemInfo.Where(s => s.IsDelete == false && s.ItemCode == childItemCode).FirstOrDefault();
                if (childItem == null)
                    return new ResultModel { Message = "您输入的子料号不存在" };

                //检查bom关系是否已存在
                var existBom= dbContext.Base_Bom.Where(s => s.IsDelete == false & s.ParentItemCode == parentItemCode && s.ChildItemCode == childItemCode).FirstOrDefault();
                if (existBom != null)
                    return new ResultModel { Message = "此父料号下面已有要添加的子料号" };

                Base_Bom base_Bom = new Base_Bom();
                base_Bom.ParentItemCode = parentItemCode;
                base_Bom.ChildItemCode = childItemCode;
                base_Bom.ChildItemName = childItem.ItemName;
                base_Bom.ChildItemCount = childCount;
                dbContext.Base_Bom.Add(base_Bom);
                dbContext.SaveChanges();
            }
            return new ResultModel { IsSuccess = true };

        }

    }
}
