using DataAccessLayer.DataObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RestrictionDataAccess
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Portfolio"].ConnectionString;
        ErrorDataAccess errorDA = new ErrorDataAccess();

        // VIEW ALL RESTRICTIONS IN DATABASE
        public List<RestrictionDAO> viewRestrictions()
        {
            List<RestrictionDAO> restrictionList = new List<RestrictionDAO>();

            try
            {
                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_ViewRestrictions", _connection))
                    {
                        // specify what type of command to use
                        _command.CommandType = CommandType.StoredProcedure;
                        // this is where the connection is opened
                        _connection.Open();
                        // this is where all commands will be executed
                        _command.ExecuteNonQuery();

                        // get the data from the database that is stored in the reader
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            if (_reader.HasRows)
                            {
                                while (_reader.Read())
                                {
                                    // create object to hold info from database
                                    RestrictionDAO restriction = new RestrictionDAO();
                                    restriction.restrictionID = (int)_reader["restrictionID"];
                                    restriction.restrictionName = (string)_reader["restrictionName"];
                                    restriction.restrictionAge = (int)_reader["restrictionAge"];
                                    // add to list that will be returned
                                    restrictionList.Add(restriction);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                // use error data access to log error to the database
                errorDA.addError(exception);
            }

            return restrictionList;
        }
    }
}
