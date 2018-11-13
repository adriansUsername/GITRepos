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
    public class StoryDataAccess
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Portfolio"].ConnectionString;
        ErrorDataAccess errorDA = new ErrorDataAccess();

        // ADD STORY
        public bool addStory(StoryDAO story)
        {
            bool success = false;

            try
            {
                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_AddStory", _connection))
                    {
                        // specify what type of command to use
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@storyRestrictionID", story.storyRestrictionID);
                        _command.Parameters.AddWithValue("@storyUserID", story.storyUserID);
                        _command.Parameters.AddWithValue("@storyGenreID", story.storyGenreID);
                        _command.Parameters.AddWithValue("@storyTitle", story.storyTitle);
                        _command.Parameters.AddWithValue("@storyURL", story.storyURL);
                        _command.Parameters.AddWithValue("@storyPublic", story.storyPublic);
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

        // DELETE STORY
        public bool deleteStory(int storyID)
        {
            bool success = false;

            try
            {
                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_DeleteStory", _connection))
                    {
                        // specify what type of command to use
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@storyID", storyID);
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

        // UPDATE STORY
        public bool updateStory(StoryDAO story)
        {
            bool success = false;
            //TODO : ADD FILE

            try
            {
                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_UpdateStory", _connection))
                    {
                        // specify what type of command to use
                        _command.CommandType = CommandType.StoredProcedure;
                        //_command.Parameters.AddWithValue("@storyFile", storyFile);
                        _command.Parameters.AddWithValue("@storyRating", story.storyRating);
                        _command.Parameters.AddWithValue("@storyRestrictionID", story.storyRestrictionID);
                        _command.Parameters.AddWithValue("@storyID", story.storyID);
                        _command.Parameters.AddWithValue("@storyGenreID", story.storyGenreID);
                        _command.Parameters.AddWithValue("@storyEditorID", story.storyEditorID);
                        _command.Parameters.AddWithValue("@storyTitle", story.storyTitle);
                        _command.Parameters.AddWithValue("@storyPublic", story.storyPublic);
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

        // VIEW ONE STORY
        public StoryDAO viewOneStory(int storyID)
        {
            StoryDAO story = new StoryDAO();

            try
            {
                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_ViewOneStory", _connection))
                    {
                        // specify what type of command to use
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@storyID", storyID);
                        // this is where the connection is opened
                        _connection.Open();
                        // this is where all commands will be executed
                        _command.ExecuteNonQuery();

                        // get the data from the database that is stored in the reader
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            _reader.Read();
                            // create object to hold info from database
                            story.storyID = storyID;
                            story.storyRating = (int)_reader["storyRating"];
                            story.storyRestrictionID = (int)_reader["storyRestrictionID"];
                            story.storyUserID = (int)_reader["storyUserID"];
                            story.storyGenreID = (int)_reader["storyGenreID"];
                            story.storyTitle = (string)_reader["storyTitle"];
                            story.storyURL = (string)_reader["storyURL"];
                            story.storyEditorID = (int)_reader["storyEditorID"];
                            story.storyPublic = (bool)_reader["storyPublic"];
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                // use error data access to log error to the database
                errorDA.addError(exception);
            }

            return story;
        }

        // VIEW ALL STORIES
        public List<StoryDAO> viewStories()
        {
            List<StoryDAO> storyList = new List<StoryDAO>();

            try
            {
                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_ViewStories", _connection))
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
                                    StoryDAO story = new StoryDAO();
                                    story.storyID = (int)_reader["storyID"];
                                    story.storyRating = (double)_reader["storyRating"];
                                    story.storyRestrictionID = (int)_reader["storyRestrictionID"];
                                    story.storyUserID = (int)_reader["storyUserID"];
                                    story.storyGenreID = (int)_reader["storyGenreID"];
                                    story.storyTitle = (string)_reader["storyTitle"];
                                    story.storyURL = (string)_reader["storyURL"];
                                    story.storyEditorID = (int)_reader["storyEditorID"];
                                    story.storyPublic = _reader.GetBoolean(_reader.GetOrdinal("storyPublic"));
                                    // add to list to be returned
                                    storyList.Add(story);
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

            return storyList;
        }
    }
}
