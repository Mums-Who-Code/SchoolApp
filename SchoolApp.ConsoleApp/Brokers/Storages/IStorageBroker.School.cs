// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using System.Collections.Generic;
using SchoolApp.ConsoleApp.Models.Schools;

namespace SchoolApp.ConsoleApp.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        School InsertSchool(School school);
        List<School> SelectAllSchools();
    }
}