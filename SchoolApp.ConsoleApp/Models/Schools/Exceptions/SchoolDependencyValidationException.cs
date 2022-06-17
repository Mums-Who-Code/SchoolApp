// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Xeptions;

namespace SchoolApp.ConsoleApp.Models.Schools.Exceptions
{
    public class SchoolDependencyValidationException : Xeption
    {
        public SchoolDependencyValidationException(Xeption innerException)
            : base(message: "School dependency validation error occured,fix the errors and try again.",
                  innerException)
        { }
    }
}
