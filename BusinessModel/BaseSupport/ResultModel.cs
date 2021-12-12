using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.BaseSupport
{
    public class ResultModel
    {
        public bool IsSuccess { get; set; }
        public string ResultString { get; set; }
        public string ResultString2 { get; set; }
        public string Message { get; set; }
        public string Message2 { get; set; }
    }
}
