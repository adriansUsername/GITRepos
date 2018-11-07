using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.BL_Objects;
using DataAccessLayer.DataObjects;

namespace BusinessLogicLayer
{
    public static class MapperBLO // Maps between DAO and BLO
    {
        // MAPPERS
        // ERROR
        public static ErrorDAO map(ErrorBLO errorToMap)
        {
            ErrorDAO errorToReturn = new ErrorDAO();

            errorToReturn.errorID = errorToMap.errorID;
            errorToReturn.errorTrace = errorToMap.errorTrace;
            errorToReturn.errorMessage = errorToMap.errorMessage;
            errorToReturn.errorSite = errorToMap.errorSite;
            errorToReturn.errorDate = errorToMap.errorDate;

            return errorToReturn;
        }

        public static ErrorBLO map(ErrorDAO errorToMap)
        {
            ErrorBLO errorToReturn = new ErrorBLO();

            errorToReturn.errorID = errorToMap.errorID;
            errorToReturn.errorTrace = errorToMap.errorTrace;
            errorToReturn.errorMessage = errorToMap.errorMessage;
            errorToReturn.errorSite = errorToMap.errorSite;
            errorToReturn.errorDate = errorToMap.errorDate;

            return errorToReturn;
        }

        // GENRE
        public static GenreDAO map(GenreBLO genreToMap)
        {
            GenreDAO genreToReturn = new GenreDAO();

            genreToReturn.genreID = genreToMap.genreID;
            genreToReturn.genreName = genreToMap.genreName;
            genreToReturn.genreDescription = genreToMap.genreDescription;
            genreToReturn.genreIsFiction = genreToMap.genreIsFiction;

            return genreToReturn;
        }

        public static GenreBLO map(GenreDAO genreToMap)
        {
            GenreBLO genreToReturn = new GenreBLO();

            genreToReturn.genreID = genreToMap.genreID;
            genreToReturn.genreName = genreToMap.genreName;
            genreToReturn.genreDescription = genreToMap.genreDescription;
            genreToReturn.genreIsFiction = genreToMap.genreIsFiction;

            return genreToReturn;
        }

        // RATINGS
        public static RatingsDAO map(RatingsBLO ratingsToMap)
        {
            RatingsDAO ratingsToReturn = new RatingsDAO();

            ratingsToReturn.ratingsID = ratingsToMap.ratingsID;
            ratingsToReturn.ratingsValue = ratingsToMap.ratingsValue;
            ratingsToReturn.ratingsStoryID = ratingsToMap.ratingsStoryID;
            ratingsToReturn.ratingsUserID = ratingsToMap.ratingsUserID;

            return ratingsToReturn;
        }

        public static RatingsBLO map(RatingsDAO ratingsToMap)
        {
            RatingsBLO ratingsToReturn = new RatingsBLO();

            ratingsToReturn.ratingsID = ratingsToMap.ratingsID;
            ratingsToReturn.ratingsValue = ratingsToMap.ratingsValue;
            ratingsToReturn.ratingsStoryID = ratingsToMap.ratingsStoryID;
            ratingsToReturn.ratingsUserID = ratingsToMap.ratingsUserID;

            return ratingsToReturn;
        }

        // STORY
        public static StoryDAO map(StoryBLO storyToMap)
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

        public static StoryBLO map(StoryDAO storyToMap)
        {
            StoryBLO storyToReturn = new StoryBLO();

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
        public static UpdateDAO map(UpdateBLO updateToMap)
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

        public static UpdateBLO map(UpdateDAO updateToMap)
        {
            UpdateBLO updateToReturn = new UpdateBLO();

            updateToReturn.updateID = updateToMap.updateID;
            updateToReturn.updateDate = updateToMap.updateDate;
            updateToReturn.updateStoryID = updateToMap.updateStoryID;
            updateToReturn.updateText = updateToMap.updateText;
            updateToReturn.updateUserID = updateToMap.updateUserID;
            updateToReturn.updateApproved = updateToMap.updateApproved;

            return updateToReturn;
        }

        // USER
        public static UserDAO map(UserBLO userToMap)
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

            return userToReturn;
        }

