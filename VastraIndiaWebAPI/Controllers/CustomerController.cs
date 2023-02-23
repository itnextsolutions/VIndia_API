using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Nancy.Json;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Xml.Linq;
using VastraIndiaDAL;
using VastraIndiaWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VastraIndiaWebAPI.Controllers
{
    //[Route("api/[controller]")]
   // [ApiController]
    public class CustomerController : ControllerBase
    {
        DataTable dt = new DataTable();
        CustomerDAL customer = new CustomerDAL();
        SaveImageDAL saveImage = new SaveImageDAL();

        // GET: api/<CustomerController>
        [HttpGet]
        [Route("api/Customer/GetCustomerReview")]
        public JsonResult GetCustomerReview()
        {
            dt = customer.GetCustomerReview();
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dt.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            return new JsonResult(parentRow);
        }

        // GET api/<CustomerController>/5
        [Route("api/Customer/GetCustomerReviewByid")]
        [HttpGet("{id}")]
        public IActionResult GetCustomerReviewById(int id)
        {
            dt = customer.GetCustomerReviewById(id);
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dt.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            return new JsonResult(parentRow);
        }



        // POST api/<CustomerController>
        [Route("api/Customer/InsertCustomerReview")]
        [HttpPost]
        public async Task<ActionResult> SaveCustReview([FromForm] CustomerModel cust)
        {

            var Ext = System.IO.Path.GetExtension(cust.formFile.FileName);

            var FileName = cust.Client_Name + "_" + DateTime.Now.ToString("dd/MM/yyyy") + Ext;

            var ClientReviewsFolderName = Path.Combine("C:", "Alpesh", "Angular Projects", "Vastra", "src", "assets", "img", "client_reviews");

            if (!Directory.Exists(ClientReviewsFolderName))
            {
                //If Directory (Folder) does not exists. Create it.
                Directory.CreateDirectory(ClientReviewsFolderName);
            }

            dt = customer.InsertCustomerReview(cust.Client_Name, cust.Profession, cust.Review, FileName, cust.Rating);

            var SaveImage = saveImage.SaveImagesAsync(cust.formFile, FileName, ClientReviewsFolderName);

            return new JsonResult("Added Successfully");
        }

        // PUT api/<CustomerController>/5
        [Route("api/Customer/UpdateCustomerReview")]
        //  [HttpPut("{id}")]
        [HttpPut]
        public async Task<ActionResult> UpdateCustReview([FromForm] CustomerModel cust)
        {

            var Ext = System.IO.Path.GetExtension(cust.formFile.FileName);

            var FileName = cust.Client_Name + "_" + DateTime.Now.ToString("dd/MM/yyyy") + Ext;

            var ClientReviewsFolderName = Path.Combine("C:", "Alpesh", "Angular Projects", "Vastra", "src", "assets", "img", "client_reviews");

            if (!Directory.Exists(ClientReviewsFolderName))
            {
                //If Directory (Folder) does not exists. Create it.
                Directory.CreateDirectory(ClientReviewsFolderName);
            }

            dt = customer.UpdateCustomerReview(cust.Customer_Review_Id, cust.Client_Name, cust.Profession, cust.Review, FileName, cust.Rating);
            var SaveImage = saveImage.SaveImagesAsync(cust.formFile, FileName, ClientReviewsFolderName);
            return new JsonResult("Updated Successfully");

        }


        // DELETE api/<CustomerController>/5
        [Route("api/Customer/DeleteCustomerReview")]
        [HttpDelete("{id}")]
        // DELETE api/<ProductController>/5
        public void Delete(int id)
        {

            dt = customer.DeleteCustomerReviewById(id);

        }

        [HttpGet]
        [Route("api/Customer/GetCustomerReviewPagination")]
        public JsonResult GetCustomerReviewPagination(int pageNo, int pageSize)
        {
            dt = customer.GetCustomerReviewPage(pageNo, pageSize);
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dt.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            return new JsonResult(parentRow);
        }


        [HttpGet]
        [Route("api/Customer/GetCustomerReviewCount")]
        public JsonResult GetCustomerReviewCount()
        {
            dt = customer.GetCustomerReviewCount();
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in dt.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            return new JsonResult(parentRow);
        }
    }
}
