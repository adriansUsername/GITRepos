using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            GenreDataAccess genreDA = new GenreDataAccess();
            RatingsDataAccess ratingsDA = new RatingsDataAccess();
            StoryDataAccess storyDA = new StoryDataAccess();
            UpdateDataAccess updateDA = new UpdateDataAccess();
            UserDataAccess userDA = new UserDataAccess();

            Console.WriteLine("Welcome!");

            string run = "";

            do
            {
                Console.WriteLine("\n1) Register");
                Console.WriteLine("2) Login");
                int choice = Convert.ToInt32(Console.ReadLine())

            } while (run.Equals("y"));
        }
    }
}
