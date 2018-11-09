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
        [StringLength(35, ErrorMessage = "Your username must not exceed 35 characters!")]
        public string userName { get; set; } = "User Name";

        [Required(ErrorMessage = "Please enter a password!")]
        [DisplayName("Password")]
        [StringLength(35, ErrorMessage = "Your password must not exceed 35 characters!")]
        public string userPassword { get; set; } = "Password";

        [Required(ErrorMessage = "Please enter your first name!")]
        [DisplayName("First Name")]
        [StringLength(35, ErrorMessage = "Your first name must not exceed 35 characters!")]
        public string userFirstName { get; set; } = "First Name";

        [Required(ErrorMessage = "Please enter your last name!")]
        [DisplayName("Last Name")]
        [StringLength(35, ErrorMessage = "Your last name must not exceed 35 characters!")]
        public string userLastName { get; set; } = "Last Name";

        [Required(ErrorMessage = "Please enter a valid city name!")]
        [DisplayName("City")]
        [StringLength(70, ErrorMessage = "The city's name must not exceed 70 characters!")]
        public string userCity { get; set; } = "City";

        [Required(ErrorMessage = "Please enter the state's full name!")]
        [DisplayName("State")]
        [StringLength(70, ErrorMessage = "The state's name must not exceed 70 characters!")]
        public string userState { get; set; } = "ST";

        [Required(ErrorMessage = "Please enter the country's full name!")]
        [DisplayName("Country")]
        [StringLength(70, ErrorMessage = "The country's name must not exceed 70 characters!")]
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
    }
}