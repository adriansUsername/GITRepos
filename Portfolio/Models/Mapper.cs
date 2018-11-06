using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer.DataObjects;

namespace Portfolio.Models
{
    public class Mapper
    {
        // ERROR MAPPER METHODS
        public ErrorModel map(ErrorDAO errorToMap)
        {
            ErrorModel errorToReturn = new ErrorModel();

            errorToReturn.errorID = errorToMap.errorID;
            errorToReturn.errorDate = errorToMap.errorDate;
            errorToReturn.errorType = errorToMap.errorType;

            return errorToReturn;
        }

        public ErrorDAO map(ErrorModel errorToMap)
        {
            ErrorDAO errorToReturn = new ErrorDAO();

            errorToReturn.errorID = errorToMap.errorID;
            errorToReturn.errorDate = errorToMap.errorDate;
            errorToReturn.errorType = errorToMap.errorType;

            return errorToReturn;
        }
        // ERROR LIST MAPPER METHODS
        public List<ErrorModel> map(List<ErrorDAO> listToMap)
        {
            List<ErrorModel> listToReturn = new List<ErrorModel>();

            foreach (ErrorDAO error in listToMap)
                listToReturn.Add(map(error));

            return listToReturn;
        }

        public List<ErrorDAO> map(List<ErrorModel> listToMap)
        {
            List<ErrorDAO> listToReturn = new List<ErrorDAO>();

            foreach (ErrorModel error in listToMap)
                listToReturn.Add(map(error));

            return listToReturn;
        }
    }
}