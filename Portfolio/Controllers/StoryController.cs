﻿using DataAccessLayer;
using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Portfolio.Controllers
{
    public class StoryController : Controller
    {
        UserDataAccess userDA = new UserDataAccess();
        StoryDataAccess storyDA = new StoryDataAccess();
        ErrorDataAccess errorDA = new ErrorDataAccess();
        RestrictionDataAccess restrictionDA = new RestrictionDataAccess();
        GenreDataAccess genreDA = new GenreDataAccess();

        // GET FOR CREATE STORY PAGE
        [HttpGet]
        public ActionResult CreateStory()
        {
            StoryViewModel model = new StoryViewModel();

            try
            {
                populateViewModelLists(ref model);
            }
            catch (Exception error)
            {
                // log the error to the error data access
                errorDA.addError(error);
            }

            return View(model);
        }

        // POST FOR CREATING A STORY
        [HttpPost]
        public ActionResult CreateStory(StoryViewModel model)
        {
            ActionResult result = View();

            try
            {
                // get the user's ID to put in story model
                UserModel currentUser = getUser();
                model.singleStory.storyUserID = currentUser.userID;

                bool success = storyDA.addStory(MapperModel.map(model.singleStory));

                if (success)
                    result = RedirectToAction("UserProfile", "User", currentUser);
            }
            catch (Exception error)
            {
                // log the error to the error data access
                errorDA.addError(error);
            }

            return result;
        }

        // GET FOR EDIT STORY PROPERTIES PAGE
        [HttpGet]
        public ActionResult EditStoryProperties(StoryModel model)
        {
            StoryViewModel viewmodel = new StoryViewModel();

            try
            {
                viewmodel.singleStory = model;
                populateViewModelLists(ref viewmodel);
            }
            catch (Exception error)
            {
                // log the error to the error data access
                errorDA.addError(error);
            }

            return View(viewmodel);
        }

        // POST FOR SUBMITTING CHANGES TO STORY PROPERTIES
        [HttpPost]
        public ActionResult EditStoryProperties(StoryViewModel model)
        {
            ActionResult result = View(model);
            try
            {
                // get the user's ID to put in story model
                UserModel currentUser = getUser();
                model.singleStory.storyUserID = currentUser.userID;

                bool success = storyDA.updateStory(MapperModel.map(model.singleStory));

                if (success)
                    result = RedirectToAction("UserProfile", "User", currentUser);
            }
            catch (Exception error)
            {
                // log the error to the error data access
                errorDA.addError(error);
            }

            return result;
        }

        // GET FOR DELETING STORY
        [HttpGet]
        public ActionResult DeleteStory(StoryModel model)
        {
            try
            {
                // delete the story
                bool success = storyDA.deleteStory(model.storyID);
            }
            catch (Exception error)
            {
                // log the error to the error data access
                errorDA.addError(error);
            }

            return View(model);
        }

        // POST FOR RETURNING TO A PROFILE FROM A DELETE STORY
        [HttpPost]
        public ActionResult DeleteStory(int userID)
        {
            UserViewModel viewModel = new UserViewModel();
            try
            {
                // get the user of the profile viewed before delete page
                viewModel.singleUser = MapperModel.map(userDA.viewOneUser(userID));
            }
            catch (Exception error)
            {
                // log the error to the error data access
                errorDA.addError(error);
            }

            return View(viewModel);
        }

        // FUNCTION TO GET THE CURRENT USER LOGGED IN
        public UserModel getUser()
        {
            UserModel userToReturn = new UserModel();

            string username = (string)Session["UserName"];
            List<UserModel> userList = MapperModel.map(userDA.viewUsers());

            foreach (UserModel userInList in userList)
            {
                if (userInList.userName.Equals(username))
                {
                    userToReturn = userInList;
                    break;
                }
            }

            return userToReturn;
        }

        // FUNCTION TO POPULATE A STORY VIEW MODEL'S RESTRICTION/GENRE LISTS AND DROPDOWNS
        public void populateViewModelLists(ref StoryViewModel storyViewModel)
        {
            // get all restrictions and populate dropdown list
            List<RestrictionModel> restrictions = MapperModel.map(restrictionDA.viewRestrictions());

            foreach (RestrictionModel r in restrictions)
            {
                storyViewModel.restrictionOptions.Add(new SelectListItem
                {
                    Text = r.restrictionName,
                    Value = r.restrictionID.ToString()
                });
            }

            // get all genres and populate dropdown list
            List<GenreModel> genres = MapperModel.map(genreDA.viewGenres());

            foreach (GenreModel g in genres)
            {
                storyViewModel.genreOptions.Add(new SelectListItem
                {
                    Text = g.genreName,
                    Value = g.genreID.ToString()
                });
            }
        }
    }
}