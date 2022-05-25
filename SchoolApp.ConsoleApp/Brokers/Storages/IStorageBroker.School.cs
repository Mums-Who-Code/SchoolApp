﻿// ------------------------------------------------
// Copyright (c) MumsWhoCode. All rights reserved.
// ------------------------------------------------

using SchoolApp.ConsoleApp.Models.Schools;

namespace SchoolApp.ConsoleApp.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        School InsertSchool(School school);
    }
}
