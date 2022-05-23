// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Xeptions;

namespace SchoolApp.ConsoleApp.Models.Schools.Exceptions
{
    public class InvalidSchoolException : Xeption
    {
        public InvalidSchoolException()
            : base(message: "School is invalid,fix the errors and try again")
        { }
    }
}