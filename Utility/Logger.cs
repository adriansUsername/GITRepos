using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class Logger
    {
        public static void writeError(Exception errorToWrite)
        {
            // Write the time the error occurred and more to the message string
            string message = string.Format("Time: {0}", DateTime.Now.ToString(""));
            message += Environment.NewLine;
            message += "----------------------I-AM-ERROR----------------------";
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", errorToWrite.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Message: {0}", errorToWrite.Message);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", errorToWrite.TargetSite);
            message += Environment.NewLine;
            string divider = new string('-', 300);
            message += divider;

            // Create a streamwriter to add the message string to a text file
            using (StreamWriter _writer = new StreamWriter("C:\\Users\\Onshore\\Source\\Repos\\Portfolio\\Portfolio\\Utility\\log.txt", true))
            {
                _writer.WriteLine(message);
            }
        }
    }
}
