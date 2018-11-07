using BusinessLogicLayer.BL_Objects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class UserLogic
    {
        // To access the database
        UserDataAccess userDA = new UserDataAccess();
        StoryDataAccess storyDA = new StoryDataAccess();
        ErrorDataAccess errorDA = new ErrorDataAccess();
        RestrictionDataAccess restrictionDA = new RestrictionDataAccess();

        // updates the number of stories edited upon author approval of an update
        public bool increaseEdited(UserBLO user)
        {
            bool success = false;

            try
            {
                user.userEdited++;
                success = userDA.updateUser(MapperBLO.map(user));
            }
            catch (Exception error)
            {
                // Call the addError which is overloaded to accept exceptions
                errorDA.addError(error);
            }

            return success;
        }

        // check if user is old enough to view/edit a story
        public bool checkAge(UserBLO user, StoryBLO story)
        {
            bool oldEnough = false;

            try
            {
                int year = DateTime.Now.Year;

                // get the restrictions
                List<RestrictionBLO> restrictionList = MapperBLO.map(restrictionDA.viewRestrictions());
                // get the age limit for a story
                int ageLimit = 0;
                foreach(RestrictionBLO r in restrictionList)
                {
                    if (r.restrictionID == story.storyRestrictionID)
                        ageLimit = r.restrictionAge;
                }

                // move backwards to find the latest birth year needed to meet requirements
                for (int i = ageLimit; i > 0; i++)
                    year--;

                // get the lastest birthday needed using year
                DateTime birthdayLimit = new DateTime(year, DateTime.Now.Month, DateTime.Now.Day);

                // check if user is old enough
                if (DateTime.Compare(user.userBDay, birthdayLimit) <= 0)
                    oldEnough = true;
            }
            catch (Exception error)
            {
                // Call the addError which is overloaded to accept exceptions
                errorDA.addError(error);
            }

            return oldEnough;
        }
    }
}
