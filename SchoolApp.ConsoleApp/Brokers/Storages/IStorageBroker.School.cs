// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using SchoolApp.ConsoleApp.Models.Schools;

namespace SchoolApp.ConsoleApp.Brokers.Storages
{
    internal partial interface IStorageBroker
    {
        School InsertSchool(School school);
    }
}
