using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Nancy.Json;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Text.Json;
using System.Xml.Linq;
using VastraIndiaDAL;
using VastraIndiaWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VastraIndiaWebAPI.Controllers
{
    // [Route("api/[controller]")]
    // [ApiController]
    public class LookupController : ControllerBase
    {
        DataTable dt = new DataTable();

        LookupDAL lookup = new LookupDAL();

        //LookupMaster start

        // GET: api/<LookupController>
        [HttpGet]
        [Route("api/Lookup/GetLookupMaster")]
        public JsonResult GetLookupMaster()
        {
            dt = lookup.LookupMaster();
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

        // GET api/<LookupController>/5
        [Route("api/Lookup/GetLookupMasterByid")]
        [HttpGet("{id}")]
        public IActionResult GetLookupMasterById(int id)
        {
            dt = lookup.GetLookupMasterById(id);
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

        // POST api/<LookupController>
        [Route("api/Lookup/InsertLookupMaster")]
        [HttpPost("")]
        public IActionResult Post([FromBody] LookupMasterModel lookupMaster)
        {
            dt = lookup.InsertLookupMaster(lookupMaster.Lookup_Name);
            return new JsonResult("Added Successfully");
        }

        // PUT api/<LookupController>/5
        [Route("api/Lookup/UpdateLookupMaster")]
        //  [HttpPut("{id}")]
        [HttpPut]
        public IActionResult Put([FromBody] LookupMasterModel lookupMaster)
        {
            if (lookupMaster.Lookup_Id != 0)
            {
                ;
                dt = lookup.UpdateLookupMaster(lookupMaster.Lookup_Id, lookupMaster.Lookup_Name);
                return new JsonResult("Updated Successfully");
            }
            return new JsonResult("Lookup_Id is not valid");

        }

        // DELETE api/<LookupController>/5
        [HttpDelete("{id}")]
        [Route("api/Lookup/DeleteLookupMaster")]
        public JsonResult Delete(int id)
        {
            dt = lookup.DeleteLookupMaster(id);
            return new JsonResult("Deleted Successfully");
        }
        //LookupMaster end


        [HttpGet]
        [Route("api/Lookup/GetLookupDetails")]
        public JsonResult GetLookupDetails()
        {
            dt = lookup.LookupDetails();
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


        [Route("api/Lookup/GetLookupDetailsById")]
        [HttpGet("{id}")]
        public IActionResult GetLookupDetailsById(int id)
        {
            dt = lookup.GetLookupDetailsById(id);
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

        [Route("api/Lookup/InsertLookupDetails")]
        [HttpPost]
        public IActionResult Post([FromBody] LookupDetailsModel lookupDetail)
        {
            dt = lookup.InsertLookupDetails(lookupDetail.Lookup_Id, lookupDetail.Description);
            return new JsonResult("Added Successfully");
        }

        [Route("api/Lookup/UpdateLookupDetails")]
        //  [HttpPut("{id}")]
        [HttpPut]
        public IActionResult Put([FromBody] LookupDetailsModel lookupDetail)
        {
            if (lookupDetail.Lookup_Details_Id != 0)
            {
                ;
                dt = lookup.UpdateLookupDetails(lookupDetail.Lookup_Details_Id, lookupDetail.Lookup_Id, lookupDetail.Description);
                return new JsonResult("Updated Successfully");
            }
            return new JsonResult("LookupDetailId is not valid");

        }
        // DELETE api/<LookupController>/5
        [HttpDelete("{id}")]
        [Route("api/Lookup/DeleteLookupDetails")]
        public JsonResult DeleteLookupDetails(int id)
        {
            dt = lookup.DeleteLookupDetailsById(id);
            return new JsonResult("Deleted Successfully");
        }

        [HttpGet]
        [Route("api/Lookup/GetLookupNameDropDown")]
        public JsonResult GetLookupNameDropDown()
        {
            dt = lookup.LookupNameDropDown();
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
        [Route("api/Lookup/GetColor")]
        public JsonResult GetColor()
        {
            dt = lookup.GetColor();
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
        [Route("api/Lookup/GetSize")]
        public JsonResult GetSize()
        {
            dt = lookup.GetSize();
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
        [Route("api/Lookup/GetLookupMasterPagination")]
        public JsonResult GetLookupMasterPagination(int pageNo, int pageSize)
        {
            dt = lookup.GetLookupMasterPagination(pageNo, pageSize);
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
        [Route("api/Lookup/GetLookupMasterCount")]
        public JsonResult GetLookupMasterCount()
        {
            dt = lookup.GetLookupMasterCount();
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

        // Lookup Details Pagination  Start
        [HttpGet]
        [Route("api/Lookup/GetLookupDetailsPagination")]
        public JsonResult GetLookupDetailsPagination(int pageNo, int pageSize)
        {
            dt = lookup.GetLookupDetailsPagination(pageNo, pageSize);
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
        [Route("api/Lookup/GetLookupDetailsCount")]
        public JsonResult GetLookupDetailsCount()
        {
            dt = lookup.GetLookupDetailsCount();
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
        // Lookup Details Pagination End

    }
}
