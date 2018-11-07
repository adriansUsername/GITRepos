using BusinessLogicLayer.BL_Objects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class StoryLogic
    {
        // To access the database
        StoryDataAccess storyDA = new StoryDataAccess();
        ErrorDataAccess errorDA = new ErrorDataAccess();
        RatingsDataAccess ratingsDA = new RatingsDataAccess();
        
        // update story's rating
        public bool getNewRating(RatingsBLO rating)
        {
            bool success = false;

            try
            {
                // Get all the ratings ever
                List<RatingsBLO> allRatings = MapperBLO.map(ratingsDA.viewRatings());

                int sum = 0;
                int count = 0;

                // Find all the ratings for one story, add and count
                foreach(RatingsBLO r in allRatings)
                {
                    if(rating.ratingsStoryID == r.ratingsStoryID)
                    {
                        sum += r.ratingsValue;
                        count++;
                    }
                }

                // Calculate the average rating for one story
                int average = sum / count;

                // Get story by ID and update
                StoryBLO story = MapperBLO.map(storyDA.viewOneStory(rating.ratingsStoryID));
                story.storyRating = average;

                success = storyDA.updateStory(MapperBLO.map(story));
            }
            catch (Exception error)
            {
                // Call the addError which is overloaded to accept exceptions
                errorDA.addError(error);
            }

            return success;
        }
    }
}
