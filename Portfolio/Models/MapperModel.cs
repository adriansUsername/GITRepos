using DataAccessLayer.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public static class MapperModel // Maps between Model and DAO
    {
        // MAPPERS
        // ERROR
        public static ErrorDAO map(ErrorModel errorToMap)
        {
            ErrorDAO errorToReturn = new ErrorDAO();

            errorToReturn.errorID = errorToMap.errorID;
            errorToReturn.errorTrace = errorToMap.errorTrace;
            errorToReturn.errorMessage = errorToMap.errorMessage;
            errorToReturn.errorSite = errorToMap.errorSite;
            errorToReturn.errorDate = errorToMap.errorDate;

            return errorToReturn;
        }

        public static ErrorModel map(ErrorDAO errorToMap)
        {
            ErrorModel errorToReturn = new ErrorModel();

            errorToReturn.errorID = errorToMap.errorID;
            errorToReturn.errorTrace = errorToMap.errorTrace;
            errorToReturn.errorMessage = errorToMap.errorMessage;
            errorToReturn.errorSite = errorToMap.errorSite;
            errorToReturn.errorDate = errorToMap.errorDate;

            return errorToReturn;
        }

        // GENRE
        public static GenreDAO map(GenreModel genreToMap)
        {
            GenreDAO genreToReturn = new GenreDAO();

            genreToReturn.genreID = genreToMap.genreID;
            genreToReturn.genreName = genreToMap.genreName;
            genreToReturn.genreDescription = genreToMap.genreDescription;
            genreToReturn.genreIsFiction = genreToMap.genreIsFiction;

            return genreToReturn;
        }

        public static GenreModel map(GenreDAO genreToMap)
        {
            GenreModel genreToReturn = new GenreModel();

            genreToReturn.genreID = genreToMap.genreID;
            genreToReturn.genreName = genreToMap.genreName;
            genreToReturn.genreDescription = genreToMap.genreDescription;
            genreToReturn.genreIsFiction = genreToMap.genreIsFiction;

            return genreToReturn;
        }

        // RATINGS
        public static RatingsDAO map(RatingsModel ratingsToMap)
        {
            RatingsDAO ratingsToReturn = new RatingsDAO();

            ratingsToReturn.ratingsID = ratingsToMap.ratingsID;
            ratingsToReturn.ratingsValue = ratingsToMap.ratingsValue;
            ratingsToReturn.ratingsStoryID = ratingsToMap.ratingsStoryID;
            ratingsToReturn.ratingsUserID = ratingsToMap.ratingsUserID;

            return ratingsToReturn;
        }

        public static RatingsModel map(RatingsDAO ratingsToMap)
        {
            RatingsModel ratingsToReturn = new RatingsModel();

            ratingsToReturn.ratingsID = ratingsToMap.ratingsID;
            ratingsToReturn.ratingsValue = ratingsToMap.ratingsValue;
            ratingsToReturn.ratingsStoryID = ratingsToMap.ratingsStoryID;
            ratingsToReturn.ratingsUserID = ratingsToMap.ratingsUserID;

            return ratingsToReturn;
        }

        // STORY
        public static StoryDAO map(StoryModel storyToMap)
        {
            StoryDAO storyToReturn = new StoryDAO();

            storyToReturn.storyID = storyToMap.storyID;
            storyToReturn.storyURL = storyToMap.storyURL;
            storyToReturn.storyRating = storyToMap.storyRating;
            storyToReturn.storyRestrictionID = storyToMap.storyRestrictionID;
            storyToReturn.storyUserID = storyToMap.storyUserID;
            storyToReturn.storyGenreID = storyToMap.storyGenreID;
            storyToReturn.storyTitle = storyToMap.storyTitle;
            storyToReturn.storyEditorID = storyToMap.storyEditorID;

            return storyToReturn;
        }

        public static StoryModel map(StoryDAO storyToMap)
        {
            StoryModel storyToReturn = new StoryModel();

            storyToReturn.storyID = storyToMap.storyID;
            storyToReturn.storyURL = storyToMap.storyURL;
            storyToReturn.storyRating = storyToMap.storyRating;
            storyToReturn.storyRestrictionID = storyToMap.storyRestrictionID;
            storyToReturn.storyUserID = storyToMap.storyUserID;
            storyToReturn.storyGenreID = storyToMap.storyGenreID;
            storyToReturn.storyTitle = storyToMap.storyTitle;
            storyToReturn.storyEditorID = storyToMap.storyEditorID;

            return storyToReturn;
        }

        // UPDATE
        public static UpdateDAO map(UpdateModel updateToMap)
        {
            UpdateDAO updateToReturn = new UpdateDAO();

            updateToReturn.updateID = updateToMap.updateID;
            updateToReturn.updateDate = updateToMap.updateDate;
            updateToReturn.updateStoryID = updateToMap.updateStoryID;
            updateToReturn.updateText = updateToMap.updateText;
            updateToReturn.updateUserID = updateToMap.updateUserID;
            updateToReturn.updateApproved = updateToMap.updateApproved;

            return updateToReturn;
        }

        public static UpdateModel map(UpdateDAO updateToMap)
        {
            UpdateModel updateToReturn = new UpdateModel();

            updateToReturn.updateID = updateToMap.updateID;
            updateToReturn.updateDate = updateToMap.updateDate;
            updateToReturn.updateStoryID = updateToMap.updateStoryID;
            updateToReturn.updateText = updateToMap.updateText;
            updateToReturn.updateUserID = updateToMap.updateUserID;
            updateToReturn.updateApproved = updateToMap.updateApproved;

            return updateToReturn;
        }

        // USER
        public static UserDAO map(UserModel userToMap)
        {
            UserDAO userToReturn = new UserDAO();

            userToReturn.userID = userToMap.userID;
            userToReturn.userName = userToMap.userName;
            userToReturn.userPassword = userToMap.userPassword;
            userToReturn.userFirstName = userToMap.userFirstName;
            userToReturn.userLastName = userToMap.userLastName;
            userToReturn.userCity = userToMap.userCity;
            userToReturn.userState = userToMap.userState;
            userToReturn.userCountry = userToMap.userCountry;
            userToReturn.userRoleID = userToMap.userRoleID;
            userToReturn.userEdited = userToMap.userEdited;
            userToReturn.userBDay = userToMap.userBDay;
            userToReturn.userDescription = userToMap.userDescription;

            return userToReturn;
        }

        public static UserModel map(UserDAO userToMap)
        {
            UserModel userToReturn = new UserModel();

            userToReturn.userID = userToMap.userID;
            userToReturn.userName = userToMap.userName;
            userToReturn.userPassword = userToMap.userPassword;
            userToReturn.userFirstName = userToMap.userFirstName;
            userToReturn.userLastName = userToMap.userLastName;
            userToReturn.userCity = userToMap.userCity;
            userToReturn.userState = userToMap.userState;
            userToReturn.userCountry = userToMap.userCountry;
            userToReturn.userRoleID = userToMap.userRoleID;
            userToReturn.userEdited = userToMap.userEdited;
            userToReturn.userBDay = userToMap.userBDay;
            userToReturn.userDescription = userToMap.userDescription;

            return userToReturn;
        }

        //LIST MAPPERS
        // ERROR LIST
        public static List<ErrorDAO> map(List<ErrorModel> listToMap)
        {
            List<ErrorDAO> listToReturn = new List<ErrorDAO>();

            foreach (ErrorModel error in listToMap)
                listToReturn.Add(map(error));

            return listToReturn;
        }

        public static List<ErrorModel> map(List<ErrorDAO> listToMap)
        {
            List<ErrorModel> listToReturn = new List<ErrorModel>();

            foreach (ErrorDAO error in listToMap)
                listToReturn.Add(map(error));

            return listToReturn;
        }

        // GENRE LIST
        public static List<GenreDAO> map(List<GenreModel> listToMap)
        {
            List<GenreDAO> listToReturn = new List<GenreDAO>();

            foreach (GenreModel genre in listToMap)
                listToReturn.Add(map(genre));

            return listToReturn;
        }

        public static List<GenreModel> map(List<GenreDAO> listToMap)
        {
            List<GenreModel> listToReturn = new List<GenreModel>();

            foreach (GenreDAO genre in listToMap)
                listToReturn.Add(map(genre));

            return listToReturn;
        }

        // RATINGS LIST
        public static List<RatingsDAO> map(List<RatingsModel> listToMap)
        {
            List<RatingsDAO> listToReturn = new List<RatingsDAO>();

            foreach (RatingsModel ratings in listToMap)
                listToReturn.Add(map(ratings));

            return listToReturn;
        }

        public static List<RatingsModel> map(List<RatingsDAO> listToMap)
        {
            List<RatingsModel> listToReturn = new List<RatingsModel>();

            foreach (RatingsDAO ratings in listToMap)
                listToReturn.Add(map(ratings));

            return listToReturn;
        }

        // STORY LIST
        public static List<StoryDAO> map(List<StoryModel> listToMap)
        {
            List<StoryDAO> listToReturn = new List<StoryDAO>();

            foreach (StoryModel story in listToMap)
                listToReturn.Add(map(story));

            return listToReturn;
        }

        public static List<StoryModel> map(List<StoryDAO> listToMap)
        {
            List<StoryModel> listToReturn = new List<StoryModel>();

            foreach (StoryDAO story in listToMap)
                listToReturn.Add(map(story));

            return listToReturn;
        }

        // UPDATE LIST
        public static List<UpdateDAO> map(List<UpdateModel> listToMap)
        {
            List<UpdateDAO> listToReturn = new List<UpdateDAO>();

            foreach (UpdateModel update in listToMap)
                listToReturn.Add(map(update));

            return listToReturn;
        }

        public static List<UpdateModel> map(List<UpdateDAO> listToMap)
        {
            List<UpdateModel> listToReturn = new List<UpdateModel>();

            foreach (UpdateDAO update in listToMap)
                listToReturn.Add(map(update));

            return listToReturn;
        }

        // USER LIST
        public static List<UserDAO> map(List<UserModel> listToMap)
        {
            List<UserDAO> listToReturn = new List<UserDAO>();

            foreach (UserModel user in listToMap)
                listToReturn.Add(map(user));

            return listToReturn;
        }

        public static List<UserModel> map(List<UserDAO> listToMap)
        {
            List<UserModel> listToReturn = new List<UserModel>();

            foreach (UserDAO user in listToMap)
                listToReturn.Add(map(user));

            return listToReturn;
        }
    }
}