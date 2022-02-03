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
    public class MarkaDal
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BakkalDb"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;


        public List<Marka> GetMarka()
        {
            cmd = new SqlCommand("Brand_List", con);
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Marka> list = new List<Marka>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Marka
                {
                    marka_id = Convert.ToInt32(dr["marka_id"]),
                    m_adi = dr["m_adi"].ToString()
                });

            }
            return list;
        }
        public bool InsertMarka(Marka marka)
        {
            try
            {
                cmd = new SqlCommand("Brand_Add", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@m_adi", marka.m_adi);

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


        public bool UpdateMarka(Marka marka)
        {
            try
            {
                cmd = new SqlCommand("MarkaUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@marka_id", marka.marka_id);
                cmd.Parameters.AddWithValue("@m_adi", marka.m_adi);

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


        public int DeleteMarka(int id)
        {
            try
            {
                cmd = new SqlCommand("Marka_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@marka_id", id);
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