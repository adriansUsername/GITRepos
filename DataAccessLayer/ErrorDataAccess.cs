using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Utility;
using System.Data.SqlClient;
using System.Data;
using DataAccessLayer.DataObjects;

namespace DataAccessLayer
{
    public class ErrorDataAccess
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Portfolio"].ConnectionString;

        // LOG ERROR TO DATABASE
        public bool addError(ErrorDAO error)
        {
            bool success = false;

            try
            {
                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_AddError", _connection))
                    {
                        // specify what type of command to use
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@errorDate", error.errorDate);
                        _command.Parameters.AddWithValue("@errorTrace", error.errorTrace);
                        _command.Parameters.AddWithValue("@errorMessage", error.errorMessage);
                        _command.Parameters.AddWithValue("@errorSite", error.errorSite);
                        // this is where the connection is opened
                        _connection.Open();
                        // this is where all commands will be executed
                        _command.ExecuteNonQuery();

                        // it all worked
                        success = true;
                    }
                }
            }
            catch (Exception errorOfError)
            {
                // if error logging throws an error then log THAT error
                Logger.writeError(errorOfError);
            }

            return success;
        }

        // OVERLOAD addError WITH EXCEPTION
        public bool addError(Exception exception)
        {
            ErrorDAO error = new ErrorDAO();
            error.errorDate = DateTime.Now;
            error.errorMessage = exception.Message;
            error.errorTrace = exception.StackTrace;
            error.errorSite = exception.TargetSite.ToString();

            return addError(error);
        }
    }
}
