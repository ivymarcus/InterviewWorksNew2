using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiWork.Models;
using WebApiWork.Services;

namespace WebApiWork.Controllers
{
    public class ProductsController : ApiController
    {
        public ProductsService service = new ProductsService();

        [HttpPost]
        [Route("ProductChanges")]
        public ResponseModel ProductChangesRequest(ProductRequestModel requestModel)
        {
            if(requestModel == null) return service.ErrorResponse("資料為空");

            ResponseModel responseModel = new ResponseModel();
            string status = requestModel.Status;
            if(status == "N")
            {
                responseModel = service.CreateProduct(requestModel);
            }
            else
            {
                responseModel = service.ErrorResponse("欄位Status無效，請確認是否正確(N/U/D)");
            }

            return responseModel;
        }

    }
}
