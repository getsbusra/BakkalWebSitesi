using BakkalWebSiteVt2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BakkalWebSiteVt2.DataBase_Dal
{
    public class CategoryDal
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BakkalDb"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;


        public List<Category> GetCategories()
        {
            cmd = new SqlCommand("Category_List", con);
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Category> list = new List<Category>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Category
                {
                    kategori_id = Convert.ToInt32(dr["kategori_id"]),
                    k_adi = dr["k_adi"].ToString()
                });
                
            }
            return list;
        }
        public bool InsertCategory(Category category)
        {
            try
            {
                cmd = new SqlCommand("Category_Add", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@k_adi", category.k_adi);                

                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        public bool UpdateCategory(Category category)
        {
            try
            {
                cmd = new SqlCommand("Category_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("kategori_id", category.kategori_id);
                cmd.Parameters.AddWithValue("@k_adi", category.k_adi);
                
                con.Open();
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        public int DeleteUser(int id)
        {
            try
            {
                cmd = new SqlCommand("Category_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@kategori_id", id);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }


        }

    }
}