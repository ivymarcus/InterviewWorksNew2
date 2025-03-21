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
        /// 新增 - 商品
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


        /// <summary>
        /// 更新 - 商品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ResponseModel UpdateProduct(ProductRequestModel model)
        {
            string sql = @"declare 
                          @v_product_id nvarchar(100),
                          @v_category_id nvarchar(30),
                          @v_out_status int,
                          @v_out_msg nvarchar(100)
                        
                         select @v_product_id = ProductID
                         from Product (nolock)
                         where ProductName = @ProductName
                        
                         if @@ROWCOUNT = 0
                           begin
                              set @v_out_status = 2
                        	  set @v_out_msg = N'此商品不存在，請先建立'
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
                        
                          update Product with (rowlock)
                          set ProductName = @ProductName,
                            Explain = @Explain,
                        	UnitPrice = @UnitPrice,
                        	Discount = @Discount,
                        	CategoryID = @v_category_id
                          where ProductID = @v_product_id
                        
                          if @@ROWCOUNT = 1
                            begin
                             set @v_out_status = 1
                        	 set @v_out_msg = N'更新-成功'
                        	 goto OutMsg
                            end
                          else
                            begin
                             set @v_out_status = 2
                        	 set @v_out_msg = N'更新-失敗'
                        	 goto OutMsg
                            end
                        
                        OutMsg:
                          select 
                          @v_out_status as 'Status',
                          @v_out_msg as 'Message'";

            ResponseModel responseModel = DapperHelper.Get<ResponseModel>(sql, model).FirstOrDefault();
            return responseModel;

        }

        /// <summary>
        /// 刪除 - 商品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ResponseModel DeleteProduct(ProductRequestModel model)
        {
            string sql = @"declare 
                          @v_product_id nvarchar(100),
                          @v_out_status int,
                          @v_out_msg nvarchar(100)
                        
                         select @v_product_id = ProductID
                         from Product (nolock)
                         where ProductName = @ProductName
                        
                         if @@ROWCOUNT = 0
                           begin
                              set @v_out_status = 2
                        	  set @v_out_msg = N'此商品不存在，無法刪除'
                        	  goto OutMsg
                           end
                        
                         begin tran
                         delete from Product
                         where ProductID = @v_product_id
                        
                          if @@ROWCOUNT = 1
                            begin
                        	  commit
                              
                        	  set @v_out_status = 1
                        	  set @v_out_msg = N'刪除-成功'
                        	  goto OutMsg
                            end
                          else
                            begin
                        	  rollback
                              
                        	  set @v_out_status = 2
                        	  set @v_out_msg = N'刪除-失敗'
                        	  goto OutMsg
                            end
                        
                        OutMsg:
                          select 
                          @v_out_status as 'Status',
                          @v_out_msg as 'Message'";

            ResponseModel responseModel = DapperHelper.Get<ResponseModel>(sql, model).FirstOrDefault();
            return responseModel;
        }

        /// <summary>
        ///  取得 - 全部商品
        /// </summary>
        /// <returns></returns>
        public List<ProductModel> GetProducts()
        {
            string sql = @"select 
                            itm.ProductName,
                            itm.Explain,
                            itc.CategoryName,
                            itm.UnitPrice,
                            itm.Discount
                          from Product itm (nolock)
                          inner join Category itc (nolock)
                            on itc.CategoryID = itm.CategoryID
                          order by itm.ProductID desc";

            List<ProductModel> responseModel = DapperHelper.Get<ProductModel>(sql);
            return responseModel;
        }

    }
}