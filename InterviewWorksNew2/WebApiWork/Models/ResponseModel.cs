using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiWork.Models
{
    public class ResponseModel
    {
        /// <summary>
        /// 成功顯示: 1
        /// 失敗顯示: 2
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 訊息
        /// </summary>
        public string Message { get; set; }
    }
}