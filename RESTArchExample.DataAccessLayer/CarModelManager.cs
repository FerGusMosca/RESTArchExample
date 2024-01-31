using Microsoft.AspNetCore.Mvc.ModelBinding;
using RESTArchExample.BusinessEntities;
using RESTArchExample.Common.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RESTArchExample.DataAccessLayer
{
    public class CarModelManager:BaseManager
    {
        #region Constructors

        public CarModelManager(string pConnectionString)
        {
            ConnectionString = pConnectionString;
        }

        #endregion

        #region Private Static Querys

        private static string _SP_PERSIST_CAR_MODEL = "PersistCarModel";

        private static string _SP_GET_CAR_MODEL = "GetCarModels";



        #endregion

        #region Public Methods

        public List<CarModel> GetCarModels(GetCarModelReqDTO dto)
        {
            SqlCommand cmd = new SqlCommand(_SP_GET_CAR_MODEL, new SqlConnection(ConnectionString));
            cmd.CommandTimeout = 60;

            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.Add("@Company", SqlDbType.VarChar, 50).Value = (object)dto.company ?? DBNull.Value;
            cmd.Parameters.Add("@ModelName", SqlDbType.VarChar, 100).Value = (object)dto.modelName ?? DBNull.Value;
            cmd.Parameters.Add("@SpecialEdition", SqlDbType.VarChar, 100).Value = (object)dto.specialEdition?? DBNull.Value;
            cmd.Parameters.Add("@IssueYear", SqlDbType.Int).Value = (object)dto.issueYear ?? DBNull.Value;



            cmd.Connection.Open();

            // Open DB
            SqlDataReader reader;
            List<CarModel> carModelList = new List<CarModel>();

            try
            {
                // Run Query
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        CarModel carModel = new CarModel()
                        {

                            Company = GetSafeString(reader, "company"),
                            ModelName = GetSafeString(reader, "model_name"),
                            SpecialEdition = GetSafeString(reader, "special_edition"),
                            IssueYear = GetNotNullSafeInt(reader, "issue_year"),
                            BookPrice = GetSafeDouble(reader, "book_price")

                        };
                        carModelList.Add(carModel);
                    }
                }
            }
            finally
            {
                cmd.Connection.Close();
            }

            return carModelList;
        }



        public void PersistCarModel(CarModel carModel)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = _SP_PERSIST_CAR_MODEL;
                    cmd.Parameters.Add(new SqlParameter("@Company", carModel.Company));
                    cmd.Parameters.Add(new SqlParameter("@ModelName", carModel.ModelName));
                    cmd.Parameters.Add(new SqlParameter("@SpecialEdition", carModel.SpecialEdition));
                    cmd.Parameters.Add(new SqlParameter("@IssueYear", carModel.IssueYear));
                    cmd.Parameters.Add(new SqlParameter("@BookPrice", carModel.BookPrice));

                    cmd.ExecuteNonQuery();
                }
                connection.Dispose();


            }
        }


        #endregion
    }
}
