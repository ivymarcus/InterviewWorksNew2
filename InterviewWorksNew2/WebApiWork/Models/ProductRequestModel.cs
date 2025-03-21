using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiWork.Models
{
    public class ProductRequestModel
    {
        /// <summary>
        /// 狀態目的 (N/U/D)
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// 商品名稱 (必填)
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 說明 (必填)
        /// </summary>
        public string Explain { get; set; }
        /// <summary>
        /// 商品類別 (必填)
        /// </summary>
        public string ItemCategory { get; set; }
        /// <summary>
        /// 單價
        /// </summary>
        public int UnitPrice { get; set; }
        /// <summary>
        /// 折扣
        /// </summary>
        public float Discount { get; set; }

    }
}