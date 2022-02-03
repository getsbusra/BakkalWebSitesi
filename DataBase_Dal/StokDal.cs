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
    public class StokDal
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BakkalDb"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;


        public List<Stok> GetStok()
        {
            cmd = new SqlCommand("Stok_List", con);
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Stok> list = new List<Stok>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Stok
                {
                    stok_id = Convert.ToInt32(dr["stok_id"]),
                    s_adedi = Convert.ToInt32(dr["s_adedi"]),
                    s_giris_tarihi = Convert.ToDateTime(dr["s_giris_tarihi"]),
                    s_bitis_tarihi = Convert.ToDateTime(dr["s_bitis_tarihi"])

                }); ;

            }
            return list;
        }
        public bool InsertStok(Stok stok)
        {
            try
            {
                cmd = new SqlCommand("Stok_Ekle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@stok_id", stok.stok_id);
                cmd.Parameters.AddWithValue("@s_adedi", stok.s_adedi);
                cmd.Parameters.AddWithValue("@s_giris_tarihi", stok.s_giris_tarihi);
                cmd.Parameters.AddWithValue("@s_bitis_tarihi", stok.s_bitis_tarihi);


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


        public bool UpdateStok(Stok stok)
        {
            try
            {
                cmd = new SqlCommand("Stok_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@stok_id", stok.stok_id);
                cmd.Parameters.AddWithValue("@s_adedi", stok.s_adedi);
                cmd.Parameters.AddWithValue("@s_giris_tarihi", stok.s_giris_tarihi);
                cmd.Parameters.AddWithValue("@s_bitis_tarihi", stok.s_bitis_tarihi);

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


        public int DeleteStok(int id)
        {
            try
            {
                cmd = new SqlCommand("Stok_Sil", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@stok_id", id);
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