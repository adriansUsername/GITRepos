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
    public class GenreDataAccess
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["Portfolio"].ConnectionString;
        ErrorDataAccess errorDA = new ErrorDataAccess();

        // ADD GENRE TO DATABASE
        public bool addGenre(GenreDAO genre)
        {
            bool success = false;

            try
            {
                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_AddGenre", _connection))
                    {
                        // specify what type of command to use
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@genreName", genre.genreName);
                        _command.Parameters.AddWithValue("@genreDescription", genre.genreDescription);
                        _command.Parameters.AddWithValue("@genreIsFiction", genre.genreIsFiction);
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

        // DELETE GENRE FROM DATABASE
        public bool deleteGenre(int genreID)
        {
            bool success = false;

            try
            {
                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_DeleteGenre", _connection))
                    {
                        // specify what type of command to use
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@genreID", genreID);
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

        // UPDATE GENRE iN DATABASE
        public bool updateGenre(GenreDAO genre)
        {
            bool success = false;

            try
            {
                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_UpdateGenre", _connection))
                    {
                        // specify what type of command to use
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@genreName", genre.genreName);
                        _command.Parameters.AddWithValue("@genreDescription", genre.genreDescription);
                        _command.Parameters.AddWithValue("@genreIsFiction", genre.genreIsFiction);
                        _command.Parameters.AddWithValue("@genreID", genre.genreID);
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

        // VIEW GENRE IN DATABASE
        public GenreDAO viewOneGenre(int genreID)
        {
            GenreDAO genre = new GenreDAO();

            try
            {
                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_ViewOneGenre", _connection))
                    {
                        // specify what type of command to use
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@genreID", genreID);
                        // this is where the connection is opened
                        _connection.Open();
                        // this is where all commands will be executed
                        _command.ExecuteNonQuery();

                        // get the data from the database that is stored in the reader
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            _reader.Read();
                            // create object to hold info from database
                            genre.genreID = genreID;
                            genre.genreName = (string)_reader["genreName"];
                            genre.genreDescription = (string)_reader["genreDescription"];
                            genre.genreIsFiction = (bool)_reader["genreIsFiction"];
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                // use error data access to log error to the database
                errorDA.addError(exception);
            }

            return genre;
        }

        // VIEW ALL GENRES IN DATABASE
        public List<GenreDAO> viewGenres()
        {
            List<GenreDAO> genreList = new List<GenreDAO>();

            try
            {
                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand _command = new SqlCommand("sp_ViewGenres", _connection))
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
                                    // create object to hold info from database
                                    GenreDAO genre = new GenreDAO();
                                    genre.genreID = _reader.GetInt32(_reader.GetOrdinal("genreID"));
                                    genre.genreName = (string)_reader["genreName"];
                                    genre.genreDescription = (string)_reader["genreDescription"];
                                    genre.genreIsFiction = (bool)_reader["genreIsFiction"];
                                    // add to list that will be returned
                                    genreList.Add(genre);
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

            return genreList;
        }
    }
}
