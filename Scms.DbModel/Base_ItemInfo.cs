using System;
using System.ComponentModel.DataAnnotations;

namespace Scms.DbModel
{
    public class Base_ItemInfo
    {
        public int Id { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Specifications { get; set; }
        public string PictureNo { get; set; }
        public string Brand { get; set; }
        public short ItemType { get; set; }
        public string CreateUser{get;set;}
        public DateTime CreateTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        //[Timestamp]
        public int RowVersion { get; set; }
        public bool IsDelete { get; set; }
        public string DeleteUser { get; set; }
        public DateTime? DeleteTime { get; set; }


    }
}
