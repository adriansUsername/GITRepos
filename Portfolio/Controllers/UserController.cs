using DataAccessLayer;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class UserController : Controller
    {
        UserDataAccess userDA = new UserDataAccess();
        ErrorDataAccess errorDA = new ErrorDataAccess();
        StoryDataAccess storyDA = new StoryDataAccess();
        RestrictionDataAccess restrictionDA = new RestrictionDataAccess();
        GenreDataAccess genreDA = new GenreDataAccess();
        RatingsDataAccess ratingsDA = new RatingsDataAccess();
        RoleDataAccess roleDA = new RoleDataAccess();

        // LOGIN USER
        public ActionResult Login()
        {
            UserViewModel model = new UserViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(UserViewModel model)
        {
            ActionResult result = View(model);

            try
            {
                // log the user in and if works it will return the user
                UserModel userLoggedIn = MapperModel.map(userDA.login(model.singleUser.userName, model.singleUser.userPassword));

                if (userLoggedIn.userName != null)
                {
                    Session["UserName"] = userLoggedIn.userName;
                    Session["UserRoleID"] = userLoggedIn.userRoleID;
                    result = RedirectToAction("UserProfile", userLoggedIn);
                }
            }
            catch (Exception error)
            {
                // log the error to the error data access
                errorDA.addError(error);
            }

            return result;
        }

        // REGISTER USER
        public ActionResult Register()
        {
            UserViewModel model = new UserViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(UserViewModel model)
        {
            ActionResult result = View(model);

            try
            {
                // register a user
                userDA.addUser(MapperModel.map(model.singleUser));
                // automatically log a user in if they register
                result = Login(model);
            }
            catch (Exception error)
            {
                // log the error to the error data access
                errorDA.addError(error);
            }

            return result;
        }

        // LOGOUT USER
        public ActionResult Logout()
        {
            Session.Clear();
            return View();
        }

        // VIEW USER PROFILE
        [HttpGet]
        public ActionResult UserProfile(UserViewModel userForProfile)
        {
            try
            {
                // Set user to view as current user if null or invalid
                if (userForProfile.singleUser == null || userForProfile.singleUser.userID < 1)
                {
                    // find the current user by going through all users
                    List<UserModel> userList = MapperModel.map(userDA.viewUsers());

                    foreach (UserModel userInList in userList)
                    {
                        // check if usernames match
                        if (userInList.userName.Equals(Session["UserName"].ToString()))
                        {
                            userForProfile.singleUser = userInList;
                            break;
                        }
                    }
                }

                // Get all stories
                List<StoryModel> allStoriesList = MapperModel.map(storyDA.viewStories());

                foreach (StoryModel story in allStoriesList)
                {
                    // Check which stories belong to the current user
                    if (story.storyUserID == userForProfile.singleUser.userID)
                    {
                        // Add story to story list in the UserModel
                        userForProfile.storyViewModel.storyList.Add(story);

                        // Get all the ratings of a story
                        List<RatingsModel> allRatingsList = MapperModel.map(ratingsDA.viewRatings());

                        foreach (RatingsModel rating in allRatingsList)
                        {
                            // Find all the ratings for a story
                            if (rating.ratingsStoryID == story.storyID)
                                userForProfile.storyViewModel.ratingList.Add(rating);
                        }
                    }
                }
                // Get lists to display the restriction and genre of user's story
                userForProfile.storyViewModel.restrictionList = MapperModel.map(restrictionDA.viewRestrictions());
                userForProfile.storyViewModel.genreList = MapperModel.map(genreDA.viewGenres());
            }
            catch (Exception error)
            {
                // log the error to the error data access
                errorDA.addError(error);
            }

            return View(userForProfile);
        }

        // GET TO VIEW AND UPDATE ALL USERS
        [HttpGet]
        public ActionResult UpdateUsers()
        {
            UserViewModel viewModel = new UserViewModel();

            try
            {
                // get all users from database
                viewModel.userList = MapperModel.map(userDA.viewUsers());

                // create role select list for editing in dropdown
                List<RoleModel> allRoles = MapperModel.map(roleDA.viewRoles());

                foreach (RoleModel r in allRoles)
                {
                    viewModel.roleOptions.Add(new SelectListItem
                    {
                        Text = r.roleName,
                        Value = r.roleID.ToString()
                    });
                }
            }
            catch (Exception error)
            {
                // log the error to the error data access
                errorDA.addError(error);
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult UpdateUsers(UserViewModel viewModel)
        {
            try
            {
                foreach(UserModel userFromTable in viewModel.userList)
                {
                    //delete users that were selected OR update if not delete
                    if (userFromTable.isSelected)
                        userDA.deleteUser(userFromTable.userID);
                    else
                        userDA.updateUser(MapperModel.map(userFromTable));
                }
            }
            catch (Exception error)
            {
                // log the error to the error data access
                errorDA.addError(error);
            }

            return View();
        }
    }
}