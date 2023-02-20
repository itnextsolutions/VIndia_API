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
        public IActionResult Post([FromBody] CustomerModel cust)
        {
            dt = customer.InsertCustomerReview(cust.Client_Name,cust.Profession,cust.Review,cust.Client_Photo,cust.Rating);
            return new JsonResult("Added Successfully");
        }


        // PUT api/<CustomerController>/5
        [Route("api/Customer/UpdateCustomerReview")]
        //  [HttpPut("{id}")]
        [HttpPut]
        public IActionResult Put([FromBody] CustomerModel cust)
        {
            if (cust != null)
            {
                if (cust.Customer_Review_Id != 0)
                {
                    dt = customer.UpdateCustomerReview(cust.Customer_Review_Id, cust.Client_Name, cust.Profession, cust.Review, cust.Client_Photo, cust.Rating);
                    return new JsonResult("Updated Successfully");
                }
            }
            return new JsonResult("Entered Data is not valid");

        }

        //// DELETE api/<CustomerController>/5
        //[Route("api/Product/DeleteProduct")]
        //[HttpDelete("{id}")]
        //// DELETE api/<ProductController>/5
        //public void Delete(int id)
        //{

        //    dt = customer.De(id);

        //}

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

        [HttpPost, DisableRequestSizeLimit]
        [Route("api/Customer/Upload")]
        public async Task<IActionResult> UploadAsync()
        {
            try
            {

                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
