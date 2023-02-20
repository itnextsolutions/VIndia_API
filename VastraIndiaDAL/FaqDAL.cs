using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VastraIndiaDAL
{

    public class FaqDAL
    {
        DataTable dt = new DataTable();
        SqlHelper objsqlHelper = new SqlHelper();
        List<SqlParameter> SqlParameters = new List<SqlParameter>();
        public DataTable GetFaqPagination(int pageNo, int pageSize)
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

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetFaqPagination", param);
            return dt;
        }

        public DataTable GetFaqCount()
        {
            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetFaqCount");
            return dt;
        }

        public DataTable InsertFaq(string question, string answer)
        {
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter();
            param[0].ParameterName = "@Question";
            param[0].Value = question;
            param[0].Direction = ParameterDirection.Input;

            param[1] = new SqlParameter();
            param[1].ParameterName = "@Answer";
            param[1].Value = answer;
            param[1].Direction = ParameterDirection.Input;

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_InsertFaq", param);
            return dt;
        }

        public DataTable updateFaq(int id, string question, string answer)
        {
            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter();
            param[0].ParameterName = "@Id";
            param[0].Value = id;
            param[0].Direction = ParameterDirection.Input;

            param[1] = new SqlParameter();
            param[1].ParameterName = "@Question";
            param[1].Value = question;
            param[1].Direction = ParameterDirection.Input;

            param[2] = new SqlParameter();
            param[2].ParameterName = "@Answer";
            param[2].Value = answer;
            param[2].Direction = ParameterDirection.Input;

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_UpdateFaq", param);
            return dt;
        }

        public DataTable DeleteFaq(int id)
        {
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter();
            param[0].ParameterName = "@Id";
            param[0].Value = id;
            param[0].Direction = ParameterDirection.Input;


            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_DeleteFaq", param);
            return dt;
        }

    }
}
