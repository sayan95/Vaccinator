using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Vaccinator.Models;
using Vaccinator.Repository.Interfaces;

namespace Vaccinator.Repository.Classes
{
    public class EmpVaccinationDetailsRepository : IEmpVaccinationDetailsRepository 
    {
        private SqlConnection connection;
        public EmpVaccinationDetailsRepository()
        {
            string _connectionString = ConfigurationManager.ConnectionStrings["VaccinatorConnectionString"].ConnectionString;
            connection = new SqlConnection(_connectionString); 
        }

        /**
         *  adds new entry to the EmpVaccinationDetails table
         */
        public bool Add(EmpVaccinationDetails details)
        {
            int result;
            SqlCommand command = new SqlCommand("AddVaccineDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Name", details.Name);
            command.Parameters.AddWithValue("@Age", details.Age);
            command.Parameters.AddWithValue("@Gender", details.Gender);
            command.Parameters.AddWithValue("@VaccineManufacturer", details.VaccineMfg);
            command.Parameters.AddWithValue("@Description", details.VaccineDescription);
            command.Parameters.AddWithValue("@VaccineLocation", details.VaccineLocation);
            command.Parameters.AddWithValue("@CowinId", details.CowinId);
            command.Parameters.AddWithValue("@CreatedAt", DateTime.UtcNow);
            command.Parameters.AddWithValue("@UpdatedAt", DateTime.UtcNow);

            // execute DB insertion 
            connection.Open();
            result = command.ExecuteNonQuery();
            connection.Close();

            if (result >= 1)
                return true;
            else
                return false;
        }
    
        /**
         *  get all entries from vaccine details table
         */
        public IList<EmpVaccinationDetails> All()
        {
            IList<EmpVaccinationDetails> details = new List<EmpVaccinationDetails>();

            SqlCommand command = new SqlCommand("GetAllVaccinationDetails", connection);
            command.CommandType =CommandType.StoredProcedure;
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            connection.Open();
            dataAdapter.Fill(dataTable);
            connection.Close();

            foreach(DataRow dr in dataTable.Rows)
            {
                details.Add(new EmpVaccinationDetails
                {
                    Id =  Convert.ToInt64(dr["Id"]),
                    Name = Convert.ToString(dr["Name"]),
                    Age = Convert.ToInt32(dr["Age"]),
                    Gender = Convert.ToString(dr["Gender"]),
                    VaccineDescription = Convert.ToString(dr["Description"]),
                    VaccineMfg = Convert.ToString(dr["VaccineManufacturer"]),
                    VaccineLocation = Convert.ToString(dr["VaccineLocation"]),
                    CowinId = Convert.ToInt32(dr["CowinId"]),
                    CreatedAt = Convert.ToDateTime(dr["CreatedAt"]),
                    UpdatedAt =  Convert.ToDateTime(dr["UpdatedAt"])
                });
            }

            return details;
        }
    
        /**
         *  Find details by Id
         */ 
        public EmpVaccinationDetails FindById(long id)
        {
            EmpVaccinationDetails vaccineDetails;
            SqlCommand command = new SqlCommand("GetVaccineDetailsById", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            connection.Open();
            dataAdapter.Fill(dataTable);
            connection.Close();

            DataRow dr = dataTable.Rows[0];

            vaccineDetails = new EmpVaccinationDetails
            {
                Id = Convert.ToInt64(dr["Id"]),
                Name = Convert.ToString(dr["Name"]),
                Age = Convert.ToInt32(dr["Age"]),
                Gender = Convert.ToString(dr["Gender"]),
                VaccineDescription = Convert.ToString(dr["Description"]),
                VaccineMfg = Convert.ToString(dr["VaccineManufacturer"]),
                VaccineLocation = Convert.ToString(dr["VaccineLocation"]),
                CowinId = Convert.ToInt32(dr["CowinId"]),
                CreatedAt = Convert.ToDateTime(dr["CreatedAt"]),
                UpdatedAt = Convert.ToDateTime(dr["UpdatedAt"])
            };

            return vaccineDetails;
        }
    
        /**
         *  Update single vaccine details
         */
        public bool Update(EmpVaccinationDetails details)
        {
            int result;
            var existingDetails = FindById(details.Id.Value);

            SqlCommand command = new SqlCommand("UpdatevaccinationDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", details.Id.Value);
            command.Parameters.AddWithValue("@Name", details.Name);
            command.Parameters.AddWithValue("@Age", details.Age);
            command.Parameters.AddWithValue("@Gender", details.Gender);
            command.Parameters.AddWithValue("@VaccineManufacturer", details.VaccineMfg);
            command.Parameters.AddWithValue("@Description", details.VaccineDescription);
            command.Parameters.AddWithValue("@VaccineLocation", details.VaccineLocation);
            command.Parameters.AddWithValue("@CowinId", details.CowinId);
            command.Parameters.AddWithValue("@UpdatedAt", DateTime.UtcNow);

            // execute DB insertion 
            connection.Open();
            result = command.ExecuteNonQuery();
            connection.Close();

            if (result >= 1)
                return true;
            else
                return false;
        }
    
        /**
         *  Delete vaccine details
         */
        public bool Delete(long id)
        {
            int result;
            SqlCommand command = new SqlCommand("DeleteEmpVaccinationDetails", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", id);

            connection.Open();
            result = command.ExecuteNonQuery();
            connection.Close();

            if(result > 0)
                return true;
            return false;
        }
    }
}