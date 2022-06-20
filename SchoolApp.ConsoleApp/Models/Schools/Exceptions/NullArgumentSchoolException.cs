// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using Xeptions;

namespace SchoolApp.ConsoleApp.Models.Schools.Exceptions
{
    public class NullArgumentSchoolException : Xeption
    {
        public NullArgumentSchoolException(Exception innerException)
            : base(message: "Null arguement school error occured,fix the errors and try again.",
                  innerException)
        { }
    }
}