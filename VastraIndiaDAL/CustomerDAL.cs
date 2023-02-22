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
    public class CustomerDAL
    {

        DataTable dt = new DataTable();
        SqlHelper objsqlHelper = new SqlHelper();
        List<SqlParameter> SqlParameters = new List<SqlParameter>();

        public DataTable GetCustomerReview()
        {
            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetCustomerReview");
            return dt;
        }

        public DataTable GetCustomerReviewById(int id)
        {

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter();
            param[0].ParameterName = "@Customer_Review_Id";
            param[0].Value = id;
            param[0].Direction = ParameterDirection.Input;

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetCustomerReviewById", param);
            return dt;
        }

        public DataTable InsertCustomerReview(string Name,string Profession,string Review,string ClientPhoto,string Rating)
        {
            SqlParameter[] param = new SqlParameter[5];

            param[0] = new SqlParameter();
            param[0].ParameterName = "@Client_Name";
            param[0].Value = Name;
            param[0].Direction = ParameterDirection.Input;

            param[1] = new SqlParameter();
            param[1].ParameterName = "@Profession";
            param[1].Value = Profession;
            param[1].Direction = ParameterDirection.Input;

            param[2] = new SqlParameter();
            param[2].ParameterName = "@Review";
            param[2].Value = Review;
            param[2].Direction = ParameterDirection.Input;

            param[3] = new SqlParameter();
            param[3].ParameterName = "@Client_Photo";
            param[3].Value = ClientPhoto;
            param[3].Direction = ParameterDirection.Input;

            param[4] = new SqlParameter();
            param[4].ParameterName = "@Rating";
            param[4].Value = Rating;
            param[4].Direction = ParameterDirection.Input;

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_InsertCustomerReview", param);
            return dt;
        }

        public DataTable UpdateCustomerReview(int Id,string Name, string Profession, string Review, string ClientPhoto, string Rating)
        {
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter();
            param[0].ParameterName = "@Customer_Review_Id";
            param[0].Value = Id;
            param[0].Direction = ParameterDirection.Input;

            param[1] = new SqlParameter();
            param[1].ParameterName = "@Client_Name";
            param[1].Value = Name;
            param[1].Direction = ParameterDirection.Input;
            
            param[2] = new SqlParameter();
            param[2].ParameterName = "@Profession";
            param[2].Value = Profession;
            param[2].Direction = ParameterDirection.Input;

            param[3] = new SqlParameter();
            param[3].ParameterName = "@Review";
            param[3].Value = Review;
            param[3].Direction = ParameterDirection.Input;

            param[4] = new SqlParameter();
            param[4].ParameterName = "@Client_Photo";
            param[4].Value = ClientPhoto;
            param[4].Direction = ParameterDirection.Input;

            param[5] = new SqlParameter();
            param[5].ParameterName = "@Rating";
            param[5].Value = Rating;
            param[5].Direction = ParameterDirection.Input;

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_UpdateCustomerReview", param);
            return dt;
        }

        public DataTable DeleteCustomerReviewById(int Id)
        {
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter();
            param[0].ParameterName = "@Customer_Review_Id";
            param[0].Value = Id;
            param[0].Direction = ParameterDirection.Input;

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_DeleteCustReview", param);
            return dt;
        }


        public DataTable GetCustomerReviewPage(int pageNo, int pageSize)
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

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetCustomerReviewPagination", param);
            return dt;
        }

        public DataTable GetCustomerReviewCount()
        {
            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetCustomerReviewCount");
            return dt;
        }
    }
}
