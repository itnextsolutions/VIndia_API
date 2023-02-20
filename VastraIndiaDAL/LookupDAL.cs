using FizzWare.NBuilder.Dates;
using NHibernate.SqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace VastraIndiaDAL
{
    public class LookupDAL
    {
        DataTable dt = new DataTable();
        SqlHelper objsqlHelper = new SqlHelper();
        List<SqlParameter> SqlParameters = new List<SqlParameter>();

        public DataTable LookupMaster()
        {
            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetLookupMaster");
            return dt;
        }

        public DataTable LookupNameDropDown()
        {
            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetLookupNameDropDown");
            return dt;
        }

        public DataTable GetLookupMasterById(int id)
        {

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter();
            param[0].ParameterName = "@Id";
            param[0].Value = id;
            param[0].Direction = ParameterDirection.Input;

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetLookupMasterById", param);
            return dt;
        }

        public DataTable InsertLookupMaster(string LookupName)
        {
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter();
            param[0].ParameterName = "@Lookup_Name";
            param[0].Value = LookupName;
            param[0].Direction = ParameterDirection.Input;

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_InsertLookupMaster", param);
            return dt;
        }
        public DataTable UpdateLookupMaster(int Id, string LookupName)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter();
            param[0].ParameterName = "@Id";
            param[0].Value = Id;
            param[0].Direction = ParameterDirection.Input;

            param[1] = new SqlParameter();
            param[1].ParameterName = "@Lookup_Name";
            param[1].Value = LookupName;
            param[1].Direction = ParameterDirection.Input;
            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_UpdateLookupMaster", param);
            return dt;
        }
        public DataTable DeleteLookupMaster(int Id)
        {
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter();
            param[0].ParameterName = "@Id";
            param[0].Value = Id;
            param[0].Direction = ParameterDirection.Input;

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_DeleteLookupMasterById", param);
            return dt;
        }
        public DataTable LookupDetails()
        {
            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetLookupDetails");
            return dt;
        }


        public DataTable GetLookupDetailsById(int LookupDetailsId)
        {
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter();
            param[0].ParameterName = "@Lookup_Details_Id";
            param[0].Value = LookupDetailsId;
            param[0].Direction = ParameterDirection.Input;

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetLookupDetailsById", param);
            return dt;
        }

        public DataTable InsertLookupDetails(int Lookup_Id, string Description)
        {
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter();
            param[0].ParameterName = "@Lookup_Id";
            param[0].Value = Lookup_Id;
            param[0].Direction = ParameterDirection.Input;

            param[1] = new SqlParameter();
            param[1].ParameterName = "@Description";
            param[1].Value = Description;
            param[1].Direction = ParameterDirection.Input;

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_InsertLookupDetails", param);
            return dt;
        }

        public DataTable UpdateLookupDetails(int LookupDetailsId, int Lookup_Id, string Description)
        {
            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter();
            param[0].ParameterName = "@Lookup_Details_Id";
            param[0].Value = LookupDetailsId;
            param[0].Direction = ParameterDirection.Input;

            param[1] = new SqlParameter();
            param[1].ParameterName = "@Lookup_Id";
            param[1].Value = Lookup_Id;
            param[1].Direction = ParameterDirection.Input;

            param[2] = new SqlParameter();
            param[2].ParameterName = "@Description";
            param[2].Value = Description;
            param[2].Direction = ParameterDirection.Input;

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_UpdateLookupDetails", param);
            return dt;
        }

        public DataTable DeleteLookupDetailsById(int Id)
        {
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter();
            param[0].ParameterName = "@Lookup_Details_Id";
            param[0].Value = Id;
            param[0].Direction = ParameterDirection.Input;

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_DeleteLookupDetailsById", param);
            return dt;
        }

        public DataTable GetColor()
        {
            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetColor");
            return dt;
        }

        public DataTable GetSize()
        {
            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetSize");
            return dt;
        }
        public DataTable GetLookupMasterPagination(int pageNo, int pageSize)
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

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetLookupMasterPagination", param);
            return dt;
        }

        public DataTable GetLookupMasterCount()
        {
            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetLookupMasterCount");
            return dt;
        }


        public DataTable GetLookupDetailsPagination(int pageNo, int pageSize)
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

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetLookupDetailPagination", param);
            return dt;
        }

        public DataTable GetLookupDetailsCount()
        {
            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetLookupDetailCount");
            return dt;
        }

    }

}
