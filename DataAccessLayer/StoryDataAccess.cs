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

        public bool addStory(StoryDAO story)
        {
            bool success = false;

            byte[] storyFile;

            try
            {
                // create the story's file
                story.storyFileName = story.storyTitle.Replace(" ", "_") + ".txt";
                File.CreateText("C:\\Temp\\PFolder\\PortfolioFS\\Files\\" + story.storyFileName);

                // create connection to run sql commands made in c#
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    // create command to take in the sql code
                    using (SqlCommand _command = _connection.CreateCommand())
                    {
                        // create command to convert file into type that can be passed to filestream column in story table
                        _command.CommandText = "SELECT * FROM OPENROWSET(BULK C:\\Temp\\PFolder\\PortfolioFS\\Files\\" +
                            story.storyFileName + ", SINGLE_BLOB) AS File)";
                        _command.CommandType = CommandType.Text;

                        // open connection
                        _command.Connection = _connection;
                        _connection.Open();

                        // create reader to get the conversion result
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            storyFile = (byte[])_reader["File"];
                        }
                    }
                }

                    // create connection to database using connection string variable
                    using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_AddStory", _connection))
                    {
                        // specify what type of command to use
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@storyFile", storyFile);
                        _command.Parameters.AddWithValue("@storyRestriction", story.storyRestriction);
                        _command.Parameters.AddWithValue("@storyUserID", story.storyUserID);
                        _command.Parameters.AddWithValue("@storyGenreID", story.storyGenreID);
                        _command.Parameters.AddWithValue("@storyTitle", story.storyTitle);
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
                // create error data access object
                ErrorDAO error = new ErrorDAO();
                error.errorDate = DateTime.Now;
                error.errorType = exception.Message;

                // use error data access to log error to the database
                errorDA.addError(error);
            }

            return success;
        }
    }
}
