using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VastraIndiaDAL
{
    public class NotificationDAL
    {

        DataTable dt = new DataTable();
        SqlHelper objsqlHelper = new SqlHelper();
        List<SqlParameter> SqlParameters = new List<SqlParameter>();


        public DataTable GetNotification()
        {
            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetNotification");
            return dt;
        }

        public DataTable InsertNotification(string Title, DateTime FromDate, DateTime ToDate, string ButtonText, string ButtonUrl)
        {
            SqlParameter[] param = new SqlParameter[5];

            param[0] = new SqlParameter();
            param[0].ParameterName = "@NotificationTitle";
            param[0].SqlDbType = SqlDbType.VarChar;
            param[0].Value = Title;
            param[0].Direction = ParameterDirection.Input;

            param[1] = new SqlParameter();
            param[1].ParameterName = "@FromDate";
            param[1].SqlDbType = SqlDbType.DateTime;
            param[1].Value = FromDate;
            param[1].Direction = ParameterDirection.Input;

            param[2] = new SqlParameter();
            param[2].ParameterName = "@ToDate";
            param[2].SqlDbType = SqlDbType.DateTime;
            param[2].Value = ToDate;
            param[2].Direction = ParameterDirection.Input;

            param[3] = new SqlParameter();
            param[3].ParameterName = "@ButtonText";
            param[3].SqlDbType = SqlDbType.VarChar;
            param[3].Value = ButtonText;
            param[3].Direction = ParameterDirection.Input;

            param[4] = new SqlParameter();
            param[4].ParameterName = "@ButtonUrl";
            param[4].SqlDbType = SqlDbType.VarChar;
            param[4].Value = ButtonUrl;
            param[4].Direction = ParameterDirection.Input;



            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_InsertNotification", param);
            return dt;
        }


        public DataTable UpdateNotification(int Id, string Title, DateTime FromDate, DateTime ToDate, string ButtonText, string ButtonUrl)
        {
            SqlParameter[] param = new SqlParameter[6];

            param[0] = new SqlParameter();
            param[0].ParameterName = "@NotificationId";
            param[0].SqlDbType = SqlDbType.VarChar;
            param[0].Value = Id;
            param[0].Direction = ParameterDirection.Input;

            param[1] = new SqlParameter();
            param[1].ParameterName = "@NotificationTitle";
            param[1].SqlDbType = SqlDbType.VarChar;
            param[1].Value = Title;
            param[1].Direction = ParameterDirection.Input;

            param[2] = new SqlParameter();
            param[2].ParameterName = "@FromDate";
            param[2].SqlDbType = SqlDbType.DateTime;
            param[2].Value = FromDate;
            param[2].Direction = ParameterDirection.Input;

            param[3] = new SqlParameter();
            param[3].ParameterName = "@ToDate";
            param[3].SqlDbType = SqlDbType.DateTime;
            param[3].Value = ToDate;
            param[3].Direction = ParameterDirection.Input;

            param[4] = new SqlParameter();
            param[4].ParameterName = "@ButtonText";
            param[4].SqlDbType = SqlDbType.VarChar;
            param[4].Value = ButtonText;
            param[4].Direction = ParameterDirection.Input;

            param[5] = new SqlParameter();
            param[5].ParameterName = "@ButtonUrl";
            param[5].SqlDbType = SqlDbType.VarChar;
            param[5].Value = ButtonUrl;
            param[5].Direction = ParameterDirection.Input;

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_UpdateNotification", param);
            return dt;
        }

        public DataTable DeleteNotification(int Id)
        {
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter();
            param[0].ParameterName = "@NotificationId";
            param[0].Value = Id;
            param[0].Direction = ParameterDirection.Input;

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_DeleteNotification", param);
            return dt;
        }
        public DataTable GetNotificationPagination(int pageNo, int pageSize)
        {
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter();
            param[0].ParameterName = "@PageNo";
            param[0].Value = pageNo;
            param[0].Direction = ParameterDirection.Input;

            param[1] = new SqlParameter();
            param[1].ParameterName = "@PageSize";
            param[1].Value = pageSize;
            param[1].Direction = ParameterDirection.Input;

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetNotificationPagination", param);
            return dt;
        }

        public DataTable GetNotificationCount()
        {
            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetNotificationCount");
            return dt;
        }

    }
}
