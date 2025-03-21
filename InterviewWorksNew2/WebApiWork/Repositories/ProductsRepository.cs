using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiWork.Helpers;
using WebApiWork.Models;

namespace WebApiWork.Repositories
{
    public class ProductsRepository
    {
        /// <summary>
        /// 建立商品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ResponseModel CreateProduct(ProductRequestModel model)
        {
            string sql = @"declare 
                            @v_product_name nvarchar(100),
                            @v_category_id nvarchar(30),
                            @v_out_status int,
                            @v_out_msg nvarchar(100)
                          
                           select @v_product_name = ProductName
                           from Product (nolock)
                           where ProductName = @ProductName
                          
                           if @@ROWCOUNT > 0
                            begin
                              set @v_out_status = 2
                          	  set @v_out_msg = N'此商品已存在'
                          	  goto OutMsg
                            end
                          
                            select @v_category_id = CategoryID
                            from Category (nolock)
                            where CategoryName = @ItemCategory
                          
                           if @@ROWCOUNT = 0
                            begin
                              set @v_out_status = 2
                          	  set @v_out_msg = N'無效的商品類別'
                          	  goto OutMsg
                            end
                          
                            insert into Product (ProductName, Explain, UnitPrice, Discount, CategoryID)
                            values (@ProductName, @Explain, @UnitPrice, @Discount, @v_category_id)
                          
                            if @@ROWCOUNT = 1
                              begin
                               set @v_out_status = 1
                          	   set @v_out_msg = N'建立-成功'
                          	   goto OutMsg
                              end
                            else
                              begin
                               set @v_out_status = 2
                          	   set @v_out_msg = N'建立-失敗'
                          	   goto OutMsg
                              end
                          
                          OutMsg:
                            select 
                            @v_out_status as 'Status',
                            @v_out_msg as 'Message'";

            ResponseModel responseModel = DapperHelper.Get<ResponseModel>(sql, model).FirstOrDefault();
            return responseModel;
        }


    }
}