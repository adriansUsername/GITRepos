using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class UserModel
    {
        [Required]
        [DisplayName("User ID#")]
        public int userID { get; set; } = 0;

        [Required(ErrorMessage = "Please enter a username!")]
        [DisplayName("Username")]
        public string userName { get; set; } = "User Name";

        [Required(ErrorMessage = "Please enter a password!")]
        [DisplayName("Password")]
        public string userPassword { get; set; } = "Password";

        [Required(ErrorMessage = "Please enter your first name!")]
        [DisplayName("First Name")]
        public string userFirstName { get; set; } = "First Name";

        [Required(ErrorMessage = "Please enter your last name!")]
        [DisplayName("Last Name")]
        public string userLastName { get; set; } = "Last Name";

        [Required(ErrorMessage = "Please enter a valid city name!")]
        [DisplayName("City")]
        public string userCity { get; set; } = "City";

        [Required(ErrorMessage = "Please enter the state's abbreviation!")]
        [DisplayName("State")]
        public string userState { get; set; } = "ST";

        [Required(ErrorMessage = "Please enter the country's full name!")]
        [DisplayName("Country")]
        public string userCountry { get; set; } = "Country";

        [Required]
        [DisplayName("Role ID#")]
        public int userRoleID { get; set; } = 0;

        [DisplayName("# of Stories Edited")]
        public int userEdited { get; set; } = 0; // count of stories this user edited

        [DisplayName("Birthday")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter your birthday!")]
        public DateTime userBDay { get; set; } = DateTime.Now.Date;

        [DisplayName("About Me")]
        [StringLength(255, ErrorMessage = "Wait! Your description cannot exceed 255 characters!")]
        public string userDescription { get; set; } = "Tell us about yourself. Don't be shy!";

        // For radio forms and such
        public bool isSelected { get; set; } = false;

        // For getting a user's stories
        public List<StoryModel> userStoryList { get; set; }
    }
}