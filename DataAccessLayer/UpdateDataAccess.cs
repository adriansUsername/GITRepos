using DataAccessLayer.DataObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UpdateDataAccess
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Portfolio"].ConnectionString;
        ErrorDataAccess errorDA = new ErrorDataAccess();

        // ADD AN UPDATE
        public bool addAnUpdate(UpdateDAO update)
        {
            bool success = false;

            try
            {
                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_AddAnUpdate", _connection))
                    {
                        // specify what type of command to use
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@updateDate", update.updateDate);
                        _command.Parameters.AddWithValue("@updateStoryID", update.updateStoryID);
                        _command.Parameters.AddWithValue("@updateText", update.updateText);
                        _command.Parameters.AddWithValue("@updateUserID", update.updateUserID);
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

        // UPDATE AN UPDATE
        public bool updateAnUpdate(UpdateDAO update)
        {
            bool success = false;

            try
            {
                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_UpdateAnUpdate", _connection))
                    {
                        // specify what type of command to use
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@updateID", update.updateID);
                        _command.Parameters.AddWithValue("@updateDate", update.updateDate);
                        _command.Parameters.AddWithValue("@updateStoryID", update.updateStoryID);
                        _command.Parameters.AddWithValue("@updateText", update.updateText);
                        _command.Parameters.AddWithValue("@updateUserID", update.updateUserID);
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

        // DELETE AN UPDATE
        public bool deleteAnUpdate(int updateID)
        {
            bool success = false;

            try
            {
                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_DeleteAnUpdate", _connection))
                    {
                        // specify what type of command to use
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@updateID", updateID);
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

        // VIEW AN UPDATE IN DATABASE
        public UpdateDAO viewOneUpdate(int updateID)
        {
            UpdateDAO update = new UpdateDAO();

            try
            {
                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_ViewOneUpdate", _connection))
                    {
                        // specify what type of command to use
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@updateID", updateID);
                        // this is where the connection is opened
                        _connection.Open();
                        // this is where all commands will be executed
                        _command.ExecuteNonQuery();

                        // get the data from the database that is stored in the reader
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            _reader.Read();
                            // create object to hold info from database
                            update.updateID = updateID;
                            update.updateDate = (DateTime)_reader["updateDate"];
                            update.updateStoryID = (int)_reader["updateStoryID"];
                            update.updateText = (string)_reader["updateText"];
                            update.updateUserID = (int)_reader["updateUserID"];
                            update.updateApproved = (bool)_reader["updateApproved"];
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                // use error data access to log error to the database
                errorDA.addError(exception);
            }

            return update;
        }

        // VIEW ALL UPDATES IN DATABASE
        public List<UpdateDAO> viewUpdates()
        {
            List<UpdateDAO> updateList = new List<UpdateDAO>();

            try
            {
                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_ViewUpdates", _connection))
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
                            if(_reader.HasRows)
                            {
                                while(_reader.Read())
                                {
                                    // get data from reader
                                    UpdateDAO update = new UpdateDAO();
                                    update.updateID = (int)_reader["updateID"];
                                    update.updateDate = (DateTime)_reader["updateDate"];
                                    update.updateStoryID = (int)_reader["updateStoryID"];
                                    update.updateText = (string)_reader["updateText"];
                                    update.updateUserID = (int)_reader["updateUserID"];
                                    update.updateApproved = (bool)_reader["updateApproved"];
                                    // add to list to return
                                    updateList.Add(update);
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

            return updateList;
        }
    }
}
