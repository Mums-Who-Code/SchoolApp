// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using Xeptions;

namespace SchoolApp.ConsoleApp.Models.Schools.Exceptions
{
    public class NullSchoolException : Xeption
    {
        public NullSchoolException()
            : base(message: "School is null.")
        { }
    }
}
