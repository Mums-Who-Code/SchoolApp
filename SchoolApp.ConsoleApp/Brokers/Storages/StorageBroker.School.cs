// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System.Collections.Generic;
using SchoolApp.ConsoleApp.Models.Schools;

namespace SchoolApp.ConsoleApp.Brokers.Storages
{
    internal partial class StorageBroker : IStorageBroker
    {
        List<School> Schools = new List<School>();
        public School insertSchool(School school)
        {
            Schools.Add(school);

            return school;
        }
    }
}
