using System;

namespace Scms.DbModel
{
    public class Base_Bom
    {
        public int Id { get; set; }
        public string ParentItemCode { get; set; }
        public string ChildItemCode { get; set; }
        public string ChildItemName { get; set; }
        /// <summary>
        /// 物料数量
        /// </summary>
        public int ChildItemCount { get; set; }
        public bool IsDelete { get; set; }
        public string DeleteUser { get; set; }
        public DateTime? DeleteTime { get; set; }
    }
}
