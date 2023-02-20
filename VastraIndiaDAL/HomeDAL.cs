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
    public class HomeDAL
    {
        DataTable dt = new DataTable();
        SqlHelper objsqlHelper = new SqlHelper();
        List<SqlParameter> SqlParameters = new List<SqlParameter>();

        /* FAQ */
        public DataTable GetFaq()
        {
            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetFaq");
            return dt;
        }

        /* Menu Bind */
        public DataTable GetMenuList()
        {
            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetMenuBind");
            return dt;
        }

        public DataTable GeNotification()
        {
            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GeNotification");
            return dt;
        }

        public DataTable GetCustomerReview()
        {
            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetCustomerReview");
            return dt;
        }

        public DataTable GetSearchProduct(string search)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter();
            param[0].ParameterName = "@search";
            param[0].Value = search;
            param[0].Direction = ParameterDirection.Input;


            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetSearchResult", param);
            return dt;
        }

        // Category Start
        public DataTable GetProductCategory()
        {
            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.Text, "SP_GetProductCategory");
            return dt;
        }

        public DataTable GetAllProductCategory()
        {
            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.Text, "SP_GetAllProductCategory");
            return dt;
        }
        // Category End

        //Header start
        public DataTable GetProductMenu()
        {
            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.Text, "SP_GetAllCategorySubCategory");
            return dt;
        }
        //Header End


        //ajit
        public DataTable GetProductBySubCategory(int catId, int subCategoryId)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter();
            param[0].ParameterName = "@Category_Id";
            param[0].Value = catId;
            param[0].Direction = ParameterDirection.Input;



            param[1] = new SqlParameter();
            param[1].ParameterName = "@SubCategory_Id";
            param[1].Value = subCategoryId;
            param[1].Direction = ParameterDirection.Input;

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetProductBySubCategory_Id", param);
            return dt;
        }


        //ajit
        public DataTable GetProductByCategory(int categoryId)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter();
            param[0].ParameterName = "@Category_Id";
            param[0].Value = categoryId;
            param[0].Direction = ParameterDirection.Input;


            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetProductByCategory_Id", param);
            return dt;
        }

        public DataTable GetSimillarProducts(int id)
        {
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter();
            param[0].ParameterName = "@Product_Id";
            param[0].Value = id;
            param[0].Direction = ParameterDirection.Input;

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetSimillarProduct", param);
            return dt;
        }

        public DataTable GetSizeListByProductId(int id)
        {

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter();
            param[0].ParameterName = "@Product_Id";
            param[0].Value = id;
            param[0].Direction = ParameterDirection.Input;

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetSizeListByProductId", param);
            return dt;
        }

        public DataTable GetColorCodeListByProductId(int id)
        {
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter();
            param[0].ParameterName = "@Product_Id";
            param[0].Value = id;
            param[0].Direction = ParameterDirection.Input;

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetColorCodeListByProductId", param);
            return dt;
        }

        public DataTable GetProductSizeById(int id)
        {
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter();
            param[0].ParameterName = "@Product_Size_Id";
            param[0].Value = id;
            param[0].Direction = ParameterDirection.Input;

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetProductSizeById", param);
            return dt;
        }

        public DataTable GetSubCategoryByCategoryId(int id)
        {

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter();
            param[0].ParameterName = "@Category_Id";
            param[0].Value = id;
            param[0].Direction = ParameterDirection.Input;

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetSubCategoryByCategoryId", param);
            return dt;
        }

        public DataTable GetSubCategoryById(int id)
        {

            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter();
            param[0].ParameterName = "@Id";
            param[0].Value = id;
            param[0].Direction = ParameterDirection.Input;

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetSubCategoryById", param);
            return dt;
        }

        //Blog start
        public DataTable GetBlog(int number)
        {
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter();
            param[0].ParameterName = "@number";
            param[0].Value = number;
            param[0].Direction = ParameterDirection.Input;

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetBlog", param);
            return dt;
        }


        public DataTable GetAllBlogs(int Blog_Id)
        {
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter();
            param[0].ParameterName = "@Blog_Id";
            param[0].Value = Blog_Id;
            param[0].Direction = ParameterDirection.Input;

            dt = objsqlHelper.ExecuteDataTable(objsqlHelper.GetConnection(), CommandType.StoredProcedure, "SP_GetAllBlog", param);
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
        //Blog end
    }
}
