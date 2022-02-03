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
    public class SatisDal
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BakkalDb"].ConnectionString);
        SqlCommand sqlCommand;

        //Veri tabanında oluşturulmuş Procedure yapılarını kullanarak veri tabanı ekleme , silme , listeleme ve güncelleme işlemlerini gerçekleştirir.
        //İşlemin procedureler ile gerçekleşeceğini System.Data.CommandType.StoredProcedure ile belirtiriz
        //Procedure yapısı parametre istiyor ise fonksiyona gelen ilgili parametreler AddWithValue() kullanılarak procedure yapısına yollanır.
        //Komutlar ExecuteNonQuery ile çalıştırılır.

        public void Add(Satis satis)
        {
            sqlConnection.Open();
            sqlCommand = new SqlCommand("SatisEkle", sqlConnection);

            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("Satis_Tarihi", satis.Stais_Tarihi);
            sqlCommand.Parameters.AddWithValue("Durum", satis.Durum);
            sqlCommand.Parameters.AddWithValue("Kullanici_id", satis.Kullanici_id);

            sqlCommand.Parameters.AddWithValue("Miktar", satis.Miktar);
            sqlCommand.Parameters.AddWithValue("Fiyat", satis.Fiyat);
            sqlCommand.Parameters.AddWithValue("İskonto", satis.İskonto);
            sqlCommand.Parameters.AddWithValue("Urun_Id", satis.Urun_Id);

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }


        public void Delete(int id)
        {
            sqlConnection.Open();
            sqlCommand = new SqlCommand("Satis_Sil", sqlConnection);

            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("Satis_Id", id);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public DataSet List()
        {
            sqlConnection.Open();
            sqlCommand = new SqlCommand("Satis_List", sqlConnection);

            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            return dataSet;
        }

        public void Update(Marka marka)
        {
        }
    }
}