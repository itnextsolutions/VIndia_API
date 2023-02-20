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
    public class BlogDAL
    {
        DataTable dt = new DataTable();
        SqlHelper objsqlHelper = new SqlHelper();
        List<SqlParameter> SqlParameters = new List<SqlParameter>();

        public DataTable GetBlog()
        {
            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetBlog");
            return dt;
        }

        public DataTable GetAllBlog()
        {
            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetAllBlog");
            return dt;
        }
        public DataTable GetBlogById(int Blog_Id)
        {
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter();
            param[0].ParameterName = "@Blog_Id";
            param[0].Value = Blog_Id;
            param[0].Direction = ParameterDirection.Input;

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetBlogById", param);
            return dt;
        }


        public DataTable InsertBlog(string Title, string Content, string Topic, string Image)
        {
            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter();
            param[0].ParameterName = "@Blog_Title";
            param[0].Value = Title;
            param[0].Direction = ParameterDirection.Input;

            param[1] = new SqlParameter();
            param[1].ParameterName = "@Blog_Topic";
            param[1].Value = Content;
            param[1].Direction = ParameterDirection.Input;

            param[2] = new SqlParameter();
            param[2].ParameterName = "@Blog_Content";
            param[2].Value = Topic;
            param[2].Direction = ParameterDirection.Input;

            param[3] = new SqlParameter();
            param[3].ParameterName = "@Image_Name";
            param[3].Value = Image;
            param[3].Direction = ParameterDirection.Input;


            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_InsertBlog", param);
            return dt;
        }


        public DataTable UpdateBlog(int id, string Title, string Topic, string Content, string Image)
        {
            SqlParameter[] param = new SqlParameter[5];


            param[0] = new SqlParameter();
            param[0].ParameterName = "@Blog_Id";
            param[0].Value = id;
            param[0].Direction = ParameterDirection.Input;

            param[1] = new SqlParameter();
            param[1].ParameterName = "@Blog_Title";
            param[1].Value = Title;
            param[1].Direction = ParameterDirection.Input;

            param[2] = new SqlParameter();
            param[2].ParameterName = "@Blog_Topic";
            param[2].Value = Topic;
            param[2].Direction = ParameterDirection.Input;

            param[3] = new SqlParameter();
            param[3].ParameterName = "@Blog_Content";
            param[3].Value = Content;
            param[3].Direction = ParameterDirection.Input;

            param[4] = new SqlParameter();
            param[4].ParameterName = "@Image_Name";
            param[4].Value = Image;
            param[4].Direction = ParameterDirection.Input;


            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_UpdateBlog", param);
            return dt;
        }
        public DataTable DeleteBlog(int Id)
        {
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter();
            param[0].ParameterName = "@Blog_Id";
            param[0].Value = Id;
            param[0].Direction = ParameterDirection.Input;

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_DeleteBlog", param);
            return dt;
        }

        public DataTable GetAllBlogPagination(int pageNo, int pageSize)
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

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetAllBlogPagination", param);
            return dt;
        }

        public DataTable GetAllBlogCount()
        {
            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetAllBlogCount");
            return dt;
        }
    }
}
