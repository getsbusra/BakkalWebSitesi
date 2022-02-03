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
    public class ÜrünDal
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BakkalDb"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;


        public List<Ürün> GetÜrün()
        {
            cmd = new SqlCommand("Ürün_List", con);
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Ürün> list = new List<Ürün>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new Ürün
                {
                    urun_id = Convert.ToInt32(dr["urun_id"]),
                    u_adi = dr["u_adi"].ToString(),
                    u_barkodu = dr["u_barkodu"].ToString(),
                    u_uretim_tarihi = Convert.ToDateTime(dr["u_uretim_tarihi"].ToString()),
                    u_tuketim_tarihi = Convert.ToDateTime(dr["u_tuketim_tarihi"].ToString()),
                    u_fiyat = Convert.ToUInt16(dr["u_fiyat"]),
                    u_agirlik = Convert.ToUInt16(dr["u_agirlik"]),
                    u_rengi = dr["u_rengi"].ToString()
                });

            }
            return list;
            
        }
    

        public bool InsertÜrün(Ürün ürün)
        {
            try
            {
                cmd = new SqlCommand("Ürün_Ekle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("u_adi", ürün.u_adi);
                cmd.Parameters.AddWithValue("u_barkodu", ürün.u_barkodu);
                cmd.Parameters.AddWithValue("u_uretim_tarihi", ürün.u_uretim_tarihi);
                cmd.Parameters.AddWithValue("u_tuketim_tarihi", ürün.u_tuketim_tarihi);
                cmd.Parameters.AddWithValue("u_fiyat", ürün.u_fiyat);
                cmd.Parameters.AddWithValue("u_agirlik", ürün.u_agirlik);
                cmd.Parameters.AddWithValue("u_rengi", ürün.u_rengi);
                

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

        public bool UpdateÜrün(Ürün ürün)
        {
            try
            {
                cmd = new SqlCommand("Ürün_Guncelle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("urun_id", ürün.urun_id);
                cmd.Parameters.AddWithValue("u_adi", ürün.u_adi);
                cmd.Parameters.AddWithValue("u_barkodu", ürün.u_barkodu);
                cmd.Parameters.AddWithValue("u_uretim_tarihi", ürün.u_uretim_tarihi);
                cmd.Parameters.AddWithValue("u_tuketim_tarihi", ürün.u_tuketim_tarihi);
                cmd.Parameters.AddWithValue("u_fiyat", ürün.u_fiyat);
                cmd.Parameters.AddWithValue("u_agirlik", ürün.u_agirlik);
                cmd.Parameters.AddWithValue("u_rengi", ürün.u_rengi);
                


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


        public int DeleteÜrün(int id)
        {
            try
            {
                cmd = new SqlCommand("Ürün_Sil", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("urun_id", id);
               
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