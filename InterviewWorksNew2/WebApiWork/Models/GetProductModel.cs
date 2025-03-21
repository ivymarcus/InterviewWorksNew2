using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiWork.Models
{
    public class GetProductModel
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
        /// <summary>
        ///  全部商品
        /// </summary>
        public List<ProductModel> ProductModels { get; set; }
    }

    public class ProductModel
    {
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
        public string CategoryName { get; set; }
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