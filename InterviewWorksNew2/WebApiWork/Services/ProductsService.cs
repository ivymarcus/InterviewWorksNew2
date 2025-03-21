using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiWork.Models;
using WebApiWork.Repositories;

namespace WebApiWork.Services
{
    public class ProductsService
    {
        public ProductsRepository resp = new ProductsRepository();

        /// <summary>
        ///  Response - 錯誤訊息
        /// </summary>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public ResponseModel ErrorResponse(string errMsg)
        {
            ResponseModel response = new ResponseModel()
            {
                Status = 2,
                Message = errMsg
            };

            return response;
        }

        /// <summary>
        /// 檢查欄位 是否皆有填寫
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public string CheckFile(ProductRequestModel model)
        {
            string errMsg = String.Empty;

            // ProductName 皆必填
            if (String.IsNullOrEmpty(model.ProductName))
            {
                errMsg += "ProductName 不可為空、";
            }

            // 新增、更新時，此欄位必填 (刪除例外)
            if (model.Status == "N" || model.Status == "U")
            {
                if (String.IsNullOrEmpty(model.Explain))
                {
                    errMsg += "Explain 不可為空、";
                }

                if (String.IsNullOrEmpty(model.ItemCategory))
                {
                    errMsg += "ItemCategory 不可為空、";
                }
            }

            return errMsg;

        }

        /// <summary>
        /// 新增 商品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ResponseModel CreateProduct(ProductRequestModel model)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                // 需確認 欄位是否皆有填寫
                string checkFileErrMsg = CheckFile(model);
                if (String.IsNullOrEmpty(checkFileErrMsg))
                {
                    responseModel = resp.CreateProduct(model);
                }
                else
                {
                    responseModel = ErrorResponse(checkFileErrMsg);
                }

            }
            catch (Exception ex)
            {
                responseModel.Status = 2;
                responseModel.Message = $"新增-失敗 訊息如下: {ex.Message}";
            }

            return responseModel;

        }



    }
}