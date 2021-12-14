using System;

namespace Scms.DbModel
{
    public class Base_ItemInfo
    {
        public long Id { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Specifications { get; set; }
        public string PictrueNo { get; set; }
        public string Brand { get; set; }
        public int ItemType { get; set; }
        public string CreateUser{get;set;}
        public DateTime CreateTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsDelete { get; set; }
        public string DeleteUser { get; set; }
        public DateTime? DeleteTime { get; set; }


    }
}
