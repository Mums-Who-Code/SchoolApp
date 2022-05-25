// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Xeptions;

namespace SchoolApp.ConsoleApp.Models.Schools.Exceptions
{
    public class SchoolValidationException : Xeption
    {
        public SchoolValidationException(Xeption innerException)
            : base(message: "School validation error occurred, fix the errors and try again.",
                 innerException)
        { }
    }
}