// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System.Collections.Generic;
using SchoolApp.ConsoleApp.Models.Schools;

namespace SchoolApp.ConsoleApp.Brokers.Storages
{
    public partial class StorageBroker : IStorageBroker
    {
        List<School> Schools = new List<School>();

        public School InsertSchool(School school)
        {
            Schools.Add(school);

            return school;
        }

        public List<School> SelectAllSchools() => Schools;

        public School SelectSchoolById(int schoolId) =>
            Schools.Find(school => school.SchoolId == schoolId);
    }
}