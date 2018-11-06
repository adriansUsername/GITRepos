﻿using DataAccessLayer.DataObjects;
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

        // ADD UPDATE
        public bool addUpdate(UpdateDAO update)
        {
            bool success = false;

            byte[] updateFile;

            try
            {
                // create the update's file
                update.updateFileName = "update_" + Convert.ToString(update.updateID) + ".txt";
                File.CreateText("C:\\Temp\\PFolder\\PortfolioFS\\Files\\" + update.updateFileName);

                // create connection to run sql commands made in c#
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    // create command to take in the sql code
                    using (SqlCommand _command = _connection.CreateCommand())
                    {
                        // create command to convert file into type that can be passed to filestream column in update table
                        _command.CommandText = "SELECT * FROM OPENROWSET(BULK C:\\Temp\\PFolder\\PortfolioFS\\Files\\" +
                            update.updateFileName + ", SINGLE_BLOB) AS File)";
                        _command.CommandType = CommandType.Text;

                        // open connection
                        _command.Connection = _connection;
                        _connection.Open();

                        // create reader to get the conversion result
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            updateFile = (byte[])_reader["File"];
                        }
                    }
                }

                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_AddAnUpdate", _connection))
                    {
                        // specify what type of command to use
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@updateDate", update.updateDate);
                        _command.Parameters.AddWithValue("@updateContent", updateFile);
                        _command.Parameters.AddWithValue("@updateStoryID", update.updateStoryID);
                        _command.Parameters.AddWithValue("@updateFileName", update.updateFileName);
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

        // DELETE UPDATE
        public bool deleteUpdate(int updateID)
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

        // VIEW UPDATE IN DATABASE
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
                            update.updateFileName = (string)_reader["updateFileName"];
                            update.updateUserID = (int)_reader["updateUserID"];
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
                                    update.updateFileName = (string)_reader["updateFileName"];
                                    update.updateUserID = (int)_reader["updateUserID"];
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
