using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using System.Data;
using VastraIndiaDAL;
using VastraIndiaWebAPI.Models;

namespace VastraIndiaWebAPI.Controllers
{
    public class NotificationController : Controller
    {
        DataTable dt = new DataTable();
        NotificationDAL objNotificationDAL = new NotificationDAL();
        SqlHelper objsqlHelper = new SqlHelper();

        [HttpGet]
        [Route("api/Notification/GetNotification")]
        public JsonResult GetNotification()
        {
            dt = objNotificationDAL.GetNotification();
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

        // POST api/<ProductController>
        [Route("api/Notification/InsertNotification")]
        [HttpPost]
        public IActionResult Post([FromBody] NotificationModel notification)
        {

            dt = objNotificationDAL.InsertNotification(notification.NotificationTitle, notification.FromDate, notification.ToDate, notification.ButtonText, notification.ButtonUrl);
            return new JsonResult("Added Successfully");
        }

        // PUT api/<ProductController>/5
        [Route("api/Notification/UpdateNotification")]
        //  [HttpPut("{id}")]
        [HttpPut]
        public IActionResult Put([FromBody] NotificationModel Notification)
        {


            dt = objNotificationDAL.UpdateNotification(Notification.NotificationId, Notification.NotificationTitle, Notification.FromDate, Notification.ToDate, Notification.ButtonText, Notification.ButtonUrl);

            return new JsonResult("Updated Successfully");

        }

        [Route("api/Notification/DeleteNotification")]
        [HttpDelete("{id}")]
        // DELETE api/<ProductController>/5
        public IActionResult DeleteProdctColor(int id)
        {

            dt = objNotificationDAL.DeleteNotification(id);
            return new JsonResult("Deleted Successfully");
        }


        [HttpGet]
        [Route("api/Notification/GetNotificationPagination")]
        public JsonResult GetNotificationPagination(int pageNo, int pageSize)
        {
            dt = objNotificationDAL.GetNotificationPagination(pageNo,pageSize);
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
        [Route("api/Notification/GetNotificationCount")]
        public JsonResult GetNotificationCount()
        {
            dt = objNotificationDAL.GetNotificationCount();
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
