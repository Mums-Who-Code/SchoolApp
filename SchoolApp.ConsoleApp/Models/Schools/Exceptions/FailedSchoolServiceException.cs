// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System;
using Xeptions;

namespace SchoolApp.ConsoleApp.Models.Schools.Exceptions
{
    public class FailedSchoolServiceException : Xeption
    {
        public FailedSchoolServiceException(Exception innerException)
            : base(message: "Failed school service error occured,contact support.",
                  innerException)
        { }
    }
}