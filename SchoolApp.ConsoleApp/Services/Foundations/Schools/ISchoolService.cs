// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System.Collections.Generic;
using SchoolApp.ConsoleApp.Models.Schools;

namespace SchoolApp.ConsoleApp.Services.Foundations.Schools
{
    public interface ISchoolService
    {
        School AddSchool(School school);
        List<School> RetrieveAllSchools();
        School RetrieveSchoolById(int id);
    }
}