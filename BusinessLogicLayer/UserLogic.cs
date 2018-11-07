﻿using BusinessLogicLayer.BL_Objects;
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
        ErrorDataAccess errorDA = new ErrorDataAccess();

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
    }
}