        public static UserBLO map(UserDAO userToMap)
        {
            UserBLO userToReturn = new UserBLO();

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

            return userToReturn;
        }

        //LIST MAPPERS
        // ERROR LIST
        public static List<ErrorDAO> map(List<ErrorBLO> listToMap)
        {
            List<ErrorDAO> listToReturn = new List<ErrorDAO>();

            foreach (ErrorBLO error in listToMap)
                listToReturn.Add(map(error));

            return listToReturn;
        }

        public static List<ErrorBLO> map(List<ErrorDAO> listToMap)
        {
            List<ErrorBLO> listToReturn = new List<ErrorBLO>();

            foreach (ErrorDAO error in listToMap)
                listToReturn.Add(map(error));

            return listToReturn;
        }

        // GENRE LIST
        public static List<GenreDAO> map(List<GenreBLO> listToMap)
        {
            List<GenreDAO> listToReturn = new List<GenreDAO>();

            foreach (GenreBLO genre in listToMap)
                listToReturn.Add(map(genre));

            return listToReturn;
        }

        public static List<GenreBLO> map(List<GenreDAO> listToMap)
        {
            List<GenreBLO> listToReturn = new List<GenreBLO>();

            foreach (GenreDAO genre in listToMap)
                listToReturn.Add(map(genre));

            return listToReturn;
        }

        // RATINGS LIST
        public static List<RatingsDAO> map(List<RatingsBLO> listToMap)
        {
            List<RatingsDAO> listToReturn = new List<RatingsDAO>();

            foreach (RatingsBLO ratings in listToMap)
                listToReturn.Add(map(ratings));

            return listToReturn;
        }

        public static List<RatingsBLO> map(List<RatingsDAO> listToMap)
        {
            List<RatingsBLO> listToReturn = new List<RatingsBLO>();

            foreach (RatingsDAO ratings in listToMap)
                listToReturn.Add(map(ratings));

            return listToReturn;
        }

        // STORY LIST
        public static List<StoryDAO> map(List<StoryBLO> listToMap)
        {
            List<StoryDAO> listToReturn = new List<StoryDAO>();

            foreach (StoryBLO story in listToMap)
                listToReturn.Add(map(story));

            return listToReturn;
        }

        public static List<StoryBLO> map(List<StoryDAO> listToMap)
        {
            List<StoryBLO> listToReturn = new List<StoryBLO>();

            foreach (StoryDAO story in listToMap)
                listToReturn.Add(map(story));

            return listToReturn;
        }

        // UPDATE LIST
        public static List<UpdateDAO> map(List<UpdateBLO> listToMap)
        {
            List<UpdateDAO> listToReturn = new List<UpdateDAO>();

            foreach (UpdateBLO update in listToMap)
                listToReturn.Add(map(update));

            return listToReturn;
        }

        public static List<UpdateBLO> map(List<UpdateDAO> listToMap)
        {
            List<UpdateBLO> listToReturn = new List<UpdateBLO>();

            foreach (UpdateDAO update in listToMap)
                listToReturn.Add(map(update));

            return listToReturn;
        }

        // USER LIST
        public static List<UserDAO> map(List<UserBLO> listToMap)
        {
            List<UserDAO> listToReturn = new List<UserDAO>();

            foreach (UserBLO user in listToMap)
                listToReturn.Add(map(user));

            return listToReturn;
        }

        public static List<UserBLO> map(List<UserDAO> listToMap)
        {
            List<UserBLO> listToReturn = new List<UserBLO>();

            foreach (UserDAO user in listToMap)
                listToReturn.Add(map(user));

            return listToReturn;
        }
    }
}
