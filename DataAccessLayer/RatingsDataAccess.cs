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
    public class RatingsDataAccess
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Portfolio"].ConnectionString;
        ErrorDataAccess errorDA = new ErrorDataAccess();

        // ADD RATING
        public bool addRatings(RatingsDAO ratings)
        {
            bool success = false;

            try
            {
                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_AddRatings", _connection))
                    {
                        // specify what type of command to use
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@ratingsValue", ratings.ratingsValue);
                        _command.Parameters.AddWithValue("@ratingsStoryID", ratings.ratingsStoryID);
                        _command.Parameters.AddWithValue("@ratingsUserID", ratings.ratingsUserID);
                        // this is where the connection is opened
                        _connection.Open();
                        // this is where all commands will be executed
                        _command.ExecuteNonQuery();

                        // it all worked
                        success = true;
                    }
                }
            }
            catch (Exception exception)
            {
                // use error data access to log error to the database
                errorDA.addError(exception);
            }

            return success;
        }

        // DELETE RATING
        public bool deleteRatings(int ratingsID)
        {
            bool success = false;

            try
            {
                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_DeleteRatings", _connection))
                    {
                        // specify what type of command to use
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@ratingsID", ratingsID);
                        // this is where the connection is opened
                        _connection.Open();
                        // this is where all commands will be executed
                        _command.ExecuteNonQuery();

                        // it all worked
                        success = true;
                    }
                }
            }
            catch (Exception exception)
            {
                // use error data access to log error to the database
                errorDA.addError(exception);
            }

            return success;
        }

        // VIEW ALL RATINGS IN DATABASE
        public List<RatingsDAO> viewRatings()
        {
            List<RatingsDAO> ratingsList = new List<RatingsDAO>();

            try
            {
                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_ViewRatings", _connection))
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
                                    RatingsDAO ratings = new RatingsDAO();
                                    ratings.ratingsID = (int)_reader["ratingsID"];
                                    ratings.ratingsValue = (int)_reader["ratingsValue"];
                                    ratings.ratingsStoryID = (int)_reader["ratingsStoryID"];
                                    ratings.ratingsUserID = (int)_reader["ratingsUserID"];
                                    // add to list that will be returned
                                    ratingsList.Add(ratings);
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

            return ratingsList;
        }
    }
}