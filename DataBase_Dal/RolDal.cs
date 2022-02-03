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
    public class RolDal
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["BakkalDb"].ConnectionString);
        SqlCommand sqlCommand;

        //Veri tabanında oluşturulmuş Procedure yapılarını kullanarak veri tabanı ekleme , silme , listeleme ve güncelleme işlemlerini gerçekleştirir.
        //İşlemin procedureler ile gerçekleşeceğini System.Data.CommandType.StoredProcedure ile belirtiriz
        //Procedure yapısı parametre istiyor ise fonksiyona gelen ilgili parametreler AddWithValue() kullanılarak procedure yapısına yollanır.
        //Komutlar ExecuteNonQuery ile çalıştırılır.
        public void Add(Rol rol)
        {
            sqlConnection.Open();
            sqlCommand = new SqlCommand("Rol_Ekle", sqlConnection);

            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("Rol_Adı", rol.r_adi);

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }


        public void Delete(int id)
        {
            sqlConnection.Open();
            sqlCommand = new SqlCommand("Rol_Sil", sqlConnection);

            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("Rol_Id", id);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public DataSet List()
        {
            sqlConnection.Open();
            sqlCommand = new SqlCommand("Rol_List", sqlConnection);

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