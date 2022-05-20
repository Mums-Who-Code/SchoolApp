// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using SchoolApp.ConsoleApp.Models.Schools;
using SchoolApp.ConsoleApp.Models.Schools.Exceptions;

namespace SchoolApp.ConsoleApp.Services.Foundations.Schools
{
    public partial class SchoolService
    {
        private static void ValidateSchool(School school)
        {
            if (school == null)
            {
                throw new NullSchoolException();
            }
        }
    }
}
