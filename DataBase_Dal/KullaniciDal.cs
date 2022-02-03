
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
    public class KullaniciDal
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BakkalDb"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;
        public List<Kullanıcı> GetUsers()
        {
            cmd = new SqlCommand("Kullanıcı_Select", con);
            cmd.CommandType = CommandType.StoredProcedure;
            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);
            List<Kullanıcı> list = new List<Kullanıcı>();
            foreach(DataRow dr in dt.Rows)
            {
                list.Add(new Kullanıcı
                {
                    kullanici_id = Convert.ToInt32(dr["kullanici_id"]),
                    k_kullaniciadi = dr["k_kullaniciadi"].ToString(),
                    k_parola = dr["k_parola"].ToString(),
                    k_adi = dr["k_adi"].ToString(),
                    k_soyadi = dr["k_soyadi"].ToString(),
                    k_eposta = dr["k_eposta"].ToString(),
                    k_telefon = dr["k_telefon"].ToString(),
                    k_durum = Convert.ToBoolean(dr["k_durum"]),
                    rol_id = Convert.ToInt32(dr["rol_id"])
                });
            }
            return list;
        }

        public bool InsertUser(Kullanıcı kullanıcı)
        {
            try
            {
                cmd = new SqlCommand("Kullanıcı_Ekle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@k_kullaniciadi", kullanıcı.k_kullaniciadi);
                cmd.Parameters.AddWithValue("@k_parola", kullanıcı.k_parola);
                cmd.Parameters.AddWithValue("@k_adi", kullanıcı.k_adi);
                cmd.Parameters.AddWithValue("@k_soyadi", kullanıcı.k_soyadi);
                cmd.Parameters.AddWithValue("@k_eposta", kullanıcı.k_eposta);
                cmd.Parameters.AddWithValue("@k_telefon", kullanıcı.k_telefon);
                cmd.Parameters.AddWithValue("@k_durum", kullanıcı.k_durum);
                cmd.Parameters.AddWithValue("@rol_id", kullanıcı.rol_id);

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

        
        public bool UpdateUser(Kullanıcı kullanıcı)
        {
            try
            {
                cmd = new SqlCommand("Kullanıcı_Guncelle", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@k_kullaniciadi", kullanıcı.k_kullaniciadi);
                cmd.Parameters.AddWithValue("@k_parola", kullanıcı.k_parola);
                cmd.Parameters.AddWithValue("@k_adi", kullanıcı.k_adi);
                cmd.Parameters.AddWithValue("@k_soyadi", kullanıcı.k_soyadi);
                cmd.Parameters.AddWithValue("@k_eposta", kullanıcı.k_eposta);
                cmd.Parameters.AddWithValue("@k_telefon", kullanıcı.k_telefon);
                cmd.Parameters.AddWithValue("@k_durum", kullanıcı.k_durum);
                cmd.Parameters.AddWithValue("@rol_id", kullanıcı.rol_id);
                cmd.Parameters.AddWithValue("@kullanici_id", kullanıcı.kullanici_id);
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
                cmd = new SqlCommand("Kullanıcı_Sil", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@kullanici_id", id);
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