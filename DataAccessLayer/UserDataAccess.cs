﻿using DataAccessLayer.DataObjects;
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
    public class UserDataAccess
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Portfolio"].ConnectionString;
        ErrorDataAccess errorDA = new ErrorDataAccess();

        // ADD USER TO DATABASE
        public bool addUser(UserDAO user)
        {
            bool success = false;

            try
            {
                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_AddAUser", _connection))
                    {
                        // specify what type of command to use
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@userName", user.userName);
                        _command.Parameters.AddWithValue("@userPassword", user.userPassword);
                        _command.Parameters.AddWithValue("@userFirstName", user.userFirstName);
                        _command.Parameters.AddWithValue("@userLastName", user.userLastName);
                        _command.Parameters.AddWithValue("@userCity", user.userCity);
                        _command.Parameters.AddWithValue("@userState", user.userState);
                        _command.Parameters.AddWithValue("@userCountry", user.userCountry);
                        _command.Parameters.AddWithValue("@userBDay", user.userBDay);
                        _command.Parameters.AddWithValue("@userDescription", user.userDescription);
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

        // DELETE USER FROM DATABASE
        public bool deleteUser(int userID)
        {
            bool success = false;

            try
            {
                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_DeleteUser", _connection))
                    {
                        // specify what type of command to use
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@userID", userID);
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

        // UPDATE USER IN DATABASE
        public bool updateUser(UserDAO user)
        {
            bool success = false;

            try
            {
                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_UpdateUser", _connection))
                    {
                        // specify what type of command to use
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@userName", user.userName);
                        _command.Parameters.AddWithValue("@userPassword", user.userPassword);
                        _command.Parameters.AddWithValue("@userFirstName", user.userFirstName);
                        _command.Parameters.AddWithValue("@userLastName", user.userLastName);
                        _command.Parameters.AddWithValue("@userCity", user.userCity);
                        _command.Parameters.AddWithValue("@userState", user.userState);
                        _command.Parameters.AddWithValue("@userCountry", user.userCountry);
                        _command.Parameters.AddWithValue("@userRoleID", user.userRoleID);
                        _command.Parameters.AddWithValue("@userID", user.userID);
                        _command.Parameters.AddWithValue("@userEdited", user.userEdited);
                        _command.Parameters.AddWithValue("@userBDay", user.userBDay);
                        _command.Parameters.AddWithValue("@userDescription", user.userDescription);
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

        // VIEW USER IN DATABASE
        public UserDAO viewOneUser(int userID)
        {
            UserDAO user = new UserDAO();

            try
            {
                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_ViewOneUser", _connection))
                    {
                        // specify what type of command to use
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@userID", userID);
                        // this is where the connection is opened
                        _connection.Open();
                        // this is where all commands will be executed
                        _command.ExecuteNonQuery();

                        // get the data from the database that is stored in the reader
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            _reader.Read();
                            // create object to hold info from database
                            user.userID = userID;
                            user.userName = (string)_reader["userName"];
                            user.userPassword = (string)_reader["userPassword"];
                            user.userFirstName = (string)_reader["userFirstName"];
                            user.userLastName = (string)_reader["userLastName"];
                            user.userCity = (string)_reader["userCity"];
                            user.userState = (string)_reader["userState"];
                            user.userCountry = (string)_reader["userCountry"];
                            user.userRoleID = _reader.GetInt32(_reader.GetOrdinal("userRoleID"));
                            user.userEdited = _reader.GetInt32(_reader.GetOrdinal("userEdited"));
                            user.userBDay = (DateTime)_reader["userBDay"];
                            user.userDescription = (string)_reader["userDescription"];
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                // use error data access to log error to the database
                errorDA.addError(exception);
            }

            return user;
        }

        // VIEW ALL USERS IN DATABASE
        public List<UserDAO> viewUsers()
        {
            List<UserDAO> userList = new List<UserDAO>();

            try
            {
                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_ViewUsers", _connection))
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
                                    UserDAO user = new UserDAO();
                                    user.userID = _reader.GetInt32(_reader.GetOrdinal("userID"));
                                    user.userName = (string)_reader["userName"];
                                    user.userPassword = (string)_reader["userPassword"];
                                    user.userFirstName = (string)_reader["userFirstName"];
                                    user.userLastName = (string)_reader["userLastName"];
                                    user.userCity = (string)_reader["userCity"];
                                    user.userState = (string)_reader["userState"];
                                    user.userCountry = (string)_reader["userCountry"];
                                    user.userRoleID = _reader.GetInt32(_reader.GetOrdinal("userRoleID"));
                                    user.userEdited = _reader.GetInt32(_reader.GetOrdinal("userEdited"));
                                    user.userBDay = (DateTime)_reader["userBDay"];
                                    user.userDescription = (string)_reader["userDescription"];
                                    // add to list that will be returned
                                    userList.Add(user);
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

            return userList;
        }

        // LOGIN A USER
        public UserDAO login(string username, string userpassword)
        {
            UserDAO user = new UserDAO();

            try
            {
                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_Login", _connection))
                    {
                        // specify what type of command to use
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@userName", username);
                        _command.Parameters.AddWithValue("@userPassword", userpassword);
                        // this is where the connection is opened
                        _connection.Open();
                        // this is where all commands will be executed
                        _command.ExecuteNonQuery();

                        // this accesses all the data given by the stored procedure
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            _reader.Read();
                            // create object to hold info from database
                            user.userID = _reader.GetInt32(_reader.GetOrdinal("userID"));
                            user.userName = (string)_reader["userName"];
                            user.userPassword = (string)_reader["userPassword"];
                            user.userFirstName = (string)_reader["userFirstName"];
                            user.userLastName = (string)_reader["userLastName"];
                            user.userCity = (string)_reader["userCity"];
                            user.userState = (string)_reader["userState"];
                            user.userCountry = (string)_reader["userCountry"];
                            user.userRoleID = _reader.GetInt32(_reader.GetOrdinal("userRoleID"));
                            user.userEdited = _reader.GetInt32(_reader.GetOrdinal("userEdited"));
                            user.userBDay = (DateTime)_reader["userBDay"];
                            user.userDescription = (string)_reader["userDescription"];
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                // use error data access to log error to the database
                errorDA.addError(exception);
            }

            return user;
        }
    }
}
