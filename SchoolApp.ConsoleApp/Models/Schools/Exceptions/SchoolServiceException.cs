// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Xeptions;

namespace SchoolApp.ConsoleApp.Models.Schools.Exceptions
{
    public class SchoolServiceException : Xeption
    {
        public SchoolServiceException(Xeption innerException)
            : base(message: "School serivce error occurred, contact support.",
                  innerException)
        { }
    }
}